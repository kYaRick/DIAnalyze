using System;
using System.Windows.Forms;

namespace DIAnalyze_lab_2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DrawGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawGraphics();
        }

        private void DrawGraphics()
        {
            var a = new DIA_lab_2();

            var MyChart = a.GetArrPoints(0f, 10f, 0.1f, Method.DefFunc);

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();

            foreach (var item in MyChart)
            {
                chart1.Series[0].Points.AddXY(item[0], item[1]);
            }

            MyChart = a.GetArrPoints(0f, 10f, 0.1f, Method.NoiceFunc);
            foreach (var item in MyChart)
            {
                chart1.Series[1].Points.AddXY(item[0], item[1]);
            }

            if (!checkBox1.Checked)
            {
                try
                {
                    ushort _temp_l = Convert.ToUInt16(tbRandomL.Text);
                    a.l = tbRandomL.Text == "" ? (ushort)0 : _temp_l > 20 || _temp_l < 0 ? (ushort)2 : _temp_l;
                } catch
                {
                    a.l = 2;
                }
                
            }

            MyChart = a.GetArrPoints(0f, 10f, 0.1f, Method.MovingAvg);
            tbRandomL.Text = a.GetL.ToString();
            
            foreach (var item in MyChart)
            {
                chart1.Series[2].Points.AddXY(item[0], item[1]);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                tbRandomL.Text = "";
                tbRandomL.ReadOnly = true;
            } else
            {
                tbRandomL.Text = "";
                tbRandomL.ReadOnly = false;
            }
        }
    }
}
