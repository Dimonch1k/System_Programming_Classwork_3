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

            // Write DATA into file "task.txt"
            Thread writeDataThread = new Thread((() => WriteDataIntoFile(numbers)));
            writeDataThread.Start();
            writeDataThread.Join();



            Console.ReadKey();
        }

        // Write all data to file "task5.txt"
        private void WriteDataIntoFile(int[] numbers)
        {
            FileStream fs = null;

            if (!File.Exists("task5.txt")) // Checking if Task5.txt exists or not
            {
            }
            fs = File.Create("task5.txt"); // Creates Task5.txt
            fs.Close(); //Closes file stream

            File.WriteAllLines("task5.txt", numbers.Select(num => num.ToString()));
            File.AppendAllText("task5.txt", $"Minimal number: {FindMin(numbers)}" + Environment.NewLine
                + $"Maximal number: {FindMax(numbers)}" + Environment.NewLine
                + $"Average number: {CountAverage(numbers)}" + Environment.NewLine);

            Console.WriteLine("The data were successfully written to the file 'task5.txt'");



            //string jsonString = JsonSerializer.Serialize(person);

            //// Write the JSON string to a file
            //File.WriteAllText("person.json", jsonString);

            //Console.WriteLine("JSON file created and data written successfully.");
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

        // Find minimal number
        private int FindMin(int[] numbers)
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
            return min;
        }

        // Find maximal number
        private int FindMax(int[] numbers)
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
            return max;
        }


        // Count Average of numbers
        private decimal CountAverage(int[] numbers)
        {
            int sum = Sum(numbers);
            decimal average = (decimal)sum / numbers.Length;
            Console.WriteLine($"Average number: {average}");
            return average;
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