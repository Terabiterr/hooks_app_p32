using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace hooks_app
{
    public class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetCursorPos(int X, int Y);
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                SetCursorPos(100 + i * 10, 100 + i * 10);
                Thread.Sleep(1000);
            }
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
