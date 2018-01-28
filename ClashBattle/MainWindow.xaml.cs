using CoreObjects;
using Deliverable6;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClashBattle {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            startOver();
        }
        int ROWS = 9;
        int COLS = 9;

        #region Clicks
        private void BtnRefreshTheMap_Click(object sender, RoutedEventArgs e) {
            startOver();
        }
        public void startOver() {
            startMenu sm = new startMenu();
            sm.ShowDialog();
            InitializeComponent();
            if (Game.Map != null) {
                DrawMap();
            }
        }
        private void BtnMoveHeroLeft_Click(object sender, RoutedEventArgs e) {
            moveHero(sender, e);
        }

        private void BtnMoveHeroUp_Click(object sender, RoutedEventArgs e) {
            moveHero(sender, e);

        }

        private void BtnMoveHeroRight_Click(object sender, RoutedEventArgs e) {
            moveHero(sender, e);

        }

        private void BtnMoveHeroDown_Click(object sender, RoutedEventArgs e) {
            moveHero(sender, e);
        }
        private void Window_KeyUp_1(object sender, KeyEventArgs e) {
            e.Handled = true;
            //I didn't see moving twice as a big concern because all actions will still happen
            if (e.Key == Key.W || e.Key == Key.Up) {
                BtnMoveHeroUp_Click(BtnMoveHeroUp, e);

            } else if (e.Key == Key.S || e.Key == Key.Down) {
                BtnMoveHeroDown_Click(BtnMoveHeroDown, e);

            } else if (e.Key == Key.A || e.Key == Key.Left) {
                BtnMoveHeroLeft_Click(BtnMoveHeroLeft, e);

            } else if (e.Key == Key.D || e.Key == Key.Right) {
                BtnMoveHeroDown_Click(BtnMoveHeroRight, e);
            }

        }
        private void moveHero(object sender, RoutedEventArgs e) {
            bool popUp = false;
            if (Game.GameState != Game.State.Running) {
                MessageBox.Show("I am sorry, you cannot move the Hero until the board has been filled.");
            } else {
                Button btn = (Button)sender;
                String btnName = btn.Name;
                if (btnName.Contains("Up")) {
                    popUp = Game.Map.MoveCharacter(CoreObjects.Actor.Direction.Up);
                } else if (btnName.Contains("Down")) {
                    popUp = Game.Map.MoveCharacter(CoreObjects.Actor.Direction.Down);
                } else if (btnName.Contains("Right")) {
                    popUp = Game.Map.MoveCharacter(CoreObjects.Actor.Direction.Right);
                } else if (btnName.Contains("Left")) {
                    popUp = Game.Map.MoveCharacter(CoreObjects.Actor.Direction.Left);
                }
                DrawMap();
                CheckCell();
            }

        }
        #endregion
        #region Load / Save
        private void btnLoadGame_Click_1(object sender, RoutedEventArgs e) {
            LoadGame();
            DrawMap();
        }

        private static void LoadGame() {
            OpenFileDialog oDia = new OpenFileDialog();
            oDia.Filter = "Map file |*.Map";
            //oDia.InitialDirectory = @"D:\CS1182";

            bool? answer = oDia.ShowDialog();
            FileStream fs = null;

            if (answer == true && oDia.CheckFileExists) {
                try {
                    Map m;
                    BinaryFormatter bf = new BinaryFormatter();
                    fs = new FileStream(oDia.FileName, FileMode.Open);
                    m = (Map)bf.Deserialize(fs);

                    Game.Map = m;

                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                } finally {
                    if (fs != null) fs.Close();
                }
            } else {
                MessageBox.Show("You should really pick a file.");
            }
        }

        private void btnSaveGame_Click(object sender, RoutedEventArgs e) {
            SaveGame();
        }
        private void SaveGame() {
            SaveFileDialog s = new SaveFileDialog();

            s.Filter = "Map file |.map";

            bool? answer = s.ShowDialog();
            if (answer == true) {
                try {
                    string FileName = s.FileName;

                    Map m = Game.Map;

                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate);
                    bf.Serialize(fs, m);
                    fs.Close();
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        #endregion

        public void DrawMap() {
            grdMap.Children.Clear();
            for (int row = 0; row < ROWS; row++) {
                for (int col = 0; col < COLS; col++) {
                    Label lbl = new Label();
                    lbl.HorizontalContentAlignment = HorizontalAlignment.Center;
                    lbl.FontSize = 10;
                    lbl.BorderBrush = new SolidColorBrush(Colors.Blue);
                    lbl.BorderThickness = new Thickness(2);

                    #region Test Map With Non hidden things
                    //if (Game.Map.Cells[row, col].Item != null) {
                    //    lbl.Content = Game.Map.Cells[row, col].Item.Name;
                    //    lbl.Background = new SolidColorBrush(Colors.Purple);
                    //    lbl.Foreground = new SolidColorBrush(Colors.White);

                    //    if (Game.Map.Cells[row, col].Item is DoorKey) {
                    //        //lbl.Content = "Door Key";
                    //        lbl.Background = new SolidColorBrush(Colors.Green);
                    //        //MessageBox.Show("Door Key");
                    //    }

                    //    if (Game.Map.Cells[row, col].Item is Door) {
                    //        // lbl.Content = "Door";
                    //        lbl.Background = new SolidColorBrush(Colors.Blue);
                    //        //Show the game over window
                    //    }


                    //} else if (Game.Map.Cells[row, col].HasMonster) {
                    //    lbl.Content = Game.Map.Cells[row, col].Monster.Name();
                    //    lbl.Background = new SolidColorBrush(Colors.Red);

                    //} else if (Game.Map.Cells[row, col].HasBeenSeen) {
                    //    lbl.Background = new SolidColorBrush(Colors.White);
                    //    lbl.Foreground = new SolidColorBrush(Colors.White);
                    //    //MessageBox.Show("x");
                    //    }
                    #endregion

                    #region Makes things invisable
                    MapCell mc = Game.Map.Cells[row, col];

                    if (mc.HasBeenSeen) {
                        lbl.Foreground = new SolidColorBrush(Colors.White);

                        if (mc.HasItem) {
                            lbl.Content = mc.Item.Name;
                            if (mc.Item is Weapon) {
                                lbl.Background = new SolidColorBrush(Colors.Blue);
                            } else if (mc.Item is Potion) {
                                lbl.Background = new SolidColorBrush(Colors.Pink);
                            } else {
                                //Nothing
                            }

                        } else if (mc.HasMonster && mc.Monster.isAlive()) {
                            lbl.Background = new SolidColorBrush(Colors.Red);
                            lbl.Content = mc.Monster.Name();

                        } else {
                            //Has nothing set to white
                            lbl.Background = new SolidColorBrush(Colors.White);
                        }

                    }
                    #endregion

                    if (Game.Map.Adventurer.PositionX == row &&
                        Game.Map.Adventurer.PositionY == col) {
                        lbl.Content = "H";
                        lbl.Background = new SolidColorBrush(Colors.Gold);
                    }

                    Grid.SetColumn(lbl, col);
                    Grid.SetRow(lbl, row);
                    grdMap.Children.Add(lbl);
                }
            }
            UpdateLabels();
        }
        private void UpdateLabels() {
            if (Game.Map.Adventurer.CheckLevelUp(Game.Map.Adventurer) == true) {
                frmLevelUpScreen lvlup = new frmLevelUpScreen();
                lvlup.ShowDialog();
            }


            if (Game.Map != null) {
                lblShowPlayerHp.Content = string.Format("{0} / {1}", Game.Map.Adventurer.CurrentHitPoints,
                Game.Map.Adventurer.MaximumHitPoints);
                lblShowPlayerName.Content = Game.Map.Adventurer.Name();
                lblShowLevelOfHero.Content = Game.Map.Adventurer.LevelOfHero;
                if (Game.Map.Adventurer.AmountOfTimesAHeroCanRunAway >= 0) {
                    lblShowAmountOfRunsLeft.Content = Game.Map.Adventurer.AmountOfTimesAHeroCanRunAway;
                } else {
                    lblShowAmountOfRunsLeft.Content = "0";

                }
                if (Game.Map.Adventurer.HasWeapon) {
                    lblShowPlayerWeapon.Content = Game.Map.Adventurer.Weapon.Name;
                    lblShowWeaponDurability.Content = Game.Map.Adventurer.Weapon.Durability;
                } else {
                    lblShowPlayerWeapon.Content = "None";

                }
            }
        }
        private void CheckCell() {
            if (Game.Map.LocationOfAdventurer.HasItem) {
                frmItem foundItem = new frmItem();
                foundItem.ShowDialog();
                UpdateLabels();
            }
            if (Game.Map.LocationOfAdventurer.HasMonster == true && Game.Map.LocationOfAdventurer.Monster.isAlive()) {
                frmMonster foundMonster = new frmMonster();
                foundMonster.ShowDialog();
                UpdateLabels();
            }
            if (Game.Map.LocationOfAdventurer.HasBeenSeen == false) {
                Game.Map.LocationOfAdventurer.HasBeenSeen = true;
            }
            showGameOver();

        }


        private void showGameOver() {

            if (!Game.Map.Adventurer.isAlive()) {
                Game.GameState = Game.State.Lost;
                frmGameOver go = new frmGameOver();
                go.ShowDialog();
                DrawMap();
            }
            if (Game.Map.Adventurer.DoorKey == null && Game.Map.LocationOfAdventurer.Item is Door) {
                Game.GameState = Game.State.Running;
                frmGameOver go = new frmGameOver();
                go.ShowDialog();
                //added
                DrawMap();
            }
            if (Game.Map.Adventurer.DoorKey != null && Game.Map.LocationOfAdventurer.Item is Door) {
                Game.GameState = Game.State.Won;
                frmGameOver go = new frmGameOver();
                go.ShowDialog();
                DrawMap();
                //if (go.restart) {
                //    Game.ResetGame();
                //    DrawMap();

                //}
            }
        }

        private void btnShowStatsOfPlayer_Click(object sender, RoutedEventArgs e) {
            frmPlayerStats ps = new frmPlayerStats();
            ps.ShowDialog();
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e) {
            FrmHints h = new FrmHints();
            h.ShowDialog();
        }
    }
}
