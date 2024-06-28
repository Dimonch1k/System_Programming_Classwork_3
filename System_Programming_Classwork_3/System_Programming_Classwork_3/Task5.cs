using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace System_Programming_Classwork_3
{
    public class Task5
    {
        public void Run()
        {
            Console.WriteLine("\n\nStart of Main thread");

            int[] numbers = GenerateArray();
            Thread findMinThread = new Thread((() => FindMin(numbers)));
            Thread findMaxThread = new Thread((() => FindMax(numbers)));
            Thread countAverageThread = new Thread((() => CountAverage(numbers)));

            findMinThread.Start();
            findMaxThread.Start();
            countAverageThread.Start();

            findMinThread.Join();
            findMaxThread.Join();
            countAverageThread.Join();

            Console.WriteLine("End of Main thread");
            Console.ReadKey();


            if (File.Exists("Task5.txt")) return; //Checking if scores.txt exists or not

            FileStream fs = File.Create("scores.txt"); //Creates Scores.txt
            fs.Close(); //Closes file stream

            System.IO.File.WriteAllLines("scores.txt", numbers.Select(num => num.ToString()));
        }


        private int[] GenerateArray()
        {
            //Random rnd = new Random(); // For random numbers
            int[] array = new int[10000];

            for (int i = 0; i < array.Length; i++)
            {
                // array[i] = rnd.Next(); // For random numbers
                array[i] = i;
            }

            return array;
        }

        private void FindMin(int[] numbers)
        {
            int min = numbers[0];
            foreach (int number in numbers)
            {
                if (number < min)
                {
                    min = number;
                }

            }
            Console.WriteLine($"Min number: {min}");
        }

        private void FindMax(int[] numbers)
        {
            int max = Int32.MinValue;
            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }

            }
            Console.WriteLine($"Max number: {max}");
        }

        private void CountAverage(int[] numbers)
        {
            int sum = Sum(numbers);
            decimal average = (decimal)sum / numbers.Length;
            Console.WriteLine($"Average number: {average}");
        }


        public int Sum(params int[] numbers)
        {
            int result = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                result += numbers[i];
            }

            return result;
        }
    }
}