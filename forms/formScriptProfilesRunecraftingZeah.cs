namespace jivarosft
{
    public partial class formScriptProfilesRunecraftingZeah : Form
    {
        public formScriptProfilesRunecraftingZeah()
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

        // Scripts profiles panel - Save runecrafting abyss profile to folder
        private void buttonScriptProfiles_RunecraftingZeah_SaveButton_Click(object sender, EventArgs e)
        {
            // Intialize variables
            string filepathProfileRunecraftingZeah = Path.Combine(@"C:\\Users\\" + pc_username + "\\OSBot\\Data\\ProjectPact\\OSRS Script Factory\\Profiles\\fxRunecrafting-Zeah.txt");
            string boolEnableBuyDragonPickaxe = "<Find>boolEnableBuyDragonPickaxe:false</Find><Replace>boolEnableBuyDragonPickaxe:false</Replace>";
            string boolEnableIronMan = "<Find>boolEnableIronMan:false</Find><Replace>boolEnableIronMan:false</Replace>";
            string boolEnableSwitchSpellbook = "<Find>boolEnableSwitchSpellbook:false</Find><Replace>boolEnableSwitchSpellbook:false</Replace>";

            // Enable death handler checkbox
            if (checkBoxScriptProfiles_RunecraftingZeah_DeathHandler.Checked)
            {
                boolEnableDeathHandler = "<Find>boolEnableDeathHandler:false</Find><Replace>boolEnableDeathHandler:true</Replace>";
            }

            // Enable renew bond checkbox
            if (checkBoxScriptProfiles_RunecraftingZeah_RenewBond.Checked)
            {
                boolEnableRenewBond = "<Find>boolEnableRenewBond:false</Find><Replace>boolEnableRenewBond:true</Replace>";
            }

            // Enable antipattern checkbox
            if (checkBoxScriptProfiles_RunecraftingZeah_Antipattern.Checked)
            {
                boolEnableAntipattern = "<Find>boolEnableAntipattern:false</Find><Replace>boolEnableAntipattern:true</Replace>";
            }

            // Enable hop world checkbox
            if (checkBoxScriptProfiles_RunecraftingZeah_WorldHopping.Checked)
            {
                boolEnableHopWorlds = "<Find>boolEnableHopWorlds:false</Find><Replace>boolEnableHopWorlds:true</Replace>";
            }

            // Enable restocking checkbox
            if (checkBoxScriptProfiles_RunecraftingZeah_Restocking.Checked)
            {
                boolEnableRestocking = "<Find>boolEnableRestocking:false</Find><Replace>boolEnableRestocking:true</Replace>";
            }

            // Enable sell loot checkbox
            if (checkBoxScriptProfiles_RunecraftingZeah_SellLoot.Checked)
            {
                boolEnableSellLoot = "<Find>boolEnableSellLoot:false</Find><Replace>boolEnableSellLoot:true</Replace>";
            }

            // Enable switch spellbook checkbox
            if (checkBoxScriptProfiles_RunecraftingZeah_ArceuusHomeTeleport.Checked)
            {
                boolEnableSwitchSpellbook = "<Find>boolEnableSwitchSpellbook:false</Find><Replace>boolEnableSwitchSpellbook:true</Replace>";
            }

            // Enable dragon pickaxe checkbox
            if (checkBoxScriptProfiles_RunecraftingZeah_DragonPickaxe.Checked)
            {
                boolEnableBuyDragonPickaxe = "<Find>boolEnableBuyDragonPickaxe:false</Find><Replace>boolEnableBuyDragonPickaxe:true</Replace>";
            }

            // Enable iron man checkbox
            if (checkBoxScriptProfiles_RunecraftingZeah_IronMan.Checked)
            {
                boolEnableIronMan = "<Find>boolEnableIronMan:false</Find><Replace>boolEnableIronMan:true</Replace>";
            }


            // Write to file
            using (StreamWriter writer = new StreamWriter(filepathProfileRunecraftingZeah))
            {
                writer.WriteLine(boolEnableProfiles);
                writer.WriteLine(boolEnableDeathHandler);
                writer.WriteLine(boolEnableRenewBond);
                writer.WriteLine(boolEnableAntipattern);
                writer.WriteLine(boolEnableHopWorlds);
                writer.WriteLine(boolEnableRestocking);
                writer.WriteLine(boolEnableSellLoot);
                writer.WriteLine(boolEnableSwitchSpellbook);
                writer.WriteLine(boolEnableBuyDragonPickaxe);
                writer.WriteLine(boolEnableIronMan);
            }

            MessageBox.Show("Profile successfully created.");
        }
    }
}
