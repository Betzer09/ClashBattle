using CoreObjects;
using Deliverable6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClashBattle {
    public partial class startMenu : Form {
        public startMenu() {
            InitializeComponent();
        }

        private void btnCreatePlayer_Click(object sender, EventArgs e) {
            if(string.IsNullOrWhiteSpace(txtName.Text)) {
                txtName.Text = "Make a name Newb";
            }
            Random rnd = new Random();
            int speed = rnd.Next(5, 9);
            int health = rnd.Next(200, 250);
            int attackValue = rnd.Next(5 , 10);
            Hero a = new Hero(txtName.Text, txtTitle.Text, speed, health, attackValue,0, 1, 8, 0, 0);
            Game.ResetGame(9, 9, a);
            //Game.GameState = Game.State.Running;
            this.Close();
        }


        private void btnRandomPlayer_Click(object sender, EventArgs e) {
            Random rnd = new Random();
            int speed = rnd.Next(5, 9);
            int health = rnd.Next(350, 500);
            int attackValue = rnd.Next(5, 10);
            Hero a = new Hero("Jerry", "The Smart", speed, health, attackValue, 0 , 1, 10, 0, 0);
            Game.ResetGame(9, 9, a);
            //Game.GameState = Game.State.Running;
            this.Close();
        }

        private void startMenu_KeyUp(object sender, KeyEventArgs e) {
            e.Handled = true;
            if (e.KeyCode == Keys.C) {
                btnRandomPlayer_Click(sender, e);  
            } else if (e.KeyCode == Keys.R) {
                btnCreatePlayer_Click(sender, e);
            }
        }
    }
}
