using System;

namespace testspace
{
    public delegate void test();
    class Program
    {
        static void Main(string[] args)
        {
            TestM();
            Console.ReadKey();
        }

        public static void TestM()
        {
            TestDelegade t = new TestDelegade();
            Action a = new Action (t.CheckDelegate1);

            byte i = 0;
            do
            {
                a += t.CheckDelegate1;
                i++;
            } while (i < 2);

            a += t.CheckDelegate2;
            a -= t.CheckDelegate1;
            a();

            Predicate<Action> pr = t.CheckDelegate3;
            a = null;
            Console.WriteLine("T/F: " + pr?.Invoke(a));

            var fn = new Func<int, int>(t.CheckDelegate4);
            Console.WriteLine($"3*5 = {fn(3)}");
        } 
    }

    class TestDelegade
    {

        public void CheckDelegate1()
        {
            Console.WriteLine("Knock, knock ... Neo.");
        }

        public void CheckDelegate2()
        {
            Console.WriteLine("End");
        }

        public bool CheckDelegate3(Action a)
        {
            return a==null;
        }

        public int CheckDelegate4(int a)
        {
            return 5*a;
        }
    }
}
