using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAnalyze_lab_3
{
    public class Matrix
    {
        double[,] Args { get; set; }
        int Row { get; set; }
        int Col { get; set; }

        public Matrix(double[] x)
        {
            this.Row = x.Length;
            this.Col = 1;
            this.Args = new double[this.Row, this.Col];
            for (int i = 0; i < this.Args.GetLength(0); i++)
                for (int j = 0; j < this.Args.GetLength(1); j++)
                    this.Args[i, j] = x[i];
        }

        public Matrix(double[,] x)
        {
            this.Row = x.GetLength(0);
            this.Col = x.GetLength(1);
            this.Args = new double[this.Row, this.Col];
            for (int i = 0; i < this.Args.GetLength(0); i++)
                for (int j = 0; j < this.Args.GetLength(1); j++)
                    this.Args[i, j] = x[i, j];
        }

        Matrix(Matrix other)
        {
            this.Row = other.Row;
            this.Col = other.Col;
            this.Args = new double[this.Row, this.Col];
            for (int i = 0; i < this.Row; i++)
                for (int j = 0; j < this.Col; j++)
                    this.Args[i, j] = other.Args[i, j];
        }

        public override string ToString()
        {
            string s = string.Empty;
            for (int i = 0; i < this.Args.GetLength(0); i++)
            {
                for (int j = 0; j < this.Args.GetLength(1); j++) s += $"{this.Args[i, j]} ";
                s += "\n";
            }
            return s;
        }

        public Matrix Transposition()
        {
            double[,] t = new double[this.Col, this.Row];
            for (int i = 0; i < this.Row; i++)
                for (int j = 0; j < this.Col; j++)
                    t[j, i] = this.Args[i, j];
            return new Matrix(t);
        }

        public static Matrix operator *(Matrix m, double k)
        {
            Matrix ans = new Matrix(m);
            for (int i = 0; i < ans.Row; i++)
                for (int j = 0; j < ans.Col; j++)
                    ans.Args[i, j] = m.Args[i, j] * k;
            return ans;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.Col != m2.Row) throw new ArgumentException("Multiplication of these two matrices can't be done!");
            double[,] ans = new double[m1.Row, m2.Col];
            for (int i = 0; i < m1.Row; i++)
                for (int j = 0; j < m2.Col; j++)
                    for (int k = 0; k < m2.Row; k++) ans[i, j] += m1.Args[i, k] * m2.Args[k, j];
            return new Matrix(ans);
        }

        Matrix GetMinor(int row, int column)
        {
            if (this.Row != this.Col) throw new ArgumentException("Matrix should be square!");
            double[,] minor = new double[this.Row - 1, this.Col - 1];
            for (int i = 0; i < this.Row; i++)
                for (int j = 0; j < this.Col; j++)
                    if (i != row || j != column)
                    {
                        if (i > row && j < column) minor[i - 1, j] = this.Args[i, j];
                        if (i < row && j > column) minor[i, j - 1] = this.Args[i, j];
                        if (i > row && j > column) minor[i - 1, j - 1] = this.Args[i, j];
                        if (i < row && j < column) minor[i, j] = this.Args[i, j];
                    }

            return new Matrix(minor);
        }

        static double Determ(Matrix m)
        {
            if (m.Row != m.Col) throw new ArgumentException("Matrix should be square!");
            double det = 0;
            int length = m.Row;

            switch (length)
            {
                case 1:
                    det = m.Args[0, 0];
                    break;
                case 2:
                    det = m.Args[0, 0] * m.Args[1, 1] - m.Args[0, 1] * m.Args[1, 0];
                    break;
            }

            if (length <= 2) return det;
            for (int i = 0; i < m.Col; i++)
                det += Math.Pow(-1, 0 + i) * m.Args[0, i] * Matrix.Determ(m.GetMinor(0, i));

            return det;
        }

        Matrix MinorMatrix()
        {
            double[,] ans = new double[this.Row, this.Col];

            for (int i = 0; i < this.Row; i++)
                for (int j = 0; j < this.Col; j++)
                    ans[i, j] = Math.Pow(-1, i + j) * Matrix.Determ(this.GetMinor(i, j));

            return new Matrix(ans);
        }

        public Matrix InverseMatrix()
        {
            if (Math.Abs(Matrix.Determ(this)) <= 0.000000001) throw new ArgumentException("Inverse matrix does not exist!");

            double k = 1 / Matrix.Determ(this);

            Matrix minorMatrix = this.MinorMatrix();

            return minorMatrix * k;
        }
    }
}
