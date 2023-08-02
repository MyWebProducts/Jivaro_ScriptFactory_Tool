namespace jivaro_osrs_launcher
{
    public partial class formScriptProfilesMotherlodeMine : Form
    {
        public formScriptProfilesMotherlodeMine()
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

        // Form load
        private void formScriptProfiles_MotherlodeMine_Load(object sender, EventArgs e)
        {

        }


        // Scripts profiles panel - Save mining motherlode mine profile to folder
        private void buttonScriptProfiles_MotherlodeMine_SaveButton_Click(object sender, EventArgs e)
        {
            // Intialize variables
            string filepathProfileMotherlodeMine = Path.Combine(@"C:\\Users\\" + pc_username + "\\OSBot\\Data\\ProjectPact\\OSRS Script Factory\\Profiles\\fxMining-MLM.txt");
            string boolEnableDragonPickaxe = "<Find>boolEnableDragonPickaxe:false</Find><Replace>boolEnableDragonPickaxe:false</Replace>";
            string boolEnableBuyOutfit = "<Find>boolEnableBuyOutfit:false</Find><Replace>boolEnableBuyOutfit:false</Replace>";
            string boolEnableBuyGemBag = "<Find>boolEnableBuyGemBag:false</Find><Replace>boolEnableBuyGemBag:false</Replace>";
            string boolEnableBuyCoalBag = "<Find>boolEnableBuyCoalBag:false</Find><Replace>boolEnableBuyCoalBag:false</Replace>";
            string boolEnableBuySoftClayPack = "<Find>boolEnableBuySoftClayPack:false</Find><Replace>boolEnableBuySoftClayPack:false</Replace>";
            string selectMotherlodeMineSector = "<Find>Random/*/West/*/SouthWest/*/South/*/SouthEast</Find><Replace>" + comboBoxScriptProfiles_MotherlodeMine_SelectSector.SelectedItem.ToString() + "</Replace>";

            // Enable death handler checkbox
            if (checkBoxScriptProfiles_MotherlodeMine_DeathHandler.Checked)
            {
                boolEnableDeathHandler = "<Find>boolEnableDeathHandler:false</Find><Replace>boolEnableDeathHandler:true</Replace>";
            }

            // Enable renew bond checkbox
            if (checkBoxScriptProfiles_MotherlodeMine_RenewBond.Checked)
            {
                boolEnableRenewBond = "<Find>boolEnableRenewBond:false</Find><Replace>boolEnableRenewBond:true</Replace>";
            }

            // Enable antipattern checkbox
            if (checkBoxScriptProfiles_MotherlodeMine_Antipattern.Checked)
            {
                boolEnableAntipattern = "<Find>boolEnableAntipattern:false</Find><Replace>boolEnableAntipattern:true</Replace>";
            }

            // Enable hop world checkbox
            if (checkBoxScriptProfiles_MotherlodeMine_WorldHopping.Checked)
            {
                boolEnableHopWorlds = "<Find>boolEnableHopWorlds:false</Find><Replace>boolEnableHopWorlds:true</Replace>";
            }

            // Enable restocking checkbox
            if (checkBoxScriptProfiles_MotherlodeMine_Restocking.Checked)
            {
                boolEnableRestocking = "<Find>boolEnableRestocking:false</Find><Replace>boolEnableRestocking:true</Replace>";
            }

            // Enable sell loot checkbox
            if (checkBoxScriptProfiles_MotherlodeMine_SellLoot.Checked)
            {
                boolEnableSellLoot = "<Find>boolEnableSellLoot:false</Find><Replace>boolEnableSellLoot:true</Replace>";
            }

            // Enable dragon pickaxe checkbox
            if (checkBoxScriptProfiles_MotherlodeMine_DragonPickaxe.Checked)
            {
                boolEnableDragonPickaxe = "<Find>boolEnableDragonPickaxe:false</Find><Replace>boolEnableDragonPickaxe:true</Replace>";
            }

            // Buy outfit
            if (listBoxScriptProfiles_MotherlodeMine_SpendNuggets.SelectedItem != null && listBoxScriptProfiles_MotherlodeMine_SpendNuggets.SelectedItem.ToString() == "Buy Outfit")
            {
                boolEnableBuyOutfit = "<Find>boolEnableBuyOutfit:false</Find><Replace>boolEnableBuyOutfit:true</Replace>";
            }

            // Buy gem bag
            if (listBoxScriptProfiles_MotherlodeMine_SpendNuggets.SelectedItem != null && listBoxScriptProfiles_MotherlodeMine_SpendNuggets.SelectedItem.ToString() == "Buy Gem Bag")
            {
                boolEnableBuyGemBag = "<Find>boolEnableBuyGemBag:false</Find><Replace>boolEnableBuyGemBag:true</Replace>";
            }

            // Buy coal bag
            if (listBoxScriptProfiles_MotherlodeMine_SpendNuggets.SelectedItem != null && listBoxScriptProfiles_MotherlodeMine_SpendNuggets.SelectedItem.ToString() == "Buy Coal Bag")
            {
                boolEnableBuyCoalBag = "<Find>boolEnableBuyCoalBag:false</Find><Replace>boolEnableBuyCoalBag:true</Replace>";
            }

            // Buy soft clay packs
            if (listBoxScriptProfiles_MotherlodeMine_SpendNuggets.SelectedItem != null && listBoxScriptProfiles_MotherlodeMine_SpendNuggets.SelectedItem.ToString() == "Buy Softclay Packs")
            {
                boolEnableBuySoftClayPack = "<Find>boolEnableBuySoftClayPack:false</Find><Replace>boolEnableBuySoftClayPack:true</Replace>";
            }

            // Write to file
            using (StreamWriter writer = new StreamWriter(filepathProfileMotherlodeMine))
            {
                writer.WriteLine(boolEnableProfiles);
                writer.WriteLine(boolEnableDeathHandler);
                writer.WriteLine(boolEnableRenewBond);
                writer.WriteLine(boolEnableAntipattern);
                writer.WriteLine(boolEnableHopWorlds);
                writer.WriteLine(boolEnableRestocking);
                writer.WriteLine(boolEnableSellLoot);
                writer.WriteLine(boolEnableDragonPickaxe);
                writer.WriteLine(boolEnableBuyOutfit);
                writer.WriteLine(boolEnableBuyGemBag);
                writer.WriteLine(boolEnableBuyCoalBag);
                writer.WriteLine(boolEnableBuySoftClayPack);
                writer.WriteLine(selectMotherlodeMineSector);
            }

            MessageBox.Show("Profile successfully created.");

        }

    }
}
