namespace jivaro_osrs_launcher
{
    public partial class formScriptProfilesGandalf : Form
    {
        public formScriptProfilesGandalf()
        {
            InitializeComponent();
        }

        string pc_username = Environment.UserName;
        string folderpathProfiles = @"C:\\Users\\" + Environment.UserName.ToString() + "\\OSBot\\Data\\ProjectPact\\OSRS Script Factory\\Profiles\\";
        string boolEnableProfiles = "<Find>boolEnableProfiles:false</Find><Replace>boolEnableProfiles:true</Replace>";
        string boolEnableDeathHandler = "<Find>boolEnableDeathHandler:false</Find><Replace>boolEnableDeathHandler:false</Replace>";
        string boolEnableRenewBond = "<Find>boolEnableRenewBond:false</Find><Replace>boolEnableRenewBond:false</Replace>";
        string boolEnableAntipattern = "<Find>boolEnableAntipattern:false</Find><Replace>boolEnableAntipattern:false</Replace>";
        string boolEnableHopWorlds = "<Find>boolEnableHopWorlds:false</Find><Replace>boolEnableHopWorlds:false</Replace>";
        string boolEnableRestocking = "<Find>boolEnableRestocking:false</Find><Replace>boolEnableRestocking:false</Replace>";
        string boolEnableSellLoot = "<Find>boolEnableSellLoot:false</Find><Replace>boolEnableSellLoot:false</Replace>";
        string boolEnableFireBolt = "<Find>boolEnableFireBolt:false</Find><Replace>boolEnableFireBolt:false</Replace>";
        string boolEnablePlayerIsSkulledHopWorlds = "<Find>boolEnablePlayerIsSkulledHopWorlds:false</Find><Replace>boolEnablePlayerIsSkulledHopWorlds:false</Replace>";

        // Script Profiles Panel - Save Gandalf profile to folder
        private void buttonScriptProfiles_Gandalf_SaveButton_Click(object sender, EventArgs e)
        {

            // Intialize variables
            string filepathProfileGandalf = Path.Combine(@"C:\\Users\\" + pc_username + "\\OSBot\\Data\\ProjectPact\\OSRS Script Factory\\Profiles\\fxLOTR-Gandalf.txt");
            string slectMode = "<Find>Splashing/*/Lava Dragons</Find><Replace>" + comboBoxScriptProfiles_Gandalf_SelectMode.SelectedItem.ToString() + "</Replace>";
            string slectLavaDragonsArea = "<Find>Random/*/North/*/West/*/East</Find><Replace>" + comboBoxScriptProfiles_Gandalf_LavaDragonsArea.SelectedItem.ToString() + "</Replace>";

            // Enable death handler checked
            if (checkBoxScriptProfiles_Gandalf_DeathHandler.Checked)
            {
                boolEnableDeathHandler = "<Find>boolEnableDeathHandler:false</Find><Replace>boolEnableDeathHandler:true</Replace>";
            }

            // Enable renew bond checked
            if (checkBoxScriptProfiles_Gandalf_RenewBond.Checked)
            {
                boolEnableRenewBond = "<Find>boolEnableRenewBond:false</Find><Replace>boolEnableRenewBond:true</Replace>";
            }

            // Enable antipattern checked
            if (checkBoxScriptProfiles_Gandalf_Antipattern.Checked)
            {
                boolEnableAntipattern = "<Find>boolEnableAntipattern:false</Find><Replace>boolEnableAntipattern:true</Replace>";
            }

            // Enable hop world checked
            if (checkBoxScriptProfiles_Gandalf_WorldHopping.Checked)
            {
                boolEnableHopWorlds = "<Find>boolEnableHopWorlds:false</Find><Replace>boolEnableHopWorlds:true</Replace>";
            }

            // Enable restocking checked
            if (checkBoxScriptProfiles_Gandalf_Restocking.Checked)
            {
                boolEnableRestocking = "<Find>boolEnableRestocking:false</Find><Replace>boolEnableRestocking:true</Replace>";
            }

            // Enable sell loot checkbox checked
            if (checkBoxScriptProfiles_Gandalf_SellLoot.Checked)
            {
                boolEnableSellLoot = "<Find>boolEnableSellLoot:false</Find><Replace>boolEnableSellLoot:true</Replace>";
            }

            // Enable use fire bolt spell
            if (checkBoxScriptProfiles_Gandalf_UseFireBolt.Checked)
            {
                boolEnableFireBolt = "<Find>boolEnableFireBolt:false</Find><Replace>boolEnableFireBolt:true</Replace>";
            }

            // Enable hop worlds if skulled player is nearby
            if (checkBoxScriptProfiles_Gandalf_HopWorldsIfPlayerIsSkulled.Checked)
            {
                boolEnablePlayerIsSkulledHopWorlds = "<Find>boolEnablePlayerIsSkulledHopWorlds:false</Find><Replace>boolEnablePlayerIsSkulledHopWorlds:true</Replace>";
            }


            // Write to file
            using (StreamWriter writer = new StreamWriter(filepathProfileGandalf))
            {
                writer.WriteLine(boolEnableProfiles);
                writer.WriteLine(boolEnableDeathHandler);
                writer.WriteLine(boolEnableRenewBond);
                writer.WriteLine(boolEnableAntipattern);
                writer.WriteLine(boolEnableHopWorlds);
                writer.WriteLine(boolEnableRestocking);
                writer.WriteLine(boolEnableSellLoot);
                writer.WriteLine(slectMode);
                writer.WriteLine(slectLavaDragonsArea);
                writer.WriteLine(boolEnableFireBolt);
                writer.WriteLine(boolEnablePlayerIsSkulledHopWorlds);
            }

            MessageBox.Show("Profile successfully created.");

        }

        private void formScriptProfiles_Gandalf_Load(object sender, EventArgs e)
        {
            comboBoxScriptProfiles_Gandalf_SelectMode.SelectedIndex = 0;
            comboBoxScriptProfiles_Gandalf_LavaDragonsArea.SelectedIndex = 0;
        }
    }
}
