using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Wave_Algorithm
{
    public partial class Form1 : Form
    {
        private enum MarkMode
        {
            HorizontalVertical,
            Diagonal,
            Mixed
        }
        private int[,] GraphMatrix;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void ClearLabirint()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1[j,i].Value = -1;
                    dataGridView1[j,i].Style.BackColor = Color.White;
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
            GraphMatrix = new int[dataGridView1.RowCount, dataGridView1.ColumnCount];
            for (int i = 0; i < dataGridView1.RowCount; i++)
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    GraphMatrix[i, j] = Convert.ToInt32(dataGridView1[j,i].Value);
            MarkMode mode = MarkMode.Mixed;
            if (radioButton1.Checked)
                mode = MarkMode.HorizontalVertical;
            else if (radioButton2.Checked)
                mode = MarkMode.Diagonal;
            else if (radioButton3.Checked)
                mode = MarkMode.Mixed;
            WaveAlgorithm(GraphMatrix, mode, Convert.ToInt32(numericUpDown3.Value));
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
                dataGridView1.Refresh();
                //System.Threading.Thread.Sleep(miliseconds);
            }
            while (!NewFront.Contains(FinishPoint) && (NewFront.Count > 0));
            sw.Stop();
            if (NewFront.Count == 0)
            {
                MessageBox.Show("Шляху від стартової точки до фінішної немає!");
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
            MessageBox.Show("Шлях знайдено: " + pathInfo + ".\nДовжина шляху - " + (Path.Count-1) +". Час - "+sw.Elapsed.ToString());
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
    }
}
