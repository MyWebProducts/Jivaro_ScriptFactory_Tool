namespace jivarosft
{
    public partial class formScriptProfilesLegolas : Form
    {
        public formScriptProfilesLegolas()
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

        // Scripts profiles panel - Save legolas profile to folder
        private void buttonScriptProfiles_Legolas_SaveButton_Click(object sender, EventArgs e)
        {
            // Intialize variables
            string filepathProfileLegolas = Path.Combine(@"C:\\Users\\" + pc_username + "\\OSBot\\Data\\ProjectPact\\OSRS Script Factory\\Profiles\\fxLOTR-Legolas.txt");
            string selectNpc = "<Find>Progressive/*/Goblins/*/Monks/*/HillGiants/*/MossGiants</Find><Replace>" + comboBoxScriptProfiles_Legolas_SelectNPC.SelectedItem.ToString() + "</Replace>";
            string boolEnableBuryBones = "<Find>boolEnableBuryBones:false</Find><Replace>boolEnableBuryBones:false</Replace>";
            string boolDisableLootArrows = "<Find>boolDisableLootArrows:false</Find><Replace>boolDisableLootArrows:false</Replace>";
            string boolEnableLongRangeTraining = "<Find>boolEnableLongRangeTraining:false</Find><Replace>boolEnableLongRangeTraining:false</Replace>";
            string boolEnableFightBryophyta = "<Find>boolEnableFightBryophyta:false</Find><Replace>boolEnableFightBryophyta:false</Replace>";

            // Enable death handler checkbox
            if (checkBoxScriptProfiles_Legolas_DeathHandler.Checked)
            {
                boolEnableDeathHandler = "<Find>boolEnableDeathHandler:false</Find><Replace>boolEnableDeathHandler:true</Replace>";
            }

            // Enable renew bond checkbox
            if (checkBoxScriptProfiles_Legolas_RenewBond.Checked)
            {
                boolEnableRenewBond = "<Find>boolEnableRenewBond:false</Find><Replace>boolEnableRenewBond:true</Replace>";
            }

            // Enable antipattern checkbox
            if (checkBoxScriptProfiles_Legolas_Antipattern.Checked)
            {
                boolEnableAntipattern = "<Find>boolEnableAntipattern:false</Find><Replace>boolEnableAntipattern:true</Replace>";
            }

            // Enable hop world checkbox
            if (checkBoxScriptProfiles_Legolas_WorldHopping.Checked)
            {
                boolEnableHopWorlds = "<Find>boolEnableHopWorlds:false</Find><Replace>boolEnableHopWorlds:true</Replace>";
            }

            // Enable restocking checkbox
            if (checkBoxScriptProfiles_Legolas_Restocking.Checked)
            {
                boolEnableRestocking = "<Find>boolEnableRestocking:false</Find><Replace>boolEnableRestocking:true</Replace>";
            }

            // Enable sell loot checkbox
            if (checkBoxScriptProfiles_Legolas_SellLoot.Checked)
            {
                boolEnableSellLoot = "<Find>boolEnableSellLoot:false</Find><Replace>boolEnableSellLoot:true</Replace>";
            }

            // Enable bury bones checkbox
            if (checkBoxScriptProfiles_Legolas_BuryBigBones.Checked)
            {
                boolEnableBuryBones = "<Find>boolEnableBuryBones:false</Find><Replace>boolEnableBuryBones:true</Replace>";
            }

            // Disable loot arrows
            if (checkBoxScriptProfiles_Legolas_DontLootArrows.Checked)
            {
                boolDisableLootArrows = "<Find>boolDisableLootArrows:false</Find><Replace>boolDisableLootArrows:true</Replace>";
            }

            // Enable long range training
            if (checkBoxScriptProfiles_Legolas_LongRangeMode.Checked)
            {
                boolEnableLongRangeTraining = "<Find>boolEnableLongRangeTraining:false</Find><Replace>boolEnableLongRangeTraining:true</Replace>\r\n";
            }

            // Enable fight Bryophyta
            if (checkBoxScriptProfiles_Legolas_FightBryophyta.Checked)
            {
                boolEnableFightBryophyta = "<Find>boolEnableFightBryophyta:false</Find><Replace>boolEnableFightBryophyta:true</Replace>";
            }

            // Write to file
            using (StreamWriter writer = new StreamWriter(filepathProfileLegolas))
            {
                writer.WriteLine(boolEnableProfiles);
                writer.WriteLine(boolEnableDeathHandler);
                writer.WriteLine(boolEnableRenewBond);
                writer.WriteLine(boolEnableAntipattern);
                writer.WriteLine(boolEnableHopWorlds);
                writer.WriteLine(boolEnableRestocking);
                writer.WriteLine(boolEnableSellLoot);
                writer.WriteLine(boolEnableBuryBones);
                writer.WriteLine(boolDisableLootArrows);
                writer.WriteLine(boolEnableLongRangeTraining);
                writer.WriteLine(boolEnableFightBryophyta);
                writer.WriteLine(selectNpc);
            }

            MessageBox.Show("Profile successfully created.");

        }

        private void formScriptProfiles_Legolas_Load(object sender, EventArgs e)
        {
            comboBoxScriptProfiles_Legolas_SelectNPC.SelectedIndex = 0;
        }
    }
}
