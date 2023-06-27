using System.Diagnostics;


namespace jivarosft

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
            string folderpathFunctionx = @"C:\\Users\\" + Environment.UserName.ToString() + "\\Jivaro\\";
            string folderpathOsrsBotting = @"C:\\Users\\" + Environment.UserName.ToString() + "\\Jivaro\\OSRSBotting\\";
            string folderpathJivaroScriptFactory = @"C:\\Users\\" + Environment.UserName.ToString() + "\\Jivaro\\OSRSBotting\\ScriptFactory\\";
            string folderpathOSBotTool = @"C:\\Users\\" + Environment.UserName.ToString() + "\\Jivaro\\OSRSBotting\\OSBotTool\\";
            string folderpathUserinput = @"C:\\Users\\" + Environment.UserName.ToString() + "\\Jivaro\\OSRSBotting\\OSBotTool\\userinput\\";
            string filepathDashboard = @"C:\\Users\\" + Environment.UserName.ToString() + "\\Jivaro\\OSRSBotting\\OSBotTool\\userinput\\dashboard";

            //
            // End of initialize global variables
            //



            //
            // Start of create folders
            //

            // Create functionx folder
            if (!Directory.Exists(folderpathFunctionx))
            {
                Directory.CreateDirectory(folderpathFunctionx);
            }

            // Create osrsbotting folder
            if (!Directory.Exists(folderpathOsrsBotting))
            {
                Directory.CreateDirectory(folderpathOsrsBotting);
            }

            // Create scriptfactory folder
            if (!Directory.Exists(folderpathJivaroScriptFactory))
            {
                Directory.CreateDirectory(folderpathJivaroScriptFactory);
            }

            // Create osbottool folder
            if (!Directory.Exists(folderpathOSBotTool))
            {
                Directory.CreateDirectory(folderpathOSBotTool);
            }

            // Create userinput folder
            if (!Directory.Exists(folderpathUserinput))
            {
                Directory.CreateDirectory(folderpathUserinput);
            }

            //
            // End of create folders
            //



            //
            // Start of create files
            //

            // Create dashboard file
            if (!File.Exists(filepathDashboard))
            {
                using (FileStream fs = File.Create(filepathDashboard))
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
            cmdDownloadOSBot.StartInfo.Arguments = "/C curl.exe --output C:\\Users\\%USERNAME%\\Jivaro\\OSRSBotting\\OSBot.jar --url https://osbot.org/mvc/get";
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
