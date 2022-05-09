using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static public double[,] centers = new double[2, 2] {{ -2, -3 }, { 0, 0 }};
        static public double[] weight = new double[3] { 1, 1, 1 };

        public Form1()
        {
            InitializeComponent();
        }
        
        public void BeatyChart()
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
            chart1.Series[4].Points.Clear();

            //chart1.ChartAreas[0].AxisY.Maximum = 5;
            ////chart1.ChartAreas[0].AxisY.Maximum = -5;
            //chart1.ChartAreas[0].AxisX.Maximum = 5;
            //chart1.ChartAreas[0].AxisX.Maximum = -3;
        }



        double sigmoid(double h, double alpha)
        {
            return 1 / (1 + Math.Exp(-alpha * h));
        }

        double hipothesis(double[]feature, double[] weight)
        {
            double S = 0;
            for (int i = 0; i < feature.Length; i++)
                S += weight[i] * feature[i];
            return S;
        }

        double cost_function(double S, double expected, double alpha)
        {
            double outt = sigmoid(S, alpha);
            double temp = (outt -expected)*alpha *outt*(1 -outt);
            return temp;
        }

        void Learning(int N, double[,] features, double [,] klasters2_01)
        {
            double alpha = 1;
            double eta = 0.7;               // Швидкість навчання.
            double J_t;
            double J = Convert.ToDouble(textBox3.Text);
            double S;                                         // Сума добутків ваг на змінні на і-му кроці.
            double outt;                                      // Вихід ф-ції активації (сигмоїди).
            double err_local = 0;
            double err_max = double.MinValue;
            int paus = Convert.ToInt32(textBox7.Text);
            int iter = 0;
            
            int max_iter = Convert.ToInt32(textBox4.Text);

            Random rand = new Random();


            weight[1] = (rand.NextDouble() * 2 - 1) * 4;
            weight[2] = (rand.NextDouble() * 2 - 1) * 4;
            weight[0] = (rand.NextDouble() * 2 - 1) * 4;

            do
            {

                chart1.Series[4].Points.AddXY(-3, -(weight[1] * (-3) + weight[0]) / weight[2]);
                chart1.Series[4].Points.AddXY(5, -(weight[1] * (5) + weight[0]) / weight[2]);


                err_max = double.MinValue;
                for (int i = 0; i < N * 2; i++)
                {
                    double[] hello = new double[3];

                    for (int j = 0; j < 3; j++)
                        hello[j] = features[i, j];

                    S = hipothesis(hello, weight);
                    outt = sigmoid(S, alpha);
                    err_local = Math.Pow(outt - klasters2_01[i, 1], 2) / 2;

                    // Обчислюємо корекцію для ваг.
                    J_t = cost_function(S, klasters2_01[i, 1], alpha);

                    if (err_max < err_local)
                        err_max = err_local;

                    for (int j = 0; j < 3; j++)
                        weight[j] = weight[j] - alpha * eta * J_t * features[i, j];

                }
                System.Threading.Thread.Sleep(paus);
                paus /= (int)2;
                chart1.Update(); // апдейтим

                chart1.Series[4].Points.Clear();
                iter++;

                if (iter == max_iter-1)
                    MessageBox.Show("Max iter!");
            } while (J < err_max && iter < max_iter);


            chart1.Series[4].Points.AddXY(-3, -(weight[1] * (-3) + weight[0]) / weight[2]);
            chart1.Series[4].Points.AddXY(5, -(weight[1] * (5) + weight[0]) / weight[2]);
        }

        private void chart1_Click(object sender, EventArgs e)
        {
                int N = Convert.ToInt32(textBox2.Text);
            double sigma = Convert.ToDouble(textBox1.Text);


            double[,] klastersii = Klasters.Initialize_Klasters(N, sigma, centers, 2);
            double[,] klasters2 = new double[N * 2, 2];
            double[,] klasters2_01 = new double[N * 2, 2];
            double[,] features = new double[N * 2, 3];
            int check = 0;

            for (int i = 0; i < N; i++)
            {
                klasters2[check , 0] = klastersii[i, 0];
                klasters2[check, 1] = klastersii[i, 1];

                klasters2_01[check, 0] = klastersii[i, 0];
                klasters2_01[check, 1] = 0;

                check += 2;
            }

            check = 1;

            for (int i = N; i < N * 2; i++)
            {
                klasters2[check, 0] = klastersii[i, 0];
                klasters2[check, 1] = klastersii[i, 1];

                klasters2_01[check, 0] = klastersii[i, 0];
                klasters2_01[check, 1] = 1;

                check += 2;
            }



            for (int i = 0; i < N * 2; i++)
            {
                features[i, 0] = 1;
                features[i, 1] = klasters2[i, 0];
                features[i, 2] = klasters2[i, 1];
            }


            BeatyChart();

            for (int i = 0; i < N; i++)
            {
                chart1.Series[0].Points.AddXY(klastersii[i, 0], klastersii[i, 1]);
                chart1.Series[1].Points.AddXY(klastersii[i + N, 0], klastersii[i + N, 1]);
            }

            if (checkBox2.Checked) Learning(N, features, klasters2_01);



            chart1.Series[4].Points.Clear();

            int A = 0;
            int B = 0;
            for (int i = 0; i < N * 2; i++)
            {
                double[] hello = new double[3];

                for (int j = 0; j < 3; j++)
                    hello[j] = features[i, j];

                if (sigmoid(hipothesis(hello, weight), 1) > 0.5)
                {
                    chart1.Series[3].Points.AddXY(features[i, 1], features[i, 2]);
                    A++;
                }
                else
                {
                    chart1.Series[2].Points.AddXY(features[i, 1], features[i, 2]);
                    B++;
                }
                
            }

            label8.Text = Convert.ToString("T(A) = ") + Convert.ToString(A / Convert.ToDouble(textBox2.Text) / 2 * 100) + "%" ;
            label9.Text = Convert.ToString("T(B) = ") + Convert.ToString(B / Convert.ToDouble(textBox2.Text) / 2 * 100) + "%";
            chart1.Series[4].Points.AddXY(-3, -(weight[1] * (-3) + weight[0]) / weight[2]);
            chart1.Series[4].Points.AddXY(5, -(weight[1] * (5) + weight[0]) / weight[2]);

            checkBox2.Checked = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox5.Text);
            double y = Convert.ToDouble(textBox6.Text);

            double[] hello = {1, x, y};

            if (sigmoid(hipothesis(hello, weight), 1) > 0.5)
                chart1.Series[1].Points.AddXY(x, y);
            else
                chart1.Series[0].Points.AddXY(x, y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1_Click(this, null);
        }
    }
}
