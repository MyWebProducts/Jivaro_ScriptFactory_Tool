namespace jivaro_osrs_launcher
{
    public partial class formScriptProfilesCookingNormal : Form
    {
        public formScriptProfilesCookingNormal()
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
        private void buttonScriptProfiles_CookingNormal_SaveButton_Click(object sender, EventArgs e)
        {
            // Intialize variables
            string filepathProfileCookingNormal = Path.Combine(@"C:\\Users\\" + pc_username + "\\OSBot\\Data\\ProjectPact\\OSRS Script Factory\\Profiles\\fxCooking-Normal.txt");
            string selectCookingArea = "<Find>AlKharid/*/Falador/*/Hosidius/*/Zanaris/*/RoguesDen</Find><Replace>" + comboBoxScriptProfiles_CookingNormal_SelectCookingArea.SelectedItem.ToString() + "</Replace>";
            string selectCookingDish = "<Find>Progressive/*/Shrimps/*/Trout/*/Salmon/*/Lobster/*/Swordfish/*/Monkfish/*/Shark/*/Anglerfish</Find><Replace>" + comboBoxScriptProfiles_CookingNormal_SelectDish.SelectedItem.ToString() + "</Replace>";

            // Enable death handler checkbox
            if (checkBoxScriptProfiles_CookingNormal_DeathHandler.Checked)
            {
                boolEnableDeathHandler = "<Find>boolEnableDeathHandler:false</Find><Replace>boolEnableDeathHandler:true</Replace>";
            }

            // Enable renew bond checkbox
            if (checkBoxScriptProfiles_CookingNormal_RenewBond.Checked)
            {
                boolEnableRenewBond = "<Find>boolEnableRenewBond:false</Find><Replace>boolEnableRenewBond:true</Replace>";
            }

            // Enable antipattern checkbox
            if (checkBoxScriptProfiles_CookingNormal_Antipattern.Checked)
            {
                boolEnableAntipattern = "<Find>boolEnableAntipattern:false</Find><Replace>boolEnableAntipattern:true</Replace>";
            }

            // Enable hop world checkbox
            if (checkBoxScriptProfiles_CookingNormal_WorldHopping.Checked)
            {
                boolEnableHopWorlds = "<Find>boolEnableHopWorlds:false</Find><Replace>boolEnableHopWorlds:true</Replace>";
            }

            // Enable restocking checkbox
            if (checkBoxScriptProfiles_CookingNormal_Restocking.Checked)
            {
                boolEnableRestocking = "<Find>boolEnableRestocking:false</Find><Replace>boolEnableRestocking:true</Replace>";
            }

            // Enable sell loot checkbox
            if (checkBoxScriptProfiles_CookingNormal_SellLoot.Checked)
            {
                boolEnableSellLoot = "<Find>boolEnableSellLoot:false</Find><Replace>boolEnableSellLoot:true</Replace>";
            }

            // Write to file
            using (StreamWriter writer = new StreamWriter(filepathProfileCookingNormal))
            {
                writer.WriteLine(boolEnableProfiles);
                writer.WriteLine(boolEnableDeathHandler);
                writer.WriteLine(boolEnableRenewBond);
                writer.WriteLine(boolEnableAntipattern);
                writer.WriteLine(boolEnableHopWorlds);
                writer.WriteLine(boolEnableRestocking);
                writer.WriteLine(boolEnableSellLoot);
                writer.WriteLine(selectCookingArea);
                writer.WriteLine(selectCookingDish);
            }

            MessageBox.Show("Profile successfully created.");

        }


        private void formScriptProfiles_CookingNormal_Load(object sender, EventArgs e)
        {
            comboBoxScriptProfiles_CookingNormal_SelectDish.SelectedIndex = 0;
            comboBoxScriptProfiles_CookingNormal_SelectCookingArea.SelectedIndex = 0;
        }

    }
}
