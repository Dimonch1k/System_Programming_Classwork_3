using System.Threading;
using System;
using System.Data.SqlTypes;
using System.Windows.Forms;

namespace System_Programming_Classwork_3
{
    public partial class Task6 : Form
    {
        public Task6()
        {
            InitializeComponent();
            Run();
        }

        public void Run()
        {
            LB.Items.Add($"1. Start of Main thread");

            Thread thread = new Thread(Print50);
            thread.Start();
            thread.Join();

            LB.Items.Add($"2. End of Main thread");
        }

        private void Print50()
        {
            for (int i = 1; i <= 50; i++)
            {
                LB.Items.Add($"\t{i} -- {i}");
            }
        }
    }
}
