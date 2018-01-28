using CoreObjects;
using Deliverable6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClashBattle {
    /// <summary>
    /// Interaction logic for frmItem.xaml
    /// </summary>
    public partial class frmItem : Window {
        public frmItem() {
            InitializeComponent();
            this.Background = new SolidColorBrush(Colors.Black);
            btnDontEquipWeapon.Foreground = new SolidColorBrush(Colors.Blue);
            btnText.Foreground = new SolidColorBrush(Colors.Blue);
            applyButtonText();
        }


        private void applyButtonText() {

            if (Game.Map.LocationOfAdventurer.Item is Potion) {
                Potion p = (Potion)Game.Map.LocationOfAdventurer.Item;
                PickImageBasedOnColor();
            } else if (Game.Map.LocationOfAdventurer.Item is Weapon) {
                PickImageBasedOnColor();
            } else if (Game.Map.LocationOfAdventurer.Item is Door) {
                imgDoor.Visibility = Visibility.Visible;
                btnText.Content = "Use Key On Door (F)";
                btnDontEquipWeapon.Content = "Don't Use Key On The Door (R)";
                txtItemFound.Text = string.Format("You Found a {0}", Game.Map.LocationOfAdventurer.Item.Name);
                if (Game.Map.LocationOfAdventurer.Item.Name == "Door Key") {
                    //YOU WIN
                }
            } else if (Game.Map.LocationOfAdventurer.Item is DoorKey) {
                imgDoorKey.Visibility = Visibility.Visible;
                btnText.Content = "Take Key (F)";
                btnDontEquipWeapon.Content = "Don't Use Key (R)";
                txtItemFound.Text = string.Format("You Found a {0}", Game.Map.LocationOfAdventurer.Item.Name);

            }
        }

        private void btnText_Click(object sender, RoutedEventArgs e) {

            Game.Map.LocationOfAdventurer.Item = Game.Map.Adventurer.applyItem(Game.Map.LocationOfAdventurer.Item);

            this.Close();
        }

        private void btnDon_tEquipWeapon_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void PickImageBasedOnColor() {
            Item i = Game.Map.LocationOfAdventurer.Item;
            string a = string.Format("Drink {0} (F)", i.Name);
            string b = "Okay (F)";
            string c = string.Format("Don't Apply {0} (R)", i.Name);
            string d = string.Format("Equip {0} (F)", i.Name);
            //MapCell Location = Game.Map.LocationOfAdventurer;
            if (i.Name == "Freeze") {
                imgFreeze.Visibility = Visibility.Visible;
                btnText.Content = b;
                txtItemFound.Text = string.Format("You Have Been Frozen! Your Speed been has been decreased by {0}",
                i.AffectValue);
                btnDontEquipWeapon.Visibility = Visibility.Hidden;
            } else if (i.Name == "Poison") {
                imgPoison.Visibility = Visibility.Visible;
                btnText.Content = b;
                txtItemFound.Text = string.Format("You Drank Poison!!! You have taken {0} Damage", i.AffectValue);
                btnDontEquipWeapon.Visibility = Visibility.Hidden;
            } else if (i.Name == "Small Healing Potion") {
                imgSmallHeal.Visibility = Visibility.Visible;
                btnText.Content = a;
                txtItemFound.Text = string.Format("You Found a {0}. Your health has been increased by {1}", 
                i.Name, i.AffectValue);
                btnDontEquipWeapon.Content = c;
            } else if (i.Name == "Spinach") {
                imgStrength.Visibility = Visibility.Visible;
                btnText.Content = a;
                txtItemFound.Text = string.Format("Congrats!!! You found Spinich! Your Damage Has Been Increased By {0}",
                Game.Map.LocationOfAdventurer.Item.AffectValue);
                btnDontEquipWeapon.Content = c;
            } else if (i.Name == "Large Healing Potion") {
                imgSuperHeal.Visibility = Visibility.Visible;
                txtItemFound.Text = string.Format("You Found a {0}. Your Health Has Been Increased By {1}", i.Name, i.AffectValue);
                btnText.Content = a;
                btnDontEquipWeapon.Content = c;
            } else if (i.Name == "Agility") {
                imgAgility.Visibility = Visibility.Visible;
                txtItemFound.Text = string.Format("You Found a {0}. Your Speed Has Been Increased By {1}", i.Name, i.AffectValue);
                btnText.Content = a;
                btnDontEquipWeapon.Content = c;
            } else if (i.Name == "Dagger") {
                imgDagger.Visibility = Visibility.Visible;
                txtItemFound.Text = string.Format("You Found a {0}", i.Name);
                btnDontEquipWeapon.Content = c;
                btnText.Content = d;
            } else if (i.Name == "Bow") {
                imgBow.Visibility = Visibility.Visible;
                txtItemFound.Text = string.Format("You Found a {0}", i.Name);
                btnDontEquipWeapon.Content = c;
                btnText.Content = d;
            } else if (i.Name == "Sword") {
                imgSword.Visibility = Visibility.Visible;
                txtItemFound.Text = string.Format("You Found a {0}", i.Name);
                btnDontEquipWeapon.Content = c;
                btnText.Content = d;
            } else if (i.Name == "Wand") {
                imgWand.Visibility = Visibility.Visible;
                txtItemFound.Text = string.Format("You Found a {0}", i.Name);
                btnDontEquipWeapon.Content = c;
                btnText.Content = d;
            
            } else {
                //nothing
            }
        }
        private void Window_KeyUp(object sender, KeyEventArgs e) {
            e.Handled = true;
            if (e.Key == Key.F) {
                btnText_Click(btnText, e);
            } else if (e.Key == Key.R) {
                btnDon_tEquipWeapon_Click(btnDontEquipWeapon, e);
            }
        }
    }
}