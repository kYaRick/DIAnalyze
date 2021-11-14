using System;
using System.Collections.Generic;

namespace kYa_DIA_lab_1
{
    public static class DIA_lab_1
    {
        public static void Main()
        {
            const ushort NUM = 10;                                   //max number(size) of random array.

            var rArr = new double[NUM];
            {
                ushort i = 0;
#if DEBUG
                Console.WriteLine("Random generated array:");
#endif
                do
                {
                    var r = new Random();
                    rArr[i] = Math.Round(r.NextDouble(), 5)*1000;
#if DEBUG
                    Console.Write(rArr[i] + " ");
#endif
                    i++;
                } while (i < NUM);
            }
#if DEBUG
            Console.WriteLine();
#endif
            double[] res = new double[NUM];
            List<double> rList = new List<double>(rArr);

            //var result = rList.OrderByDescending(u => u);           //linq sort.
            //Array.Sort(rArr);                                       //array sort.
            //Array.Reverse(rArr);                                    //array reverse.
            //rArr.CopyTo(res, 0);

            for (ushort i = 0; i < NUM; i++)
            {
                for (ushort j = 1; j < NUM; j++)
                {
                    if (rArr[j - 1] < rArr[j])
                    {
                        double temp = rArr[j];
                        rArr[j] = rArr[j - 1];
                        rArr[j - 1] = temp;
                    }
                }
            }

            Console.WriteLine("Sorted array:");
            foreach (var item in rArr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.ReadKey();

        }
    }
}