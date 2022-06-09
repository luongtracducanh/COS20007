using System;

namespace CounterTask
{
    public class MainClass
    {
        private static void Print_Counters(Counter[] counters)
        {
            foreach (Counter c in counters){
                Console.WriteLine("{0} is {1}", c.Name, c.Ticks);
            }
        }

        public static void Main(string[] args)
        {
            Counter[] myCounter = new Counter[3];
            int i;

            myCounter[0] = new Counter("Counter 1");
            myCounter[1] = new Counter("Counter 2");
            myCounter[2] = myCounter[0];

            for (i = 0; i <= 4; i++)
            {
                myCounter[0].Increment();
            }

            for (i = 0; i <= 9; i++)
            {
                myCounter[1].Increment();
            }

            Print_Counters(myCounter);
            Console.ReadLine();

            myCounter[2].Reset();

            Print_Counters(myCounter);
            Console.ReadLine();
        }
    }
}
