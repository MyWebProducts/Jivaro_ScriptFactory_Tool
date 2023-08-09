using System.ComponentModel;
using System.Diagnostics;
using System.Text;


namespace jivaro_osrs_launcher
{

    public partial class formMainForm : Form
    {
        // Initialize main form
        public formMainForm()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Enable WS_EX_COMPOSITED
                return cp;
            }
        }


        //
        // Start of initialize class variables
        //

        string pc_username = Environment.UserName;
        string filepathAccountsScriptFactory = @"C:\\Users\\" + Environment.UserName.ToString() + "\\Jivaro\\Jivaro Launcher\\Accounts_ScriptFactory";
        string filepathAccountsOSBot = @"C:\\Users\\" + Environment.UserName.ToString() + "\\Jivaro\\Jivaro Launcher\\Accounts_OSBot";
        string filepathAccountsTRiBot = @"C:\\Users\\" + Environment.UserName.ToString() + "\\Jivaro\\Jivaro Launcher\\Accounts_TRiBot";
        string filepathAccountsDreamBot = @"C:\\Users\\" + Environment.UserName.ToString() + "\\Jivaro\\Jivaro Launcher\\Accounts_DreamBot";
        string filepathSbieIni = @"C:\Program Files\Sandboxie-Plus\SbieIni.exe";
        string folderpathOSBot = @"C:\\Users\\" + Environment.UserName.ToString() + "\\OSBot";
        string folderpathOSBotProfiles = @"C:\\Users\\" + Environment.UserName.ToString() + "\\OSBot\\Data\\ProjectPact\\OSRS Script Factory\\Profiles";
        string folderpathJivaro = @"C:\\Users\\" + Environment.UserName.ToString() + "\\Jivaro\\";
        string folderpathJivaroTemp = @"C:\\Users\\" + Environment.UserName.ToString() + "\\Jivaro\\Temp\\";
        string folderpathJagexCache = @"C:\\Users\\" + Environment.UserName.ToString() + "\\jagexcache";
        string folderpathJivaroLauncher = @"C:\\Users\\" + Environment.UserName.ToString() + "\\Jivaro\\Jivaro Launcher\\";
        BackgroundWorker workerFileHandler = new BackgroundWorker();

        //
        // End of initialize class variables
        //



        //
        // Start of callable methods and variables
        //

        // Repopulate Script Factory dataGridView
        private void LoadDataGridViewFromFile(DataGridView dataGridView)
        {
            // Read all lines from the file
            string[] lines = System.IO.File.ReadAllLines(filepathAccountsScriptFactory);

            // Clear existing rows in the DataGridView
            dataGridView.Rows.Clear();

            // Iterate through each line
            foreach (string line in lines)
            {
                // Split the line by comma to get cell values
                string[] cellValues = line.Split(',');

                // Create a new row in the DataGridView
                int rowIndex = dataGridView.Rows.Add();

                // Iterate through each cell value and assign it to the corresponding cell in the row
                for (int columnIndex = 0; columnIndex < cellValues.Length; columnIndex++)
                {
                    // Check if the column index is valid
                    if (columnIndex < dataGridView.Columns.Count)
                    {
                        string cellValue = cellValues[columnIndex];

                        // Check if the cell is a combobox cell
                        if (dataGridView.Columns[columnIndex] is DataGridViewComboBoxColumn)
                        {
                            DataGridViewComboBoxCell comboBoxCell = dataGridView.Rows[rowIndex].Cells[columnIndex] as DataGridViewComboBoxCell;

                            // Populate the combobox with text files
                            if (columnIndex == 5) // Change this to the correct index if needed
                            {
                                PopulateComboBoxWithTextFiles(comboBoxCell);
                            }

                            // Find the index of the cell value in the combobox items
                            int itemIndex = comboBoxCell.Items.IndexOf(cellValue);

                            // Set the selected index of the combobox cell
                            comboBoxCell.Value = itemIndex >= 0 ? comboBoxCell.Items[itemIndex] : null;
                        }
                        else
                        {
                            // Set the cell value for other types of cells (e.g., textbox cells)
                            dataGridView.Rows[rowIndex].Cells[columnIndex].Value = cellValue;
                        }
                    }
                }
            }
        }

        private void PopulateComboBoxWithTextFiles(DataGridViewComboBoxCell comboBoxCell)
        {
            string path = folderpathOSBotProfiles;

            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path, "*.txt");
                comboBoxCell.Items.Clear();

                foreach (string file in files)
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
                    comboBoxCell.Items.Add(fileNameWithoutExtension);
                }

                if (comboBoxCell.Items.Count > 0)
                {
                    comboBoxCell.Value = comboBoxCell.Items[0];
                }
            }
            else
            {
                MessageBox.Show("Directory not found!");
            }
        }


        // Create Sandboxes 
        private bool CheckSandboxExists(string sandboxie, string sbieIniPath)
        {
            Process process = new Process();
            process.StartInfo.FileName = filepathSbieIni;
            process.StartInfo.Arguments = $"queryex /boxes *";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output.Contains(sandboxie);
        }
        private void CreateSandbox(string sandboxie, string filepathSbieIni)
        {
            Process process = new Process();
            process.StartInfo.FileName = filepathSbieIni;
            process.StartInfo.Arguments = $"set {sandboxie} Enabled y";
            process.Start();
            process.WaitForExit();
        }

        // Copy to sandboxie
        private void DirectoryCopy(string sourceDir, string destDir)
        {
            DirectoryInfo sourceDirectory = new DirectoryInfo(sourceDir);
            DirectoryInfo destinationDirectory = new DirectoryInfo(destDir);

            if (!destinationDirectory.Exists)
            {
                destinationDirectory.Create();
            }

            foreach (FileInfo file in sourceDirectory.GetFiles())
            {
                string destinationFilePath = Path.Combine(destDir, file.Name);
                file.CopyTo(destinationFilePath, true);
            }

            foreach (DirectoryInfo subdirectory in sourceDirectory.GetDirectories())
            {
                string destinationSubdirectoryPath = Path.Combine(destDir, subdirectory.Name);
                DirectoryCopy(subdirectory.FullName, destinationSubdirectoryPath);
            }
        }

        //
        // End of callable methods
        //



        //
        // Start of background workers & loop
        //

        // Form load & workers

        private void formMainForm_Load(object sender, EventArgs e)
        {

            // Close all panels and open dashboard
            foreach (Control control in this.Controls)
            {
                if (control is Panel)
                {
                    control.Visible = false;
                    panelDashboard.Visible = true;
                }
            }

            // Repopulate dashboard's dataGridView
            LoadDataGridViewFromFile(dataGridViewDashboard_Bots);

            // Disable sorting on dashboard's dataGriView
            dataGridViewDashboard_Bots.Columns.Cast<DataGridViewColumn>().ToList().ForEach(column =>
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            });

            //
            // Start of start workers.
            //

            // Start FileHandler worker
            workerFileHandler = new BackgroundWorker();
            workerFileHandler.DoWork += Worker_FileHandler;
            workerFileHandler.WorkerSupportsCancellation = true;
            workerFileHandler.RunWorkerAsync();

            //
            // End of start workers.
            //

        }

        // Form close
        private void formMainForm_FormClose(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Worker for creating the files inside the Jivaro folder
        private void Worker_FileHandler(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                // Create jivaro folder
                if (!Directory.Exists(folderpathJivaro))
                {
                    Directory.CreateDirectory(folderpathJivaro);
                }

                // Create jivaro launcher folder
                if (!Directory.Exists(folderpathJivaroLauncher))
                {
                    Directory.CreateDirectory(folderpathJivaroLauncher);
                }

                // Create temp folder
                if (!Directory.Exists(folderpathJivaroTemp))
                {
                    Directory.CreateDirectory(folderpathJivaroTemp);
                }

                // Create account script factory file
                if (!System.IO.File.Exists(filepathAccountsScriptFactory))
                {
                    using (FileStream fs = System.IO.File.Create(filepathAccountsScriptFactory))
                    {
                        fs.Close();
                    }
                }

                // Create account osbot file
                if (!System.IO.File.Exists(filepathAccountsOSBot))
                {
                    using (FileStream fs = System.IO.File.Create(filepathAccountsOSBot))
                    {
                        fs.Close();
                    }
                }

                // Create account tribot file
                if (!System.IO.File.Exists(filepathAccountsTRiBot))
                {
                    using (FileStream fs = System.IO.File.Create(filepathAccountsTRiBot))
                    {
                        fs.Close();
                    }
                }

                // Create account dreambot file
                if (!System.IO.File.Exists(filepathAccountsDreamBot))
                {
                    using (FileStream fs = System.IO.File.Create(filepathAccountsDreamBot))
                    {
                        fs.Close();
                    }
                }

                // Wait 15 seconds before updating again
                System.Threading.Thread.Sleep(15000);
            }
        }

        // Cancel Non-Numbers from textbox input
        public void textBoxGlobal_CancelNonNumberInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Cancel non number input and set the limit to 99 on textchange
        public void textBoxGlobal_CancelNonNumber_SetLimitTo99_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            var textBox = sender as System.Windows.Forms.TextBox;
            if (textBox != null && textBox.Text.Length >= 99)
            {
                e.Handled = true;
            }
        }

        // Require Input on textboxes
        public void textBoxGlobal_InputRequired_Validating(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            // Ensure the textbox always has an input
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show("This field is required");
                e.Cancel = true;
            }
        }

        //
        // End of background workers & loop
        //



        //
        // Start of Navigation Buttons
        // 

        // Navigate to Dashboard
        private void buttonNavigation_ScriptFactory_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Panel)
                {
                    control.Visible = false;
                    panelDashboard.Visible = true;
                }
            }
        }

        // Navigate to Break Profiles
        private void buttonNavigation_BreakProfiles_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Panel)
                {
                    control.Visible = false;
                    panelBreakProfiles.Visible = true;
                }
            }

            // Default selection on the combobox 
            comboBoxBreakProfiles_SelectBreakFilename.SelectedIndex = 0;
        }

        // Navigate to Script Profiles
        private void buttonNavigation_ScriptProfiles_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Panel)
                {
                    control.Visible = false;
                    panelScriptProfiles.Visible = true;
                }
            }
        }

        // Navigate to OSBot Manager
        private void buttonNavigation_OSBotManager_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Panel)
                {
                    control.Visible = false;
                    panelOSBotManager.Visible = true;
                }
            }
        }

        // Navigate to TRiBot Manager
        private void buttonNavigation_TRiBotManager_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Panel)
                {
                    control.Visible = false;
                    panelTRiBotManager.Visible = true;
                }
            }
        }

        // Navigate to DreamBot Manager
        private void buttonNavigation_DreamBotManager_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Panel)
                {
                    control.Visible = false;
                    panelDreamBotManager.Visible = true;
                }
            }
        }

        // Navigate to settings
        private void buttonNavigation_Settings_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Panel)
                {
                    control.Visible = false;
                    panelAccountsAndSettings.Visible = true;
                }
            }
        }

        //
        // End of navigation buttons
        //



        //
        // Start of Dashboard Panel
        //

        // Dashboard Panel - Launch OSBot Button Interaction
        private void buttonDashboard_LaunchOsbot_Click(object sender, EventArgs e)
        {
            // Launch OSBot
            Process.Start("cmd.exe", "/c start javaw -jar C:\\Users\\" + pc_username + "\\Jivaro\\Jivaro Launcher\\OSBot.jar");
        }

        // Dashboard Panel - Cancel Data Grid View Sorting
        private void dataGridView_NoSort_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Disable automatic sorting
            DataGridViewColumn clickedColumn = dataGridViewDashboard_Bots.Columns[e.ColumnIndex];
            clickedColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            clickedColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
        }

        // Dashboard Panel - CLI Launch
        public void dataGridView_RunBot_CellButtonClick(object sender, DataGridViewCellEventArgs e)
        {
            // Initialize variables
            string sandboxie;
            string cliArgs;
            string cliCommand;

            // Create CLI Args
            if (e.ColumnIndex == dataGridViewDashboard_Bots.Columns["dataGridViewDashboard_Run"].Index && e.RowIndex >= 0)
            {
                // Declare variables
                DataGridViewRow clickedRow = dataGridViewDashboard_Bots.Rows[e.RowIndex];

                // Bot variable
                string account = clickedRow.Cells["dataGridViewDashboard_Account"].Value?.ToString();
                string password = clickedRow.Cells["dataGridViewDashboard_Password"].Value?.ToString();
                string pin = clickedRow.Cells["dataGridViewDashboard_Pin"].Value?.ToString();
                string bot = "-bot " + account + ":" + password + ":" + pin + " ";

                // Proxy variable
                string proxy = clickedRow.Cells["dataGridViewDashboard_Proxy"].Value?.ToString();

                if (proxy != null)
                {
                    proxy = "-proxy " + proxy + " ";
                }

                // Script variable
                string script = clickedRow.Cells["dataGridViewDashboard_Script"].Value?.ToString();

                if (script == "SF")
                {
                    script = "-script 1097:";
                }

                if (script == "SF Exp")
                {
                    script = "-script 1144:";
                }

                if (script == "SF Pro")
                {
                    script = "-script 1163:";
                }

                // Task variable
                string task = clickedRow.Cells["dataGridViewDashboard_Task"].Value?.ToString();

                // Script and task variable
                string scriptandtask = script + task + " ";

                // World variable
                string world = clickedRow.Cells["dataGridViewDashboard_World"].Value?.ToString();

                if (world != "-F2P-" && world != "-P2P-")
                {
                    world = "-world " + clickedRow.Cells["dataGridViewDashboard_World"].Value?.ToString() + " ";
                }

                if (world == "-F2P-")
                {
                    int[] numberList = { 301, 308, 316, 326, 335, 371, 380, 382, 383, 384, 394, 397, 398, 399, 417, 418, 430, 431, 433, 434, 435, 436, 437, 451, 452, 453, 454, 455, 456, 469, 470, 471, 475, 476, 483, 497, 498, 499, 500, 501, 537, 542, 543, 544, 545, 546, 547, 552, 553, 554, 555, 556, 557, 562, 563, 571, 575 };
                    Random rnd = new Random();
                    int randomIndex = rnd.Next(0, numberList.Length);
                    world = "-world " + numberList[randomIndex].ToString() + " ";
                }

                if (world == "-P2P-")
                {
                    int[] numberList = { 302, 303, 304, 305, 306, 307, 309, 310, 311, 312, 313, 314, 315, 317, 318, 319, 320, 321, 322, 323, 324, 325, 327, 328, 329, 330, 331, 332, 333, 334, 336, 337, 338, 339, 340, 341, 343, 344, 346, 347, 348, 350, 351, 352, 354, 355, 357, 358, 359, 360, 362, 367, 368, 369, 370, 374, 375, 376, 377, 378, 386, 387, 388, 389, 390, 395, 421, 422, 424, 443, 444, 445, 446, 463, 464, 465, 466, 477, 478, 480, 481, 482, 484, 485, 486, 487, 488, 489, 490, 491, 492, 493, 494, 495, 496, 505, 506, 507, 508, 509, 510, 511, 512, 513, 514, 515, 516, 517, 518, 519, 520, 521, 522, 523, 524, 525, 531, 532, 533, 534, 535, 580 };
                    Random rnd = new Random();
                    int randomIndex = rnd.Next(0, numberList.Length);
                    world = "-world " + numberList[randomIndex].ToString() + " ";
                }

                // Mode variable
                string mode = clickedRow.Cells["dataGridViewDashboard_Mode"].Value?.ToString();

                if (mode == "Stealth")
                {
                    mode = "";
                }

                if (mode == "Mirror")
                {
                    mode = "-mirror ";
                }

                // New mouse variable
                string newmouse = clickedRow.Cells["dataGridViewDashboard_NewMouse"].Value?.ToString();

                if (newmouse == "Yes")
                {
                    newmouse = "-newmouse ";
                }

                if (newmouse == "No")
                {
                    newmouse = "";
                }

                // Delete files starting with "mirror_"
                string[] filesMirrorJunk = Directory.GetFiles(folderpathOSBot + "\\Data", "mirror_*");
                foreach (string file in filesMirrorJunk)
                {
                    try
                    {
                        System.IO.File.Delete(file);
                        Console.WriteLine($"Deleted mirror junk files from osbot folder.");
                        Thread.Sleep(100); // Wait for 1 second
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }
                }

                // Delete jagex_cl_oldschool_LIVE.dat
                string filepathOldSchoolLiveDat = "C:\\Users\\" + pc_username + "\\jagex_cl_oldschool_LIVE.dat";
                if (System.IO.File.Exists(filepathOldSchoolLiveDat))
                {
                    try
                    {
                        System.IO.File.Delete(filepathOldSchoolLiveDat);
                        Console.WriteLine($"Deleted jagex_cl_oldschool_LIVE.dat");
                        Thread.Sleep(100); // Wait for 1 second
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }
                }

                // Delete jagexappletviewer.preferences
                string filepathJagexAppletViewer = "C:\\Users\\" + pc_username + "\\jagexappletviewer.preferences";
                if (System.IO.File.Exists(filepathJagexAppletViewer))
                {
                    try
                    {
                        System.IO.File.Delete(filepathJagexAppletViewer);
                        Console.WriteLine($"Deleted jagexappletviewer.preferences");
                        Thread.Sleep(100); // Wait for 1 second
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }
                }

                // Delete random.dat
                string filepathRandomDat = "C:\\Users\\" + pc_username + "\\random.dat";
                if (System.IO.File.Exists(filepathRandomDat))
                {
                    try
                    {
                        System.IO.File.Delete(filepathRandomDat);
                        Console.WriteLine($"Deleted random.dat");
                        Thread.Sleep(100); // Wait for 1 second
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }
                }

                // Get use sandboxie
                sandboxie = clickedRow.Cells["dataGridViewDashboard_Sandboxie"].Value?.ToString();

                // No Sandboxie Launch
                if (sandboxie == "No")
                {
                    // Initialize variables
                    cliArgs = "java -jar \"C:\\Users\\" + pc_username + "\\Jivaro\\Jivaro Launcher\\OSBot.jar\" -autologin -launchgame -mfps 25 -mreactiontime 50 " + bot + proxy + scriptandtask + world + mode + newmouse;

                    // Launch cmd with args
                    Process.Start("cmd.exe", "/c " + cliArgs);
                    Console.WriteLine("No Sandboxie CLI Args: " + cliArgs);
                }

                // Sandboxie Launch
                if (sandboxie == "Yes")
                {

                    // Initialize variables
                    string sandboxieNumber = clickedRow.Cells["dataGridViewDashboard_SandboxieNumber"].Value?.ToString();
                    string folderpathSandboxieCurrent = "C:\\Sandbox\\" + pc_username + "\\" + sandboxieNumber + "\\user\\current\\";
                    bool sandboxExists = CheckSandboxExists(sandboxieNumber, filepathSbieIni);
                    cliArgs = "/elevate /box:" + sandboxieNumber + " java -jar \"C:\\Users\\" + pc_username + "\\Jivaro\\Jivaro Launcher\\OSBot.jar\" -autologin -launchgame -mfps 25 -mreactiontime 50 " + bot + proxy + scriptandtask + world + mode + newmouse;
                    cliCommand = "C:\\Program Files\\Sandboxie-Plus\\Start.exe";

                    // Create sandbox if it doesn't exist.
                    if (sandboxExists)
                    {

                    }
                    else
                    {
                        // Create the sandbox using SbieIni.exe command
                        CreateSandbox(sandboxieNumber, filepathSbieIni);
                        Thread.Sleep(100); // Wait for 1 second
                    }

                    // Delete sandbox jagex_cl_oldschool_LIVE.dat
                    string filepathSandboxieOldSchoolLiveDat = "C:\\Sandbox\\" + pc_username + "\\" + sandboxieNumber + "\\user\\current\\jagex_cl_oldschool_LIVE.dat";
                    if (System.IO.File.Exists(filepathSandboxieOldSchoolLiveDat))
                    {
                        try
                        {
                            System.IO.File.Delete(filepathSandboxieOldSchoolLiveDat);
                            Console.WriteLine($"Deleted sandbox jagex_cl_oldschool_LIVE.dat");
                            Thread.Sleep(100); // Wait for 1 second
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                    }

                    // Delete sandbox jagexappletviewer.preferences
                    string filepathSandboxieJagexAppletViewer = "C:\\Sandbox\\" + pc_username + "\\" + sandboxieNumber + "\\user\\current\\jagexappletviewer.preferences";
                    if (System.IO.File.Exists(filepathSandboxieJagexAppletViewer))
                    {
                        try
                        {
                            System.IO.File.Delete(filepathSandboxieJagexAppletViewer);
                            Console.WriteLine($"Deleted sandbox jagexappletviewer.preferences");
                            Thread.Sleep(100); // Wait for 1 second
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                    }

                    // Delete sandbox random.dat
                    string filepathSandboxieRandomDat = "C:\\Sandbox\\" + pc_username + "\\" + sandboxieNumber + "\\user\\current\\random.dat";
                    if (System.IO.File.Exists(filepathSandboxieRandomDat))
                    {
                        try
                        {
                            System.IO.File.Delete(filepathSandboxieRandomDat);
                            Console.WriteLine($"Deleted sandboxed random.dat");
                            Thread.Sleep(100); // Wait for 1 second
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                    }

                    // Delete sandbox osbot data folder 
                    string folderpathSandboxieOSBotData = "C:\\Sandbox\\" + pc_username + "\\" + sandboxieNumber + "\\user\\current\\OSBot\\Data";
                    if (Directory.Exists(folderpathSandboxieOSBotData))
                    {
                        try
                        {
                            DirectoryInfo directory = new DirectoryInfo(folderpathSandboxieOSBotData);
                            foreach (FileInfo file in directory.GetFiles())
                            {
                                if (file.Name.Equals("map.bin", StringComparison.OrdinalIgnoreCase) ||
                                    file.Name.Equals("map.zip", StringComparison.OrdinalIgnoreCase))
                                {
                                    continue; // Skip map.bin file and map.zip compressed folder
                                }

                                file.Delete();
                                Thread.Sleep(100); // Wait for 1 second
                            }

                            foreach (DirectoryInfo subdirectory in directory.GetDirectories())
                            {
                                if (subdirectory.Name.Equals("map.zip", StringComparison.OrdinalIgnoreCase))
                                {
                                    continue; // Skip map.zip compressed folder
                                }

                                subdirectory.Delete(true);
                                Thread.Sleep(100); // Wait for 1 second
                            }

                            Console.WriteLine($"Sandbox OSBot files deleted successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                    }

                    // Copy jagexcache to sandbox
                    if (Directory.Exists(folderpathJagexCache))
                    {
                        try
                        {
                            DirectoryCopy(folderpathJagexCache, folderpathSandboxieCurrent + "\\jagexcache");
                            Thread.Sleep(100); // Wait for 1 second
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                    }

                    // Copy osbot to sandbox
                    if (Directory.Exists(folderpathOSBot))
                    {
                        try
                        {
                            DirectoryCopy(folderpathOSBot, folderpathSandboxieCurrent + "\\OSBot");
                            Thread.Sleep(100); // Wait for 1 second
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                    }

                    // Launch cmd with args
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = cliCommand,
                        Arguments = cliArgs,
                        CreateNoWindow = true,
                        UseShellExecute = false
                    };

                    try
                    {
                        Process.Start(startInfo);
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that occur during process execution
                        MessageBox.Show("Error running command: " + ex.Message);
                    }

                    Console.WriteLine("Sandboxie CLI Args: " + cliCommand + cliArgs);
                }
            }
        }


        // Dashboard Panel - Add Bot
        private void buttonDashboard_AddBot_Click(object sender, EventArgs e)
        {
            // Add a new row to the DataGridView
            dataGridViewDashboard_Bots.Rows.Add();

            // Get the index of the newly added row
            int rowIndex = dataGridViewDashboard_Bots.Rows.Count - 1;

            // Set the values for each cell in the new row
            dataGridViewDashboard_Bots.Rows[rowIndex].Cells[0].Value = "ACCOUNT_EMAIL";
            dataGridViewDashboard_Bots.Rows[rowIndex].Cells[1].Value = "PASSWORD";
            dataGridViewDashboard_Bots.Rows[rowIndex].Cells[2].Value = "1234";
            dataGridViewDashboard_Bots.Rows[rowIndex].Cells[3].Value = "IP:PORT:USER:PASS";

            // Get the ComboBox cell
            DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)dataGridViewDashboard_Bots.Rows[rowIndex].Cells[5];

            // Populate the ComboBox cell with text files
            PopulateComboBoxWithTextFiles(comboBoxCell);

            // Set the selected index of ComboBoxes in cells 4-9 to 0 (first selection)
            for (int i = 4; i <= 9; i++)
            {
                if (dataGridViewDashboard_Bots.Rows[rowIndex].Cells[i] is DataGridViewComboBoxCell comboBoxCellLoop)
                {
                    comboBoxCellLoop.Value = comboBoxCellLoop.Items[0];
                }
            }

            // Generate a random number between 1 and 1000
            Random random = new Random();
            int randomNumber;

            // Check if the random number already exists in any existing row's cell[11]
            bool numberExists;
            do
            {
                randomNumber = random.Next(1, 1001);
                numberExists = false;
                foreach (DataGridViewRow row in dataGridViewDashboard_Bots.Rows)
                {
                    if (row.Index != rowIndex && row.Cells[11].Value != null && row.Cells[11].Value.ToString() == randomNumber.ToString())
                    {
                        numberExists = true;
                        break;
                    }
                }
            } while (numberExists);

            // Set the random number to the new row's cell[11]
            dataGridViewDashboard_Bots.Rows[rowIndex].Cells[11].Value = randomNumber;
        }

        // Dashboard Panel - Delete Bot
        private void buttonDashboard_DeleteBot_Click(object sender, EventArgs e)
        {
            // Check if any row is selected
            if (dataGridViewDashboard_Bots.SelectedRows.Count > 0)
            {
                // Get the selected row index
                int rowIndex = dataGridViewDashboard_Bots.SelectedRows[0].Index;

                // Remove the selected row from the DataGridView
                dataGridViewDashboard_Bots.Rows.RemoveAt(rowIndex);
            }
        }

        // Dashboard Panel - Save
        private void SaveDataGridViewToFile(DataGridView dataGridView)
        {
            StringBuilder sb = new StringBuilder();

            // Iterate through each row in the DataGridView
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Skip the last row if it is the new row for adding new data
                if (!row.IsNewRow)
                {
                    // Iterate through each cell in the row
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        // Append the cell value to the StringBuilder
                        string cellValue = cell.Value != null ? cell.Value.ToString() : string.Empty;
                        sb.Append(cellValue);
                        sb.Append(",");
                    }

                    // Append a new line after each row
                    sb.AppendLine();
                }
            }

            // Write the StringBuilder content to the file
            System.IO.File.WriteAllText(filepathAccountsScriptFactory, sb.ToString());
            MessageBox.Show("Dashboard saved successfully.");
        }
        private void buttonDashboard_Save_Click(object sender, EventArgs e)
        {
            SaveDataGridViewToFile(dataGridViewDashboard_Bots);
        }

        // Dashboard Panel - Update Lifetime Scripts Button
        private void buttonDashboard_UpdateScriptsLifetime_Click(object sender, EventArgs e)
        {
            string cmdUpdateScriptsLifetime = @"rmdir /Q /S ""C:\Users\%USERNAME%\Jivaro\Temp\"" & " +
                             @"rmdir /Q /S ""C:\Users\%USERNAME%\OSBot\Data\ProjectPact\OSRS Script Factory\Private Scripts\FushigiBot\"" & " +
                             @"git clone ""https://github.com/xhannyah/ScriptFactoryLifetime"" ""C:\Users\%USERNAME%\Jivaro\Temp"" & " +
                             @"xcopy /E /C /I /Y ""C:\Users\%USERNAME%\Jivaro\Temp\"" ""C:\Users\%USERNAME%\OSBot\Data\ProjectPact\OSRS Script Factory\Private Scripts\"" & " +
                             @"rmdir /Q /S ""C:\Users\%USERNAME%\Jivaro\Temp\""";

            Process.Start("cmd.exe", "/c " + cmdUpdateScriptsLifetime);
        }

        // Dashboard Panel - Update Monthly Scripts Button
        private void buttonDashboard_UpdateScriptsMonthly_Click(object sender, EventArgs e)
        {
            string cmdUpdateScriptsMonthly = @"rmdir /Q /S ""C:\Users\%USERNAME%\Jivaro\Temp\"" & " +
                             @"rmdir /Q /S ""C:\Users\%USERNAME%\OSBot\Data\ProjectPact\OSRS Script Factory\Private Scripts\FushigiBot\"" & " +
                             @"git clone ""https://github.com/xhannyah/ScriptFactoryMonthly"" ""C:\Users\%USERNAME%\Jivaro\Temp"" & " +
                             @"xcopy /E /C /I /Y ""C:\Users\%USERNAME%\Jivaro\Temp\"" ""C:\Users\%USERNAME%\OSBot\Data\ProjectPact\OSRS Script Factory\Private Scripts\"" & " +
                             @"rmdir /Q /S ""C:\Users\%USERNAME%\Jivaro\Temp\""";

            Process.Start("cmd.exe", "/c " + cmdUpdateScriptsMonthly);
        }

        //
        // End of Dashboard Panel
        //



        //
        // Start of Break Profiles Panel
        //

        // Break Profiles Panel - Save Profile to folder method
        private void buttonBreakProfiles_Save_Click(object sender, EventArgs e)
        {

            // Break Profiles Panel - Intialize Variables
            string filepathScriptFactoryProfiles = Path.Combine(@"C:\\Users\\" + pc_username + "\\OSBot\\Data\\ProjectPact\\OSRS Script Factory\\Profiles\\" + comboBoxBreakProfiles_SelectBreakFilename.SelectedItem.ToString());
            string breakFileEnableBreaks = "<Find>boolEnableBreaks:true</Find><Replace>boolEnableBreaks:false</Replace>";
            string breakFileEnableSleepBreaks = "<Find>boolEnableSleepBreaks:true</Find><Replace>boolEnableSleepBreaks:false</Replace>";
            string botTime;
            string botTimeVariation;
            string breakTime;
            string breakTimeVariation = textBoxBreakProfiles_BreakTimeVariation.Text;
            string timeUntilSleep;
            string timeUntilSleepVariation;
            string sleepTime;
            string sleepTimeVariation = textBoxBreakProfiles_SleepTimeVariation.Text;
            int intBotTime;
            int intBotTimeVariation;
            int intBreakTime;
            int intTimeUntilSleep;
            int intTimeUntilSleepVariation;
            int intSleepTime;

            // Enable breaks checkbox
            if (checkBoxBreakProfiles_EnableBreaks.Checked)
            {
                breakFileEnableBreaks = "<Find>boolEnableBreaks:true</Find><Replace>boolEnableBreaks:true</Replace>";
            }

            // Enable sleep breaks checkbox
            if (checkBoxBreakProfiles_EnableSleepBreaks.Checked)
            {
                breakFileEnableSleepBreaks = "<Find>boolEnableSleepBreaks:true</Find><Replace>boolEnableSleepBreaks:true</Replace>";
            }

            // Conver bot time mins into ms
            int.TryParse(textBoxBreakProfiles_BotTime.Text, out int intBotTimeMs);
            {
                intBotTime = intBotTimeMs * 60000;
                botTime = intBotTime.ToString();
            }

            // Convert bot time variation mins into ms
            int.TryParse(textBoxBreakProfiles_BotTimeVariation.Text, out int intBotTimeVariationMs);
            {
                intBotTimeVariation = intBotTimeVariationMs * 60000;
                botTimeVariation = intBotTimeVariation.ToString();
            }

            // Convert break time mins into ms
            int.TryParse(textBoxBreakProfiles_BreakTime.Text, out int intBreakTimeMs);
            {
                intBreakTime = intBreakTimeMs * 60000;
                breakTime = intBreakTime.ToString();
            }

            // Convert time until sleep mins to ms
            int.TryParse(textBoxBreakProfiles_TimeUntilSleep.Text, out int intTimeUntilSleepMs);
            {
                intTimeUntilSleep = intTimeUntilSleepMs * 60000;
                timeUntilSleep = intTimeUntilSleep.ToString();
            }

            // Convert time until sleep variation mins to ms
            int.TryParse(textBoxBreakProfiles_TimeUntilSleepVariation.Text, out int intTimeUntilSleepVariationMs);
            {
                intTimeUntilSleepVariation = intTimeUntilSleepVariationMs * 60000;
                timeUntilSleepVariation = intTimeUntilSleepVariation.ToString();
            }

            // Convert sleep time mins to ms
            int.TryParse(textBoxBreakProfiles_SleepTime.Text, out int intSleepTimeMs);
            {
                intSleepTime = intSleepTimeMs * 60000;
                sleepTime = intSleepTime.ToString();
            }

            // Break Profiles Press Save Button - Write to file.
            using (StreamWriter writer = new StreamWriter(filepathScriptFactoryProfiles))
            {
                // Break Profiles Press Save Button - Write to file content
                writer.WriteLine(breakFileEnableBreaks);
                writer.WriteLine(breakFileEnableSleepBreaks);
                writer.WriteLine("<Find>3600000,true,1800000,true</Find><Replace>" + botTime + ",true," + botTimeVariation + ",true</Replace>");
                writer.WriteLine("<Find>1200000:0.75</Find><Replace>" + breakTime + ":0." + breakTimeVariation + "</Replace>");
                writer.WriteLine("<Find>32400000,true,7200000,false</Find><Replace>" + timeUntilSleep + ",true," + timeUntilSleepVariation + ",false</Replace>");
                writer.WriteLine("<Find>19200000:0.25</Find><Replace>" + sleepTime + ":0." + sleepTimeVariation + "</Replace>");
            }

            MessageBox.Show("Profile successfully created.");

        }

        //
        // End of Break Profiles Panel
        //



        //
        // Start of Script Profiles Panel
        //

        // Scripts Profiles Panel - Change panel when script is selected
        private void comboBoxScriptProfiles_SelectScript_ChangeCommited(object sender, EventArgs e)
        {

            // Initialize variable
            string currentSelectedItem = comboBoxScriptProfiles_SelectScript.SelectedItem.ToString();

            // Show account builder form
            if (currentSelectedItem == "fxAccountBuilder.txt")
            {
                formScriptProfilesAccountBuilder formAccountBuilder = new formScriptProfilesAccountBuilder();
                formAccountBuilder.Show();
            }

            // Show cooking normal form
            if (currentSelectedItem == "fxCooking-Normal.txt")
            {
                formScriptProfilesCookingNormal formCookingNormal = new formScriptProfilesCookingNormal();
                formCookingNormal.Show();
            }

            // Show fighter elder chaos druids form
            if (currentSelectedItem == "fxFighter-ElderChaosDruids.txt")
            {
                formScriptProfilesFighterElderChaosDruids formFighterElderChaosDruids = new formScriptProfilesFighterElderChaosDruids();
                formFighterElderChaosDruids.Show();
            }

            // Show fighter kurasks form
            if (currentSelectedItem == "fxFighter-Kurasks.txt")
            {
                formScriptProfilesFighterKurasks formFighterKurasks = new formScriptProfilesFighterKurasks();
                formFighterKurasks.Show();
            }

            // Show lotr aragorn form
            if (currentSelectedItem == "fxLOTR-Aragorn.txt")
            {
                formScriptProfilesAragorn formAragorn = new formScriptProfilesAragorn();
                formAragorn.Show();
            }

            // Show lotr gandalf form
            if (currentSelectedItem == "fxLOTR-Gandalf.txt")
            {
                formScriptProfilesGandalf formGandalf = new formScriptProfilesGandalf();
                formGandalf.Show();
            }

            // Show lotr legolas form
            if (currentSelectedItem == "fxLOTR-Legolas.txt")
            {
                formScriptProfilesLegolas formLegolas = new formScriptProfilesLegolas();
                formLegolas.Show();
            }

            // Show firemaking grand exchange form
            if (currentSelectedItem == "fxFiremaking-GrandExchange.txt")
            {
                formScriptProfilesFiremakingGrandExchange formFiremakingGrandExchange = new formScriptProfilesFiremakingGrandExchange();
                formFiremakingGrandExchange.Show();
            }

            // Show fletching longbows druids form
            if (currentSelectedItem == "fxFletching-Longbows.txt")
            {
                formScriptProfilesFletchingLongbows formFletchingLongbows = new formScriptProfilesFletchingLongbows();
                formFletchingLongbows.Show();
            }

            // Show magic house alcher form
            if (currentSelectedItem == "fxMagic-HouseAlcher.txt")
            {
                formScriptProfilesMagicHouseAlcher formMagicHouseAlcher = new formScriptProfilesMagicHouseAlcher();
                formMagicHouseAlcher.Show();
            }

            // Show magic orber form
            if (currentSelectedItem == "fxMagic-Orber.txt")
            {
                formScriptProfilesMagicOrber formMagicOrber = new formScriptProfilesMagicOrber();
                formMagicOrber.Show();
            }

            // Show motherlode mine form
            if (currentSelectedItem == "fxMining-MLM.txt")
            {
                formScriptProfilesMotherlodeMine formMotherlodeMine = new formScriptProfilesMotherlodeMine();
                formMotherlodeMine.Show();
            }

            // Show muler form
            if (currentSelectedItem == "fxMuler.txt")
            {
                formScriptProfilesMuler formMuler = new formScriptProfilesMuler();
                formMuler.Show();
            }

            // Show runecrafting abyss form
            if (currentSelectedItem == "fxRunecrafting-Abyss.txt")
            {
                formScriptProfilesRunecraftingAbyss formRunecraftingAbyss = new formScriptProfilesRunecraftingAbyss();
                formRunecraftingAbyss.Show();
            }

            // Show runecrafting zeah form
            if (currentSelectedItem == "fxRunecrafting-Zeah.txt")
            {
                formScriptProfilesRunecraftingZeah formRunecraftingZeah = new formScriptProfilesRunecraftingZeah();
                formRunecraftingZeah.Show();
            }

            // Show slayer aio form
            if (currentSelectedItem == "fxSlayer-AIO.txt")
            {
                formScriptProfilesSlayerAIO formSlayerAIO = new formScriptProfilesSlayerAIO();
                formSlayerAIO.Show();
            }

            // Show thieving master farmers form
            if (currentSelectedItem == "fxThieving-MasterFarmers.txt")
            {
                formScriptProfilesThievingMasterFarmers formThievingMasterFarmers = new formScriptProfilesThievingMasterFarmers();
                formThievingMasterFarmers.Show();
            }

            // Show thieving vyres form
            if (currentSelectedItem == "fxThieving-Vyres.txt")
            {
                formScriptProfilesThievingVyres formThievingVyres = new formScriptProfilesThievingVyres();
                formThievingVyres.Show();
            }

            // Show tutorial island form
            if (currentSelectedItem == "fxTutorial.txt")
            {
                formScriptProfilesTutorial formTutorial = new formScriptProfilesTutorial();
                formTutorial.Show();
            }

        }

        //
        // End of Script Profiles Panel
        //



        //
        // Start of Settings Panel
        //

        // Install Git Button
        private void buttonSettings_InstallGit_Click(object sender, EventArgs e)
        {
            // Get current working directory and store it in a variable
            string currentWorkingDirectory = Directory.GetCurrentDirectory();

            // Save the git path in a string
            string pathGitInstaller = currentWorkingDirectory + "\\dependencies\\git\\Git-2.39.1-64-bit.exe";

            // Run the git installer
            Process process = new Process();
            process.StartInfo.FileName = pathGitInstaller;
            process.Start();
        }

        // Install sandboxie
        private void buttonSettings_InstallSandboxie_Click(object sender, EventArgs e)
        {
            // Get current working directory and store it in a variable
            string currentWorkingDirectory = Directory.GetCurrentDirectory();

            // Save the git path in a string
            string pathSandboxieInstaller = currentWorkingDirectory + "\\dependencies\\sandboxie\\Sandboxie-Plus-x64-v1.7.2.exe";

            // Run the git installer
            Process process = new Process();
            process.StartInfo.FileName = pathSandboxieInstaller;
            process.Start();
        }

        // Install proxifier
        private void buttonSettings_InstallProxifier_Click(object sender, EventArgs e)
        {
            // Get current working directory and store it in a variable
            string currentWorkingDirectory = Directory.GetCurrentDirectory();

            // Save the git path in a string
            string pathProxifierInstaller = currentWorkingDirectory + "\\dependencies\\proxifier\\ProxifierSetup.exe";

            // Run the git installer
            Process process = new Process();
            process.StartInfo.FileName = pathProxifierInstaller;
            process.Start();
        }

        // Check For Updates Button
        private void buttonSettings_CheckForUpdates_Click(object sender, EventArgs e)
        {
            string url = "https://download.jivaro.net/s/2L9S8tPcWkAAEBa";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to open the link: " + ex.Message);
            }
        }

        // Visit Jivaro
        private void buttonSettings_VisitWebsite_Click(object sender, EventArgs e)
        {
            string url = "https://download.jivaro.net/";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to open the link: " + ex.Message);
            }
        }

        // Join Discord
        private void buttonSettings_JoinDiscord_Click(object sender, EventArgs e)
        {
            string url = "https://discord.gg/FSzuW4mR4M";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to open the link: " + ex.Message);
            }
        }

        // Botting Guide
        private void buttonSettings_BottingGuide_Click(object sender, EventArgs e)
        {
            string url = "https://www.jivaro.net/media/guides/the-ultimate-guide-to-botting-old-school-runescape";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to open the link: " + ex.Message);
            }
        }

        // Buy Proxies
        private void buttonSettings_BuyProxies_Click(object sender, EventArgs e)
        {
            string url = "https://www.jivaro.net/media/blog/the-best-affordable-proxy-providers";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to open the link: " + ex.Message);
            }
        }

        // Create OSRS Account
        private void buttonSettings_CreateOSRSAccount_Click(object sender, EventArgs e)
        {
            string url = "https://secure.runescape.com/m=account-creation/create_account";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to open the link: " + ex.Message);
            }
        }


        //
        // End of Accounts and Settings Panel
        //

    }
}
