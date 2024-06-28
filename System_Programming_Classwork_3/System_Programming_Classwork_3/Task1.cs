using System;
using System.Threading;

namespace System_Programming_Classwork_3
{
    public class Task1
    {
        public void Run()
        {
            Console.WriteLine("Start of Main thread");

            Thread thread = new Thread(Print50);
            thread.Start();
            thread.Join();

            Console.WriteLine("End of Main thread");
            Console.ReadKey();
        }

        private void Print50()
        {
            for (int i = 1; i <= 50; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
