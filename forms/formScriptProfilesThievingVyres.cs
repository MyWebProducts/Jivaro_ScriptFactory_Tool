namespace jivaro_osrs_launcher
{
    public partial class formScriptProfilesThievingVyres : Form
    {
        public formScriptProfilesThievingVyres()
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


        // Script Profiles Panel - Save ThievingVyres profile to folder
        private void buttonScriptProfiles_ThievingVyres_SaveButton_Click(object sender, EventArgs e)
        {

            // Intialize variables
            string filepathProfileThievingVyres = Path.Combine(@"C:\\Users\\" + pc_username + "\\OSBot\\Data\\ProjectPact\\OSRS Script Factory\\Profiles\\fxThieving-Vyres.txt");
            string boolEnableShadowVeil = "<Find>boolEnableShadowVeil:false</Find><Replace>boolEnableShadowVeil:false</Replace>";
            string slectNpc = "<Find>Random/*/Vallessia von Pitt/*/Vlad Diaemus/*/Vonnetta Varnis</Find><Replace>Random/*/Vallessia von Pitt/*/Vlad Diaemus/*/Vonnetta Varnis</Replace>";

            // Enable death handler checked
            if (checkBoxScriptProfiles_ThievingVyres_DeathHandler.Checked)
            {
                boolEnableDeathHandler = "<Find>boolEnableDeathHandler:false</Find><Replace>boolEnableDeathHandler:true</Replace>";
            }

            // Enable renew bond checked
            if (checkBoxScriptProfiles_ThievingVyres_RenewBond.Checked)
            {
                boolEnableRenewBond = "<Find>boolEnableRenewBond:false</Find><Replace>boolEnableRenewBond:true</Replace>";
            }

            // Enable antipattern checked
            if (checkBoxScriptProfiles_ThievingVyres_Antipattern.Checked)
            {
                boolEnableAntipattern = "<Find>boolEnableAntipattern:false</Find><Replace>boolEnableAntipattern:true</Replace>";
            }

            // Enable hop world checked
            if (checkBoxScriptProfiles_ThievingVyres_WorldHopping.Checked)
            {
                boolEnableHopWorlds = "<Find>boolEnableHopWorlds:false</Find><Replace>boolEnableHopWorlds:true</Replace>";
            }

            // Enable restocking checked
            if (checkBoxScriptProfiles_ThievingVyres_Restocking.Checked)
            {
                boolEnableRestocking = "<Find>boolEnableRestocking:false</Find><Replace>boolEnableRestocking:true</Replace>";
            }

            // Enable sell loot checkbox checked
            if (checkBoxScriptProfiles_ThievingVyres_SellLoot.Checked)
            {
                boolEnableSellLoot = "<Find>boolEnableSellLoot:false</Find><Replace>boolEnableSellLoot:true</Replace>";
            }

            // Enable shadow veil
            if (checkBoxScriptProfiles_ThievingVyres_ShadowVeil.Checked)
            {
                boolEnableShadowVeil = "<Find>boolDisableGearChecks:false</Find><Replace>boolDisableGearChecks:true</Replace>";
            }

            // Select npc
            if (comboBoxScriptProfiles_ThievingVyres_SelectNpc != null)
            {
                slectNpc = "<Find>Random/*/Vallessia von Pitt/*/Vlad Diaemus/*/Vonnetta Varnis</Find><Replace>" + comboBoxScriptProfiles_ThievingVyres_SelectNpc.SelectedItem.ToString() + "</Replace>";
            }


            // Write to file
            using (StreamWriter writer = new StreamWriter(filepathProfileThievingVyres))
            {
                writer.WriteLine(boolEnableProfiles);
                writer.WriteLine(boolEnableDeathHandler);
                writer.WriteLine(boolEnableRenewBond);
                writer.WriteLine(boolEnableAntipattern);
                writer.WriteLine(boolEnableHopWorlds);
                writer.WriteLine(boolEnableRestocking);
                writer.WriteLine(boolEnableSellLoot);
                writer.WriteLine(boolEnableShadowVeil);
                writer.WriteLine(slectNpc);

            }

            MessageBox.Show("Profile successfully created.");

        }

        private void formScriptProfiles_ThievingVyres_Load(object sender, EventArgs e)
        {
            comboBoxScriptProfiles_ThievingVyres_SelectNpc.SelectedIndex = 0;
        }

    }
}
