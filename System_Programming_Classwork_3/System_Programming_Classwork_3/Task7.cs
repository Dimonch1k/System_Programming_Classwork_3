using System;
using System.Threading;
using System.Windows.Forms;

namespace System_Programming_Classwork_3
{
    public partial class Task7 : Form
    {
        public Task7()
        {
            InitializeComponent();
            Run();
        }

        public void Run()
        {
            LB.Items.Add($"1. Start of Main thread");

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

            LB.Items.Add($"2. End of Main thread");
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
            LB.Items.Add($"\t1. Array has been generated");

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
            LB.Items.Add($"\t2. Min number: {min}");
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
            LB.Items.Add($"\t3. Max number: {max}");
        }

        private void CountAverage(int[] numbers)
        {
            int sum = Sum(numbers);
            decimal average = (decimal)sum / numbers.Length;

            LB.Items.Add($"\t4. Average number: {average}");
        }

        private int Sum(params int[] numbers)
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
