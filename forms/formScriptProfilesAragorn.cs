namespace jivarosft
{
    public partial class formScriptProfilesAragorn : Form
    {
        public formScriptProfilesAragorn()
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

        // Script Profiles Panel - Save aragorn profile to folder
        private void buttonScriptProfiles_Aragorn_SaveButton_Click(object sender, EventArgs e)
        {

            // Intialize variables
            string filepathProfileAragorn = Path.Combine(@"C:\\Users\\" + pc_username + "\\OSBot\\Data\\ProjectPact\\OSRS Script Factory\\Profiles\\fxLOTR-Aragorn.txt");
            string boolDisableGearChecks = "<Find>boolDisableGearChecks:false</Find><Replace>boolDisableGearChecks:false</Replace>";
            string boolEnableFightObor = "<Find>boolEnableFightObor:false</Find><Replace>boolEnableFightObor:false</Replace>";
            string boolEnableBuryBones = "<Find>boolEnableBuryBones:false</Find><Replace>boolEnableBuryBones:false</Replace>";
            string boolEnableProgressiveTraining = "<Find>boolEnableProgressiveTraining:false</Find><Replace>boolEnableProgressiveTraining:false</Replace>";
            string slectNpc = "<Find>Progressive/*/Chickens/*/Giant Frogs/*/Hill Giants/*/Sand Crabs/*/Chaos Druids</Find><Replace>" + comboBoxScriptProfiles_Aragorn_SelectNpc.SelectedItem.ToString() + "</Replace>";

            // Enable death handler checked
            if (checkBoxScriptProfiles_Aragorn_DeathHandler.Checked)
            {
                boolEnableDeathHandler = "<Find>boolEnableDeathHandler:false</Find><Replace>boolEnableDeathHandler:true</Replace>";
            }

            // Enable renew bond checked
            if (checkBoxScriptProfiles_Aragorn_RenewBond.Checked)
            {
                boolEnableRenewBond = "<Find>boolEnableRenewBond:false</Find><Replace>boolEnableRenewBond:true</Replace>";
            }

            // Enable antipattern checked
            if (checkBoxScriptProfiles_Aragorn_Antipattern.Checked)
            {
                boolEnableAntipattern = "<Find>boolEnableAntipattern:false</Find><Replace>boolEnableAntipattern:true</Replace>";
            }

            // Enable hop world checked
            if (checkBoxScriptProfiles_Aragorn_WorldHopping.Checked)
            {
                boolEnableHopWorlds = "<Find>boolEnableHopWorlds:false</Find><Replace>boolEnableHopWorlds:true</Replace>";
            }

            // Enable restocking checked
            if (checkBoxScriptProfiles_Aragorn_Restocking.Checked)
            {
                boolEnableRestocking = "<Find>boolEnableRestocking:false</Find><Replace>boolEnableRestocking:true</Replace>";
            }

            // Enable sell loot checkbox checked
            if (checkBoxScriptProfiles_Aragorn_SellLoot.Checked)
            {
                boolEnableSellLoot = "<Find>boolEnableSellLoot:false</Find><Replace>boolEnableSellLoot:true</Replace>";
            }

            // Disable gear checks checked
            if (checkBoxScriptProfiles_Aragorn_UseOwnGear.Checked)
            {
                boolDisableGearChecks = "<Find>boolDisableGearChecks:false</Find><Replace>boolDisableGearChecks:true</Replace>";
            }

            // Enable fight Obor checked
            if (checkBoxScriptProfiles_Aragorn_FightObor.Checked)
            {
                boolEnableFightObor = "<Find>boolEnableFightObor:false</Find><Replace>boolEnableFightObor:true</Replace>";
            }

            // Enable bury bones checked
            if (checkBoxScriptProfiles_Aragorn_BuryBigBones.Checked)
            {
                boolEnableBuryBones = "<Find>boolEnableBuryBones:false</Find><Replace>boolEnableBuryBones:true</Replace>";
            }

            // Enable progressive training checked
            if (checkBoxScriptProfiles_Aragorn_TrainStatsEvenly.Checked)
            {
                boolEnableProgressiveTraining = "<Find>boolEnableProgressiveTraining:false</Find><Replace>boolEnableProgressiveTraining:true</Replace>";
            }

            // Write to file
            using (StreamWriter writer = new StreamWriter(filepathProfileAragorn))
            {
                writer.WriteLine(boolEnableProfiles);
                writer.WriteLine(boolEnableDeathHandler);
                writer.WriteLine(boolEnableRenewBond);
                writer.WriteLine(boolEnableAntipattern);
                writer.WriteLine(boolEnableHopWorlds);
                writer.WriteLine(boolEnableRestocking);
                writer.WriteLine(boolEnableSellLoot);
                writer.WriteLine(boolDisableGearChecks);
                writer.WriteLine(boolEnableFightObor);
                writer.WriteLine(boolEnableBuryBones);
                writer.WriteLine(boolEnableProgressiveTraining);
                writer.WriteLine(slectNpc);
            }

            MessageBox.Show("Profile successfully created.");

        }

        private void formScriptProfiles_Aragorn_Load(object sender, EventArgs e)
        {
            comboBoxScriptProfiles_Aragorn_SelectNpc.SelectedIndex = 0;
        }
    }
}
