using System.Diagnostics;


namespace jivaro_osrs_launcher

{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        // Static variables
        static Form formProgressBar;
        static Form formMainForm;
        static System.Windows.Forms.Timer timerStartup;

        [STAThread]
        static void Main()
        {
            //
            // Start of initialize global variables
            //

            // Paths
            string pc_username = Environment.UserName;
            string folderpathJivaro = @"C:\\Users\\" + Environment.UserName.ToString() + "\\Jivaro\\";
            string folderpathJivaroLauncher = @"C:\\Users\\" + Environment.UserName.ToString() + "\\Jivaro\\Jivaro Launcher\\";
            string filepathAccountsScriptFactory = @"C:\\Users\\" + Environment.UserName.ToString() + "\\Jivaro\\Jivaro Launcher\\Accounts_ScriptFactory";
            string filepathAccountsOSBot = @"C:\\Users\\" + Environment.UserName.ToString() + "\\Jivaro\\Jivaro Launcher\\Accounts_OSBot";
            string filepathAccountsTRiBot = @"C:\\Users\\" + Environment.UserName.ToString() + "\\Jivaro\\Jivaro Launcher\\Accounts_TRiBot";
            string filepathAccountsDreamBot = @"C:\\Users\\" + Environment.UserName.ToString() + "\\Jivaro\\Jivaro Launcher\\Accounts_DreamBot";

            //
            // End of initialize global variables
            //



            //
            // Start of create folders
            //

            // Create functionx folder
            if (!Directory.Exists(folderpathJivaro))
            {
                Directory.CreateDirectory(folderpathJivaro);
            }

            // Create osrsbotting folder
            if (!Directory.Exists(folderpathJivaroLauncher))
            {
                Directory.CreateDirectory(folderpathJivaroLauncher);
            }


            //
            // End of create folders
            //



            //
            // Start of create files
            //

            // Create Script Factory Account file
            if (!File.Exists(filepathAccountsScriptFactory))
            {
                using (FileStream fs = File.Create(filepathAccountsScriptFactory))
                {
                    fs.Close();
                }
            }

            // Create OSBot Account file
            if (!File.Exists(filepathAccountsOSBot))
            {
                using (FileStream fs = File.Create(filepathAccountsOSBot))
                {
                    fs.Close();
                }
            }

            // Create TRiBot Account file
            if (!File.Exists(filepathAccountsTRiBot))
            {
                using (FileStream fs = File.Create(filepathAccountsTRiBot))
                {
                    fs.Close();
                }
            }

            // Create DreamBot Account file
            if (!File.Exists(filepathAccountsDreamBot))
            {
                using (FileStream fs = File.Create(filepathAccountsDreamBot))
                {
                    fs.Close();
                }
            }


            //
            // End of create files
            //



            //
            // Start of download files
            //

            // Download OSBot
            Process cmdDownloadOSBot = new Process();
            cmdDownloadOSBot.StartInfo.FileName = "cmd.exe";
            cmdDownloadOSBot.StartInfo.Arguments = "/C curl.exe --output \"C:\\Users\\%USERNAME%\\Jivaro\\Jivaro Launcher\\OSBot.jar\" --url https://osbot.org/mvc/get";
            cmdDownloadOSBot.StartInfo.CreateNoWindow = true;
            cmdDownloadOSBot.Start();

            //
            // End of download files
            //



            //
            // Start of startup forms
            //

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            formProgressBar = new formProgressBar();
            formMainForm = new formMainForm();

            timerStartup = new System.Windows.Forms.Timer();
            timerStartup.Interval = 10000; // 10 seconds
            timerStartup.Tick += Timer_Tick;
            timerStartup.Start();

            Application.Run(formProgressBar);

            //
            // End of startup forms
            //
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            timerStartup.Stop();
            formProgressBar.Hide();
            formMainForm.Show();
        }
    }
}
