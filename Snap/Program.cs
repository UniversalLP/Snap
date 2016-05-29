using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snap
{
    static class Program
    {
        public static options formOptions = new options();
        public static select formSelect = new select();
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Uploader.initClient();
            Application.EnableVisualStyles();

            formOptions.initScreens();
            formOptions.loadSettings();
            if (Properties.Settings.Default.firststart)
            {
                Properties.Settings.Default.firststart = false;
                Application.Run(formOptions);
            }
            else
            {
                formOptions.hideToTray();
                Application.Run();
            }
        }
    }
}
