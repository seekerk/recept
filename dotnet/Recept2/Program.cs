using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Recept2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string []args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if (DEBUG)
            if (args.Length > 0)
                Application.Run(new FormMain(args[0]));
            else
                Application.Run(new FormMain());
#else
            try
            {
                if (args.Length > 0)
                    Application.Run(new FormMain(args[0]));
                else
                    Application.Run(new FormMain());
            }
            catch (System.Exception e)
            {
                MessageBox.Show("В программе обнаружена ошибка и она будет закрыта. Сейчас будет создан отчет.\n Отправьте его разработчику для скорейшего исправления.");
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = "txt";
                dlg.Filter = "Отчеты об ошибках (*.txt)|*.txt";
                dlg.FileName = "recept2-error.txt";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sf = new StreamWriter(dlg.FileName, true);
                    sf.WriteLine("Version: " + Application.ProductVersion);
                    sf.WriteLine("Module: " + e.Source);
                    sf.WriteLine("=====================Program error==================");
                    sf.WriteLine(e.Message);
                    sf.WriteLine("==================Program StackTrace================");
                    sf.WriteLine(e.StackTrace);
                    sf.Close();
                }

            }
#endif
        }
    }
}