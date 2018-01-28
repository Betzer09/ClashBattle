using Deliverable6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClashBattle {
    /// <summary>
    /// Interaction logic for frmPlayerStats.xaml
    /// </summary>
    public partial class frmPlayerStats : Window {
        public frmPlayerStats() {
            InitializeComponent();
            updateLabels();
        }
        private void updateLabels() {
            lblShowPlayerHp.Content = string.Format("{0} / {1}", Game.Map.Adventurer.CurrentHitPoints,
               Game.Map.Adventurer.MaximumHitPoints);
            lblShowPlayerName.Content = Game.Map.Adventurer.Name();
            lblShowExperiencePoints.Content = Game.Map.Adventurer.ExperiencePoints;
            lblShowLevelOfHero.Content = Game.Map.Adventurer.LevelOfHero;
            lblShowSpeed.Content = Game.Map.Adventurer.AttackSpeed;
            lblShowDamageAmountWithoutAnItem.Content = Game.Map.Adventurer.HandAttackValue;
            if (Game.Map.Adventurer.Weapon != null) {
                lblShowDamageAmountWithItem.Content = Game.Map.Adventurer.AttackDamage;
            } else {
                lblShowDamageAmountWithItem.Content = "No Weapon";
            }
            if (Game.Map != null) {
                if (Game.Map.Adventurer.DoorKey != null) {
                    lblShowKeys.Content = Game.Map.Adventurer.DoorKey.Name;
                } else {
                    lblShowKeys.Content = "None";
                }

            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
