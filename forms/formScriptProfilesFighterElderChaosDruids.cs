namespace jivaro_osrs_launcher
{
    public partial class formScriptProfilesFighterElderChaosDruids : Form
    {
        public formScriptProfilesFighterElderChaosDruids()
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


        // Script Profiles Panel - Save fighter elder chaos druids profile to folder
        private void buttonScriptProfiles_FighterElderChaosDruids_SaveButton_Click(object sender, EventArgs e)
        {
            // Intialize variables
            string filepathProfileFighterElderChaosDruids = Path.Combine(@"C:\\Users\\" + pc_username + "\\OSBot\\Data\\ProjectPact\\OSRS Script Factory\\Profiles\\fxFighter-ElderChaosDruids.txt");
            string boolEnableProgressiveTraining = "<Find>boolEnableProgressiveTraining:false</Find><Replace>boolEnableProgressiveTraining:false</Replace>";
            string boolEnableTeleportFromPkers = "<Find>boolEnableTeleportFromPkers:false</Find><Replace>boolEnableTeleportFromPkers:false</Replace>";
            string boolEnableDamagePrayers = "<Find>boolEnableDamagePrayers:false</Find><Replace>boolEnableDamagePrayers:false</Replace>";
            string selectGear = comboBoxScriptProfiles_FighterElderChaosDruids_SelectGear.SelectedItem.ToString();
            string selectCape = comboBoxScriptProfiles_FighterElderChaosDruids_SelectCape.SelectedItem.ToString();
            string selectBoots = comboBoxScriptProfiles_FighterElderChaosDruids_SelectBoots.SelectedItem.ToString();
            string selectHeadgear = comboBoxScriptProfiles_FighterElderChaosDruids_SelectHeadgear.SelectedItem.ToString();
            string selectWeapon = comboBoxScriptProfiles_FighterElderChaosDruids_SelectWeapon.SelectedItem.ToString();

            // Enable death handler checkbox
            if (checkBoxScriptProfiles_FighterElderChaosDruids_DeathHandler.Checked)
            {
                boolEnableDeathHandler = "<Find>boolEnableDeathHandler:false</Find><Replace>boolEnableDeathHandler:true</Replace>";
            }

            // Enable renew bond checkbox
            if (checkBoxScriptProfiles_FighterElderChaosDruids_RenewBond.Checked)
            {
                boolEnableRenewBond = "<Find>boolEnableRenewBond:false</Find><Replace>boolEnableRenewBond:true</Replace>";
            }

            // Enable antipattern checkbox
            if (checkBoxScriptProfiles_FighterElderChaosDruids_Antipattern.Checked)
            {
                boolEnableAntipattern = "<Find>boolEnableAntipattern:false</Find><Replace>boolEnableAntipattern:true</Replace>";
            }

            // Enable hop world checkbox
            if (checkBoxScriptProfiles_FighterElderChaosDruids_WorldHopping.Checked)
            {
                boolEnableHopWorlds = "<Find>boolEnableHopWorlds:false</Find><Replace>boolEnableHopWorlds:true</Replace>";
            }

            // Enable restocking checkbox
            if (checkBoxScriptProfiles_FighterElderChaosDruids_Restocking.Checked)
            {
                boolEnableRestocking = "<Find>boolEnableRestocking:false</Find><Replace>boolEnableRestocking:true</Replace>";
            }

            // Enable sell loot checkbox
            if (checkBoxScriptProfiles_FighterElderChaosDruids_SellLoot.Checked)
            {
                boolEnableSellLoot = "<Find>boolEnableSellLoot:false</Find><Replace>boolEnableSellLoot:true</Replace>";
            }

            // Train stats evenly
            if (checkBoxScriptProfiles_FighterElderChaosDruids_TrainStatsEvenly.Checked)
            {
                boolEnableProgressiveTraining = "<Find>boolEnableProgressiveTraining:false</Find><Replace>boolEnableProgressiveTraining:true</Replace>";
            }

            // Teleport From Pkers
            if (checkBoxScriptProfiles_FighterElderChaosDruids_TeleportFromPkers.Checked)
            {
                boolEnableTeleportFromPkers = "<Find>boolEnableTeleportFromPkers:false</Find><Replace>boolEnableTeleportFromPkers:true</Replace>";
            }

            // Use Offensive Prayers
            if (checkBoxScriptProfiles_FighterElderChaosDruids_UseOffensivePrayers.Checked)
            {
                boolEnableDamagePrayers = "<Find>boolEnableDamagePrayers:false</Find><Replace>boolEnableDamagePrayers:true</Replace>";
            }


            // Write to file
            using (StreamWriter writer = new StreamWriter(filepathProfileFighterElderChaosDruids))
            {
                writer.WriteLine(boolEnableProfiles);
                writer.WriteLine(boolEnableDeathHandler);
                writer.WriteLine(boolEnableRenewBond);
                writer.WriteLine(boolEnableAntipattern);
                writer.WriteLine(boolEnableHopWorlds);
                writer.WriteLine(boolEnableRestocking);
                writer.WriteLine(boolEnableSellLoot);
                writer.WriteLine(boolEnableProgressiveTraining);
                writer.WriteLine(boolEnableTeleportFromPkers);
                writer.WriteLine(boolEnableDamagePrayers);
                writer.WriteLine("<Find>None/*/Random/*/DruidsRobe/*/MonksRobe/*/ZamorakMonksRobe</Find><Replace>" + selectGear + "</Replace>");
                writer.WriteLine("<Find>None/*/Random/*/GuthixCloak/*/ZamorakCloak/*/SaradominCloak</Find><Replace>" + selectCape + "</Replace>");
                writer.WriteLine("<Find>None/*/Progressive/*/ClimbingBoots/*/RuneBoots/*/DragonBoots</Find><Replace>" + selectBoots + "</Replace>");
                writer.WriteLine("<Find>None/*/Random/*/GuthixMitre/*/SaradominMitre/*/ZamorakMitre</Find><Replace>" + selectHeadgear + "</Replace>");
                writer.WriteLine("<Find>HighestUsable/*/DragonSword/*/DragonScimitar/*/SaradominSword/*/AbyssalWhip</Find><Replace>" + selectWeapon + "</Replace>");
            }

            MessageBox.Show("Profile successfully created.");

        }

        private void formScriptProfilesFighterElderChaosDruids_Load(object sender, EventArgs e)
        {
            comboBoxScriptProfiles_FighterElderChaosDruids_SelectCape.SelectedIndex = 0;
            comboBoxScriptProfiles_FighterElderChaosDruids_SelectGear.SelectedIndex = 0;
            comboBoxScriptProfiles_FighterElderChaosDruids_SelectBoots.SelectedIndex = 0;
            comboBoxScriptProfiles_FighterElderChaosDruids_SelectHeadgear.SelectedIndex = 0;
            comboBoxScriptProfiles_FighterElderChaosDruids_SelectWeapon.SelectedIndex = 0;
        }
    }
}
