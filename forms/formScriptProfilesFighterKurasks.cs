using System.ComponentModel;

namespace jivaro_osrs_launcher
{
    public partial class formScriptProfilesFighterKurasks : Form
    {
        public formScriptProfilesFighterKurasks()
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

        private void buttonScriptProfiles_Kurasks_SaveButton_Click(object sender, EventArgs e)
        {

            // Intialize variables
            string filepathProfileKurasks = Path.Combine(@"C:\\Users\\" + pc_username + "\\OSBot\\Data\\ProjectPact\\OSRS Script Factory\\Profiles\\fxFighter-Kurasks.txt");
            string boolEnableHighAlching = "<Find>boolEnableHighAlching:false</Find><Replace>boolEnableHighAlching:false</Replace>";
            string selectMode = "<Find>Ranged/*/Melee</Find><Replace>" + comboBoxScriptProfiles_Kurasks_SelectMode.SelectedItem.ToString() + "</Replace>";
            string selectPotion = "<Find>None/*/RangingPotion/*/CombatPotion/*/SuperCombatPotion</Find><Replace>" + comboBoxScriptProfiles_Kurasks_SelectPotion.SelectedItem.ToString() + "</Replace>";
            string rangedGearArrow = "<Find>Broad bolts</Find><Replace>" + textBoxScriptProfiles_Kurasks_RangedArrow.Text + "</Replace>";
            string rangedGearCape = "<Find>Ava's</Find><Replace>" + textBoxScriptProfiles_Kurasks_RangedCape.Text + "</Replace>";
            string rangedGearChest = "<Find>Black d'hide body</Find><Replace>" + textBoxScriptProfiles_Kurasks_RangedChest.Text + "</Replace>";
            string rangedGearFeet = "<Find>Snakeskin boots</Find><Replace>" + textBoxScriptProfiles_Kurasks_RangedFeet.Text + "</Replace>";
            string rangedGearHands = "<Find>Black d'hide vambraces</Find><Replace>" + textBoxScriptProfiles_Kurasks_RangedHands.Text + "</Replace>";
            string rangedGearHead = "<Find>Snakeskin bandana</Find><Replace>" + textBoxScriptProfiles_Kurasks_RangedHead.Text + "</Replace>";
            string rangedGearLegs = "<Find>Black d'hide chaps</Find><Replace>" + textBoxScriptProfiles_Kurasks_RangedLegs.Text + "</Replace>";
            string rangedGearRing = "<Find>Ring of wealth</Find><Replace>" + textBoxScriptProfiles_Kurasks_RangedRing.Text + "</Replace>";
            string rangedGearWeapon = "<Find>Rune crossbow</Find><Replace>" + textBoxScriptProfiles_Kurasks_RangedWeapon.Text + "</Replace>";
            string meleeGearArrow = "<Find>None</Find><Replace>" + textBoxScriptProfiles_Kurasks_MeleeArrow.Text + "</Replace>";
            string meleeGearCape = "<Find>Zamorak cloak</Find><Replace>" + textBoxScriptProfiles_Kurasks_MeleeCape.Text + "</Replace>";
            string meleeGearChest = "<Find>Obsidian platebody</Find><Replace>" + textBoxScriptProfiles_Kurasks_MeleeChest.Text + "</Replace>";
            string meleeGearFeet = "<Find>Dragon boots</Find><Replace>" + textBoxScriptProfiles_Kurasks_MeleeFeet.Text + "</Replace>";
            string meleeGearHands = "<Find>Granite gloves</Find><Replace>" + textBoxScriptProfiles_Kurasks_MeleeHands.Text + "</Replace>";
            string meleeGearHead = "<Find>Obsidian helmet</Find><Replace>" + textBoxScriptProfiles_Kurasks_MeleeHead.Text + "</Replace>";
            string meleeGearLegs = "<Find>Obsidian platelegs</Find><Replace>" + textBoxScriptProfiles_Kurasks_MeleeLegs.Text + "</Replace>";
            string meleeGearRing = "<Find>Warrior ring</Find><Replace>" + textBoxScriptProfiles_Kurasks_MeleeRing.Text + "</Replace>";
            string meleeGearWeapon = "<Find>Abyssal whip</Find><Replace>" + textBoxScriptProfiles_Kurasks_MeleeWeapon.Text + "</Replace>";
            string miscGearAmulet = "<Find>Amulet of glory</Find><Replace>" + textBoxScriptProfiles_Kurasks_MiscAmulet.Text + "</Replace>";
            string miscGearShield = "<Find>Mirror shield</Find><Replace>" + textBoxScriptProfiles_Kurasks_MiscShield.Text + "</Replace>";


            // Enable death handler checked
            if (checkBoxScriptProfiles_Kurasks_DeathHandler.Checked)
            {
                boolEnableDeathHandler = "<Find>boolEnableDeathHandler:false</Find><Replace>boolEnableDeathHandler:true</Replace>";
            }

            // Enable renew bond checked
            if (checkBoxScriptProfiles_Kurasks_RenewBond.Checked)
            {
                boolEnableRenewBond = "<Find>boolEnableRenewBond:false</Find><Replace>boolEnableRenewBond:true</Replace>";
            }

            // Enable antipattern checked
            if (checkBoxScriptProfiles_Kurasks_Antipattern.Checked)
            {
                boolEnableAntipattern = "<Find>boolEnableAntipattern:false</Find><Replace>boolEnableAntipattern:true</Replace>";
            }

            // Enable hop world checked
            if (checkBoxScriptProfiles_Kurasks_WorldHopping.Checked)
            {
                boolEnableHopWorlds = "<Find>boolEnableHopWorlds:false</Find><Replace>boolEnableHopWorlds:true</Replace>";
            }

            // Enable restocking checked
            if (checkBoxScriptProfiles_Kurasks_Restocking.Checked)
            {
                boolEnableRestocking = "<Find>boolEnableRestocking:false</Find><Replace>boolEnableRestocking:true</Replace>";
            }

            // Enable sell loot checkbox checked
            if (checkBoxScriptProfiles_Kurasks_SellLoot.Checked)
            {
                boolEnableSellLoot = "<Find>boolEnableSellLoot:false</Find><Replace>boolEnableSellLoot:true</Replace>";
            }

            // Enable High Alching checked
            if (checkBoxScriptProfiles_Kurasks_HighAlching.Checked)
            {
                boolEnableHighAlching = "<Find>boolEnableHighAlching:false</Find><Replace>boolEnableHighAlching:true</Replace>";
            }

            // Write to file
            using (StreamWriter writer = new StreamWriter(filepathProfileKurasks))
            {
                writer.WriteLine(boolEnableProfiles);
                writer.WriteLine(boolEnableDeathHandler);
                writer.WriteLine(boolEnableRenewBond);
                writer.WriteLine(boolEnableAntipattern);
                writer.WriteLine(boolEnableHopWorlds);
                writer.WriteLine(boolEnableRestocking);
                writer.WriteLine(boolEnableSellLoot);
                writer.WriteLine(boolEnableHighAlching);
                writer.WriteLine(selectMode);
                writer.WriteLine(selectPotion);
                writer.WriteLine(rangedGearArrow);
                writer.WriteLine(rangedGearCape);
                writer.WriteLine(rangedGearChest);
                writer.WriteLine(rangedGearFeet);
                writer.WriteLine(rangedGearHands);
                writer.WriteLine(rangedGearHead);
                writer.WriteLine(rangedGearLegs);
                writer.WriteLine(rangedGearRing);
                writer.WriteLine(rangedGearWeapon);
                writer.WriteLine(meleeGearArrow);
                writer.WriteLine(meleeGearCape);
                writer.WriteLine(meleeGearChest);
                writer.WriteLine(meleeGearFeet);
                writer.WriteLine(meleeGearHands);
                writer.WriteLine(meleeGearHead);
                writer.WriteLine(meleeGearLegs);
                writer.WriteLine(meleeGearRing);
                writer.WriteLine(meleeGearWeapon);
                writer.WriteLine(miscGearAmulet);
                writer.WriteLine(miscGearShield);
            }

            MessageBox.Show("Profile successfully created.");

        }

        // Require Input on textboxes
        public void textBoxScriptProfiles_InputRequired_Validating(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            // Ensure the textbox always has an input
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show("This field is required");
                e.Cancel = true;
            }
        }
        private void formScriptProfilesFighterKurasks_Load(object sender, EventArgs e)
        {
            comboBoxScriptProfiles_Kurasks_SelectMode.SelectedIndex = 0;
            comboBoxScriptProfiles_Kurasks_SelectPotion.SelectedIndex = 0;
        }
    }
}
