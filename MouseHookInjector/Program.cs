using EasyHook;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace MouseHookInjector
{
    public class Program
    {
        static void Main(string[] args)
        {
            int targetPID = 0;
            Console.WriteLine($"Enter PID:");
            targetPID = Int32.Parse(Console.ReadLine());

            string injectionLibrary_32 = @"C:\Users\brole\OneDrive\Рабочий стол\hooks_app\MouseHookInjector\bin\Debug\x86\MouseHookInjector.exe";
            string injectionLibrary_64 = @"C:\Users\brole\OneDrive\Рабочий стол\hooks_app\MouseHookInjector\bin\Debug\x64\MouseHookInjector.exe";

            try
            {   
                RemoteHooking.Inject(
                    targetPID,
                    injectionLibrary_32,
                    injectionLibrary_64
                    );

                Console.WriteLine("Injection successfully ...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Injection faild: {ex.Message}");
            }


            Console.ReadKey();
        }
    }
}
