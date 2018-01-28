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
    /// Interaction logic for frmInformUser.xaml
    /// </summary>
    public partial class frmInformUser : Window {
        public frmInformUser() {
            InitializeComponent();
            updateLabels();
        }

        private void button_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e) {
            e.Handled = true;
            if (e.Key == Key.Enter) {
                button_Click(btnCloseForm, e);

            }
        }
        private void updateLabels() {
            MapCell mc = Game.Map.LocationOfAdventurer;
            if (mc.HasMonster && !mc.Monster.isAlive()) {
                tbInformUser.Text = string.Format("Nice you have killed a(n) {0}", mc.Monster.Name());
            } else if (Game.Map.Adventurer.HasWeapon && Game.Map.Adventurer.Weapon.Durability == 0) {
                tbInformUser.Text = string.Format("Your {0} Broke! Find a new weapon!",
                    Game.Map.Adventurer.Weapon.Name);
            } else if (Game.Map.Adventurer.AmountOfTimesAHeroCanRunAway <= 0) {
                tbInformUser.Text = "OOH NO YOU'RE OUT OF RUNS!!";
                //if the hero has run away to many times the screen needs to inform the user that he can't run
            } else if (Game.GameState == Game.State.Lost){
                tbInformUser.Text = string.Format("You were killed by a {0}" , 
                    Game.Map.LocationOfAdventurer.Monster.Name());
            } else {
                //nothing
            }
        }
    }
}
