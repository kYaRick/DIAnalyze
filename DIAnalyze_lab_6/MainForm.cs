using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DIAnalyze_lab_6
{
    struct Point {

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X;
        public double Y;

        public static Point operator+(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point operator/(Point p1,double n)
        {
            return new Point(p1.X / n, p1.Y / n);
        }
        public static double Distance(Point p1, Point p2)
        {
            var d1 = p1.X - p2.X;
            var d2 = p1.Y - p2.Y;
            return Math.Sqrt(d1 * d1 + d2 * d2);
        }

        public bool Equals(Point p2, double tolerance)
        {
            return Math.Abs(X - p2.X) < tolerance && Math.Abs(Y - p2.Y) < tolerance;
        }
    }

    enum Mode
    {
        Random,
        FromFirstCluster,
        PredefinedPoints
    }

    public partial class formsPlot : Form
    {
        double _sigma = 0.1;

        Mode _mode = Mode.PredefinedPoints;

        static Random _r = new Random();
        double Normal(double m, double sigma)
        {
            double sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += _r.NextDouble();
            }

            return m + sigma * (sum - 6);
        }

        Point GenerateRandom(Point center)
        {
            var x = Normal(center.X, _sigma);
            var y = Normal(center.Y, _sigma);
            return new Point(x, y);
        }

        List<Point> _centres;
        Color[] _colors;


        public formsPlot()
        {
            InitializeComponent();


            _centres = new List<Point>() {
            new Point(-1, 2),
            new Point(2, 1),
            new Point(3, 5),
        };

        _colors = new Color[] {Color.Orange, Color.Blue, Color.Violet};
        }

        IEnumerable<Point[]> KMeans(Point[] points, int countOfCluters)
        {
            if (points.Length < countOfCluters)
                throw new InvalidOperationException();

            if (points.Length == countOfCluters)
            {
                return points.Select(x => new Point[] { x });
            }

            var prevCentres = new Point[countOfCluters];
            switch (_mode) {
                case Mode.FromFirstCluster:
                    for (int i = 0; i < countOfCluters; i++)
                    {
                        prevCentres[i] = points[i];
                    }
                    break;
                case Mode.PredefinedPoints:
                    prevCentres = _centres.ToArray();
                    break;
                case Mode.Random:
                    List<int> taken = new List<int>();
                    for (int i = 0; i< countOfCluters; i++)
                    {
                        var r = _r.Next(points.Length);
                        while (taken.Contains(r))
                            r = _r.Next(points.Length);
                        taken.Add(r);
                        prevCentres[i] = points[r];
                    }
                    break;
            }
            while (true)
            {
                var clusters = new Dictionary<int, List<Point>>();
                for (int i = 0; i < countOfCluters; i++)
                {
                    clusters[i] = new List<Point>();
                }

                foreach (var point in points)
                {
                    double minDistance = double.MaxValue;
                    int clusterNumber = -1;
                    for (int i = 0; i < countOfCluters; i++)
                    {
                        var clusterCenter = prevCentres[i];
                        var distance = Point.Distance(clusterCenter, point);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            clusterNumber = i;
                        }
                    }
                    clusters[clusterNumber].Add(point);
                }

                var centres = new Point[countOfCluters];
                foreach(var cluster in clusters)
                {
                    var no = cluster.Key;
                    var clPoints = cluster.Value;

                    Point mean = new Point(0, 0);
                    for(int i = 0; i < clPoints.Count; i++)
                    {
                        mean += clPoints[i];
                    }
                    centres[no] = mean / clPoints.Count;
                }

                bool haventEqual = false;
                for(int i = 0; i < countOfCluters; i++)
                {
                    bool haveEqual = false;
                    for(int j = 0; j < countOfCluters; j++)
                    {
                        if(centres[i].Equals(prevCentres[j]))
                        {
                            haveEqual = true;
                            break;
                        }
                    }
                    if (!haveEqual)
                    {
                        haventEqual = true;
                        break;
                    }
                }
                if(!haventEqual)
                {
                    return clusters.Select(cluster => cluster.Value.ToArray());
                }
                else
                {
                    prevCentres = centres;
                }
            }

        }

        private void _updateBtn_Click(object sender, EventArgs e)
        {
            formsPlot1.Plot.Clear();
            _sigma = double.Parse(_sigmaTB.Text);
            var points = new List<Point>(_centres.Count * 40);
            foreach (var center in _centres)
            {
                for (int i = 0; i < 40; i++)
                    points.Add(GenerateRandom(center));
            }

            var clusters = KMeans(points.ToArray(), _centres.Count).ToArray();

            for (int i = 0; i < _centres.Count; i++)
            {
                var cluster = clusters.ElementAt(i);
                //If cluster is empty.
                if (cluster.Length == 0)
                    continue;

                formsPlot1.Plot.AddScatterPoints(cluster.Select(x => x.X).ToArray(), cluster.Select(x => x.Y).ToArray(), _colors[i]);
            }

            ShowCenters();

            formsPlot1.Refresh();
        }

        private void ShowCenters()
        {
            formsPlot1.Plot.AddScatterPoints(_centres.Select(x => x.X).ToArray(),_centres.Select(y => y.Y).ToArray(), Color.Red, markerSize: 8, markerShape: ScottPlot.MarkerShape.eks);
        }

        private void _centresMode_CheckedChanged(object sender, EventArgs e)
        {
            _mode = Mode.PredefinedPoints;
        }
        private void _randomMode_CheckedChanged(object sender, EventArgs e)
        {
            _mode = Mode.Random;
        }
        private void _fromFirst_CheckedChanged(object sender, EventArgs e)
        {
            _mode = Mode.FromFirstCluster;
        }
    }
}
