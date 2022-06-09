using System;
using System.Threading;

namespace CounterTask
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            Clock clock = new Clock();
            int i;

            for (i = 0; i < 86400; i++)
            {
                Thread.Sleep(100);
                Console.Clear();
                clock.Tick();
                Console.WriteLine(clock.Time());
            }
        }
    }
}
