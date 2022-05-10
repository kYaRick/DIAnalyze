using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lab1 {
	public partial class Form1 : Form {

		private static Random r = new Random();
		private double alpha = 2;

		private double[][] x;  // Перший елемент навчаючих пар
		private double[] t;  // Другий елемент навчаючих пар

		private double[] w; // Ваги
		private double b;  // Зміщення

		int epochs;
		double learnRate;
		List<double> loss;  // Значенння сумарної похибки на кожній ітерації

		public Form1() {
			InitializeComponent();

			dataChart.ChartAreas[0].AxisY.Minimum = -2;
			dataChart.ChartAreas[0].AxisY.Maximum = 2;

			lossChart.ChartAreas[0].AxisX.Minimum = 0;
			lossChart.ChartAreas[0].AxisY.Minimum = -0.1;
		}

		private void button1_Click(object sender, EventArgs ea) {

			// Зчитую альфа.
			if (double.TryParse(tb_Alpha.Text, out double localAlpha))
			{
				alpha = localAlpha;
			}
			else
			{
				var mbRes = MessageBox.Show("Некоректне значення поля \"α\", тому \"α\" = 1 ", "\"α\"- convert error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (mbRes == DialogResult.Yes)
				{
					tb_Alpha.Text = "1";
					alpha = 1;
				}
				else
					return;
			}

            // Зчитати значення навчаючих пар, к-сть епох і швидкість навчання.
            var tempX = xList.Text.Replace("; ", ";").Split('\n');
            x = new double[tempX.Length][];

            for (int i = 0; i < tempX.Length; i++)
            {
                var tempX_elem = tempX[i].Split(';');
                x[i] = new double[] {
                    double.Parse(tempX_elem[0].Replace('.', ',')),
                    double.Parse(tempX_elem[1].Replace('.', ','))
                };
            }

            t = tList.Text.Split('\n').Select(t_elem => double.Parse(t_elem.Replace('.', ','))).ToArray();

            epochs = int.Parse(epochsTextBox.Text);
			learnRate = double.Parse(learnRateTextBox.Text.Replace('.', ','));

			// Згенерувати випадкові ваги
			w = new double[] {
				r.NextDouble() - 0.5,
				r.NextDouble() - 0.5,
			};
			b = r.NextDouble() - 0.5;

			// Очистити список loss
			loss = new List<double>();

			// Запустити навчання нейромережі
			for (int ep = 0; ep < epochs; ep++) {
				double e = 0;
				for (int i = 0; i < x.Length; i++) {
					double s = Summator(x[i], w, b);
					double outV = ActivationFunction(s, alpha);
					e += ErrorFunction(outV, t[i]);

					for (int j = 0; j < w.Length; j++) {
						double delta = Delta(outV, t[i], x[i][j]);
						w[j] = CorrectWeight(w[j], learnRate, delta);
					}
					b = b - learnRate * Delta(outV, t[i], 1);
				}
				loss.Add(e);
			}

			// Вивести отримані в результаті навчання ваги
			wList.Text = "";
			for (int i = 0; i < w.Length; i++) {
				wList.Text += $"{Math.Round(w[i], 9).ToString("0.000")}\r\n";
			}
			wList.Text += $"{Math.Round(b, 9).ToString("0.000")}\r\n";

			// Вивести графік похибки
			lossChart.Series[0].Points.Clear();
			for (int ep = 0; ep < epochs; ep++) {
				lossChart.Series[0].Points.AddXY(ep + 1, loss[ep]);
			}

			lossChart.ChartAreas[0].AxisY.Maximum = 
				lossChart.Series[0].Points[0].YValues[0] > 1 ? 1.5 : 1;

			// Вивести на графік точки, відповідні значенням логічної функції
			dataChart.Series[0].Points.Clear();
			for (int i = 0; i < x.Length; i++) {
				dataChart.Series[0].Points.AddXY(x[i][0], x[i][1]);

				if (t[i] == 0) 
					dataChart.Series[0].Points[i].Color = Color.Red;
				else 
					dataChart.Series[0].Points[i].Color = Color.Green;
			}

			// Вивести на графік лінію, яка розділяє дві множини точок
			dataChart.Series[1].Points.Clear();

			for (double x = -1; x < 2; x += 0.1) {
				double y = (-x * w[0] - b) / w[1];
				dataChart.Series[1].Points.AddXY(x, y);
			}

			// Активувати кнопку для перевірки навченої мережі
			button2.Enabled = true;
		}

		private void button2_Click(object sender, EventArgs ea) {
			// Зчитати вхідні дані
			var tempTestX = testInputTextBox.Text.Replace("; ", ";").Split(';');
			double[] testX = tempTestX.Select(elem => double.Parse(elem.Replace('.', ','))).ToArray();

			// Запустити нейронку на введених даних та вивести результат
			MessageBox.Show($"Результат навчання: " + Math.Round(Predict(testX, w, b), 6).ToString("0.######"), 
				"Перевірка", MessageBoxButtons.OK, MessageBoxIcon.Information) ;

			// Вивести задану точку на перший графік
			if (dataChart.Series[0].Points.Count > 4) {
				dataChart.Series[0].Points.RemoveAt(4);  // Прибрати стару точку
			}

			dataChart.Series[0].Points.AddXY(testX[0], testX[1]);
			dataChart.Series[0].Points.Last().Color = Color.Blue;
		}

		private static double Summator(double[] x, double[] w, double b) {
			double sum = 0;

			for (int i = 0; i < x.Length; i++)
				sum += x[i] * w[i];

			return sum + b;
		}

		// Сигмоїдальна функція активації
		private static double ActivationFunction(double s, double alpha) {
			return 1 / (1 + Math.Exp(-alpha * s));
		}
		private static double ErrorFunction(double outV, double t) {
			return Math.Pow(outV - t, 2) / 2;
		}
		private static double Delta(double outV, double t, double x) {
			return (outV - t) * outV * (1 - outV) * x;
		}

		// Перевірка навченої мережі
		private static double Predict(double[] x, double[] w, double b) {
			double s = Summator(x, w, b);
			double outV = ActivationFunction(s, 10);
			return outV;
		}

		private static double CorrectWeight(double w, double learnRate, double delta) {
			return w - learnRate * delta;
		}
    }
}
