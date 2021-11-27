using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DIAnalyze_lab_7
{
    public partial class MainForm : Form
    {
        Dictionary<string, double> LoadData(string filename)
        {
            var result = new Dictionary<string, double>();
            var lines = File.ReadAllLines(filename);
            var rows = lines.Select(x => x.Split(new[] { ' ' }));
            foreach(var row in rows)
            {
                result.Add(row[0], double.Parse(row[1]));
            }
            return result;
        }
        public MainForm()
        {
            InitializeComponent();
        }

        IEnumerable<double> NaiveMetod1(double[] input)
        {
            var data = new List<double>(input);
            while (true)
            {
                var prev = data.Last();
                var prevPrev = data[data.Count - 2];
                var next = prev + (prev - prevPrev);
                
                yield return next;

                data.Add(next);
            }
        }

        IEnumerable<double> NaiveMetod2(double[] input)
        {
            var data = new List<double>(input);
            while (true)
            {
                var prev = data.Last();
                var prevPrev = data[data.Count - 2];
                var next = prev * (prev / prevPrev);

                yield return next;

                data.Add(next);
            }
        }

        IEnumerable<double> Average(double[] input)
        {
            var data = new List<double>(input);
            while (true)
            {
                var sum = data.Sum();
                var next = sum / data.Count;

                yield return next;

                data.Add(next);
            }
        }

        IEnumerable<double> FloatedAverage(double[] input, int k)
        {
            var data = new List<double>(input);
            while (true)
            {
                double sum = 0;
                int startIndex = data.Count - 1 - k;
                int kCounter = 0;
                for(int i = startIndex; i < data.Count; i++)
                {
                    sum += data[i];
                    kCounter++;
                }

                var next = sum / (1 + k);

                yield return next;

                data.Add(next);
            }
        }

        IEnumerable<double> ExponentialAverage(double[] input, float alpha)
        {
            var data = new List<double>(input);
            while (true)
            {
                var prev = data.Last();
                var prevPrev = data[data.Count - 2];

                var next = alpha * prev + (1 - alpha) * prevPrev;

                yield return next;

                data.Add(next);
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            formsPlot.Plot.Clear();
            var data = LoadData("data.txt");

            float alpha = float.Parse(alphaTBox.Text);

            double[] trueNumbers = data.Select(x => x.Value).ToArray();
            double[] initialYears = data.Select(x => double.Parse(x.Key)).ToArray();

            int take = 3;
            double[] years = new double[initialYears.Length];
            double lastYear = initialYears.Last();
            Array.Copy(initialYears, years, initialYears.Length);

            List<double[]> prognoses = new List<double[]>();

            var numbers = trueNumbers.Take(trueNumbers.Length - take).ToArray();

            var prognosed = NaiveMetod1(numbers).Take(take).ToArray();
            prognoses.Add(prognosed);

            var prognosed2 = NaiveMetod2(numbers).Take(take).ToArray();
            prognoses.Add(prognosed2);

            prognoses.Add(Average(numbers).Take(take).ToArray());

            var prognosed3 = FloatedAverage(numbers, 4).Take(take).ToArray();
            prognoses.Add(prognosed3);

            var prognosed4 = ExponentialAverage(numbers, alpha).Take(take).ToArray();
            prognoses.Add(prognosed4);

            string[] methods = new string[] { "As yesterday 1", "As yesterday 2", "Simple average", "Floated average", "Exponential average" };

            Color[] colors = new Color[] {Color.Red, Color.Green, Color.Blue, Color.Violet, Color.Gold};
            
            var logBuilder = new StringBuilder();

            for(int i = 0; i < 5; i++)
            {
                logBuilder.AppendLine(methods[i]);
                var d = new List<double>(numbers);
                var pr = prognoses[i];
                for(var j = 0; j < pr.Length; j++)
                {
                    var p = pr[j];
                    d.Add(p);

                    var trueData = trueNumbers[numbers.Length + j];
                    var relative = (p - trueData) / trueData;
                    logBuilder.AppendLine($"{trueData}\t\t{p:0.##}\t\t{relative * 100:0.##}%");
                }

                formsPlot.Plot.AddScatter(years, d.ToArray(), colors[i]);
            }

            File.WriteAllText("log.txt", logBuilder.ToString());

            formsPlot.Plot.AddScatter(initialYears, trueNumbers, Color.Black);
            formsPlot.Refresh();
        }
    }
}
