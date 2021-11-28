using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Calc = DIAnalyze_lab_3.DIA_lab_3;

namespace DIAnalyze_lab_3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ProgramName.Text = "kYa_DIA_lab_3_"+Text;
            comboboxMethods.SelectedIndex = 0;
            BuildGraph(this);
        }

        private static void BuildGraph(MainForm form)
        {
            List<Dictionary<decimal, decimal>> graphs = new List<Dictionary<decimal, decimal>>();

            form.mainChart.ChartAreas[0].AxisX.Interval = Function.step*10;
            double l = 0;
            string str = form.lTextBox.Text;
            {
                double.TryParse(str, out l);

                if (l == 0)
                {
                    l = 1;
                    form.lTextBox.Text = l.ToString("0.##");
                }
            }

            if (form.radioFLinear.Checked)
            {
                graphs.Add(Calc.GetGraphXY(Calc.XYtype.defFLinear, l));
                graphs.Add(Calc.GetGraphXY(Calc.XYtype.noiseL, l));
                graphs.Add(Calc.GetGraphXY(Calc.XYtype.linear, l));
                graphs.Add(Calc.GetGraphXY(Calc.XYtype.squareslinear, l));
            }
            else if (form.radioFSquare.Checked)
            {
                graphs.Add(Calc.GetGraphXY(Calc.XYtype.defFSquare, l));
                graphs.Add(Calc.GetGraphXY(Calc.XYtype.noiseS, l));
                graphs.Add(Calc.GetGraphXY(Calc.XYtype.linear, l));
                graphs.Add(Calc.GetGraphXY(Calc.XYtype.squareslinear, l));
            }

                for (byte i = 0; i < 4; i++)
                {
                    form.mainChart.Series[i].Points.Clear();

                if (form.comboboxMethods.Text.Equals("linear empirical") && i == 3)
                {
                    continue;
                }
                else if (form.comboboxMethods.Text.Equals("quadratic empirical") && i == 2)
                {
                    continue;
                }

                var keys = graphs[i].Keys;
                    foreach (var x in keys)
                    {
                        form.mainChart.Series[i].Points.AddXY(x, graphs[i][x]);
                    }
                }
            form.comboboxMethods_SelectedIndexChanged(form.comboboxMethods, EventArgs.Empty);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            BuildGraph(this);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboboxMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxMethods.Text.Equals("linear empirical"))
            {
                resultBox.Size = new Size(resultBox.Size.Width, 130);
                btShowInfo.Location = new Point(25, 103);
                updateButton.Location = new Point(926, 400);
                a2Lable.Visible = false;
                resTBa2.Visible = false;
                radioFLinear.Checked = true;


                resTBa0.Text = Calc.al[0].ToString("0.##");
                resTBa1.Text = Calc.al[1].ToString("0.##");
            }
            else if (comboboxMethods.Text.Equals("quadratic empirical"))
            {
                resultBox.Size = new Size(resultBox.Size.Width, 160);
                btShowInfo.Location = new Point(25, 130);
                updateButton.Location = new Point(926, 430);
                a2Lable.Visible = true;
                resTBa2.Visible = true;
                radioFSquare.Checked = true;

                resTBa0.Text = Calc.asql[0].ToString("0.##");
                resTBa1.Text = Calc.asql[1].ToString("0.##");
                resTBa2.Text = Calc.asql[2].ToString("0.##");
            }
        }

        private void btShowInfo_Click(object sender, EventArgs e)
        {

            if (comboboxMethods.Text.Equals("linear empirical"))
                MessageBox.Show(
                    $"a0[base]:{Math.Round(Function.a[1], 2)} - a0[experimental]:{Math.Round(Calc.al[0], 2)} - a0[error %]:{Math.Round(Math.Abs((Calc.al[0] / Function.a[1] - 1)) * 100, 2)} %" + "\n" +
                    $"a1[base]:{Math.Round(Function.a[2], 2)} - a1[experimental]:{Math.Round(Calc.al[1], 2)} - a1[error %]:{Math.Round(Math.Abs((Calc.al[1] / Function.a[2] - 1)) * 100, 2)} %"
                    , "Info list", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            else if (comboboxMethods.Text.Equals("quadratic empirical"))
                MessageBox.Show(
                   $"a0[base]:{Math.Round(Function.a[0], 2)} - a0[experimental]:{Math.Round(Calc.asql[0], 2)} - a0[error %]:{Math.Round(Math.Abs((Calc.asql[0] / Function.a[0] - 1)) * 100, 2)} %" + "\n" +
                   $"a1[base]:{Math.Round(Function.a[1], 2)} - a1[experimental]:{Math.Round(Calc.asql[1], 2)} - a1[error %]:{Math.Round(Math.Abs((Calc.asql[1] / Function.a[1] - 1)) * 100, 2)} %" + "\n" +
                   $"a2[base]:{Math.Round(Function.a[2], 2)} - a2[experimental]:{Math.Round(Calc.asql[2], 2)} - a2[error %]:{Math.Round(Math.Abs((Calc.asql[2] / Function.a[2] - 1)) * 100, 2)} %"
                   , "Info list", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
    }
}
