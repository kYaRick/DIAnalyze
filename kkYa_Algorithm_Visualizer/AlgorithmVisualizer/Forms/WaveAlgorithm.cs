using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;

using AlgorithmVisualizer.Forms;

namespace Wave_Algorithm
{
    public partial class WaveAlgorithmForm : Form
    {
        private readonly MainUIForm parentForm;
        private RichTextBox rtbLog = new RichTextBox();

        private enum MarkMode
        {
            HorizontalVertical,
            Diagonal,
            Mixed
        }
        private int[,] GraphMatrix;

        public WaveAlgorithmForm(MainUIForm _parentForm)
        {
            InitializeComponent();
            parentForm = _parentForm;
            cbMethodsMode.SelectedIndex = 0;

            rtbLog = new RichTextBox()
            {
                Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right),
                Margin = new Padding(20, 10, 20, 10),
                BackColor = parentForm.PanelLog.BackColor,
                Font = parentForm.PanelLog.Font,
                BorderStyle = BorderStyle.None,
                ForeColor = Color.White,
                ReadOnly = true,
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Visible = true
            };
            parentForm.PanelLog.Controls.Add(rtbLog);
            
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.GridColor = Color.LightGray;
            
            dataGridView1.Click += dataGridClear;
            dataGridView1.DoubleClick += dataGridClear;
            chbShowWeights.CheckedChanged += HideOrShowWeights;

            var buttons = new[] { btnSetMazeSize, btnFullClean, button4 };
            foreach (var button in buttons)
                button.Click += rtbLogClean;
        }

