﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using AlgorithmVisualizer.Forms.Dialogs;
using AlgorithmVisualizer.Forms.Dialogs.AlgoDetails;
using AlgorithmVisualizer.GraphTheory;
using AlgorithmVisualizer.GraphTheory.Algorithms;
using AlgorithmVisualizer.GraphTheory.FDGV;
using AlgorithmVisualizer.GraphTheory.Utils;
using AlgorithmVisualizer.Utils;
using static AlgorithmVisualizer.Forms.Dialogs.EdgeDialog;
using static AlgorithmVisualizer.Forms.GraphAlgoSettings;
using static AlgorithmVisualizer.Threading.PauseResumeSleep;

namespace AlgorithmVisualizer.Forms
{
	public partial class GraphAlgoForm : Form
	{
		private readonly Graph graph;

		// Selected algo name index in settings.AlgoNames
		private int selectedAlgoIdx;
		// Stores the algo names and the what node ids are required per algo
		private readonly GraphAlgoSettings settings;

		private readonly MainUIForm parentForm;
		private readonly Panel panelLog;
		private readonly Graphics panelLogG;

		/*
		 * canvasRightClickPos - used when adding new particles
		 * canvasHoverPos - pos of the mouse within the canvas on hover (null if outside)
		 * movingParticle - particle movment by drag(left click hold)
		 * activeParticleId - toggling vertex pins, removing particles, adding/removing edges
		 * 
		 * inGraphAlgoViz - avoid adding/removing nodes/edges during graph algo viz
		 * forcesEnabled - store force toggle status for graph viz bgw
		 * formIsMinimized - avoid applying forces and drawing the graph while form is minimized
		 * formClosePending - making sure to close graph viz bgw before form close
		 */
		private Vector canvasRightClickPos, canvasMouseHoverPos;
		private Particle movingParticle;
		private int activeParticleId = -1;
		private bool inGraphAlgoViz = false, forcesEnabled = true, formClosePending = false;
		private bool formIsMinimized() => parentForm.WindowState == FormWindowState.Minimized;

		public GraphAlgoForm(MainUIForm _parentForm)
		{
			InitializeComponent();

			settings = new GraphAlgoSettings();
			// adding algo names to the combo box
			foreach (string algoName in settings.AlgoNames) algoComboBox.Items.Add(algoName);
			algoComboBox.SelectedIndex = selectedAlgoIdx = 0;

			parentForm = _parentForm;
			panelLog = parentForm.PanelLog;
			panelLogG = panelLog.CreateGraphics();
			graph = new Graph(canvas, panelLogG);

			StartGraphViz();
			FPSTimer.Start();
		}

		#region Visualizing a graph (force directed graph drawing)
		private BackgroundWorker bgwGraphViz;

