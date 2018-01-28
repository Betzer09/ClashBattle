/*
Map.cs
CS 1182 
Written By: Austin Betzer
4/4/2017
Jon Holmes
Description - Representation of our Map. It needs to know everything about what is on the Map.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreObjects {
    [Serializable]
    public class Map {
        #region "Private Variables"
        private MapCell[,] _Cells = null;
        private List<Monster> _Monsters = new List<Monster>();
        private List<Item> _Items = new List<Item>();
        private Hero _Adventurer;
        Random rnd = new Random();
        //int damageDone = 0;
        #endregion

        #region "Constructors"
        /// <summary>
        /// Create and fill the Map
        /// </summary>
        /// <param name="rows">Number of Rows the map should have</param>
        /// <param name="cols">Number of Columns the map should have</param>
        public Map(int rows, int cols) {
            _Cells = new MapCell[rows, cols];
            fillMonsters();
            fillPotions();
            fillWeapons();
            fillMap();
        }
        #endregion
        #region "Private Methods"
        /// <summary>
        /// Fill the List of Potions
        /// </summary>
        private void fillPotions() {
            _Items.Add(new Potion("Small Healing Potion", 25, Potion.Colors.Pink));
            _Items.Add(new Potion("Large Healing Potion", 50, Potion.Colors.Red));
            _Items.Add(new Potion("Freeze", -2, Potion.Colors.Blue));
            _Items.Add(new Potion("Agility", 2, Potion.Colors.Purple));
            _Items.Add(new Potion("Poison", -25, Potion.Colors.Green));
            _Items.Add(new Potion("Spinach", 5, Potion.Colors.Yellow));
        }
        /// <summary>
        /// Fill the list of Weapons
        /// </summary>
        private void fillWeapons() {
            _Items.Add(new Weapon("Dagger", CreateDamageAmountForWeapon(5, 15), 2, 6));
            _Items.Add(new Weapon("Bow", CreateDamageAmountForWeapon(5, 25), -1, 15));
            _Items.Add(new Weapon("Sword", CreateDamageAmountForWeapon(10, 30), -3,10));
            _Items.Add(new Weapon("Wand", CreateDamageAmountForWeapon(10, 30), 1,5));
        }
        /// <summary>
        /// Fill the List of Monsters
        /// </summary>
        private void fillMonsters() {
            Monsters.Add(new Monster("Orc", "", 3, 150, 0, 0, 15, 30));
            Monsters.Add(new Monster("Goblin", "", 5, 50, 0, 0, 10, 20));
            Monsters.Add(new Monster("Slug", "", 1, 50, 0, 0, 10, 15));
            Monsters.Add(new Monster("Rat", "", 15, 70, 0, 0, 10, 25));
            Monsters.Add(new Monster("Skeleton", "", 4, 100, 0, 0, 10, 25));
        }
        private int CreateDamageAmountForWeapon(int min, int max) {
            int a = rnd.Next(min, max);
            return a;
        }
        public bool MoveCharacter(Hero.Direction CurrentSpot) {

            if (CurrentSpot == Hero.Direction.Up) {
                if (_Adventurer.PositionX > 0) {
                    _Adventurer.Move(Actor.Direction.Up);
                }
            }
            if (CurrentSpot == Hero.Direction.Right) {
                if (_Adventurer.PositionY < _Cells.GetLength(0) - 1) {
                    _Adventurer.Move(Actor.Direction.Right);

                }
            }
            if (CurrentSpot == Hero.Direction.Left) {
                if (_Adventurer.PositionY > 0) {
                    _Adventurer.Move(Actor.Direction.Left);

                }
            }
            if (CurrentSpot == Hero.Direction.Down) {
                if (_Adventurer.PositionX < _Cells.GetLength(1) - 1) {
                    _Adventurer.Move(Actor.Direction.Down);

                }

            }
            if (LocationOfAdventurer.HasItem == true || LocationOfAdventurer.HasMonster == true) {
                //Hero needs to act 
                return true;
            } else {
                return false;
            }
        }


        /// <summary>
        /// Fill the map with empty MapCells
        /// </summary>
        bool IsThereADoor = false;
        bool isThereADoorKey = false;
        int monsterCount = 17;
        int HealCount = 5;
        int AgilityCount = 10;
        int WeaponCount = 6;
        public void fillMap() {

            Random rnd = new Random();
            int rows = Cells.GetLength(0);
            int cols = Cells.GetLength(1);
            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < cols; col++) {
                    MapCell mc = new MapCell();
                    int rndNum = rnd.Next(10);


                    //Adds a monster to the map
                    #region First try
                    //if (rndNum == 0) {
                    //    mc.Monster = Monsters[rnd.Next(Monsters.Count)].CreateCopy();
                    //} else if (rndNum == 1) {
                    //    int ItemSelector = rnd.Next(Items.Count);
                    //    //Decides what to put on the map

                    //    if (ItemSelector <= 5) {
                    //        mc.Item = ((Potion)Items[ItemSelector]).CreateCopy();
                    //    } else {
                    //        mc.Item = ((Weapon)Items[ItemSelector]).CreateCopy();
                    //    }

                    //}
                    #endregion
                    #region SecondTry
                    if (rndNum < 4) {
                        // add a monster while there are less then 25
                        if (monsterCount > 0) {
                            mc.Monster = Monsters[rnd.Next(Monsters.Count)].CreateCopy();
                            monsterCount--;
                        } else {
                            //nothing
                        }

                    } else if (rndNum == 6) {
                        //add healing potion .06 percent of the time 
                        //while the count of healing potions are less then 6
                        int itemSelector = rnd.Next(2);
                        if (HealCount > 0) {
                            mc.Item = ((Potion)Items[itemSelector]).CreateCopy();
                            HealCount--;
                        } else {
                            //nothing
                        }
                    } else if (rndNum == 7) {
                        int itemSelector = rnd.Next(2, 5);
                        //add a hero modifer to the map while the count is less then 10
                        if (AgilityCount > 0) {
                            mc.Item = ((Potion)Items[itemSelector]).CreateCopy();
                            AgilityCount--;
                        } else {
                            //nothing
                        }
                    } else if (rndNum == 8) {
                        int itemSelector = rnd.Next(6, 10);
                        //add the weapon to the map while the count is less then 4
                        if (WeaponCount > 0) {
                            mc.Item = ((Weapon)Items[itemSelector]).CreateCopy();
                            WeaponCount--;
                        } else {
                            //nothing
                        }
                    } else {
                        //blank space
                    }
                    #endregion

                    //adds cell to the map
                    Cells[row, col] = mc;
                }
            }
            PlaceKey();
            PlaceDoor();

        }
        private void PlaceKey() {
            Random rnd = new Random();

            while (isThereADoorKey == false) {
                int row = rnd.Next(9);
                int col = rnd.Next(9);
                if (Cells[row, col].HasItem == false
                    && Cells[row, col].HasMonster == false
                    && LocationOfAdventurer != Cells[row, col]) {
                    DoorKey dk = new DoorKey("Door Key", 0, "God Be With You");
                    Cells[row, col].Item = dk;
                    isThereADoorKey = true;
                    //Console.WriteLine("DoorKey");
                }
            }
        }
        private void PlaceDoor() {
            Random rnd = new Random();

            while (IsThereADoor == false) {
                int row = rnd.Next(9);
                int col = rnd.Next(9);
                if (Cells[row, col].HasItem == false
                    && Cells[row, col].HasMonster == false
                    && LocationOfAdventurer != Cells[row, col]) {
                    Door d = new Door("Door", 1, "God Be With You");
                    Cells[row, col].Item = d;
                    IsThereADoor = true;
                }
            }
        }

        #endregion
        #region "Public Properties"
        /// <summary>
        /// Get all of the cells of the map
        /// </summary>
        public MapCell[,] Cells {
            get {
                if (_Cells == null) fillMap();
                return _Cells;
            }

            set {
                _Cells = value;
            }
        }

        public MapCell LocationOfAdventurer {
            get {
                if (_Cells != null && Adventurer != null) {
                    if (Adventurer.PositionX >= 0
                        && Adventurer.PositionX <= _Cells.GetUpperBound(0)
                        && Adventurer.PositionY >= 0
                        && Adventurer.PositionY <= _Cells.GetUpperBound(1)) {
                        return _Cells[Adventurer.PositionX, Adventurer.PositionY];
                    }
                }
                return new MapCell();
            }
        }

        /// <summary>
        /// Get and Set the Adventurer on the Map
        /// </summary>
        public Hero Adventurer {
            get {
                return _Adventurer;
            }

            set {
                _Adventurer = value;
            }
        }
        /// <summary>
        /// Get the List of Monsters available on our map
        /// </summary>
        public List<Monster> Monsters {
            get {
                return _Monsters;
            }
        }
        /// <summary>
        /// Gets the list of Items available
        /// </summary>
        public List<Item> Items {
            get {
                return _Items;
            }
        }
        public int AmountOfMonsters {
            get {
                int count = 0;
                foreach (MapCell m in Cells) {
                    if (m.HasMonster == true) {
                        count++;
                    }
                }
                return count;
            }
        }

        public int AmountOfItems {
            get {
                int count = 0;
                foreach (MapCell m in Cells) {
                    if (m.HasItem == true) {
                        count++;
                    }
                }
                return count;
            }
        }
        public double AmountOfMapThatHasBeenDiscovered {
            get {
                int CellsThatHaveBeenSeen = 0;
                int CellsThatHaveNotBeenSeen = 0;
                foreach (MapCell m in Cells) {
                    if (m.HasBeenSeen == true) {
                        CellsThatHaveBeenSeen++;
                    } else {
                        CellsThatHaveNotBeenSeen++;
                    }
                }
                return CellsThatHaveBeenSeen / CellsThatHaveBeenSeen;
            }
        }
        #endregion
    }
}
