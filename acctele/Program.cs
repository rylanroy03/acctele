using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace acctele
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SplashScreenForm splashScreen = new SplashScreenForm();
            splashScreen.FormClosed += (sender, e) =>
            {
                // Start the main form after the splash screen closes
                Form1 mainForm = new Form1();
                mainForm.FormClosed += (s, args) => Application.ExitThread(); // Exit the message loop when main form closes
                mainForm.Show();

            };
            splashScreen.Show();

            // Start the application message loop
            Application.Run();
        }
    }
}
