using System;
using System.Threading;

namespace System_Programming_Classwork_3
{
    public class Task2
    {

        public void Run()
        {
            Console.Write("Enter start of range numbers: ");
            int start = int.Parse(Console.ReadLine());

            Console.Write("Enter end of range numbers: ");
            int end = int.Parse(Console.ReadLine());



            Console.WriteLine("\n\nStart of Main thread");

            Thread thread = new Thread((() => Print(start, end)));
            thread.Start();
            thread.Join();


            Console.WriteLine("End of Main thread");
            Console.ReadKey();
        }

        private void Print(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
