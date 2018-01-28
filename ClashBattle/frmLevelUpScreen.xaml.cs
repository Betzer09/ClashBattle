using CoreObjects;
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
    /// Interaction logic for frmLevelUpScreen.xaml
    /// </summary>
    public partial class frmLevelUpScreen : Window {
        public frmLevelUpScreen() {
            InitializeComponent();
            txtShowLevelOfHero.Text = string.Format("Congrats {0}! You are now level {1}", Game.Map.Adventurer.Name(),
                Game.Map.Adventurer.LevelOfHero);
            updateLabels();
        }

        private void btnIncreaseSpeed_Click(object sender, RoutedEventArgs e) {
            Hero h = Game.Map.Adventurer;
            if (h.LevelOfHero == 2) {
                //increase speed by 1
                h.AttackSpeed += 1;
            } else if (h.LevelOfHero == 3) {
                //increase by 2
                h.AttackSpeed += 2;
            } else if (h.LevelOfHero == 4) {
                // Increase by 3
                h.AttackSpeed += 3;
            } else if (h.LevelOfHero == 5) {
                // 4
                h.AttackSpeed += 4;
            } else {
                MessageBox.Show("Add level 1");
            }
            this.Close();
        }
        private void updateLabels() {
            lblShowPlayerHp.Content = string.Format("{0} / {1}", Game.Map.Adventurer.CurrentHitPoints,
            Game.Map.Adventurer.MaximumHitPoints);
            lblShowPlayerName.Content = Game.Map.Adventurer.Name();
            lblShowExperiencePoints.Content = Game.Map.Adventurer.ExperiencePoints;
            if (Game.Map != null) {
                if (Game.Map.Adventurer.DoorKey != null) {
                    lblShowKeys.Content = Game.Map.Adventurer.DoorKey.Name;
                } else {
                    lblShowKeys.Content = "None";
                }


                if (Game.Map.Adventurer.HasWeapon) {
                    lblShowPlayerWeapon.Content = Game.Map.Adventurer.Weapon.Name;
                } else {
                    lblShowPlayerWeapon.Content = "None";

                }
            }
        }

        private void btnIncreaseAttackDamage_Click(object sender, RoutedEventArgs e) {
            Hero h = Game.Map.Adventurer;
            if (h.LevelOfHero == 2) {
                //increase Damage by 1
                h.AttackDamage += 1;
            } else if (h.LevelOfHero == 3) {
                //increase by 2
                h.AttackDamage += 2;
            } else if (h.LevelOfHero == 4) {
                // Increase by 3
                h.AttackDamage += 3;
            } else if (h.LevelOfHero == 5) {
                // 4
                h.AttackDamage += 4;
            } else {
                MessageBox.Show("Add level 1");
            }
            this.Close();
        }

        private void btnIncreaseHeath_Click(object sender, RoutedEventArgs e) {
            Hero h = Game.Map.Adventurer;
            if (h.LevelOfHero == 2) {
                //increase Damage by 1
                h.MaximumHitPoints += 5;
            } else if (h.LevelOfHero == 3) {
                //increase by 2
                h.MaximumHitPoints += 10;
            } else if (h.LevelOfHero == 4) {
                // Increase by 3
                h.MaximumHitPoints += 15;
            } else if (h.LevelOfHero == 5) {
                // 4
                h.MaximumHitPoints += 20
                    ;
            } else {
                MessageBox.Show("Add level 1");
            }
            h.CurrentHitPoints = h.MaximumHitPoints;
            this.Close();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e) {
            if (e.Key == Key.S) {
                btnIncreaseSpeed_Click(btnIncreaseSpeed, e);
            } else if (e.Key == Key.D) {
                btnIncreaseAttackDamage_Click(btnIncreaseAttackDamage, e);

            } else if (e.Key == Key.A) {
                btnIncreaseHeath_Click(btnIncreaseHeath, e);
            }
        }
    }
}

