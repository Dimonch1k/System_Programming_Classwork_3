using System;
using System.Threading;

namespace System_Programming_Classwork_3
{
    public class Task3
    {
        public void Run()
        {
            Console.Write("Enter start of range numbers: ");
            int start = int.Parse(Console.ReadLine());

            Console.Write("Enter end of range numbers: ");
            int end = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of threads: ");
            int userThreads = Int32.Parse(Console.ReadLine());



            Console.WriteLine("\n\nStart of Main thread");

            Thread[] threads = new Thread[userThreads];

            for (int i = 0; i < threads.Length; i++)
            {
                var i1 = i;
                threads[i] = new Thread(() => Print(i1 + 1, start, end));
                threads[i].Start();
            }

            foreach (var t in threads)
            {
                t.Join();
            }

            Console.WriteLine("End of Main thread");
            Console.ReadKey();
        }

        private void Print(int threadNum, int start, int end)
        {
            lock (this)
            {
                for (int i = start; i < end; i++)
                {
                    Console.WriteLine($"T{threadNum} {i}");
                }
            }
        }
    }
}
