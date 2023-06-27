using System.ComponentModel;

namespace jivarosft
{
    public partial class formScriptProfilesSlayerAIO : Form
    {
        public formScriptProfilesSlayerAIO()
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
        private void buttonScriptProfiles_SlayerAIO_SaveButton_Click(object sender, EventArgs e)
        {
            // Intialize variables
            string filepathProfileSlayerAIO = Path.Combine(@"C:\\Users\\" + pc_username + "\\OSBot\\Data\\ProjectPact\\OSRS Script Factory\\Profiles\\fxSlayer-AIO.txt");
            string gearMeleeChest = "<Find>Rune chainbody</Find><Replace>" + textBoxScriptProfiles_SlayeAIO_GearMelee_Chest.Text + "</Replace>";
            string gearMeleeFeetOne = "<Find>Rune boots</Find><Replace>" + textBoxScriptProfiles_SlayeAIO_GearMelee_FeetOne.Text + "</Replace>";
            string gearMeleeFeetTwo = "<Find>Dragon boots</Find><Replace>" + textBoxScriptProfiles_SlayeAIO_GearMelee_FeetTwo.Text + "</Replace>";
            string gearMeleeHeadgear = "<Find>Black mask</Find><Replace>" + textBoxScriptProfiles_SlayeAIO_GearMelee_Headgear.Text + "</Replace>";
            string gearMeleeLegs = "<Find>Rune platelegs</Find><Replace>" + textBoxScriptProfiles_SlayeAIO_GearMelee_Legs.Text + "</Replace>";
            string gearMeleeShield = "<Find>Rune kiteshield</Find><Replace>" + textBoxScriptProfiles_SlayeAIO_GearMelee_Shield.Text + "</Replace>";
            string gearMeleeWeaponOne = "<Find>Dragon sword</Find><Replace>" + textBoxScriptProfiles_SlayeAIO_GearMelee_WeaponOne.Text + "</Replace>";
            string gearMeleeWeaponTwo = "<Find>Abyssal whip</Find><Replace>" + textBoxScriptProfiles_SlayeAIO_GearMelee_WeaponTwo.Text + "</Replace>";
            string gearRangedChestOne = "<Find>Blue d'hide body</Find><Replace>" + textBoxScriptProfiles_SlayeAIO_GearRanged_ChestOne.Text + "</Replace>";
            string gearRangedChestTwo = "<Find>Black d'hide body</Find><Replace>" + textBoxScriptProfiles_SlayeAIO_GearRanged_ChestTwo.Text + "</Replace>";
            string gearRangedFeet = "<Find>Snakeskin boots</Find><Replace>" + textBoxScriptProfiles_SlayeAIO_GearRanged_Feet.Text + "</Replace>";
            string gearRangedHandsOne = "<Find>Blue d'hide vambraces</Find><Replace>" + textBoxScriptProfiles_SlayeAIO_GearRanged_HandsOne.Text + "</Replace>";
            string gearRangedHandsTwo = "<Find>Black d'hide vambraces</Find><Replace>" + textBoxScriptProfiles_SlayeAIO_GearRanged_HandsTwo.Text + "</Replace>";
            string gearRangedHeadgear = "<Find>Snakeskin bandana</Find><Replace>" + textBoxScriptProfiles_SlayeAIO_GearRanged_Headgear.Text + "</Replace>";
            string gearRangedLegsOne = "<Find>Blue d'hide chaps</Find><Replace>" + textBoxScriptProfiles_SlayeAIO_GearRanged_LegsOne.Text + "</Replace>";
            string gearRangedLegsTwo = "<Find>Black d'hide chaps</Find><Replace>" + textBoxScriptProfiles_SlayeAIO_GearRanged_LegsTwo.Text + "</Replace>";
            string gearRangedShieldOne = "<Find>Blue d'hide shield</Find><Replace>" + textBoxScriptProfiles_SlayeAIO_GearRanged_ShieldOne.Text + "</Replace>";
            string gearRangedShieldTwo = "<Find>Black d'hide shield</Find><Replace>" + textBoxScriptProfiles_SlayeAIO_GearRanged_ShieldTwo.Text + "</Replace>";
            string gearRangedWeaponOne = "<Find>Adamant crossbow</Find><Replace>" + textBoxScriptProfiles_SlayeAIO_GearRanged_WeaponOne.Text + "</Replace>";
            string gearRangedWeaponTwo = "<Find>Rune crossbow</Find><Replace>" + textBoxScriptProfiles_SlayeAIO_GearRanged_WeaponTwo.Text + "</Replace>";
            string gearMagicChest = "<Find>Mystic robe top</Find><Replace>" + textboxScriptProfiles_SlayerAIO_GearMagic_Chest.Text + "</Replace>";
            string gearMagicHeadgear = "<Find>Mystic hat</Find><Replace>" + textboxScriptProfiles_SlayerAIO_GearMagic_Headgear.Text + "</Replace>";
            string gearMagicLegs = "<Find>Mystic robe bottom</Find><Replace>" + textboxScriptProfiles_SlayerAIO_GearMagic_Legs.Text + "</Replace>";
            string gearMagicWeapon = "<Find>Mystic lava staff</Find><Replace>" + textboxScriptProfiles_SlayerAIO_GearMagic_Weapon.Text + "</Replace>";
            string gearMiscCape = "<Find>Armadyl cloak</Find><Replace>" + textboxScriptProfiles_SlayerAIO_GearMisc_Cape.Text + "</Replace>";
            string gearMiscHands = "<Find>Combat bracelet</Find><Replace>" + textboxScriptProfiles_SlayerAIO_GearMisc_Hands.Text + "</Replace>";

            // Enable death handler checkbox
            if (checkBoxScriptProfiles_SlayerAIO_GeneralSettings_DeathHandler.Checked)
            {
                boolEnableDeathHandler = "<Find>boolEnableDeathHandler:false</Find><Replace>boolEnableDeathHandler:true</Replace>";
            }

            // Enable renew bond checkbox
            if (checkBoxScriptProfiles_SlayerAIO_GeneralSettings_RenewBond.Checked)
            {
                boolEnableRenewBond = "<Find>boolEnableRenewBond:false</Find><Replace>boolEnableRenewBond:true</Replace>";
            }

            // Enable antipattern checkbox
            if (checkBoxScriptProfiles_SlayerAIO_GeneralSettings_Antipattern.Checked)
            {
                boolEnableAntipattern = "<Find>boolEnableAntipattern:false</Find><Replace>boolEnableAntipattern:true</Replace>";
            }

            // Enable hop world checkbox
            if (checkBoxScriptProfiles_SlayerAIO_GeneralSettings_WorldHopping.Checked)
            {
                boolEnableHopWorlds = "<Find>boolEnableHopWorlds:false</Find><Replace>boolEnableHopWorlds:true</Replace>";
            }

            // Enable restocking checkbox
            if (checkBoxScriptProfiles_SlayerAIO_GeneralSettings_Restocking.Checked)
            {
                boolEnableRestocking = "<Find>boolEnableRestocking:false</Find><Replace>boolEnableRestocking:true</Replace>";
            }

            // Enable sell loot checkbox
            if (checkBoxScriptProfiles_SlayerAIO_GeneralSettings_SellLoot.Checked)
            {
                boolEnableSellLoot = "<Find>boolEnableSellLoot:false</Find><Replace>boolEnableSellLoot:true</Replace>";
            }

            // Write to file
            using (StreamWriter writer = new StreamWriter(filepathProfileSlayerAIO))
            {
                writer.WriteLine(boolEnableProfiles);
                writer.WriteLine(boolEnableDeathHandler);
                writer.WriteLine(boolEnableRenewBond);
                writer.WriteLine(boolEnableAntipattern);
                writer.WriteLine(boolEnableHopWorlds);
                writer.WriteLine(boolEnableRestocking);
                writer.WriteLine(boolEnableSellLoot);
                writer.WriteLine(gearMagicChest);
                writer.WriteLine(gearMagicHeadgear);
                writer.WriteLine(gearMagicLegs);
                writer.WriteLine(gearMagicWeapon);
                writer.WriteLine(gearMeleeChest);
                writer.WriteLine(gearMeleeFeetOne);
                writer.WriteLine(gearMeleeFeetTwo);
                writer.WriteLine(gearMeleeHeadgear);
                writer.WriteLine(gearMeleeLegs);
                writer.WriteLine(gearMeleeShield);
                writer.WriteLine(gearMeleeWeaponOne);
                writer.WriteLine(gearMeleeWeaponTwo);
                writer.WriteLine(gearMiscCape);
                writer.WriteLine(gearMiscHands);
                writer.WriteLine(gearRangedChestOne);
                writer.WriteLine(gearRangedChestTwo);
                writer.WriteLine(gearRangedFeet);
                writer.WriteLine(gearRangedHandsOne);
                writer.WriteLine(gearRangedHandsTwo);
                writer.WriteLine(gearRangedHeadgear);
                writer.WriteLine(gearRangedLegsOne);
                writer.WriteLine(gearRangedLegsTwo);
                writer.WriteLine(gearRangedShieldOne);
                writer.WriteLine(gearRangedShieldTwo);
                writer.WriteLine(gearRangedWeaponOne);
                writer.WriteLine(gearRangedWeaponTwo);
            }

            MessageBox.Show("Profile successfully created.");

        }

        public void textBoxGlobal_InputRequired_Validating(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            // Ensure the textbox always has an input
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show("This field is required");
                e.Cancel = true;
            }
        }

    }
}