        private void dataGridClear(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = DialogResult.OK;

            if (new[] { dataGridView1.RowCount, dataGridView1.ColumnCount }.Any(el => el > 0))
            {
                dialogResult = MessageBox.Show("If you set a new field you will lose the old experience!", "", MessageBoxButtons.OKCancel);
            }

            if (dialogResult == DialogResult.OK)
            {
                dataGridView1.ColumnCount = Convert.ToInt32(numericUpDown1.Value);
                dataGridView1.RowCount = Convert.ToInt32(numericUpDown2.Value);
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView1.Columns[i].HeaderCell.Value = i.ToString();
                    dataGridView1.Columns[i].Width = 25;
                }
                for (int i = 0; i < dataGridView1.RowCount; i++)
                    dataGridView1.Rows[i].HeaderCell.Value = i.ToString();
                ClearLabirint();
                dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            }
        }

        private void ClearLabirint()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1[j, i].Style.SelectionForeColor = Color.Transparent;
                    dataGridView1[j, i].Style.SelectionBackColor = Color.Transparent;
                    dataGridView1[j, i].Style.ForeColor = Color.Transparent;

                    dataGridView1[j,i].Value = -1;
                    dataGridView1[j,i].Style.BackColor = Color.White;
                }
        }

        private void HideOrShowWeights(object sender, EventArgs e)
        {
            if (sender is CheckBox localSender)
            {
                bool isShow = localSender.Checked;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1[j, i].Style.ForeColor = isShow ? Color.DarkGray : Color.Transparent;
                    }
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (e.Clicks == 1)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "-9";
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Black;
                    }
                    if (e.Clicks == 2)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "-1";
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                    }
                    break;
                case MouseButtons.Right:
                    if (e.Clicks == 1)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "-7";
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;

                    }
                    if (e.Clicks == 2)
                    { 
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "-5";
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                    }
                    break;
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearLabirint();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (new[] { dataGridView1.RowCount, dataGridView1.ColumnCount }.Any(el => el < 1))
            {
                MessageBox.Show("Algorithm plaсe is empty.");
            }
            else
            {
                GraphMatrix = new int[dataGridView1.RowCount, dataGridView1.ColumnCount];
                for (int i = 0; i < dataGridView1.RowCount; i++)
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        GraphMatrix[i, j] = Convert.ToInt32(dataGridView1[j, i].Value);
                MarkMode mode = MarkMode.Mixed;
                if (radioButton1.Checked)
                    mode = MarkMode.HorizontalVertical;
                else if (radioButton2.Checked)
                    mode = MarkMode.Diagonal;
                else if (radioButton3.Checked)
                    mode = MarkMode.Mixed;

                if (cbMethodsMode.SelectedIndex == 0)
                    WaveAlgorithm(GraphMatrix, mode, Convert.ToInt32(numericUpDown3.Value));
                else
                    WaveAlgorithmBidir(GraphMatrix, mode, Convert.ToInt32(numericUpDown3.Value));
            }
        }

        private void WaveAlgorithm(int[,] matrix, MarkMode markMode, int miliseconds)
        {
            int[,] WorkMatrix = (int[,])matrix.Clone();
            Point StartPoint = new Point();
            Point FinishPoint = new Point();
            int found = 0;
            for (int i = 0; i < WorkMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < WorkMatrix.GetLength(1); j++)
                {
                    if (WorkMatrix[i, j] == -7)
                    {
                        StartPoint = new Point(i, j);
                        WorkMatrix[i, j] = -1;
                        if (++found == 2)
                            break;
                    }
                    if (WorkMatrix[i, j] == -5)
                    {
                        FinishPoint = new Point(i, j);
                        WorkMatrix[i, j] = -1;
                        if (++found==2)
                            break;
                    }
                }
                if (found == 2)
                    break;
            }
            int Step = 1;
            WorkMatrix[StartPoint.X, StartPoint.Y] = 0;
            List<Point> NewFront = new List<Point>() { StartPoint };
            List<Point> OldFront = new List<Point>();
            List<Point> AllFront = new List<Point>();
            Stopwatch sw = Stopwatch.StartNew();
            do
            {
                OldFront = NewFront;
                AllFront.AddRange(OldFront);
                NewFront = new List<Point>();
                for (int i = 0; i < OldFront.Count; i++)
                    MarkUnmarkedCells(WorkMatrix, OldFront[i].X, OldFront[i].Y, NewFront, Step, markMode);
                Step++;
                ShowMatrix(WorkMatrix, NewFront, AllFront);

                if (!chbIsIgnoreSpeed.Checked)
                {
                    System.Threading.Thread.Sleep(miliseconds);
                    dataGridView1.Refresh();
                }
            }
            while (!NewFront.Contains(FinishPoint) && (NewFront.Count > 0));
            
            dataGridView1.Refresh();
            
            sw.Stop();
            if (NewFront.Count == 0)
            {
                MessageBox.Show("The path found was not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Point ActualNode = FinishPoint;
            List<Point> Path = new List<Point>() { FinishPoint };
            string pathInfo = "";
            do
            {
                ActualNode = GetNextNode(WorkMatrix, ActualNode.X, ActualNode.Y, markMode);
                Path.Add(ActualNode);
            }
            while (ActualNode != StartPoint);
            for (int i = 1; i < Path.Count-1; i++)
                dataGridView1[Path[i].Y, Path[i].X].Style.BackColor = Color.Yellow;
            for (int i = Path.Count -1; i > -1; i--)
                pathInfo += "[" + Path[i].X + "; " + Path[i].Y + "] ";

            rtbLog.Text += "Path found:\n\t" + pathInfo + ".\nThe length of the path - " + (Path.Count - 1) + "\n\t\t\tTime - " + sw.Elapsed.Milliseconds.ToString() + " ms\n";
        }

        private void WaveAlgorithmBidir(int[,] matrix, MarkMode markMode, int miliseconds)
        {
            int[,] WorkMatrix = (int[,])matrix.Clone();
            Point StartPoint = new Point();
            Point FinishPoint = new Point();
            int found = 0;
            for (int i = 0; i < WorkMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < WorkMatrix.GetLength(1); j++)
                {
                    if (WorkMatrix[i, j] == -7)
                    {
                        StartPoint = new Point(i, j);
                        WorkMatrix[i, j] = -1;
                        if (++found == 2)
                            break;
                    }
                    if (WorkMatrix[i, j] == -5)
                    {
                        FinishPoint = new Point(i, j);
                        WorkMatrix[i, j] = -1;
                        if (++found == 2)
                            break;
                    }
                }
                if (found == 2)
                    break;
            }
            bool f = false;
            int Step = 1;
            WorkMatrix[StartPoint.X, StartPoint.Y] = 0;
            WorkMatrix[FinishPoint.X, FinishPoint.Y] = 0;
            List<Point> NewFront1 = new List<Point>() { StartPoint };
            List<Point> OldFront1 = new List<Point>();
            List<Point> NewFront2 = new List<Point>() { FinishPoint };
            List<Point> OldFront2 = new List<Point>();
            List<Point> AllFront1 = new List<Point>();
            List<Point> AllFront2 = new List<Point>();
            Point MeetPoint = new Point(-100500, -100500);
            Stopwatch sw = Stopwatch.StartNew();
            do
            {
                OldFront1 = NewFront1;
                AllFront1.AddRange(OldFront1);
                NewFront1 = new List<Point>();
                for (int i = 0; i < OldFront1.Count; i++)
                    MarkUnmarkedCells(WorkMatrix, OldFront1[i].X, OldFront1[i].Y, NewFront1, NewFront2, Step, markMode, ref MeetPoint);
                if (MeetPoint.X != -100500 & MeetPoint.Y != -100500)
                {
                    break;
                    f = true;
                }
                OldFront2 = NewFront2;
                AllFront2.AddRange(OldFront2);
                NewFront2 = new List<Point>();
                for (int i = 0; i < OldFront2.Count; i++)
                    MarkUnmarkedCells(WorkMatrix, OldFront2[i].X, OldFront2[i].Y, NewFront2, NewFront1, Step, markMode, ref MeetPoint);
                Step++;
                ShowMatrix(WorkMatrix, NewFront1, NewFront2, AllFront1, AllFront2);
                
                if (!chbIsIgnoreSpeed.Checked)
                {
                    System.Threading.Thread.Sleep(miliseconds);
                    dataGridView1.Refresh();
                }
            }
            while ((NewFront2.Count > 0) && (NewFront1.Count > 0) && (MeetPoint.X == -100500 & MeetPoint.Y == -100500));

            dataGridView1.Refresh();

            sw.Stop();
            if (NewFront1.Count == 0 || NewFront2.Count == 0 || MeetPoint.X == -100500 & MeetPoint.Y == -100500)
            {
                MessageBox.Show("The path found was not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Point ActualNode = MeetPoint;
            List<Point> Path = new List<Point>();
            do
            {
                ActualNode = GetNextNode(WorkMatrix, ActualNode.X, ActualNode.Y, markMode, AllFront1);
                Path.Add(ActualNode);
            }
            while (ActualNode != FinishPoint);
            Path.Reverse();
            Path.Add(MeetPoint);
            ActualNode = MeetPoint;
            do
            {
                ActualNode = GetNextNode(WorkMatrix, ActualNode.X, ActualNode.Y, markMode, AllFront2);
                Path.Add(ActualNode);
            }
            while (ActualNode != StartPoint);
            string pathInfo = "";
            for (int i = 1; i < Path.Count - 1; i++)
                dataGridView1[Path[i].Y, Path[i].X].Style.BackColor = Color.Yellow;
            for (int i = Path.Count - 1; i > -1; i--)
                pathInfo += "[" + Path[i].X + "; " + Path[i].Y + "] ";

            rtbLog.Text += "Path found:\n\t" + pathInfo + ".\nThe length of the path - " + (f ? (Path.Count - 2) : (Path.Count - 1)) + "\n\t\t\tTime - " + sw.Elapsed.Milliseconds.ToString() + " ms\n";
        }

        private Point GetNextNode(int[,] workMatrix, int i, int j, MarkMode markMode)
        {
            Point NextNode = new Point(i, j);
            List<Point> Candidates = new List<Point>();
            switch (markMode)
            {
                case MarkMode.HorizontalVertical:
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i, j + 1] > -1)
                                    Candidates.Add(new Point(i, j + 1));
                                if (workMatrix[i + 1, j] > -1)
                                        Candidates.Add(new Point(i + 1, j));
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] > -1)
                                        Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i, j + 1] > -1)
                                        Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i + 1, j] > -1)
                                        Candidates.Add(new Point(i + 1, j));
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] > -1)
                                        Candidates.Add(new Point(i, j - 1));
                            }
                        }
                        if (i > 0 & i < workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i - 1, j] > -1)
                                        Candidates.Add(new Point(i - 1, j));
                                if (workMatrix[i, j + 1] > -1)
                                        Candidates.Add(new Point(i, j + 1));
                                if (workMatrix[i + 1, j] > -1)
                                        Candidates.Add(new Point(i + 1, j));
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i - 1, j] > -1)
                                        Candidates.Add(new Point(i - 1, j));
                                if (workMatrix[i, j - 1] > -1)
                                        Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i, j + 1] > -1)
                                        Candidates.Add(new Point(i, j + 1));
                                if (workMatrix[i + 1, j] > -1)
                                        Candidates.Add(new Point(i + 1, j));
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i - 1, j] > -1)
                                        Candidates.Add(new Point(i - 1, j));
                                if (workMatrix[i, j - 1] > -1)
                                        Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i + 1, j] > -1)
                                        Candidates.Add(new Point(i + 1, j));
                            }
                        }
                        if (i == workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i, j + 1] > -1)
                                        Candidates.Add(new Point(i, j + 1));
                                if (workMatrix[i - 1, j] > -1)
                                        Candidates.Add(new Point(i - 1, j));
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] > -1)
                                        Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i, j + 1] > -1)
                                        Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i - 1, j] > -1)
                                        Candidates.Add(new Point(i - 1, j));
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] > -1)
                                        Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i - 1, j] > -1)
                                        Candidates.Add(new Point(i - 1, j));
                            }

                        }
                        break;
                    }
                case MarkMode.Diagonal:
                    {

                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i + 1, j + 1] > -1)
                                        Candidates.Add(new Point(i + 1, j + 1));
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i + 1, j - 1] > -1)
                                        Candidates.Add(new Point(i + 1, j - 1));
                                if (workMatrix[i + 1, j + 1] > -1)
                                        Candidates.Add(new Point(i + 1, j + 1));
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i + 1, j - 1] > -1)
                                        Candidates.Add(new Point(i + 1, j - 1));
                            }
                        }
                        if (i > 0 & i < workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i - 1, j + 1] > -1)
                                        Candidates.Add(new Point(i - 1, j + 1));
                                if (workMatrix[i + 1, j + 1] > -1)
                                        Candidates.Add(new Point(i + 1, j + 1));
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i - 1, j - 1] > -1)
                                        Candidates.Add(new Point(i - 1, j - 1));
                                if (workMatrix[i - 1, j + 1] > -1)
                                        Candidates.Add(new Point(i - 1, j + 1));
                                if (workMatrix[i + 1, j - 1] > -1)
                                        Candidates.Add(new Point(i + 1, j - 1));
                                if (workMatrix[i + 1, j + 1] > -1)
                                        Candidates.Add(new Point(i + 1, j + 1));
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i - 1, j - 1] > -1)
                                        Candidates.Add(new Point(i - 1, j - 1));
                                if (workMatrix[i + 1, j - 1] > -1)
                                        Candidates.Add(new Point(i + 1, j - 1));
                            }
                        }
                        if (i == workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i - 1, j + 1] > -1)
                                        Candidates.Add(new Point(i - 1, j + 1));
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i - 1, j - 1] > -1)
                                        Candidates.Add(new Point(i - 1, j - 1));
                                if (workMatrix[i - 1, j + 1] > -1)
                                        Candidates.Add(new Point(i - 1, j + 1));
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i - 1, j - 1] > -1)
                                        Candidates.Add(new Point(i - 1, j - 1));
                            }
                        }
                        break;
                    }
                case MarkMode.Mixed:
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i, j + 1] > -1)
                                        Candidates.Add(new Point(i, j + 1));
                                if (workMatrix[i + 1, j] > -1)
                                        Candidates.Add(new Point(i + 1, j));
                                if (workMatrix[i + 1, j + 1] > -1)
                                        Candidates.Add(new Point(i + 1, j + 1));
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] > -1)
                                        Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i, j + 1] > -1)
                                        Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i + 1, j - 1] > -1)
                                        Candidates.Add(new Point(i + 1, j - 1));
                                if (workMatrix[i + 1, j] > -1)
                                        Candidates.Add(new Point(i + 1, j));
                                if (workMatrix[i + 1, j + 1] > -1)
                                        Candidates.Add(new Point(i + 1, j + 1));
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] > -1)
                                        Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i + 1, j - 1] > -1)
                                        Candidates.Add(new Point(i + 1, j - 1));
                                if (workMatrix[i + 1, j] > -1)
                                        Candidates.Add(new Point(i + 1, j));
                            }
                        }
                        if (i > 0 & i < workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i - 1, j] > -1)
                                        Candidates.Add(new Point(i - 1, j));
                                if (workMatrix[i - 1, j + 1] > -1)
                                        Candidates.Add(new Point(i - 1, j + 1));
                                if (workMatrix[i, j + 1] > -1)
                                        Candidates.Add(new Point(i, j + 1));
                                if (workMatrix[i + 1, j] > -1)
                                        Candidates.Add(new Point(i + 1, j));
                                if (workMatrix[i + 1, j + 1] > -1)
                                        Candidates.Add(new Point(i + 1, j + 1));
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i - 1, j - 1] > -1)
                                        Candidates.Add(new Point(i - 1, j - 1));
                                if (workMatrix[i - 1, j] > -1)
                                        Candidates.Add(new Point(i - 1, j));
                                if (workMatrix[i - 1, j + 1] > -1)
                                        Candidates.Add(new Point(i - 1, j + 1));
                                if (workMatrix[i, j - 1] > -1)
                                        Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i, j + 1] > -1)
                                        Candidates.Add(new Point(i, j + 1));
                                if (workMatrix[i + 1, j - 1] > -1)
                                        Candidates.Add(new Point(i + 1, j - 1));
                                if (workMatrix[i + 1, j] > -1)
                                        Candidates.Add(new Point(i + 1, j));
                                if (workMatrix[i + 1, j + 1] > -1)
                                        Candidates.Add(new Point(i + 1, j + 1));
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i - 1, j - 1] > -1)
                                        Candidates.Add(new Point(i - 1, j - 1));
                                if (workMatrix[i - 1, j] > -1)
                                        Candidates.Add(new Point(i - 1, j));
                                if (workMatrix[i, j - 1] > -1)
                                        Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i + 1, j - 1] > -1)
                                        Candidates.Add(new Point(i + 1, j - 1));
                                if (workMatrix[i + 1, j] > -1)
                                        Candidates.Add(new Point(i + 1, j));
                            }
                        }
                        if (i == workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i, j + 1] > -1)
                                        Candidates.Add(new Point(i, j + 1));
                                if (workMatrix[i - 1, j] > -1)
                                        Candidates.Add(new Point(i - 1, j));
                                if (workMatrix[i - 1, j + 1] > -1)
                                        Candidates.Add(new Point(i - 1, j + 1));
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] > -1)
                                        Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i, j + 1] > -1)
                                        Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i - 1, j - 1] > -1)
                                        Candidates.Add(new Point(i - 1, j - 1));
                                if (workMatrix[i - 1, j] > -1)
                                        Candidates.Add(new Point(i - 1, j));
                                if (workMatrix[i - 1, j + 1] > -1)
                                        Candidates.Add(new Point(i - 1, j + 1));
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] > -1)
                                        Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i - 1, j - 1] > -1)
                                        Candidates.Add(new Point(i - 1, j - 1));
                                if (workMatrix[i - 1, j] > -1)
                                        Candidates.Add(new Point(i - 1, j));
                            }

                        }
                        break;
                    }
            };
            NextNode = Candidates[0];
            for (int k = 1; k < Candidates.Count; k++)
            {
                if (workMatrix[Candidates[k].X, Candidates[k].Y] < workMatrix[i, j])
                {
                    NextNode = Candidates[k];
                    break;
                }
            }
            return NextNode;
        }

        private Point GetNextNode(int[,] workMatrix, int i, int j, MarkMode markMode, List<Point> oppositeFront)
        {
            Point NextNode = new Point(i, j);
            List<Point> Candidates = new List<Point>();
            switch (markMode)
            {
                case MarkMode.HorizontalVertical:
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i, j + 1] > -1)
                                    Candidates.Add(new Point(i, j + 1));
                                if (workMatrix[i + 1, j] > -1)
                                    Candidates.Add(new Point(i + 1, j));
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] > -1)
                                    Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i, j + 1] > -1)
                                    Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i + 1, j] > -1)
                                    Candidates.Add(new Point(i + 1, j));
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] > -1)
                                    Candidates.Add(new Point(i, j - 1));
                            }
                        }
                        if (i > 0 & i < workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i - 1, j] > -1)
                                    Candidates.Add(new Point(i - 1, j));
                                if (workMatrix[i, j + 1] > -1)
                                    Candidates.Add(new Point(i, j + 1));
                                if (workMatrix[i + 1, j] > -1)
                                    Candidates.Add(new Point(i + 1, j));
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i - 1, j] > -1)
                                    Candidates.Add(new Point(i - 1, j));
                                if (workMatrix[i, j - 1] > -1)
                                    Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i, j + 1] > -1)
                                    Candidates.Add(new Point(i, j + 1));
                                if (workMatrix[i + 1, j] > -1)
                                    Candidates.Add(new Point(i + 1, j));
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i - 1, j] > -1)
                                    Candidates.Add(new Point(i - 1, j));
                                if (workMatrix[i, j - 1] > -1)
                                    Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i + 1, j] > -1)
                                    Candidates.Add(new Point(i + 1, j));
                            }
                        }
                        if (i == workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i, j + 1] > -1)
                                    Candidates.Add(new Point(i, j + 1));
                                if (workMatrix[i - 1, j] > -1)
                                    Candidates.Add(new Point(i - 1, j));
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] > -1)
                                    Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i, j + 1] > -1)
                                    Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i - 1, j] > -1)
                                    Candidates.Add(new Point(i - 1, j));
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] > -1)
                                    Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i - 1, j] > -1)
                                    Candidates.Add(new Point(i - 1, j));
                            }

                        }
                        break;
                    }
                case MarkMode.Diagonal:
                    {

                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i + 1, j + 1] > -1)
                                    Candidates.Add(new Point(i + 1, j + 1));
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i + 1, j - 1] > -1)
                                    Candidates.Add(new Point(i + 1, j - 1));
                                if (workMatrix[i + 1, j + 1] > -1)
                                    Candidates.Add(new Point(i + 1, j + 1));
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i + 1, j - 1] > -1)
                                    Candidates.Add(new Point(i + 1, j - 1));
                            }
                        }
                        if (i > 0 & i < workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i - 1, j + 1] > -1)
                                    Candidates.Add(new Point(i - 1, j + 1));
                                if (workMatrix[i + 1, j + 1] > -1)
                                    Candidates.Add(new Point(i + 1, j + 1));
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i - 1, j - 1] > -1)
                                    Candidates.Add(new Point(i - 1, j - 1));
                                if (workMatrix[i - 1, j + 1] > -1)
                                    Candidates.Add(new Point(i - 1, j + 1));
                                if (workMatrix[i + 1, j - 1] > -1)
                                    Candidates.Add(new Point(i + 1, j - 1));
                                if (workMatrix[i + 1, j + 1] > -1)
                                    Candidates.Add(new Point(i + 1, j + 1));
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i - 1, j - 1] > -1)
                                    Candidates.Add(new Point(i - 1, j - 1));
                                if (workMatrix[i + 1, j - 1] > -1)
                                    Candidates.Add(new Point(i + 1, j - 1));
                            }
                        }
                        if (i == workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i - 1, j + 1] > -1)
                                    Candidates.Add(new Point(i - 1, j + 1));
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i - 1, j - 1] > -1)
                                    Candidates.Add(new Point(i - 1, j - 1));
                                if (workMatrix[i - 1, j + 1] > -1)
                                    Candidates.Add(new Point(i - 1, j + 1));
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i - 1, j - 1] > -1)
                                    Candidates.Add(new Point(i - 1, j - 1));
                            }
                        }
                        break;
                    }
                case MarkMode.Mixed:
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i, j + 1] > -1)
                                    Candidates.Add(new Point(i, j + 1));
                                if (workMatrix[i + 1, j] > -1)
                                    Candidates.Add(new Point(i + 1, j));
                                if (workMatrix[i + 1, j + 1] > -1)
                                    Candidates.Add(new Point(i + 1, j + 1));
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] > -1)
                                    Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i, j + 1] > -1)
                                    Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i + 1, j - 1] > -1)
                                    Candidates.Add(new Point(i + 1, j - 1));
                                if (workMatrix[i + 1, j] > -1)
                                    Candidates.Add(new Point(i + 1, j));
                                if (workMatrix[i + 1, j + 1] > -1)
                                    Candidates.Add(new Point(i + 1, j + 1));
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] > -1)
                                    Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i + 1, j - 1] > -1)
                                    Candidates.Add(new Point(i + 1, j - 1));
                                if (workMatrix[i + 1, j] > -1)
                                    Candidates.Add(new Point(i + 1, j));
                            }
                        }
                        if (i > 0 & i < workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i - 1, j] > -1)
                                    Candidates.Add(new Point(i - 1, j));
                                if (workMatrix[i - 1, j + 1] > -1)
                                    Candidates.Add(new Point(i - 1, j + 1));
                                if (workMatrix[i, j + 1] > -1)
                                    Candidates.Add(new Point(i, j + 1));
                                if (workMatrix[i + 1, j] > -1)
                                    Candidates.Add(new Point(i + 1, j));
                                if (workMatrix[i + 1, j + 1] > -1)
                                    Candidates.Add(new Point(i + 1, j + 1));
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i - 1, j - 1] > -1)
                                    Candidates.Add(new Point(i - 1, j - 1));
                                if (workMatrix[i - 1, j] > -1)
                                    Candidates.Add(new Point(i - 1, j));
                                if (workMatrix[i - 1, j + 1] > -1)
                                    Candidates.Add(new Point(i - 1, j + 1));
                                if (workMatrix[i, j - 1] > -1)
                                    Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i, j + 1] > -1)
                                    Candidates.Add(new Point(i, j + 1));
                                if (workMatrix[i + 1, j - 1] > -1)
                                    Candidates.Add(new Point(i + 1, j - 1));
                                if (workMatrix[i + 1, j] > -1)
                                    Candidates.Add(new Point(i + 1, j));
                                if (workMatrix[i + 1, j + 1] > -1)
                                    Candidates.Add(new Point(i + 1, j + 1));
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i - 1, j - 1] > -1)
                                    Candidates.Add(new Point(i - 1, j - 1));
                                if (workMatrix[i - 1, j] > -1)
                                    Candidates.Add(new Point(i - 1, j));
                                if (workMatrix[i, j - 1] > -1)
                                    Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i + 1, j - 1] > -1)
                                    Candidates.Add(new Point(i + 1, j - 1));
                                if (workMatrix[i + 1, j] > -1)
                                    Candidates.Add(new Point(i + 1, j));
                            }
                        }
                        if (i == workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i, j + 1] > -1)
                                    Candidates.Add(new Point(i, j + 1));
                                if (workMatrix[i - 1, j] > -1)
                                    Candidates.Add(new Point(i - 1, j));
                                if (workMatrix[i - 1, j + 1] > -1)
                                    Candidates.Add(new Point(i - 1, j + 1));
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] > -1)
                                    Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i, j + 1] > -1)
                                    Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i - 1, j - 1] > -1)
                                    Candidates.Add(new Point(i - 1, j - 1));
                                if (workMatrix[i - 1, j] > -1)
                                    Candidates.Add(new Point(i - 1, j));
                                if (workMatrix[i - 1, j + 1] > -1)
                                    Candidates.Add(new Point(i - 1, j + 1));
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] > -1)
                                    Candidates.Add(new Point(i, j - 1));
                                if (workMatrix[i - 1, j - 1] > -1)
                                    Candidates.Add(new Point(i - 1, j - 1));
                                if (workMatrix[i - 1, j] > -1)
                                    Candidates.Add(new Point(i - 1, j));
                            }

                        }
                        break;
                    }
            };

            try
            {
                NextNode = Candidates[0];
                for (int k = 1; k < Candidates.Count; k++)
                {
                    if (workMatrix[Candidates[k].X, Candidates[k].Y] < workMatrix[i, j] && !oppositeFront.Contains(Candidates[k]))
                    {
                        NextNode = Candidates[k];
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("An error occurred while executing the program, and the path cannot be found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception();
            }

            return NextNode;
        }

        private void ShowMatrix(int[,] workMatrix, List<Point> Front1, List<Point> AllFront)
        {
            for (int i = 0; i < workMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < workMatrix.GetLength(1); j++)
                {
                    if (workMatrix[i, j] != -1)
                    {
                        dataGridView1[j, i].Value = workMatrix[i, j];
                        if (workMatrix[i, j] > 0)
                        {
                            if (AllFront.Contains(new Point(i, j)))
                                dataGridView1[j, i].Style.BackColor = Color.LightSeaGreen;
                            else if (Front1.Contains(new Point(i, j)))
                                dataGridView1[j, i].Style.BackColor = Color.SeaGreen;
                        }
                    }
                }
            }
        }

        private void ShowMatrix(int[,] workMatrix, List<Point> Front1, List<Point> Front2, List<Point> AllFront1, List<Point> AllFront2)
        {
            for (int i = 0; i < workMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < workMatrix.GetLength(1); j++)
                {
                    if (workMatrix[i, j] != -1)
                    {
                        dataGridView1[j, i].Value = workMatrix[i, j];
                        if (workMatrix[i, j] > 0)
                        {
                            if (AllFront1.Contains(new Point(i, j)))
                                dataGridView1[j, i].Style.BackColor = Color.LightSeaGreen;
                            else if (AllFront2.Contains(new Point(i, j)))
                                dataGridView1[j, i].Style.BackColor = Color.LightSalmon;
                            else if (Front1.Contains(new Point(i, j)))
                                dataGridView1[j, i].Style.BackColor = Color.SeaGreen;
                            else if (Front2.Contains(new Point(i, j)))
                                dataGridView1[j, i].Style.BackColor = Color.Salmon;
                        }
                    }
                }
            }
        }

        private void MarkUnmarkedCells(int[,] workMatrix, int i, int j, List<Point> newFront, int step, MarkMode markMode)
        {
            switch (markMode)
            {
                case MarkMode.Mixed:
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i, j + 1]== -1)
                                {
                                    workMatrix[i, j + 1] = step;
                                    if (!newFront.Contains(new Point(i, j + 1)))
                                        newFront.Add(new Point(i, j + 1));
                                }
                                if (workMatrix[i + 1, j]== -1)
                                {
                                    workMatrix[i + 1, j] = step;
                                    if (!newFront.Contains(new Point(i + 1, j)))
                                        newFront.Add(new Point(i + 1, j));
                                }
                                if (workMatrix[i + 1, j + 1]== -1)
                                {
                                    workMatrix[i + 1, j + 1] = step;
                                    if (!newFront.Contains(new Point(i + 1, j + 1)))
                                        newFront.Add(new Point(i + 1, j + 1));
                                }
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1]== -1)
                                {
                                    workMatrix[i, j - 1] = step;
                                    if (!newFront.Contains(new Point(i, j - 1)))
                                        newFront.Add(new Point(i, j - 1));
                                }
                                if (workMatrix[i, j + 1]== -1)
                                {
                                    workMatrix[i, j + 1] = step;
                                    if (!newFront.Contains(new Point(i, j - 1)))
                                        newFront.Add(new Point(i, j - 1));
                                }
                                if (workMatrix[i + 1, j - 1] == -1)
                                {
                                    workMatrix[i + 1, j - 1] = step;
                                    if (!newFront.Contains(new Point(i + 1, j - 1)))
                                        newFront.Add(new Point(i + 1, j - 1));
                                }
                                if (workMatrix[i + 1, j] == -1)
                                {
                                    workMatrix[i + 1, j] = step;
                                    if (!newFront.Contains(new Point(i + 1, j)))
                                        newFront.Add(new Point(i + 1, j));
                                }
                                if (workMatrix[i + 1, j + 1] == -1)
                                {
                                    workMatrix[i + 1, j + 1] = step;
                                    if (!newFront.Contains(new Point(i + 1, j + 1)))
                                        newFront.Add(new Point(i + 1, j + 1));
                                }
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] == -1)
                                {
                                    workMatrix[i, j - 1] = step;
                                    if (!newFront.Contains(new Point(i, j - 1)))
                                        newFront.Add(new Point(i, j - 1));
                                }
                                if (workMatrix[i + 1, j - 1] == -1)
                                {
                                    workMatrix[i + 1, j - 1] = step;
                                    if (!newFront.Contains(new Point(i + 1, j - 1)))
                                        newFront.Add(new Point(i + 1, j - 1));
                                }
                                if (workMatrix[i + 1, j] == -1)
                                {
                                    workMatrix[i + 1, j] = step;
                                    if (!newFront.Contains(new Point(i + 1, j)))
                                        newFront.Add(new Point(i + 1, j));
                                }
                            }
                        }
                        if (i > 0 & i < workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i - 1, j] == -1)
                                {
                                    workMatrix[i - 1, j] = step;
                                    if (!newFront.Contains(new Point(i - 1, j)))
                                        newFront.Add(new Point(i - 1, j));
                                }
                                if (workMatrix[i - 1, j + 1] == -1)
                                {
                                    workMatrix[i - 1, j + 1] = step;
                                    if (!newFront.Contains(new Point(i - 1, j + 1)))
                                        newFront.Add(new Point(i - 1, j + 1));
                                }
                                if (workMatrix[i, j + 1] == -1)
                                {
                                    workMatrix[i, j + 1] = step;
                                    if (!newFront.Contains(new Point(i, j + 1)))
                                        newFront.Add(new Point(i, j + 1));
                                }
                                if (workMatrix[i + 1, j] == -1)
                                {
                                    workMatrix[i + 1, j] = step;
                                    if (!newFront.Contains(new Point(i + 1, j)))
                                        newFront.Add(new Point(i + 1, j));
                                }
                                if (workMatrix[i + 1, j + 1] == -1)
                                {
                                    workMatrix[i + 1, j + 1] = step;
                                    if (!newFront.Contains(new Point(i + 1, j + 1)))
                                        newFront.Add(new Point(i + 1, j + 1));
                                }
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i - 1, j - 1] == -1)
                                {
                                    workMatrix[i - 1, j - 1] = step;
                                    if (!newFront.Contains(new Point(i - 1, j - 1)))
                                        newFront.Add(new Point(i - 1, j - 1));
                                }
                                if (workMatrix[i - 1, j] == -1)
                                {
                                    workMatrix[i - 1, j] = step;
                                    if (!newFront.Contains(new Point(i - 1, j)))
                                        newFront.Add(new Point(i - 1, j));
                                }
                                if (workMatrix[i - 1, j + 1] == -1)
                                {
                                    workMatrix[i - 1, j + 1] = step;
                                    if (!newFront.Contains(new Point(i - 1, j + 1)))
                                        newFront.Add(new Point(i - 1, j + 1));
                                }
                                if (workMatrix[i, j - 1] == -1)
                                {
                                    workMatrix[i, j - 1] = step;
                                    if (!newFront.Contains(new Point(i, j - 1)))
                                        newFront.Add(new Point(i, j - 1));
                                }
                                if (workMatrix[i, j + 1] == -1)
                                {
                                    workMatrix[i, j + 1] = step;
                                    if (!newFront.Contains(new Point(i, j + 1)))
                                        newFront.Add(new Point(i, j + 1));
                                }
                                if (workMatrix[i + 1, j - 1] == -1)
                                {
                                    workMatrix[i + 1, j - 1] = step;
                                    if (!newFront.Contains(new Point(i + 1, j - 1)))
                                        newFront.Add(new Point(i + 1, j - 1));
                                }
                                if (workMatrix[i + 1, j] == -1)
                                {
                                    workMatrix[i + 1, j] = step;
                                    if (!newFront.Contains(new Point(i + 1, j)))
                                        newFront.Add(new Point(i + 1, j));
                                }
                                if (workMatrix[i + 1, j + 1] == -1)
                                {
                                    workMatrix[i + 1, j + 1] = step;
                                    if (!newFront.Contains(new Point(i + 1, j + 1)))
                                        newFront.Add(new Point(i + 1, j + 1));
                                }
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i - 1, j - 1] == -1)
                                {
                                    workMatrix[i - 1, j - 1] = step;
                                    if (!newFront.Contains(new Point(i - 1, j - 1)))
                                        newFront.Add(new Point(i - 1, j - 1));
                                }
                                if (workMatrix[i - 1, j] == -1)
                                {
                                    workMatrix[i - 1, j] = step;
                                    if (!newFront.Contains(new Point(i - 1, j)))
                                        newFront.Add(new Point(i - 1, j));
                                }
                                if (workMatrix[i, j - 1] == -1)
                                {
                                    workMatrix[i, j - 1] = step;
                                    if (!newFront.Contains(new Point(i, j - 1)))
                                        newFront.Add(new Point(i, j - 1));
                                }
                                if (workMatrix[i + 1, j - 1] == -1)
                                {
                                    workMatrix[i + 1, j - 1] = step;
                                    if (!newFront.Contains(new Point(i + 1, j - 1)))
                                        newFront.Add(new Point(i + 1, j - 1));
                                }
                                if (workMatrix[i + 1, j] == -1)
                                {
                                    workMatrix[i + 1, j] = step;
                                    if (!newFront.Contains(new Point(i + 1, j)))
                                        newFront.Add(new Point(i + 1, j));
                                }
                            }
                        }
                        if (i == workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i, j + 1] == -1)
                                {
                                    workMatrix[i, j + 1] = step;
                                    if (!newFront.Contains(new Point(i, j + 1)))
                                        newFront.Add(new Point(i, j + 1));
                                }
                                if (workMatrix[i - 1, j] == -1)
                                {
                                    workMatrix[i - 1, j] = step;
                                    if (!newFront.Contains(new Point(i - 1, j)))
                                        newFront.Add(new Point(i - 1, j));
                                }
                                if (workMatrix[i - 1, j + 1] == -1)
                                {
                                    workMatrix[i - 1, j + 1] = step;
                                    if (!newFront.Contains(new Point(i - 1, j + 1)))
                                        newFront.Add(new Point(i - 1, j + 1));
                                }
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] == -1)
                                {
                                    workMatrix[i, j - 1] = step;
                                    if (!newFront.Contains(new Point(i, j - 1)))
                                        newFront.Add(new Point(i, j - 1));
                                }
                                if (workMatrix[i, j + 1] == -1)
                                {
                                    workMatrix[i, j + 1] = step;
                                    if (!newFront.Contains(new Point(i, j - 1)))
                                        newFront.Add(new Point(i, j - 1));
                                }
                                if (workMatrix[i - 1, j - 1] == -1)
                                {
                                    workMatrix[i - 1, j - 1] = step;
                                    if (!newFront.Contains(new Point(i - 1, j - 1)))
                                        newFront.Add(new Point(i - 1, j - 1));
                                }
                                if (workMatrix[i - 1, j] == -1)
                                {
                                    workMatrix[i - 1, j] = step;
                                    if (!newFront.Contains(new Point(i - 1, j)))
                                        newFront.Add(new Point(i - 1, j));
                                }
                                if (workMatrix[i - 1, j + 1] == -1)
                                {
                                    workMatrix[i - 1, j + 1] = step;
                                    if (!newFront.Contains(new Point(i - 1, j + 1)))
                                        newFront.Add(new Point(i - 1, j + 1));
                                }
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] == -1)
                                {
                                    workMatrix[i, j - 1] = step;
                                    if (!newFront.Contains(new Point(i, j - 1)))
                                        newFront.Add(new Point(i, j - 1));
                                }
                                if (workMatrix[i - 1, j - 1] == -1)
                                {
                                    workMatrix[i - 1, j - 1] = step;
                                    if (!newFront.Contains(new Point(i - 1, j - 1)))
                                        newFront.Add(new Point(i - 1, j - 1));
                                }
                                if (workMatrix[i - 1, j] == -1)
                                {
                                    workMatrix[i - 1, j] = step;
                                    if (!newFront.Contains(new Point(i - 1, j)))
                                        newFront.Add(new Point(i - 1, j));
                                }
                            }

                        }
                        break;
                    }
                case MarkMode.Diagonal:
                    {

                        if (i == 0)
                        {
                            if (j == 0)
                            {                               
                                if (workMatrix[i + 1, j + 1] == -1)
                                {
                                    workMatrix[i + 1, j + 1] = step;
                                    if (!newFront.Contains(new Point(i + 1, j + 1)))
                                        newFront.Add(new Point(i + 1, j + 1));
                                }
                            }
                           
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i + 1, j - 1] == -1)
                                {
                                    workMatrix[i + 1, j - 1] = step;
                                    if (!newFront.Contains(new Point(i + 1, j - 1)))
                                        newFront.Add(new Point(i + 1, j - 1));
                                }
                                if (workMatrix[i + 1, j + 1] == -1)
                                {
                                    workMatrix[i + 1, j + 1] = step;
                                    if (!newFront.Contains(new Point(i + 1, j + 1)))
                                        newFront.Add(new Point(i + 1, j + 1));
                                }
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i + 1, j - 1] == -1)
                                {
                                    workMatrix[i + 1, j - 1] = step;
                                    if (!newFront.Contains(new Point(i + 1, j - 1)))
                                        newFront.Add(new Point(i + 1, j - 1));
                                }
                            }
                        }
                        if (i > 0 & i < workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {                                
                                if (workMatrix[i - 1, j + 1] == -1)
                                {
                                    workMatrix[i - 1, j + 1] = step;
                                    if (!newFront.Contains(new Point(i - 1, j + 1)))
                                        newFront.Add(new Point(i - 1, j + 1));
                                }
                                if (workMatrix[i + 1, j + 1] == -1)
                                {
                                    workMatrix[i + 1, j + 1] = step;
                                    if (!newFront.Contains(new Point(i + 1, j + 1)))
                                        newFront.Add(new Point(i + 1, j + 1));
                                }
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i - 1, j - 1] == -1)
                                {
                                    workMatrix[i - 1, j - 1] = step;
                                    if (!newFront.Contains(new Point(i - 1, j - 1)))
                                        newFront.Add(new Point(i - 1, j - 1));
                                }
                                if (workMatrix[i - 1, j + 1] == -1)
                                {
                                    workMatrix[i - 1, j + 1] = step;
                                    if (!newFront.Contains(new Point(i - 1, j + 1)))
                                        newFront.Add(new Point(i - 1, j + 1));
                                }
                                if (workMatrix[i + 1, j - 1] == -1)
                                {
                                    workMatrix[i + 1, j - 1] = step;
                                    if (!newFront.Contains(new Point(i + 1, j - 1)))
                                        newFront.Add(new Point(i + 1, j - 1));
                                }
                                if (workMatrix[i + 1, j + 1] == -1)
                                {
                                    workMatrix[i + 1, j + 1] = step;
                                    if (!newFront.Contains(new Point(i + 1, j + 1)))
                                        newFront.Add(new Point(i + 1, j + 1));
                                }
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i - 1, j - 1] == -1)
                                {
                                    workMatrix[i - 1, j - 1] = step;
                                    if (!newFront.Contains(new Point(i - 1, j - 1)))
                                        newFront.Add(new Point(i - 1, j - 1));
                                }
                                if (workMatrix[i + 1, j - 1] == -1)
                                {
                                    workMatrix[i + 1, j - 1] = step;
                                    if (!newFront.Contains(new Point(i + 1, j - 1)))
                                        newFront.Add(new Point(i + 1, j - 1));
                                }
                            }
                        }
                        if (i == workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i - 1, j + 1] == -1)
                                {
                                    workMatrix[i - 1, j + 1] = step;
                                    if (!newFront.Contains(new Point(i - 1, j + 1)))
                                        newFront.Add(new Point(i - 1, j + 1));
                                }
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i - 1, j - 1] == -1)
                                {
                                    workMatrix[i - 1, j - 1] = step;
                                    if (!newFront.Contains(new Point(i - 1, j - 1)))
                                        newFront.Add(new Point(i - 1, j - 1));
                                }
                                if (workMatrix[i - 1, j + 1] == -1)
                                {
                                    workMatrix[i - 1, j + 1] = step;
                                    if (!newFront.Contains(new Point(i - 1, j + 1)))
                                        newFront.Add(new Point(i - 1, j + 1));
                                }
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {                                
                                if (workMatrix[i - 1, j - 1] == -1)
                                {
                                    workMatrix[i - 1, j - 1] = step;
                                    if (!newFront.Contains(new Point(i - 1, j - 1)))
                                        newFront.Add(new Point(i - 1, j - 1));
                                }
                            }

                        }
                        break;
                    }
                case MarkMode.HorizontalVertical:
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i, j + 1] == -1)
                                {
                                    workMatrix[i, j + 1] = step;
                                    if (!newFront.Contains(new Point(i, j + 1)))
                                        newFront.Add(new Point(i, j + 1));
                                }
                                if (workMatrix[i + 1, j] == -1)
                                {
                                    workMatrix[i + 1, j] = step;
                                    if (!newFront.Contains(new Point(i + 1, j)))
                                        newFront.Add(new Point(i + 1, j));
                                }
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] == -1)
                                {
                                    workMatrix[i, j - 1] = step;
                                    if (!newFront.Contains(new Point(i, j - 1)))
                                        newFront.Add(new Point(i, j - 1));
                                }
                                if (workMatrix[i, j + 1] == -1)
                                {
                                    workMatrix[i, j + 1] = step;
                                    if (!newFront.Contains(new Point(i, j - 1)))
                                        newFront.Add(new Point(i, j - 1));
                                }
                                if (workMatrix[i + 1, j] == -1)
                                {
                                    workMatrix[i + 1, j] = step;
                                    if (!newFront.Contains(new Point(i + 1, j)))
                                        newFront.Add(new Point(i + 1, j));
                                }
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] == -1)
                                {
                                    workMatrix[i, j - 1] = step;
                                    if (!newFront.Contains(new Point(i, j - 1)))
                                        newFront.Add(new Point(i, j - 1));
                                }
                                if (workMatrix[i + 1, j] == -1)
                                {
                                    workMatrix[i + 1, j] = step;
                                    if (!newFront.Contains(new Point(i + 1, j)))
                                        newFront.Add(new Point(i + 1, j));
                                }
                            }
                        }
                        if (i > 0 & i < workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i - 1, j] == -1)
                                {
                                    workMatrix[i - 1, j] = step;
                                    if (!newFront.Contains(new Point(i - 1, j)))
                                        newFront.Add(new Point(i - 1, j));
                                }
                                if (workMatrix[i, j + 1] == -1)
                                {
                                    workMatrix[i, j + 1] = step;
                                    if (!newFront.Contains(new Point(i, j + 1)))
                                        newFront.Add(new Point(i, j + 1));
                                }
                                if (workMatrix[i + 1, j] == -1)
                                {
                                    workMatrix[i + 1, j] = step;
                                    if (!newFront.Contains(new Point(i + 1, j)))
                                        newFront.Add(new Point(i + 1, j));
                                }
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {                               
                                if (workMatrix[i - 1, j] == -1)
                                {
                                    workMatrix[i - 1, j] = step;
                                    if (!newFront.Contains(new Point(i - 1, j)))
                                        newFront.Add(new Point(i - 1, j));
                                }
                                if (workMatrix[i, j - 1] == -1)
                                {
                                    workMatrix[i, j - 1] = step;
                                    if (!newFront.Contains(new Point(i, j - 1)))
                                        newFront.Add(new Point(i, j - 1));
                                }
                                if (workMatrix[i, j + 1] == -1)
                                {
                                    workMatrix[i, j + 1] = step;
                                    if (!newFront.Contains(new Point(i, j + 1)))
                                        newFront.Add(new Point(i, j + 1));
                                }
                                if (workMatrix[i + 1, j] == -1)
                                {
                                    workMatrix[i + 1, j] = step;
                                    if (!newFront.Contains(new Point(i + 1, j)))
                                        newFront.Add(new Point(i + 1, j));
                                }
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {                                
                                if (workMatrix[i - 1, j] == -1)
                                {
                                    workMatrix[i - 1, j] = step;
                                    if (!newFront.Contains(new Point(i - 1, j)))
                                        newFront.Add(new Point(i - 1, j));
                                }
                                if (workMatrix[i, j - 1] == -1)
                                {
                                    workMatrix[i, j - 1] = step;
                                    if (!newFront.Contains(new Point(i, j - 1)))
                                        newFront.Add(new Point(i, j - 1));
                                }
                                if (workMatrix[i + 1, j] == -1)
                                {
                                    workMatrix[i + 1, j] = step;
                                    if (!newFront.Contains(new Point(i + 1, j)))
                                        newFront.Add(new Point(i + 1, j));
                                }
                            }
                        }
                        if (i == workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                if (workMatrix[i, j + 1] == -1)
                                {
                                    workMatrix[i, j + 1] = step;
                                    if (!newFront.Contains(new Point(i, j + 1)))
                                        newFront.Add(new Point(i, j + 1));
                                }
                                if (workMatrix[i - 1, j] == -1)
                                {
                                    workMatrix[i - 1, j] = step;
                                    if (!newFront.Contains(new Point(i - 1, j)))
                                        newFront.Add(new Point(i - 1, j));
                                }
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] == -1)
                                {
                                    workMatrix[i, j - 1] = step;
                                    if (!newFront.Contains(new Point(i, j - 1)))
                                        newFront.Add(new Point(i, j - 1));
                                }
                                if (workMatrix[i, j + 1] == -1)
                                {
                                    workMatrix[i, j + 1] = step;
                                    if (!newFront.Contains(new Point(i, j - 1)))
                                        newFront.Add(new Point(i, j - 1));
                                }
                                if (workMatrix[i - 1, j] == -1)
                                {
                                    workMatrix[i - 1, j] = step;
                                    if (!newFront.Contains(new Point(i - 1, j)))
                                        newFront.Add(new Point(i - 1, j));
                                }
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                if (workMatrix[i, j - 1] == -1)
                                {
                                    workMatrix[i, j - 1] = step;
                                    if (!newFront.Contains(new Point(i, j - 1)))
                                        newFront.Add(new Point(i, j - 1));
                                }
                                if (workMatrix[i - 1, j] == -1)
                                {
                                    workMatrix[i - 1, j] = step;
                                    if (!newFront.Contains(new Point(i - 1, j)))
                                        newFront.Add(new Point(i - 1, j));
                                }
                            }

                        }
                        break;
                    }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (GraphMatrix != null)
            for (int i = 0; i < dataGridView1.RowCount; i++)
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1[j, i].Value = GraphMatrix[i, j];
                    switch (GraphMatrix[i,j])
                    {
                        case -5:
                            dataGridView1[j,i].Style.BackColor = Color.Red;
                            break;
                        case -7:
                            dataGridView1[j, i].Style.BackColor = Color.Green;
                            break;
                        case -9:
                            dataGridView1[j, i].Style.BackColor = Color.Black;
                            break;
                        case -1:
                            dataGridView1[j, i].Style.BackColor = Color.White;
                            break;
                    }
                }
        }

        private void MarkUnmarkedCells(int[,] workMatrix, int i, int j, List<Point> newFront, List<Point> opponentFront, int step, MarkMode markMode, ref Point MeetPoint)
        {
            switch (markMode)
            {
                case MarkMode.Mixed:
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                FindDuplicate(i, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                FindDuplicate(i, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                FindDuplicate(i, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                        }
                        if (i > 0 & i < workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                FindDuplicate(i - 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i - 1, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                FindDuplicate(i - 1, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i - 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i - 1, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                FindDuplicate(i - 1, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i - 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                        }
                        if (i == workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                FindDuplicate(i - 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i - 1, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                FindDuplicate(i - 1, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i - 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i - 1, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                FindDuplicate(i - 1, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i - 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }

                        }
                        break;
                    }
                case MarkMode.Diagonal:
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                FindDuplicate(i + 1, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                FindDuplicate(i + 1, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                FindDuplicate(i + 1, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                        }
                        if (i > 0 & i < workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                FindDuplicate(i - 1, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                FindDuplicate(i - 1, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i - 1, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                FindDuplicate(i - 1, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                        }
                        if (i == workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                FindDuplicate(i - 1, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                FindDuplicate(i - 1, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i - 1, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                FindDuplicate(i - 1, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }

                        }
                        break;
                    }
                case MarkMode.HorizontalVertical:
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                FindDuplicate(i, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                FindDuplicate(i, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                FindDuplicate(i, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                        }
                        if (i > 0 & i < workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                FindDuplicate(i, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i - 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                FindDuplicate(i - 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                FindDuplicate(i - 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i + 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                        }
                        if (i == workMatrix.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                FindDuplicate(i - 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                            if (j > 0 & j < workMatrix.GetLength(1) - 1)
                            {
                                FindDuplicate(i - 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i, j + 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }
                            if (j == workMatrix.GetLength(1) - 1)
                            {
                                FindDuplicate(i - 1, j, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                                FindDuplicate(i, j - 1, opponentFront, step, workMatrix, newFront, ref MeetPoint);
                            }

                        }
                        break;
                    }
            }

        }

        private static void TryMarkCell(int[,] workMatrix, int i, int j, List<Point> newFront, int step)
        {
            workMatrix[i, j] = step;
            if (!newFront.Contains(new Point(i, j)))
                newFront.Add(new Point(i, j));
        }

        private static bool FindDuplicate(int i, int j, List<Point> opponentFront, int step, int[,] workMatrix, List<Point> newFront, ref Point MeetPoint)
        {
            bool founded = false;
            for (int k = 0; k < opponentFront.Count; k++)
                if (opponentFront.Contains(new Point(i, j)))
                {
                    MeetPoint = new Point(i, j);
                    founded = true;
                    break;
                }
            if (workMatrix[i, j] == -1)
            {
                TryMarkCell(workMatrix, i, j, newFront, step);
            }
            return founded;
        }

        private void rtbLogClean(object sender, EventArgs e) { rtbLog.Text = ""; }

        private void cbExsamples_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnRandMaze_Click(object sender, EventArgs e)
        {
            var wallPercent = Convert.ToDouble(nudWallsPerc.Value)/100;

            var rnd = new Random();
            for (int i = 0; i < dataGridView1.RowCount; i++)
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    var vertex = dataGridView1[j, i];
                    rnd.NextDouble();

                    if (rnd.NextDouble() < wallPercent)
                    {
                        vertex.Value = -9;
                        vertex.Style.BackColor = Color.Black;
                    }
                    else
                    {
                        vertex.Value = -1;
                        vertex.Style.BackColor = Color.White;
                    }

                }
        }
    }
}
