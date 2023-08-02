using System.ComponentModel;

namespace jivaro_osrs_launcher
{
    public partial class formScriptProfilesAccountBuilder : Form
    {
        public formScriptProfilesAccountBuilder()
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

        // Cancel Non-Numbers from textbox input
        public void textBoxGlobal_CancelNonNumberInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

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
        // Script Profiles Panel - Save account builder profile to folder
        //

        private void buttonScriptProfiles_AccountBuilder_SaveButton_Click(object sender, EventArgs e)
        {

            // Intialize variables
            string filepathProfileAccountBuilder = Path.Combine(@"C:\\Users\\" + pc_username + "\\OSBot\\Data\\ProjectPact\\OSRS Script Factory\\Profiles\\fxAccountBuilder.txt");
            string boolEnableStopScriptAtGoal = "<Find>boolEnableStopScriptAtGoal:false</Find><Replace>boolEnableStopScriptAtGoal:false</Replace>";
            string boolEnableBankCoal = "<Find>boolEnableBankCoal:false</Find><Replace>boolEnableBankCoal:false</Replace>";
            string boolEnableRooftops = "<Find>boolEnableRooftops:false</Find><Replace>boolEnableRooftops:false</Replace>";
            string boolEnableNoGpStart = "<Find>boolEnableNoGpStart:false</Find><Replace>boolEnableNoGpStart:false</Replace>";
            string boolEnableLongRangeTraining = "<Find>boolEnableLongRangeTraining:false</Find><Replace>boolEnableLongRangeTraining:false</Replace>";
            string boolEnableQuests = "<Find>boolEnableQuests:false</Find><Replace>boolEnableQuests:false</Replace>";
            string questCooksAssistant = "<Find>boolEnableCooksAssistant:false</Find><Replace>boolEnableCooksAssistant:false</Replace>";
            string questGoblinDiplomacy = "<Find>boolEnableGoblinDiplomacy:false</Find><Replace>boolEnableGoblinDiplomacy:false</Replace>";
            string questRomeoAndJuliet = "<Find>boolEnableRomeoAndJuliet:false</Find><Replace>boolEnableRomeoAndJuliet:false</Replace>";
            string questRuneMysteries = "<Find>boolEnableRuneMysteries:false</Find><Replace>boolEnableRuneMysteries:false</Replace>";
            string questSheepShearer = "<Find>boolEnableSheepShearer:false</Find><Replace>boolEnableSheepShearer:false</Replace>";
            string questXMarksTheSpot = "<Find>boolEnableXMarksTheSpot:false</Find><Replace>boolEnableXMarksTheSpot:false</Replace>";
            string questDruidicRitual = "<Find>boolEnableDruidicRitual:false</Find><Replace>boolEnableDruidicRitual:false</Replace>";
            string questLostCity = "<Find>boolEnableLostCity:false</Find><Replace>boolEnableLostCity:false</Replace>";
            string questMageArenaOne = "<Find>boolEnableMageArenaOne:false</Find><Replace>boolEnableMageArenaOne:false</Replace>";
            string activityDuration;
            string activityDurationVariation;
            string goldFarmingDuration;
            int intGoldFarmingDuration;
            int intActivityDuration;
            int intActivityDurationVariation;

            // Enable death handler checkbox
            if (checkBoxScriptProfiles_AccountBuilder_DeathHandler.Checked)
            {
                boolEnableDeathHandler = "<Find>boolEnableDeathHandler:false</Find><Replace>boolEnableDeathHandler:true</Replace>";
            }

            // Enable renew bond checkbox
            if (checkBoxScriptProfiles_AccountBuilder_RenewBond.Checked)
            {
                boolEnableRenewBond = "<Find>boolEnableRenewBond:false</Find><Replace>boolEnableRenewBond:true</Replace>";
            }

            // Enable antipattern checkbox
            if (checkBoxScriptProfiles_AccountBuilder_Antipattern.Checked)
            {
                boolEnableAntipattern = "<Find>boolEnableAntipattern:false</Find><Replace>boolEnableAntipattern:true</Replace>";
            }

            // Enable hop world checkbox
            if (checkBoxScriptProfiles_AccountBuilder_WorldHopping.Checked)
            {
                boolEnableHopWorlds = "<Find>boolEnableHopWorlds:false</Find><Replace>boolEnableHopWorlds:true</Replace>";
            }

            // Enable restocking checkbox
            if (checkBoxScriptProfiles_AccountBuilder_Restocking.Checked)
            {
                boolEnableRestocking = "<Find>boolEnableRestocking:false</Find><Replace>boolEnableRestocking:true</Replace>";
            }

            // Enable sell loot checkbox
            if (checkBoxScriptProfiles_AccountBuilder_SellLoot.Checked)
            {
                boolEnableSellLoot = "<Find>boolEnableSellLoot:false</Find><Replace>boolEnableSellLoot:true</Replace>";
            }

            // Enable bank coal checkbox
            if (checkBoxScriptProfiles_AccountBuilder_BankCoal.Checked)
            {
                boolEnableBankCoal = "<Find>boolEnableBankCoal:false</Find><Replace>boolEnableBankCoal:true</Replace>";
            }

            // Enable rooftops checkbox
            if (checkBoxScriptProfiles_AccountBuilder_EnableRooftops.Checked)
            {
                boolEnableRooftops = "<Find>boolEnableRooftops:false</Find><Replace>boolEnableRooftops:true</Replace>";
            }

            // Enable longrange checkbox
            if (checkBoxScriptProfiles_AccountBuilder_EnableLongrangeTraining.Checked)
            {
                boolEnableLongRangeTraining = "<Find>boolEnableLongRangeTraining:false</Find><Replace>boolEnableLongRangeTraining:true</Replace>";
            }

            // Enable no gp start checkbox
            if (checkBoxScriptProfiles_AccountBuilder_EnableNoGpStart.Checked)
            {
                boolEnableNoGpStart = "<Find>boolEnableNoGpStart:false</Find><Replace>boolEnableNoGpStart:true</Replace>";
            }

            // Enable quests checkbox 
            if (checkBoxScriptProfiles_AccountBuilder_StopAtGoal.Checked)
            {
                boolEnableStopScriptAtGoal = "<Find>boolEnableStopScriptAtGoal:false</Find><Replace>boolEnableStopScriptAtGoal:true</Replace>";
            }

            // Stop script at goal checkbox 
            if (checkBoxScriptProfiles_AccountBuilder_EnableQuests.Checked)
            {
                boolEnableQuests = "<Find>boolEnableQuests:false</Find><Replace>boolEnableQuests:true</Replace>";
            }

            // F2P Quests
            if (listBoxScriptProfiles_AccountBuilder_F2PQuests.SelectedItems.Count > 0)
            {
                foreach (var selectedItem in listBoxScriptProfiles_AccountBuilder_F2PQuests.SelectedItems)
                {
                    string selectedQuest = selectedItem.ToString();

                    // Goblin Diplomacy quest data to string
                    if (selectedQuest.Contains("Cooks Assistant"))
                    {
                        questCooksAssistant = "<Find>boolEnableCooksAssistant:false</Find><Replace>boolEnableCooksAssistant:true</Replace>";
                    }

                    // Goblin Diplomacy quest data to string
                    if (selectedQuest.Contains("Goblin Diplomacy"))
                    {
                        questGoblinDiplomacy = "<Find>boolEnableGoblinDiplomacy:false</Find><Replace>boolEnableGoblinDiplomacy:true</Replace>";
                    }

                    // Romeo & Juliet quest data to string
                    if (selectedQuest.Contains("Romeo & Juliet"))
                    {
                        questRomeoAndJuliet = "<Find>boolEnableRomeoAndJuliet:false</Find><Replace>boolEnableRomeoAndJuliet:true</Replace>";
                    }

                    // Rune Mysteries quest data to string
                    if (selectedQuest.Contains("Rune Mysteries"))
                    {
                        questRuneMysteries = "<Find>boolEnableRuneMysteries:false</Find><Replace>boolEnableRuneMysteries:true</Replace>";
                    }

                    // Sheep Shearer quest data to string
                    if (selectedQuest.Contains("Sheep Shearer"))
                    {
                        questSheepShearer = "<Find>boolEnableSheepShearer:false</Find><Replace>boolEnableSheepShearer:true</Replace>";
                    }

                    // X Marks the spot quest data to string
                    if (selectedQuest.Contains("X Marks The Spot"))
                    {
                        questXMarksTheSpot = "<Find>boolEnableXMarksTheSpot:false</Find><Replace>boolEnableXMarksTheSpot:true</Replace>";
                    }

                    // Druidic Ritual quest data to string
                    if (selectedQuest.Contains("Druidic Ritual"))
                    {
                        questDruidicRitual = "<Find>boolEnableDruidicRitual:false</Find><Replace>boolEnableDruidicRitual:true</Replace>";
                    }

                    // Lost City quest data to string
                    if (selectedQuest.Contains("Lost City"))
                    {
                        questLostCity = "<Find>boolEnableLostCity:false</Find><Replace>boolEnableLostCity:true</Replace>";
                    }

                    // Mare Arena I quest data to string
                    if (selectedQuest.Contains("Mage Arena I"))
                    {
                        questMageArenaOne = "<Find>boolEnableMageArenaOne:false</Find><Replace>boolEnableMageArenaOne:true</Replace>";
                    }
                }
            }

            // P2P Quests
            if (listBoxScriptProfiles_AccountBuilder_P2PQuests.SelectedItems.Count > 0)
            {
                foreach (var selectedItem in listBoxScriptProfiles_AccountBuilder_P2PQuests.SelectedItems)
                {
                    string selectedQuest = selectedItem.ToString();

                    // Druidic Ritual quest data to string
                    if (selectedQuest.Contains("Druidic Ritual"))
                    {
                        questDruidicRitual = "<Find>boolEnableDruidicRitual:false</Find><Replace>boolEnableDruidicRitual:true</Replace>";
                    }

                    // Lost City quest data to string
                    if (selectedQuest.Contains("Lost City"))
                    {
                        questLostCity = "<Find>boolEnableLostCity:false</Find><Replace>boolEnableLostCity:true</Replace>";
                    }

                    // Mare Arena I quest data to string
                    if (selectedQuest.Contains("Mage Arena I"))
                    {
                        questMageArenaOne = "<Find>boolEnableMageArenaOne:false</Find><Replace>boolEnableMageArenaOne:true</Replace>";
                    }
                }
            }

            // Mini Quests
            if (listBoxScriptProfiles_AccountBuilder_MiniQuests.SelectedItems.Count > 0)
            {
                foreach (var selectedItem in listBoxScriptProfiles_AccountBuilder_MiniQuests.SelectedItems)
                {
                    string selectedQuest = selectedItem.ToString();

                    // Mare Arena I quest data to string
                    if (selectedQuest.Contains("Mage Arena I"))
                    {
                        questMageArenaOne = "<Find>boolEnableMageArenaOne:false</Find><Replace>boolEnableMageArenaOne:true</Replace>";
                    }
                }
            }

            // Conver activity time mins into ms
            int.TryParse(textBoxScriptProfiles_AccountBuilder_ActivityDuration.Text, out int intActivityDurationMs);
            {
                intActivityDuration = intActivityDurationMs * 60000;
                activityDuration = intActivityDuration.ToString();
            }

            // Convert activity time variation mins to ms
            int.TryParse(textBoxScriptProfiles_AccountBuilder_AcivityDurationVariation.Text, out int intActivityDurationVariationMs);
            {
                intActivityDurationVariation = intActivityDurationVariationMs * 60000;
                activityDurationVariation = intActivityDurationVariation.ToString();
            }

            // Convert gold farming duration mins to ms
            int.TryParse(textBoxScriptProfiles_AccountBuilder_GoldFarmingDuration.Text, out int intGoldFarmingDurationMs);
            {
                intGoldFarmingDuration = intGoldFarmingDurationMs * 60000;
                goldFarmingDuration = intGoldFarmingDuration.ToString();
            }

            // Write to file
            using (StreamWriter writer = new StreamWriter(filepathProfileAccountBuilder))
            {
                writer.WriteLine(boolEnableProfiles);
                writer.WriteLine(boolEnableDeathHandler);
                writer.WriteLine(boolEnableRenewBond);
                writer.WriteLine(boolEnableAntipattern);
                writer.WriteLine(boolEnableHopWorlds);
                writer.WriteLine(boolEnableRestocking);
                writer.WriteLine(boolEnableSellLoot);
                writer.WriteLine(boolEnableStopScriptAtGoal);
                writer.WriteLine(boolEnableBankCoal);
                writer.WriteLine(boolEnableRooftops);
                writer.WriteLine(boolEnableLongRangeTraining);
                writer.WriteLine(boolEnableNoGpStart);
                writer.WriteLine(boolEnableQuests);
                writer.WriteLine(questCooksAssistant);
                writer.WriteLine(questGoblinDiplomacy);
                writer.WriteLine(questRomeoAndJuliet);
                writer.WriteLine(questRuneMysteries);
                writer.WriteLine(questSheepShearer);
                writer.WriteLine(questXMarksTheSpot);
                writer.WriteLine(questDruidicRitual);
                writer.WriteLine(questLostCity);
                writer.WriteLine(questMageArenaOne);
                writer.WriteLine("<Find>AgilityStopLevel</Find><Replace>" + textBoxScriptProfiles_AccountBuilder_Agility.Text + "</Replace>");
                writer.WriteLine("<Find>ConstructionStopLevel</Find><Replace>" + textBoxScriptProfiles_AccountBuilder_Construction.Text + "</Replace>");
                writer.WriteLine("<Find>CookingStopLevel</Find><Replace>" + textBoxScriptProfiles_AccountBuilder_Cooking.Text + "</Replace>");
                writer.WriteLine("<Find>CraftingStopLevel</Find><Replace>" + textBoxScriptProfiles_AccountBuilder_Crafting.Text + "</Replace>");
                writer.WriteLine("<Find>FarmingStopLevel</Find><Replace>" + textBoxScriptProfiles_AccountBuilder_Farming.Text + "</Replace>");
                writer.WriteLine("<Find>FiremakingStopLevel</Find><Replace>" + textBoxScriptProfiles_AccountBuilder_Firemaking.Text + "</Replace>");
                writer.WriteLine("<Find>FishingStopLevel</Find><Replace>" + textBoxScriptProfiles_AccountBuilder_Fishing.Text + "</Replace>");
                writer.WriteLine("<Find>FletchingStopLevel</Find><Replace>" + textBoxScriptProfiles_AccountBuilder_Fletching.Text + "</Replace>");
                writer.WriteLine("<Find>HerbloreStopLevel</Find><Replace>" + textBoxScriptProfiles_AccountBuilder_Herblore.Text + "</Replace>");
                writer.WriteLine("<Find>HunterStopLevel</Find><Replace>" + textBoxScriptProfiles_AccountBuilder_Hunter.Text + "</Replace>");
                writer.WriteLine("<Find>MagicStopLevel</Find><Replace>" + textBoxScriptProfiles_AccountBuilder_Magic.Text + "</Replace>");
                writer.WriteLine("<Find>MeleeStopLevel</Find><Replace>" + textBoxScriptProfiles_AccountBuilder_Melee.Text + "</Replace>");
                writer.WriteLine("<Find>MiningStopLevel</Find><Replace>" + textBoxScriptProfiles_AccountBuilder_Mining.Text + "</Replace>");
                writer.WriteLine("<Find>PrayerStopLevel</Find><Replace>" + textBoxScriptProfiles_AccountBuilder_Prayer.Text + "</Replace>");
                writer.WriteLine("<Find>RangedStopLevel</Find><Replace>" + textBoxScriptProfiles_AccountBuilder_Ranged.Text + "</Replace>");
                writer.WriteLine("<Find>RunecraftingStopLevel</Find><Replace>" + textBoxScriptProfiles_AccountBuilder_Runecrafting.Text + "</Replace>");
                writer.WriteLine("<Find>SlayerStopLevel</Find><Replace>" + textBoxScriptProfiles_AccountBuilder_Slayer.Text + "</Replace>");
                writer.WriteLine("<Find>SmithingStopLevel</Find><Replace>" + textBoxScriptProfiles_AccountBuilder_Smithing.Text + "</Replace>");
                writer.WriteLine("<Find>ThievingStopLevel</Find><Replace>" + textBoxScriptProfiles_AccountBuilder_Thieving.Text + "</Replace>");
                writer.WriteLine("<Find>WoodcuttingStopLevel</Find><Replace>" + textBoxScriptProfiles_AccountBuilder_Woodcutting.Text + "</Replace>");
                writer.WriteLine("<Find>5400000,true,1800000,true</Find><Replace>" + activityDuration + ",true," + activityDurationVariation + ",true</Replace>");
                writer.WriteLine("<Find>12600000</Find><Replace>" + goldFarmingDuration + "</Replace>");
            }

            MessageBox.Show("Profile successfully created.");

        }

        private void formScriptProfiles_AccountBuilder_Load(object sender, EventArgs e)
        {

        }
    }
}
