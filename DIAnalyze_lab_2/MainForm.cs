using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            MyChart = a.GetArrPoints(0f, 10f, 0.1f, Method.MovingAvg);
            label1.Text = "l = "+a.GetL.ToString();
            foreach (var item in MyChart)
            {
                chart1.Series[2].Points.AddXY(item[0], item[1]);
            }

        }
    }
}