		private void StartGraphViz()
		{
			// Assign work to bgw (a function) and run async (supports cancelation)
			if (bgwGraphViz != null) bgwGraphViz.Dispose();
			bgwGraphViz = new BackgroundWorker { WorkerSupportsCancellation = true };
			bgwGraphViz.DoWork += new DoWorkEventHandler(bgw_GraphViz);
			bgwGraphViz.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_GraphVizRunWorkerCompleted);
			bgwGraphViz.RunWorkerAsync();
		}
		private void bgw_GraphViz(object sender, DoWorkEventArgs e)
		{
			while (!formClosePending)
			{
				if (!formIsMinimized() && !graph.IsEmpty())
				{
					if (forcesEnabled) graph.ApplyForcesAndUpdatePositions();
					RefreshCanvas();
					Thread.Sleep(1); // BUG - Delay needed to avoid form resize issues.
				}
			}
		}
		private void bgw_GraphVizRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// Occurs when the background operation has completed, canceled or has raised an exception.
			// Required to avoid crashing as a result of graph viz still running when this
			// form is closed, i.e when loading another form.
			if (formClosePending)
			{
				FPSTimer.Stop();
				parentForm.Text = $"Algorithm visualizer";
				Close();
			}
			formClosePending = false;
		}

		// Safely invoke "canvas.Refresh()"
		private delegate void RefreshCanvasCallback();
		private void RefreshCanvas()
		{
			// InvokeRequired required compares the thread ID of the
			// calling thread to the thread ID of the creating thread.
			// If these threads are different, it returns true.
			if (canvas.InvokeRequired)
				canvas.Invoke(new RefreshCanvasCallback(RefreshCanvas), new object[] { });
			else canvas.Refresh();
		}
		#endregion

		#region Visualizing a graph algorithm
		private BackgroundWorker bgwGraphAlgoViz;

		private void VisualizeGraphAlgo()
		{
			if (!graph.IsEmpty())
			{
				if (bgwGraphAlgoViz != null) bgwGraphAlgoViz.Dispose();
				// Create new backgroundworker
				bgwGraphAlgoViz = new BackgroundWorker();
				// Assign work to bgw (a function) and run async
				bgwGraphAlgoViz.DoWork += new DoWorkEventHandler(bgw_VisualizeGraphAlgo);
				bgwGraphAlgoViz.RunWorkerAsync();
			}
			else SimpleDialog.ShowMessage("Graph is empty!", "Algorithm did not run \n" +
				"Hint: Click \"Presets\" to load a preset or rightclick in canvas create a vertex");
		}
		private bool GetStartAndEndNodes(ref int from, ref int to)
		{
			// Ensure node ids are sequential
			graph.FixNodeIdNumbering();
			RequiredNodes reqNodes = settings.RequiredNodeIds[selectedAlgoIdx];
			if (reqNodes == RequiredNodes.None) return true; // input unneeded
			// Get start/end nodes
			bool includeTo = reqNodes == RequiredNodes.StartAndEnd;
			using (var startEndNodeDialog = new StartEndNodeDialog(graph, includeTo))
			{
				startEndNodeDialog.StartPosition = FormStartPosition.CenterParent;
				// if 'startEndNodeDialog' is closed and user input is valid
				if (startEndNodeDialog.ShowDialog() == DialogResult.OK && startEndNodeDialog.InputIsValid)
				{
					// set user input to given int refs (pointers)
					from = startEndNodeDialog.From;
					to = startEndNodeDialog.To;
					MarkNodes(from, to, includeTo);
					UnmarkNodes(from, to);
					return true; // valid input given
				}
			}
			return false; // invalid input given
		}
		private void MarkNodes(int from, int to, bool includeTo)
		{
			graph.MarkParticle(from, Colors.Green); // start node
			if (includeTo)
			{
				if (from == to) graph.Sleep(Delay.Short);
				graph.MarkParticle(to, Colors.Red); // end node
			}
			graph.Sleep(Delay.Long);
		}
		private void UnmarkNodes(int from, int to)
		{
			foreach (int id in new int[] { from, to })
				if (id != -1) graph.ResetParticleColors(id);
			graph.Sleep(Delay.Long);
		}
		private void RunAlgo(int from, int to)
		{
			bool isIgnoreDelay = cbMaxSpeed.Checked;
			bool isToUp = cbIsToUp.Checked;

			// TODO: refactor this uisng reflection?
			switch (selectedAlgoIdx)
			{
                case 0:
                    {
                        var bfsObj = new BFS(graph, from, to, isToUp, isIgnoreDelay);
						bfsObj.Solve(out double time);

                        if (bfsObj.IsIgnoreDelay)
                            MessageBox.Show($"Time: {time} miliseconds");

                    } break;
				case 1:
                    {
                        var djsObj = new DFS(graph, from, to, isToUp, isIgnoreDelay);
						djsObj.Solve(from, out double time);

						if (djsObj.IsIgnoreDelay)
                            MessageBox.Show($"Time: {time} miliseconds");
                    }
                    break;
				case 2:
					new ConnectedComponentsDFS(graph).Solve();
					break;
				case 3:
					new ConnectedComponentsDisjointSet(graph).Solve();
					break;
				case 4:
					new LazyPrimsMST(graph).Solve();
					break;
				case 5:
					new KruskalsMST(graph).Solve();
					break;
				case 6:
					new TopSortDFS(graph).Solve();
					break;
				case 7:
					new KahnsTopSort(graph).Solve();
					break;
				case 8:
					new DAGSSSP(graph, from).Solve();
					break;
				case 9:
					new LazyDijkstrasSSSP(graph, from, to).Solve();
					break;
				case 10:
					new EagerDijkstrasSSSP(graph, from, to).Solve();
					break;
				case 11:
					new BellmanFords(graph, from).Solve();
					break;
				case 12:
					new TarjansSCCs(graph).Solve();
					break;
				case 13:
					new KosarajusSCCs(graph).Solve();
					break;
				default:
					Console.WriteLine($"{selectedAlgoIdx} is not a valid selection");
					break;
			}
		}
		private void bgw_VisualizeGraphAlgo(object sender, DoWorkEventArgs e)
		{
			// Controls to disable while visualizing (not including parent form)
			Control[] controls = new Control[] { btnPauseResume, btnStart, btnReset, btnClearState, btnPresets, algoComboBox };
			parentForm.inGraphAlgoViz = inGraphAlgoViz = true;
			parentForm.ToggleMainMenuBtns();
			// Enable Pause/Resume and disable the rest of the controls before visualizing
			foreach (Control control in controls) SetControlEnabled(control, control == btnPauseResume);

			int from = -1, to = -1;
			// Visualize graph algo on valid input (input may not be required)
			if (GetStartAndEndNodes(ref from, ref to)) RunAlgo(from, to);

			// Disable Pause/Resume and re-enable the rest of the controls after visualizing
			foreach (Control control in controls) SetControlEnabled(control, control != btnPauseResume);
			parentForm.ToggleMainMenuBtns();
			parentForm.inGraphAlgoViz = inGraphAlgoViz = false;
		}
		private delegate void SetControlEnabledCallback(Control control, bool enabled);
		private void SetControlEnabled(Control control, bool enabled)
		{
			// Thread safe control.Enabled setting

			// InvokeRequired required compares the thread ID of the
			// calling thread to the thread ID of the creating thread.
			// If these threads are different, it returns true.
			if (control.InvokeRequired)
			{
				var d = new SetControlEnabledCallback(SetControlEnabled);
				Invoke(d, new object[] { control, enabled });
			}
			else control.Enabled = enabled;
		}
		#endregion

		#region Event handlers
		private void btnStart_Click(object sender, EventArgs e)
		{
			supressClearStateMsg = true;
			btnClearState_Click(sender, e);
			supressClearStateMsg = false;
			VisualizeGraphAlgo();
		}
		private void btnPauseResume_Click(object sender, EventArgs e)
		{
			// Note that this button is only enabled during a visualization!

			// Event handler for the Pause/Resume button, will pause or resume
			// the visualization depending on the current state of the visualization 
			if (graph.Paused)
			{
				btnPauseResume.Text = "Pause";
				graph.Resume();
			}
			else
			{
				btnPauseResume.Text = "Resume";
				graph.Pause();
			}
		}
		private void btnReset_Click(object sender, EventArgs e)
		{
			if (!graph.IsEmpty() && SimpleDialog.OKCancel("Clear the graph",
				"You are about to remove all vertices and edges\n press OK to proceed."))
			{
				graph.ClearGraph();
				canvas.Refresh();
				panelLogG.Clear(Colors.UndrawLog);
			}
		}
		private bool supressClearStateMsg = false;
		private void btnClearState_Click(object sender, EventArgs e)
		{
			// If graph is not empty and the confirmation msg is suppressed or confirmed(dialog result is OK)
			if (!graph.IsEmpty() && (supressClearStateMsg || SimpleDialog.OKCancel("Clear state", "Clear " +
				"particle/spring colors, spring \"Reversed\" state and the logging panel?")))
			{
				graph.ClearVizState();
				panelLogG.Clear(Colors.UndrawLog);
			}
		}
		private void btnPresets_Click(object sender, EventArgs e)
		{
			using (var presetDialog = new PresetDialog(graph))
			{
				presetDialog.StartPosition = FormStartPosition.CenterParent;
				presetDialog.ShowDialog();
			}
		}
		private void btnDetails_Click(object sender, EventArgs e)
		{
			string fileName = settings.AlgoNames[selectedAlgoIdx] + ".xml", 
				fileDir = @"Forms\Dialogs\AlgoDetails\xml\GraphTheory\" + fileName,
				filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())
				.Parent.FullName, fileDir);
			using(Form dialog = new DetailsDialog(filePath))
			{
				dialog.StartPosition = FormStartPosition.CenterParent;
				dialog.ShowDialog();
			}
		}
		private FDGVConfigForm configForm = null;
		private void btnPreferences_Click(object sender, EventArgs e)
		{
			// If form was already opened make sure to close 
			if (configForm != null)
			{
				configForm.Close();
				configForm.Dispose(); // not sure if I should dispose the form
			}
			configForm = new FDGVConfigForm(graph);
			configForm.Show();
		}

		private void speedBar_Scroll(object sender, ScrollEventArgs e)
		{
			if (graph != null) graph.DelayFactor = speedBar.Value;
		}
		private void algoComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedAlgoIdx = algoComboBox.SelectedIndex;
		}
		
		private void togglePhysicsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Toggle physics for graph drawing
			forcesEnabled = !forcesEnabled;
			Console.WriteLine($"Physics toggled " + (forcesEnabled ? "on" : "off"));
		}
		private void toggleCenterPullToolStripMenuItem_Click(object sender, EventArgs e)
		{
			graph.CenterPull = !graph.CenterPull;
		}
		private void toggleVertexPinToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (activeParticleId != -1)
			{
				graph.ToggleParticlePin(activeParticleId);
				activeParticleId = -1;
			}
		}
		private void pinAllVerticesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			graph.PinAllParticles();
		}
		private void unpinAllVerticesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			graph.UnpinAllParticles();
		}
		
		private void addVertexToolStripMenuItem_Click(object sender, EventArgs e)
		{
			graph.AddNode(canvasRightClickPos);
		}
		private void removeVertexToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (inGraphAlgoViz) return; // do nothing if currently visualizing somthing
			if (activeParticleId != -1)
			{
				bool remStatus = graph.RemoveNode(activeParticleId);
				Console.WriteLine("Removing particle with id {0}, status: {1}",
					activeParticleId, remStatus ? "Success" : "Failure");
				activeParticleId = -1;
			}
			canvas.Refresh(); // May be needed in case graph becomes empty
		}
		private void addEdgeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (inGraphAlgoViz) return; // do nothing if currently visualizing an algo
			using (var edgeDialog = new EdgeDialog(activeParticleId, graph, DialogMode.AddEdge))
			{
				edgeDialog.StartPosition = FormStartPosition.CenterParent;
				edgeDialog.ShowDialog();
			}
		}
		private void removeEdgeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (inGraphAlgoViz) return; // do nothing if currently visualizing an algo
			using (var edgeDialog = new EdgeDialog(activeParticleId, graph, DialogMode.RemoveEdge))
			{
				edgeDialog.StartPosition = FormStartPosition.CenterParent;
				edgeDialog.ShowDialog();
			}
		}

		private void canvas_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graph.DrawGraph(e.Graphics);
			frameCount++;
		}
		private void canvas_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				int x = e.X, y = e.Y;
				Particle clickedParticle = graph.GetParticle(x, y);
				if (clickedParticle != null)
				{
					movingParticle = clickedParticle;
					movingParticle.Pinned = true;
				}
			}
		}
		private void canvas_MouseMove(object sender, MouseEventArgs e)
		{
			canvasMouseHoverPos = new Vector(e.X, e.Y);
			if (movingParticle != null)
			{
				movingParticle.Pos = canvasMouseHoverPos;
				// Needed in case trying to move a particle outside of the canvas
				movingParticle.BoundWithinCanvas(canvas.Height, canvas.Width);
			}
		}
		private void canvas_MouseUp(object sender, MouseEventArgs e)
		{
			// Unpin particle for left/right click release
			if (movingParticle != null && (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
			{
				movingParticle.Pinned = false;
				movingParticle = null;
			}
			// Additionaly for rightlick release open the appropriate conect menu
			if (e.Button == MouseButtons.Right)
			{
				// Find location of click release and get clicked particle
				float x = e.X, y = e.Y;
				Particle clickedParticle = graph.GetParticle(x, y);
				
				// clicked on particle particle
				if (clickedParticle != null)
				{
					// show vertexContextStrip (remove vertex/add edge for current particle, ...)
					activeParticleId = clickedParticle.Id;
					vertexContextStrip.Show(Cursor.Position);
				}
				else
				{
					// show canvasContextStrip (add vertex, toggle physics, ...)
					canvasRightClickPos = new Vector(x, y);
					canvasContextStrip.Show(Cursor.Position);
				}
			}
		}
		private void canvas_MouseLeave(object sender, EventArgs e)
		{
			canvasMouseHoverPos = null;
		}

		private void GraphAlgoForm_Resize(object sender, EventArgs e)
		{
			// Update the center pos for the graph visualizer
			if (!formIsMinimized()) graph.UpdateCenterPos();
		}
		private void GraphAlgoForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			// https://stackoverflow.com/questions/1731384/how-to-stop-backgroundworker-on-forms-closing-event
			// Stopping graph viz bgw on form close to avoid crashing
			if (bgwGraphViz.IsBusy)
			{
				formClosePending = true;
				bgwGraphViz.CancelAsync();
				e.Cancel = true;
				Enabled = false; // or this.Hide()
			}
		}
		private void GraphAlgoForm_KeyDown(object sender, KeyEventArgs e)
		{
			// If not during a graph algo viz
			if (!inGraphAlgoViz)
			{
				// If pressd key is 'a' try adding a node, if failed to add show a message
				if (e.KeyCode == Keys.A && canvasMouseHoverPos != null && !graph.AddNode(canvasMouseHoverPos))
					SimpleDialog.ShowMessage("", "Failed to add node");
				// If pressd key is 'r' and hovering within canvas
				else if (e.KeyCode == Keys.R && canvasMouseHoverPos != null)
				{
					// Try getting the hovered particle using the postion of the mouse
					var hoverParticle = graph.GetParticle(canvasMouseHoverPos.X, canvasMouseHoverPos.Y);
					// Try removing the particle if non null, if failed to remove show a message
					if (hoverParticle != null)
					{
						bool remStatus = graph.RemoveNode(hoverParticle.Id);
						if (!remStatus) SimpleDialog.ShowMessage("", "Failed to remove node with id " + hoverParticle.Id);
						else canvas.Refresh(); // May be needed in case graph becomes empty
					}
				}
				else if (e.KeyCode == Keys.C)
				{
					// for 'ctrl' + 'c' clear the graph (remove vertices and edges)
					if (e.Modifiers == Keys.Control) btnReset_Click(sender, e);
					// else for 'c' clear the state (colors, "Reversed" stat for springs and panel log)
					else btnClearState_Click(sender, e);
				}
			}
			if (e.KeyCode == Keys.P)
			{
				// for 'ctrl' + 'p' toggle center pull
				if (e.Modifiers == Keys.Control) toggleCenterPullToolStripMenuItem_Click(sender, e);
				// else for 'p' toggle the physics
				else togglePhysicsToolStripMenuItem_Click(sender, e);
			}
		}
		protected override void OnShown(EventArgs e)
		{
			// Used to make key binds work, otherwise need to foucs on the form, i.e,
			// press a button, and only then will keybinds work
			Focus();
		}

        private void cbMaxSpeed_CheckStateChanged(object sender, EventArgs e)
        {
			speedBar.Enabled = !cbMaxSpeed.Checked;
			switch (cbMaxSpeed.Checked)
            {
				case true:
					speedBar.Value = speedBar.Maximum;
					break;
				case false:
					speedBar.Value = (speedBar.Maximum - speedBar.Minimum)*3/4;
					break;
			}
        }

        private DateTime lastFPSCheckTime = DateTime.Now;
		private int frameCount = 0;
		private void FPSTimer_Tick(object sender, EventArgs e)
		{
			// Update parent from's title to show the FPS estimate
			double deltaTime = (DateTime.Now - lastFPSCheckTime).TotalSeconds;
			double FPS = frameCount / deltaTime;

			parentForm.Text = string.Format("Algorithm visualizer \t\t FPS - {0:0.00}", FPS);

			lastFPSCheckTime = DateTime.Now;
			frameCount = 0;
		}
		#endregion
	}
}
