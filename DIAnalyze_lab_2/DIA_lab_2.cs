using System;
using System.Collections.Generic;

namespace DIAnalyze_lab_2
{
    enum Method
    {
        DefFunc,
        NoiceFunc,
        MovingAvg
    }
    class DIA_lab_2
    {
        private float[] intr = new float[2];
        private Random noice = new Random();

        public ushort l
        {
            get
            {
                return _l;
            }
            set
            {
                _l = value;
            }
        }
        private ushort _l = 0;
        public ushort GetL { get { return l; } }

        public DIA_lab_2() {}

        private double Func (double x)
        {
            return Math.Cos(0.1 * x) + Math.Cos(x);
        }

        public List<double[]> GetArrPoints(float sPointX, float fPointX, float step, Method flag)
        {
            intr[0] = sPointX;
            intr[1] = fPointX;

            List<double[]> Points = new List <double[]>();
            while (intr[0] < intr[1])
            {
                switch (flag)
                {
                    case Method.DefFunc:
                        {
                            Points.Add(new double[] { 
                                    Math.Round(intr[0], 2), 
                                    Math.Round(Func(intr[0]), 2)
                            });
                        }
                        break;
                    case Method.NoiceFunc:
                        {
                            Points.Add(new double[] {
                                    Math.Round(intr[0], 2),
                                    Math.Round(Func(intr[0])+(noice.Next(-2500, 2500)*Math.Pow(10, -4)), 4)
                            });
                        }
                        break;
                    case Method.MovingAvg:
                        {
                            var rnd = new Random();   
                            l = l == 0 ? (ushort)rnd.Next(2, 20) : l;
                            return GetYMovingAvg(GetArrPoints(sPointX, fPointX, step, Method.NoiceFunc), l);
                        }
                    default:
                        break;
                }
                intr[0] += step;
            }

            return Points;
        }
        private List<double[]> GetYMovingAvg(List<double[]> Point, ushort l)
        {
            List<double[]> MovAvgPoints = new List<double[]>();
            ushort len = (ushort)Point.Count;
            ushort avg = (ushort)Math.Round((decimal)l/2, l);
            for (ushort i = 0; i < len ; i++)
            {
                if (i < l || i > len - l - 1)
                    MovAvgPoints.Add(new double[] { Point[i][0], Point[i][1] });
                else
                {
                    double temp = 0;
                    for (ushort j = (ushort)(i - avg); j<i+avg; j++)
                    {
                        temp += Point[j][1];
                    }

                    MovAvgPoints.Add(new double[] { Point[i][0], temp/l });
                }
            }
            return MovAvgPoints;
        }
    }
}
