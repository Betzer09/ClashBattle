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
    /// Interaction logic for frmMonster.xaml
    /// </summary>
    public partial class frmMonster : Window {
        //static String img = null;
        public frmMonster() {
            InitializeComponent();
            //GiveImageBasedOnColor();
            if (Game.Map != null) {
                CheckIfMonsterAndHeroIsAlive();
                //MessageBox.Show(Game.Map.Adventurer.Weapon.Durability.ToString());
            }
            GiveImageBasedOnMonster();
            UpdateLabels();
        }

        private void UpdateLabels() {
            txtShowPlayerInfo.Text = string.Format("Player Name is: \r\n {0} \r\n Player Hp is: \r\n {1} / {2}", Game.Map.Adventurer.Name(), Game.Map.Adventurer.CurrentHitPoints,
                Game.Map.Adventurer.MaximumHitPoints);
            txtShowMonsterInfo.Text = string.Format("You found a: \r\n {0} \r\n {0} Hp is: \r\n {1} / {2}", Game.Map.LocationOfAdventurer.Monster.Name(),
                Game.Map.LocationOfAdventurer.Monster.CurrentHitPoints,
                Game.Map.LocationOfAdventurer.Monster.MaximumHitPoints);
        }

        private void btnAttack_Click(object sender, RoutedEventArgs e) {
            Game.Map.Adventurer.IsRunningAway = false;
            if (Game.Map.Adventurer.isAlive()) {
                bool n = Game.Map.Adventurer + Game.Map.LocationOfAdventurer.Monster;
                if (Game.Map.Adventurer.Weapon != null) {
                    Game.Map.Adventurer.Weapon.Durability--;

                    if (Game.Map.Adventurer.Weapon.Durability == 0) {
                        frmInformUser inform = new frmInformUser();
                        inform.ShowDialog();
                        Game.Map.Adventurer.Weapon = null;
                    }
                }
            }
            UpdateLabels();

            //For testing
            //if (Game.Map.Adventurer.isAlive() && !Game.Map.LocationOfAdventurer.Monster.isAlive()) {
            //    //MessageBox.Show(Game.Map.LocationOfAdventurer.Monster.AttackValue.ToString());
            //    //MessageBox.Show(Game.Map.Adventurer.Weapon.AffectValue.ToString());
            //    //MessageBox.Show(Game.Map.Adventurer.ExperiancePoints.ToString());
            //}
            CheckIfMonsterAndHeroIsAlive();
        }

        private void CheckIfMonsterAndHeroIsAlive() {
            if (!Game.Map.LocationOfAdventurer.Monster.isAlive()) {
                this.Close();
                frmInformUser monsterDied = new frmInformUser();
                monsterDied.ShowDialog();
            } else if (!Game.Map.Adventurer.isAlive()) {
                Game.GameState = Game.State.Lost;
                this.Close();
                frmInformUser monsterDied = new frmInformUser();
                monsterDied.ShowDialog();
            }
        }

        private void btnRun_Click(object sender, RoutedEventArgs e) {
            Game.Map.Adventurer.IsRunningAway = true;
            if(Game.Map.Adventurer.AmountOfTimesAHeroCanRunAway <= 0) {
                bool n = Game.Map.Adventurer + Game.Map.LocationOfAdventurer.Monster;
                frmInformUser inf = new frmInformUser();
                inf.ShowDialog();
                Game.Map.Adventurer.IsRunningAway = false;
            } else if(Game.Map.Adventurer.AmountOfTimesAHeroCanRunAway > 0){
                bool n = Game.Map.Adventurer + Game.Map.LocationOfAdventurer.Monster;
                this.Close();
            }
            //MessageBox.Show(Game.Map.LocationOfAdventurer.Monster.AttackValue.ToString());
        }
        private void GiveImageBasedOnMonster() {
            if(Game.Map.LocationOfAdventurer.Monster.Name() == "Slug") {
                imgSlug.Visibility = Visibility.Visible;
            } else if (Game.Map.LocationOfAdventurer.Monster.Name() == "Rat") {
                imgRat.Visibility = Visibility.Visible;
            } else if (Game.Map.LocationOfAdventurer.Monster.Name() == "Skeleton") {
                imgSkeleton.Visibility = Visibility.Visible;
            } else if(Game.Map.LocationOfAdventurer.Monster.Name() == "Orc") {
                imgOrc.Visibility = Visibility.Visible;
            } else if (Game.Map.LocationOfAdventurer.Monster.Name() == "Goblin") {
                imgGoblin.Visibility = Visibility.Visible;
            }
        }

      
        private void Window_KeyUp(object sender, KeyEventArgs e) {
            e.Handled = true;
            if (e.Key == Key.C) {
                btnAttack_Click(btnAttack, e);
            }  else if (e.Key == Key.R) {
                btnRun_Click(btnRun, e);
            }
        }
    }
}


