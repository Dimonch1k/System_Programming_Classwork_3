using System;
using System.Windows.Forms;

namespace System_Programming_Classwork_3
{
    internal class Program
    {
        // FOR TASK 1-5

        //static void Main(string[] args)
        //{
        //    //Task1 task1 = new Task1();
        //    //task1.Run();

        //    //Task2 task2 = new Task2();
        //    //task2.Run();

        //    //Task3 task3 = new Task3();
        //    //task3.Run();

        //    //Task4 task4 = new Task4();
        //    //task4.Run();

        //    //Task5 task5 = new Task5();
        //    //task5.Run();
        //}

        
        // FOR TASK 6-7

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Task7());
        }
    }
}
