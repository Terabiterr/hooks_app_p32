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
            while(true)
            {
                SetCursorPos(new Random().Next(1, 2000), new Random().Next(1, 2000));
                Thread.Sleep(1000);
            } 
        }
    }
}
