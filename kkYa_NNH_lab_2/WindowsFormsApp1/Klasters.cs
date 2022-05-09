using System;
using System.Linq;

namespace WindowsFormsApp1
{
    class Klasters
    {
        static public double[,] Initialize_Klasters(int N, double sigmax, double[,] mx, int k)
        {
            double[,] klaster1 = new double[N * k, 2];

            double[] random_values_X = new double[N * k];
            double[] random_values_Y = new double[N * k];
            int i = 0;

            for (int j = 0; j < k; j++)
            {
                random_values_X = Ksi_N_Random(N * k, sigmax, mx[j, 0]);
                random_values_Y = Ksi_N_Random(N * k, sigmax, mx[j, 1]);

                for (i = j * N; i < (j + 1) * N; i++)
                {
                    double X = random_values_X[i];
                    double Y = random_values_Y[i];
                    klaster1[i, 0] = X;
                    klaster1[i, 1] = Y;
                }
            }

            return klaster1;
        }

        static public double[] Ksi_N_Random(int N, double sigmax, double mx)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            double[] random_values = new double[N];

            for (int i = 0; i < N; i++)
            {
                double miu = 0;
                for (int j = 0; j < 5; j++)
                    miu += rand.NextDouble();

                double ksi_zirka = Math.Sqrt(12.0 / 5.0) * (miu - 5.0 / 2.0);
                double ksi = mx + sigmax * (0.01 * ksi_zirka * (97 + Math.Pow((ksi_zirka), 2)));
                random_values[i] = ksi;
            }

            return random_values;
        }

        static public double[,] Shuffle(double[,] klasters, Random r)
        {
            int N = klasters.Length / 2;
            int[] perm = Enumerable.Range(0, N).ToArray(); // 0 1 2 ... (n - 1)
            

            for (int i = N - 1; i >= 1; i--)
            {
                int j = r.Next(i + 1);
                int temp = perm[j];
                perm[j] = perm[i];
                perm[i] = temp;
            }

            double[,] hallo = new double[N, 2];
            for (int i = 0; i < N; i++)
            {
                hallo[i, 0] = klasters[perm[i], 0];
                hallo[i, 1] = klasters[perm[i], 1];
            }
            return hallo;
        }
    }
}
