
namespace AlgorithmVisualizer.Forms
{
	partial class MazeGenForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblSpeedBar = new System.Windows.Forms.Label();
            this.heightTxtBox = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.speedBar = new System.Windows.Forms.HScrollBar();
            this.widthTxtBox = new System.Windows.Forms.TextBox();
            this.btnDrawSolveClearMaze = new System.Windows.Forms.Button();
            this.panelControls = new System.Windows.Forms.Panel();
            this.btnPauseResume = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.cmsAddPoints = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addStartPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFinishPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btSolve = new System.Windows.Forms.Button();
            this.panelControls.SuspendLayout();
            this.cmsAddPoints.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWidth
            // 
            this.lblWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWidth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.lblWidth.Location = new System.Drawing.Point(361, 7);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(100, 22);
            this.lblWidth.TabIndex = 26;
            this.lblWidth.Text = "Width";
            this.lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSpeedBar
            // 
            this.lblSpeedBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeedBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.lblSpeedBar.Location = new System.Drawing.Point(461, 7);
            this.lblSpeedBar.Name = "lblSpeedBar";
            this.lblSpeedBar.Size = new System.Drawing.Size(110, 19);
            this.lblSpeedBar.TabIndex = 22;
            this.lblSpeedBar.Text = "Speed";
            this.lblSpeedBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // heightTxtBox
            // 
            this.heightTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heightTxtBox.Location = new System.Drawing.Point(255, 29);
            this.heightTxtBox.Name = "heightTxtBox";
            this.heightTxtBox.Size = new System.Drawing.Size(100, 23);
            this.heightTxtBox.TabIndex = 23;
            // 
            // lblHeight
            // 
            this.lblHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.lblHeight.Location = new System.Drawing.Point(255, 7);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(100, 22);
            this.lblHeight.TabIndex = 25;
            this.lblHeight.Text = "Height";
            this.lblHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // speedBar
            // 
            this.speedBar.LargeChange = 1;
            this.speedBar.Location = new System.Drawing.Point(464, 29);
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(107, 20);
            this.speedBar.TabIndex = 21;
            this.speedBar.Value = 90;
            this.speedBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.speedBar_Scroll);
            // 
            // widthTxtBox
            // 
            this.widthTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.widthTxtBox.Location = new System.Drawing.Point(361, 29);
            this.widthTxtBox.Name = "widthTxtBox";
            this.widthTxtBox.Size = new System.Drawing.Size(100, 23);
            this.widthTxtBox.TabIndex = 24;
            // 
            // btnDrawSolveClearMaze
            // 
            this.btnDrawSolveClearMaze.BackColor = System.Drawing.Color.Gray;
            this.btnDrawSolveClearMaze.FlatAppearance.BorderSize = 0;
            this.btnDrawSolveClearMaze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawSolveClearMaze.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrawSolveClearMaze.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.btnDrawSolveClearMaze.Location = new System.Drawing.Point(12, 7);
            this.btnDrawSolveClearMaze.Name = "btnDrawSolveClearMaze";
            this.btnDrawSolveClearMaze.Size = new System.Drawing.Size(75, 42);
            this.btnDrawSolveClearMaze.TabIndex = 20;
            this.btnDrawSolveClearMaze.Text = "Draw Maze";
            this.btnDrawSolveClearMaze.UseVisualStyleBackColor = false;
            this.btnDrawSolveClearMaze.Click += new System.EventHandler(this.btnDrawSolveClearMaze_Click);
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.btSolve);
            this.panelControls.Controls.Add(this.btnPauseResume);
            this.panelControls.Controls.Add(this.btnDrawSolveClearMaze);
            this.panelControls.Controls.Add(this.widthTxtBox);
            this.panelControls.Controls.Add(this.lblWidth);
            this.panelControls.Controls.Add(this.speedBar);
            this.panelControls.Controls.Add(this.lblSpeedBar);
            this.panelControls.Controls.Add(this.lblHeight);
            this.panelControls.Controls.Add(this.heightTxtBox);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(1008, 55);
            this.panelControls.TabIndex = 28;
            // 
            // btnPauseResume
            // 
            this.btnPauseResume.BackColor = System.Drawing.Color.Gray;
            this.btnPauseResume.Enabled = false;
            this.btnPauseResume.FlatAppearance.BorderSize = 0;
            this.btnPauseResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPauseResume.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPauseResume.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.btnPauseResume.Location = new System.Drawing.Point(93, 7);
            this.btnPauseResume.Name = "btnPauseResume";
            this.btnPauseResume.Size = new System.Drawing.Size(75, 42);
            this.btnPauseResume.TabIndex = 27;
            this.btnPauseResume.Text = "Pause";
            this.btnPauseResume.UseVisualStyleBackColor = false;
            this.btnPauseResume.Click += new System.EventHandler(this.btnPauseResume_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 55);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1008, 506);
            this.panelMain.TabIndex = 29;
            // 
            // cmsAddPoints
            // 
            this.cmsAddPoints.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStartPointToolStripMenuItem,
            this.addFinishPointToolStripMenuItem});
            this.cmsAddPoints.Name = "cmsAddPoints";
            this.cmsAddPoints.Size = new System.Drawing.Size(160, 48);
            // 
            // addStartPointToolStripMenuItem
            // 
            this.addStartPointToolStripMenuItem.Name = "addStartPointToolStripMenuItem";
            this.addStartPointToolStripMenuItem.ShowShortcutKeys = false;
            this.addStartPointToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.addStartPointToolStripMenuItem.Text = "Add start point";
            // 
            // addFinishPointToolStripMenuItem
            // 
            this.addFinishPointToolStripMenuItem.Name = "addFinishPointToolStripMenuItem";
            this.addFinishPointToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.addFinishPointToolStripMenuItem.Text = "Add finish point";
            // 
            // btSolve
            // 
            this.btSolve.BackColor = System.Drawing.Color.Gray;
            this.btSolve.Enabled = false;
            this.btSolve.FlatAppearance.BorderSize = 0;
            this.btSolve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSolve.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.btSolve.Location = new System.Drawing.Point(174, 7);
            this.btSolve.Name = "btSolve";
            this.btSolve.Size = new System.Drawing.Size(75, 42);
            this.btSolve.TabIndex = 28;
            this.btSolve.Text = "Solve";
            this.btSolve.UseVisualStyleBackColor = false;
            this.btSolve.Click += new System.EventHandler(this.btSolve_Click);
            // 
            // MazeGenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelControls);
            this.Name = "MazeGenForm";
            this.Text = "Maze genrator";
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.cmsAddPoints.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblWidth;
		private System.Windows.Forms.Label lblSpeedBar;
		private System.Windows.Forms.TextBox heightTxtBox;
		private System.Windows.Forms.Label lblHeight;
		private System.Windows.Forms.HScrollBar speedBar;
		private System.Windows.Forms.TextBox widthTxtBox;
		private System.Windows.Forms.Button btnDrawSolveClearMaze;
		private System.Windows.Forms.Panel panelControls;
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.Button btnPauseResume;
        private System.Windows.Forms.ContextMenuStrip cmsAddPoints;
        private System.Windows.Forms.ToolStripMenuItem addStartPointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFinishPointToolStripMenuItem;
        private System.Windows.Forms.Button btSolve;
    }
}