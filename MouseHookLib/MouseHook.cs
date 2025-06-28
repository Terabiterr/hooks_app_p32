using EasyHook;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace MouseHookLib
{
    public class MouseHook
    {
        private LocalHook _hook;

        //?
        public MouseHook(RemoteHooking.IContext context) { }

        public void Run(RemoteHooking.IContext context)
        {
            try
            {
                _hook = LocalHook.Create(
                        LocalHook.GetProcAddress("user32.dll", "SetCursorPos"),
                        new SetCursorPosDelegate(SetCursorPos_Hooked),
                        this
                    );
                //Init thread for hook
                _hook.ThreadACL.SetInclusiveACL(new int[] { 0 });

                while (true)
                {
                    Thread.Sleep(500);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Hook error: {ex.Message}");
            }
        }

        private bool SetCursorPos_Hooked(int x, int y)
        {
            Console.WriteLine($"Mouse moved to: {x}, {y}");
            return SetCursorPos(x, y);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall, SetLastError = true)]
        delegate bool SetCursorPosDelegate(int x, int y);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetCursorPos(int X, int Y);
    }
}
