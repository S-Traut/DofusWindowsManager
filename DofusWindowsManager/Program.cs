using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DofusWindowsManager
{
    class Program
    {
        private static WindowManager windowsManager;
        private static bool space = false;
        private static bool alt = false;

        [STAThread]
        static void Main()
        {
            Console.Title = "Dofus Windows Manager | By PoNo";
            Console.Write("Dofus Windows Manager - Created by PoNo\nFor more informations check the git page [...]\n");
            windowsManager = new WindowManager();
            InputReader reader = new InputReader();
            reader.OnKeyPressed += OnKeyPressed;
            reader.OnKeyUnpressed += OnKeyRelease;
            reader.HookKeyboard();
            Application.Run();
            reader.UnHookKeyboard();
        }

        private static void OnKeyRelease(object sender, Keys e)
        {
            if(e == Keys.Space) space = false;
            if(e == Keys.LMenu) alt = false;
        }

        private static void OnKeyPressed(object sender, Keys e)
        {
            if(e == Keys.Space) space = true;
            if(e == Keys.LMenu) alt = true;
            if(e == Keys.Tab && !alt) windowsManager.NextWindow();
            if(space)
            {
                switch(e)
                {
                    case Keys.D1: windowsManager.SwitchWindow(0); break;
                    case Keys.D2: windowsManager.SwitchWindow(1); break;
                    case Keys.D3: windowsManager.SwitchWindow(2); break;
                    case Keys.D4: windowsManager.SwitchWindow(3); break;
                    case Keys.D5: windowsManager.SwitchWindow(4); break;
                    case Keys.D6: windowsManager.SwitchWindow(5); break;
                    case Keys.D7: windowsManager.SwitchWindow(6); break;
                    case Keys.D8: windowsManager.SwitchWindow(7); break;
                }
            }
        }
    }
}