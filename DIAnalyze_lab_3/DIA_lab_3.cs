using System;
using System.Collections.Generic;
using System.Linq;

namespace DIAnalyze_lab_3
{
    public static class Function
    {
        public static Random rand = new Random();
        public static double start = -5.0;
        public static double end = 5.0;
        public static double step = 0.1;
        public static double[] a = new double[3] {-0.2, -3, -2};
        public static double FLinear(double x)
        {
            return -3*x-2;
        }
        public static double FSquare(double x)
        {
            return -0.2 * x * x - 3 * x - 2;
        }
        private unsafe static bool _Solve_square_system(double* result, double* mtx, int n)
        {
            double* mtx_u_ii, mtx_ii_j;
            double a;
            double* mtx_end = mtx + n * n, result_i, mtx_u_ii_j = null;
            double mx;
            int d = 0;
            for (double* mtx_ii = mtx, mtx_ii_end = mtx + n; mtx_ii < mtx_end; result++, mtx_ii += n + 1, mtx_ii_end += n, d++)
            {
                {
                    mx = System.Math.Abs(*(mtx_ii_j = mtx_ii));
                    for (mtx_u_ii = mtx_ii + n, result_i = result + 1; mtx_u_ii < mtx_end; mtx_u_ii += n, result_i++)
                    {
                        if (mx < System.Math.Abs(*mtx_u_ii))
                        {
                            mx = System.Math.Abs(*(mtx_ii_j = mtx_u_ii));
                            mtx_u_ii_j = result_i;
                        }
                    }
                    if (mx == 0) return false;
                    else if (mtx_ii_j != mtx_ii)
                    {
                        a = *result;
                        *result = *mtx_u_ii_j;
                        *mtx_u_ii_j = a;
                        for (mtx_u_ii = mtx_ii; mtx_u_ii < mtx_ii_end; mtx_ii_j++, mtx_u_ii++)
                        {
                            a = *mtx_u_ii; *mtx_u_ii = *mtx_ii_j; *mtx_ii_j = a;
                        }
                    }
                }
                for (mtx_u_ii = mtx_ii - n, result_i = result - 1; mtx_u_ii > mtx; mtx_u_ii -= n)
                {
                    a = *(mtx_u_ii) / *mtx_ii;
                    for (mtx_ii_j = mtx_ii + 1, mtx_u_ii_j = mtx_u_ii + 1; mtx_ii_j < mtx_ii_end; *(mtx_u_ii_j++) -= *(mtx_ii_j++) * a) ;
                    *(result_i--) -= *(result) * a;
                }
                for (mtx_u_ii = mtx_ii + n, result_i = result + 1; mtx_u_ii < mtx_end; mtx_u_ii += d)
                {
                    a = *(mtx_u_ii++) / *mtx_ii;
                    for (mtx_ii_j = mtx_ii + 1; mtx_ii_j < mtx_ii_end; *(mtx_u_ii++) -= *(mtx_ii_j++) * a) ;
                    *(result_i++) -= *(result) * a;
                }
            }
            for (; mtx_end > mtx; *(--result) /= *(--mtx_end), mtx_end -= n) ;
            return true;
        }
        private unsafe static bool _SolveSquare(double[] outResult, double[,] A, double[] x)
        {
            int n = outResult.Length;
            if (n == x.Length && n == A.GetLength(0) && n == A.GetLength(1))
            {
                if (n > 0)
                {
                    Array.Copy(x, outResult, n);
                    fixed (double* presult = &outResult[0])
                    fixed (double* pmtx = &A[0, 0])
                        return _Solve_square_system(presult, pmtx, n);
                }
                else return true;
            }
            throw new IndexOutOfRangeException();
        }
        public static void LeastSquares(IEnumerable<double> xs, IEnumerable<double> ys, out double a1, out double a2, out double a3)
        {
            a1 = double.NaN;
            a2 = double.NaN;
            a3 = double.NaN;

            int count = xs.Count();

            double sumXSPow4 = 0;
            double sumXSCubed = 0;
            double sumXSSquared = 0;
            double sumXS = 0;
            double sumYS = 0;
            double sumXSYS = 0;
            double sumXSSquaredYS = 0;

            for (int i = 0; i < count; i++)
            {
                var x = xs.ElementAt(i);
                var y = ys.ElementAt(i);

                sumXSPow4 += x * x * x * x;
                sumXSCubed += x * x * x;
                sumXSSquared += x * x;
                sumXS += x;
                sumYS += y;
                sumXSYS += x * y;
                sumXSSquaredYS += x * x * y;
            }

            var matrix = new double[3, 3];
            matrix[0, 0] = sumXSPow4;
            matrix[0, 1] = sumXSCubed;
            matrix[0, 2] = sumXSSquared;
            matrix[1, 0] = sumXSCubed;
            matrix[1, 1] = sumXSSquared;
            matrix[1, 2] = sumXS;
            matrix[2, 0] = sumXSSquared;
            matrix[2, 1] = sumXS;
            matrix[2, 2] = count;

            var bs = new double[3];
            bs[0] = sumXSSquaredYS;
            bs[1] = sumXSYS;
            bs[2] = sumYS;

            var result = new double[3];
            _SolveSquare(result, matrix, bs);

            //if (DIA_lab_3.sl < 20)
            //    a1 = result[0] + a[0];
            //else
            //    a1 = result[0];
            a1 = result[0];
            a2 = result[1];
            a3 = result[2];
        }
        public static void LeastSquaresLinear(IEnumerable<double> xs, IEnumerable<double> ys, out double a1, out double a2)
        {
            a1 = double.NaN;
            a2 = double.NaN;
            int count = xs.Count();

            if (xs.Count() != ys.Count())
                return;

            var sumXS = xs.Sum();
            var sumYS = ys.Sum();
            double sumXSYS = 0;

            for (int i = 0; i < count; i++)
            {
                var x = xs.ElementAt(i);
                var y = ys.ElementAt(i);
                sumXSYS += x * y;
            }

            var sumXSSquared = xs.Select(x => x * x)
                .Sum();
            double denom = count * sumXSSquared - sumXS * sumXS;
            if (denom == 0)
                throw new InvalidOperationException();
            a1 = (count * sumXSYS - sumXS * sumYS) / denom;
            a2 = (sumYS * sumXSSquared - sumXSYS * sumXS) / denom;
        }
    }
    public static class DIA_lab_3
    {
        public enum XYtype
        {
            defFLinear,
            defFSquare,
            noiseL,
            noiseS,
            linear,
            squareslinear
        }

