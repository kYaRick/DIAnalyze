using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAnalyze_lab_2
{
    enum Method
    {
        DefFunc
    }
    class DIA_lab_2
    {
        private float[] intr = new float[2];

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
                    default:
                        break;
                }
                intr[0] += step;
            }

            return Points;
        }
    }
}
