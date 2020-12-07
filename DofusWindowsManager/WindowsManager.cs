using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Media;

namespace DofusWindowsManager
{
    public class WindowManager
    {
        private const int ALT = 0xA4;
        private const int EXTENDEDKEY = 0x1;
        private const int KEYUP = 0x2;
        private int currentIndex = 0;

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool SetForegroundWindow(IntPtr windowHandle);

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        public void SwitchWindow(int index)
        {  
            try
            {
                var fullProcess = Process.GetProcessesByName("dofus");
                if (index >= fullProcess.Length)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("WARNING: The window index is not openned\n");
                    SystemSounds.Beep.Play();
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
                Process process = fullProcess[index];
                if (process != null)
                {
                    keybd_event((byte)ALT, 0x45, EXTENDEDKEY | 0, 0);
                    SetForegroundWindow(process.MainWindowHandle);
                    keybd_event((byte)ALT, 0x45, EXTENDEDKEY | KEYUP, 0);
                    Console.Write($"Windows as been switched to index {index}\n");
                    currentIndex = index;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: Application is not running!\nException: {ex.Message}\n");
                Console.Read();
                return;
            }
        }

        public void NextWindow()
        {
            int toIndex = currentIndex == Process.GetProcessesByName("dofus").Length - 1 ? 0 : currentIndex + 1;
            SwitchWindow(toIndex);
        }
    }
}
