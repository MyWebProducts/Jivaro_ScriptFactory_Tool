namespace jivaro_osrs_launcher
{
    public partial class formScriptProfilesThievingMasterFarmers : Form
    {
        public formScriptProfilesThievingMasterFarmers()
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

        // Script Profiles Panel - Save ThievingMasterFarmers profile to folder
        private void buttonScriptProfiles_ThievingMasterFarmers_SaveButton_Click(object sender, EventArgs e)
        {

            // Intialize variables
            string filepathProfileThievingMasterFarmers = Path.Combine(@"C:\\Users\\" + pc_username + "\\OSBot\\Data\\ProjectPact\\OSRS Script Factory\\Profiles\\fxThieving-MasterFarmers.txt");
            string selectLocation = "<Find>Random Sector/*/Varrock/*/Hosidius South/*/Hosidius North</Find><Replace>" + comboBoxScriptProfiles_ThievingMasterFarmers_SelectLocation.SelectedItem.ToString() + "</Replace>";

            // Enable death handler checked
            if (checkBoxScriptProfiles_ThievingMasterFarmers_DeathHandler.Checked)
            {
                boolEnableDeathHandler = "<Find>boolEnableDeathHandler:false</Find><Replace>boolEnableDeathHandler:true</Replace>";
            }

            // Enable renew bond checked
            if (checkBoxScriptProfiles_ThievingMasterFarmers_RenewBond.Checked)
            {
                boolEnableRenewBond = "<Find>boolEnableRenewBond:false</Find><Replace>boolEnableRenewBond:true</Replace>";
            }

            // Enable antipattern checked
            if (checkBoxScriptProfiles_ThievingMasterFarmers_Antipattern.Checked)
            {
                boolEnableAntipattern = "<Find>boolEnableAntipattern:false</Find><Replace>boolEnableAntipattern:true</Replace>";
            }

            // Enable hop world checked
            if (checkBoxScriptProfiles_ThievingMasterFarmers_WorldHopping.Checked)
            {
                boolEnableHopWorlds = "<Find>boolEnableHopWorlds:false</Find><Replace>boolEnableHopWorlds:true</Replace>";
            }

            // Enable restocking checked
            if (checkBoxScriptProfiles_ThievingMasterFarmers_Restocking.Checked)
            {
                boolEnableRestocking = "<Find>boolEnableRestocking:false</Find><Replace>boolEnableRestocking:true</Replace>";
            }

            // Enable sell loot checkbox checked
            if (checkBoxScriptProfiles_ThievingMasterFarmers_SellLoot.Checked)
            {
                boolEnableSellLoot = "<Find>boolEnableSellLoot:false</Find><Replace>boolEnableSellLoot:true</Replace>";
            }


            // Write to file
            using (StreamWriter writer = new StreamWriter(filepathProfileThievingMasterFarmers))
            {
                writer.WriteLine(boolEnableProfiles);
                writer.WriteLine(boolEnableDeathHandler);
                writer.WriteLine(boolEnableRenewBond);
                writer.WriteLine(boolEnableAntipattern);
                writer.WriteLine(boolEnableHopWorlds);
                writer.WriteLine(boolEnableRestocking);
                writer.WriteLine(boolEnableSellLoot);
                writer.WriteLine(selectLocation);

            }

            MessageBox.Show("Profile successfully created.");

        }

        private void formScriptProfiles_ThievingMasterFarmers_Load(object sender, EventArgs e)
        {
            comboBoxScriptProfiles_ThievingMasterFarmers_SelectLocation.SelectedIndex = 0;
        }
    }
}
