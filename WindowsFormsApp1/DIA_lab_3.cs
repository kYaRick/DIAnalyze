using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAnalyze_lab_3
{
    public static class DIA_lab_3
    {
        public static void DIAnalyze_lab_3()
        {
            double z = 0;
            int r = 1;
            int n = 1;
            int l = 2;
            int N = 100;
            double noise = 0;
            bool s;
            double[,] E_kof = new double[6, 6];
            double[,] rez_matx = new double[6, 6];
            double[,] inver_matx = new double[6, 6];
            double[,] rez3_matx = new double[6, 6];
            double[] A_vect = new double[6]; 
            double[] A = new double[1];
            double[] B = new double[5];
            double[] Z = new double[100];
            double[] X = new double[5];
            double[,] X_matx = new double[100, 6];
            double[,] XT_matx = new double[6, 100];
            double[] rez_vect = new double[6];

            A[0] = 0.75;
            B[0] = 0.3;
            B[1] = -0.65;
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
                Z[i] = 0;
            X[0] = rnd.Next(-1, 1) + rnd.NextDouble();
            X[1] = rnd.Next(-1, 1) + rnd.NextDouble();
            X[2] = rnd.Next(-1, 1) + rnd.NextDouble();
            X[3] = rnd.Next(-1, 1) + rnd.NextDouble();
            X[4] = rnd.Next(-1, 1) + rnd.NextDouble();

            for (int k = 0; k < 100; k++)
            {
                
                for (int i = 0; i < 11; i++)
                {
                    noise = rnd.Next(-1, 1) + rnd.NextDouble();
                    noise += noise;
                }

                if (k % 3 == 0)
                    X[0] = rnd.Next(-1, 1) + rnd.NextDouble();
                if (k % 5 == 0)
                    X[1] = rnd.Next(-1, 1) + rnd.NextDouble();
                if (k % 7 == 0)
                    X[2] = rnd.Next(-1, 1) + rnd.NextDouble();
                if (k % 11 == 0)
                    X[3] = rnd.Next(-1, 1) + rnd.NextDouble();
                if (k % 13 == 0)
                    X[4] = rnd.Next(-1, 1) + rnd.NextDouble();

                
                if (k != 0)
                {
                    Z[k] = A[0] * Z[k - 1] + noise;
                    for (int i = 0; i < n; i++)
                        Z[k] += B[i] * X[i];
                }


                
                for (int i = 0; i < 6; i++)
                {
                    if (i == 0)
                        X_matx[k, i] = Z[k];
                    if (i > 0)
                        X_matx[k, i] = X[i - 1];
                }
            }

            
            Matrix X_matxM = new Matrix(X_matx);
            Matrix XT_matxM = X_matxM.Transposition();
            
            Matrix rez_matxM = XT_matxM * X_matxM;
            
            Matrix obr_rezmatxM = rez_matxM.InverseMatrix();
            Matrix prov = obr_rezmatxM * rez_matxM;
            
            Matrix ZM = new Matrix(Z);
            Matrix rez_vectM = XT_matxM * ZM;
            
            Matrix A_vectM = rez_matxM * rez_vectM;
        }
    }
}
