using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DIAnalyze_lab_8
{
    public partial class MainForm : Form
    {
        Dictionary<string, double> LoadData(string filename)
        {
            var result = new Dictionary<string, double>();
            var lines = File.ReadAllLines(filename);
            var rows = lines.Select(x => x.Split(new[] { ' ' }));
            foreach (var row in rows)
            {
                result.Add(row[0], double.Parse(row[1]));
            }
            return result;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        IEnumerable<double> Holt(double[] data, double alpha, double beta)
        {
            var trends = new List<double>() { 0 };

            var smothed = new List<double>
            {
                data[0]
            };

            for (int i = 1; i < data.Length; i++)
            {
                var lastSmoothed = smothed.Last();
                var lastTrend = trends.Last();
                var current = alpha * data[i] + (1 - alpha) * (lastSmoothed - lastTrend);
                var currentTrend = beta * (current - lastSmoothed) + (1 - beta) * lastTrend;

                smothed.Add(current);
                trends.Add(currentTrend);
            }

            var lastSm = smothed.Last();
            var lastTr = trends.Last();

            int j = 1;
            while(true)
            {
                yield return lastSm + j * lastTr;
                j++;
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            double alpha = double.Parse(alphaTB.Text);
            double beta = double.Parse(betaTB.Text);

            formsPlot.Plot.Clear();

            var data = LoadData("data.txt");

            var years = data.Select(x=>double.Parse(x.Key)).ToArray();

            var trueNumbers = data.Select(x => x.Value).ToArray();

            int take = 3;
            var numbers = trueNumbers.Take(trueNumbers.Length - take).ToArray();

            var prognosed = Holt(numbers, alpha, beta).Take(take).ToArray();

            var withPrognosed = new List<double>(numbers);

            var logBuilder = new StringBuilder();

            logBuilder.AppendLine("Holt");
            for(int j = 0; j < prognosed.Length; j++)
            {
                var pr = prognosed[j];

                var trueValue = trueNumbers[numbers.Length + j];
                var absolute = pr - trueValue;
                var relative = absolute / trueValue;
                logBuilder.AppendLine($"{trueValue}\t{pr:0.##}\t{absolute:0.##}\t{relative:0.##}%");

                withPrognosed.Add(pr);
            }
            File.WriteAllText("log.txt", logBuilder.ToString());    
           
            formsPlot.Plot.AddScatter(years, withPrognosed.ToArray(), Color.Red);
            formsPlot.Plot.AddScatter(years, trueNumbers, Color.Black);
            formsPlot.Refresh();
        }
    }
}
