using System.Diagnostics;

namespace jivaro_osrs_launcher
{
    public partial class formScriptProfilesMagicHouseAlcher : Form
    {
        public formScriptProfilesMagicHouseAlcher()
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

        // Scripts profiles panel - Save MagicHouseAlcher profile to folder
        private void buttonScriptProfiles_MagicHouseAlcher_SaveButton_Click(object sender, EventArgs e)
        {
            // Intialize variables
            string filepathProfileMagicHouseAlcher = Path.Combine(@"C:\\Users\\" + pc_username + "\\OSBot\\Data\\ProjectPact\\OSRS Script Factory\\Profiles\\fxMagic-HouseAlcher.txt");
            string itemToAlch = "<Find>Yew longbow</Find><Replace>Yew longbow</Replace>";
            string itemToAlchId = "<Find>855</Find><Replace>855</Replace>";

            // Enable death handler checkbox
            if (checkBoxScriptProfiles_MagicHouseAlcher_DeathHandler.Checked)
            {
                boolEnableDeathHandler = "<Find>boolEnableDeathHandler:false</Find><Replace>boolEnableDeathHandler:true</Replace>";
            }

            // Enable renew bond checkbox
            if (checkBoxScriptProfiles_MagicHouseAlcher_RenewBond.Checked)
            {
                boolEnableRenewBond = "<Find>boolEnableRenewBond:false</Find><Replace>boolEnableRenewBond:true</Replace>";
            }

            // Enable antipattern checkbox
            if (checkBoxScriptProfiles_MagicHouseAlcher_Antipattern.Checked)
            {
                boolEnableAntipattern = "<Find>boolEnableAntipattern:false</Find><Replace>boolEnableAntipattern:true</Replace>";
            }

            // Enable hop world checkbox
            if (checkBoxScriptProfiles_MagicHouseAlcher_WorldHopping.Checked)
            {
                boolEnableHopWorlds = "<Find>boolEnableHopWorlds:false</Find><Replace>boolEnableHopWorlds:true</Replace>";
            }

            // Enable restocking checkbox
            if (checkBoxScriptProfiles_MagicHouseAlcher_Restocking.Checked)
            {
                boolEnableRestocking = "<Find>boolEnableRestocking:false</Find><Replace>boolEnableRestocking:true</Replace>";
            }

            // Enable sell loot checkbox
            if (checkBoxScriptProfiles_MagicHouseAlcher_SellLoot.Checked)
            {
                boolEnableSellLoot = "<Find>boolEnableSellLoot:false</Find><Replace>boolEnableSellLoot:true</Replace>";
            }

            // Item to alch
            if (!string.IsNullOrEmpty(textBoxScriptProfiles_MagicHouseAlcher_ItemToAlch.Text))
            {
                itemToAlch = "<Find>Yew longbow</Find><Replace>" + textBoxScriptProfiles_MagicHouseAlcher_ItemToAlch.Text + "</Replace>";
            }

            // Item to alch id
            if (!string.IsNullOrEmpty(textBoxScriptProfiles_MagicHouseAlcher_ItemId.Text))
            {
                itemToAlchId = "<Find>855</Find><Replace>" + textBoxScriptProfiles_MagicHouseAlcher_ItemId.Text + "</Replace>";
            }

            // Write to file
            using (StreamWriter writer = new StreamWriter(filepathProfileMagicHouseAlcher))
            {
                writer.WriteLine(boolEnableProfiles);
                writer.WriteLine(boolEnableDeathHandler);
                writer.WriteLine(boolEnableRenewBond);
                writer.WriteLine(boolEnableAntipattern);
                writer.WriteLine(boolEnableHopWorlds);
                writer.WriteLine(boolEnableRestocking);
                writer.WriteLine(boolEnableSellLoot);
                writer.WriteLine(itemToAlch);
                writer.WriteLine(itemToAlchId);
            }

            MessageBox.Show("Profile successfully created.");

        }

        private void buttonScriptProfiles_MagicHouseAlcher_SearchForId_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.osrsbox.com/tools/item-search/");
        }
    }
}
