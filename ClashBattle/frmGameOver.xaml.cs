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
    /// Interaction logic for frmGameOver.xaml
    /// </summary>
    public partial class frmGameOver : Window {
        public frmGameOver() {
            InitializeComponent();
            updateText();
        }

        public bool restart = false;
        private void updateText() {
            if (Game.GameState == Game.State.Won) {
                txtState.Text = "Congrats!!! You Won!! :)";
                btnOk.Visibility = Visibility.Hidden;
            } else if (Game.GameState == Game.State.Lost) {
                txtState.Text = "Shucks Good try! :(";
                btnOk.Visibility = Visibility.Hidden;
            } else if (Game.GameState == Game.State.Running) {
                txtState.Text = "Find the Key!";
                btnExit.Visibility = Visibility.Hidden;
                btnRestart.Visibility = Visibility.Hidden;
            }
        }
        private void btnRestart_Click(object sender, RoutedEventArgs e) {
            restart = true;
            Game.ResetGame();
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e) {
            e.Handled = true;
            if (e.Key == Key.C) {
                btnOk_Click(btnOk, e);

            } else if (e.Key == Key.R) {
                btnRestart_Click(btnRestart, e);
            } else if (e.Key == Key.S) {
                btnExit_Click(btnExit, e);
            } else {
                //do nothing
            }
        }
    }
}