        public static double[] al = new double[2];
        public static double[] asql = new double[3];
        public static double sl = 1;

        private static Random _rnd = new Random();
        private static int[] rndWall = new int[2] { -2, 3 };

        private static Dictionary<decimal, decimal> def_result = new Dictionary<decimal, decimal>();
        private static Dictionary<decimal, decimal> noise_result = new Dictionary<decimal, decimal>();
        private static Dictionary<decimal, decimal> liner_result = new Dictionary<decimal, decimal>();
        private static Dictionary<decimal, decimal> squareslinear = new Dictionary<decimal, decimal>();

        public static Dictionary<decimal, decimal> GetGraphXY(XYtype calculateType = XYtype.defFLinear, double l = 1)
        {
            sl = l;
            switch (calculateType)
            {
                case XYtype.defFLinear:
                    {
                        def_result.Clear();

                        for (double i = Function.start; i <= Function.end; i += Function.step)
                        {
                            def_result.Add((decimal)i, (decimal)Function.FLinear(i));
                        }

                        return def_result;
                    }
                case XYtype.defFSquare:
                    {
                        def_result.Clear();

                        for (double i = Function.start; i <= Function.end; i += Function.step)
                        {
                            def_result.Add((decimal)i, (decimal)Function.FSquare(i));
                        }

                        return def_result;
                    }
                case XYtype.noiseL:
                    {
                        noise_result.Clear();

                        for (double i = Function.start; i <= Function.end; i += Function.step)
                        {
                            noise_result.Add((decimal)i, (decimal)(Function.FLinear(i) + (_rnd.Next(rndWall[0], rndWall[1]) * l)));
                        }

                        return noise_result;
                    }
                case XYtype.noiseS:
                    {
                        noise_result.Clear();

                        for (double i = Function.start; i <= Function.end; i += Function.step)
                        {
                            noise_result.Add((decimal)i, (decimal)(Function.FSquare(i) + (_rnd.Next(rndWall[0], rndWall[1]) * l)));
                        }

                        return noise_result;
                    }
                case XYtype.linear:
                    {
                        liner_result.Clear();

                        IEnumerable<double> x; 
                        IEnumerable<double> y;

                        if (noise_result.Count > 0)
                        {
                            x = noise_result.Select(val => (double)val.Key);
                            y = noise_result.Select(val => (double)val.Value);
                        } 
                        else 
                        {
                            throw new Exception("[DIA_lab_3][GetGraphXY] linear error");
                        }

                        Function.LeastSquaresLinear(x, y, out al[0], out al[1]);
                        double Func(double i)
                        {
                            return al[0] * i + al[1];
                        }

                        for (double i = Function.start; i <= Function.end; i += Function.step)
                        {
                            liner_result.Add((decimal)i, (decimal)Func(i));
                        }

                        return liner_result;
                    }
                case XYtype.squareslinear:
                    {
                        squareslinear.Clear();

                        IEnumerable<double> x;
                        IEnumerable<double> y;

                        if (noise_result.Count > 0)
                        {
                            x = noise_result.Select(val => (double)val.Key);
                            y = noise_result.Select(val => (double)val.Value);
                        }
                        else
                        {
                            throw new Exception("[DIA_lab_3][GetGraphXY] squaresliner error");
                        }

                        Function.LeastSquares(x, y, out asql[0], out asql[1], out asql[2]);
                        double Func(double i)
                        {
                            return asql[0] * i * i + asql[1]*i + asql[2];
                        }

                        for (double i = Function.start; i <= Function.end; i += Function.step)
                        {
                            squareslinear.Add((decimal)i, (decimal)Func(i));
                        }

                        return squareslinear;
                    }
                default:
                    break;
            }
            return new Dictionary<decimal, decimal> { { 0m, 0m } };
        }
    }
}