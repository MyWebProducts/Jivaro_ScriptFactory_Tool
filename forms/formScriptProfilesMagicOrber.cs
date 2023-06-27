using System.ComponentModel;

namespace jivarosft
{
    public partial class formScriptProfilesMagicOrber : Form
    {
        public formScriptProfilesMagicOrber()
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

        // Cancel non number input and set the limit to 99 on textchange
        public void textBoxGlobal_CancelNonNumber_SetLimitTo99_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            var textBox = sender as System.Windows.Forms.TextBox;
            if (textBox != null && textBox.Text.Length >= 99)
            {
                e.Handled = true;
            }
        }

        // Require Input on textboxes
        public void textBox_InputRequired_Validating(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            // Ensure the textbox always has an input
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show("This field is required");
                e.Cancel = true;
            }
        }

        //
        // Script Profiles Panel - Save magic orber profile to folder
        //

        private void buttonScriptProfiles_MagicOrber_SaveButton_Click(object sender, EventArgs e)
        {

            // Intialize variables
            string filepathProfileMagicOrber = Path.Combine(@"C:\\Users\\" + pc_username + "\\OSBot\\Data\\ProjectPact\\OSRS Script Factory\\Profiles\\fxMagic-Orber.txt");
            string boolEnableStaminaPotions = "<Find>boolEnableStaminaPotions:false</Find><Replace>boolEnableStaminaPotions:false</Replace>";
            string boolEnableUseRandomCape = "<Find>boolEnableUseRandomCape:false</Find><Replace>boolEnableUseRandomCape:false</Replace>";
            string trainAgility = "<Find>1029384756</Find><Replace>" + textBoxScriptProfiles_MagicOrber_TrainAgility.Text + "</Replace>";
            string trainMelee = "<Find>0192837465</Find><Replace>" + textBoxScriptProfiles_MagicOrber_TrainMelee.Text + "</Replace>";
            string selectOrb = "<Find>Earth/*/Air</Find><Replace>" + comboBoxScriptProfiles_MagicOrber_SelectOrb.SelectedItem.ToString() + "</Replace>";

            // Enable death handler checkbox
            if (checkBoxScriptProfiles_MagicOrber_DeathHandler.Checked)
            {
                boolEnableDeathHandler = "<Find>boolEnableDeathHandler:false</Find><Replace>boolEnableDeathHandler:true</Replace>";
            }

            // Enable renew bond checkbox
            if (checkBoxScriptProfiles_MagicOrber_RenewBond.Checked)
            {
                boolEnableRenewBond = "<Find>boolEnableRenewBond:false</Find><Replace>boolEnableRenewBond:true</Replace>";
            }

            // Enable antipattern checkbox
            if (checkBoxScriptProfiles_MagicOrber_Antipattern.Checked)
            {
                boolEnableAntipattern = "<Find>boolEnableAntipattern:false</Find><Replace>boolEnableAntipattern:true</Replace>";
            }

            // Enable hop world checkbox
            if (checkBoxScriptProfiles_MagicOrber_WorldHopping.Checked)
            {
                boolEnableHopWorlds = "<Find>boolEnableHopWorlds:false</Find><Replace>boolEnableHopWorlds:true</Replace>";
            }

            // Enable restocking checkbox
            if (checkBoxScriptProfiles_MagicOrber_Restocking.Checked)
            {
                boolEnableRestocking = "<Find>boolEnableRestocking:false</Find><Replace>boolEnableRestocking:true</Replace>";
            }

            // Enable sell loot checkbox
            if (checkBoxScriptProfiles_MagicOrber_SellLoot.Checked)
            {
                boolEnableSellLoot = "<Find>boolEnableSellLoot:false</Find><Replace>boolEnableSellLoot:true</Replace>";
            }

            // Enable bank coal checkbox
            if (checkBoxScriptProfiles_MagicOrber_UseStaminas.Checked)
            {
                boolEnableStaminaPotions = "<Find>boolEnableStaminaPotions:false</Find><Replace>boolEnableStaminaPotions:true</Replace>";
            }

            // Enable bank coal checkbox
            if (checkBoxScriptProfiles_MagicOrber_UseRandomCape.Checked)
            {
                boolEnableUseRandomCape = "<Find>boolEnableUseRandomCape:false</Find><Replace>boolEnableUseRandomCape:true</Replace>";
            }

            // Write to file
            using (StreamWriter writer = new StreamWriter(filepathProfileMagicOrber))
            {
                writer.WriteLine(boolEnableProfiles);
                writer.WriteLine(boolEnableDeathHandler);
                writer.WriteLine(boolEnableRenewBond);
                writer.WriteLine(boolEnableAntipattern);
                writer.WriteLine(boolEnableHopWorlds);
                writer.WriteLine(boolEnableRestocking);
                writer.WriteLine(boolEnableSellLoot);
                writer.WriteLine(boolEnableStaminaPotions);
                writer.WriteLine(boolEnableUseRandomCape);
                writer.WriteLine(trainAgility);
                writer.WriteLine(trainMelee);
                writer.WriteLine(selectOrb);
            }

            MessageBox.Show("Profile successfully created.");

        }

        // Form load
        private void formScriptProfiles_MagicOrber_Load(object sender, EventArgs e)
        {
            comboBoxScriptProfiles_MagicOrber_SelectOrb.SelectedIndex = 0;
        }



    }
}
