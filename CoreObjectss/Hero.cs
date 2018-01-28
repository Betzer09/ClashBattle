/*
Hero.cs
CS 1182 
Written By: Austin Betzer
4/4/2017
Jon Holmes 
Description - Makes a Hero for the game. 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreObjects {
    [Serializable]
    public class Hero : Actor {

        private Weapon _Weapon;
        private bool _IsRunningAway;
        private int _experiancePoints;
        private DoorKey _DoorKey;
        private int _handAttackValue = 0;
        private int _LevelOfHero = 1;

        //I hope you lose tutors!!!!
        private int _AmountOfTimesAHeroCanRunAway = 8;

        /// <summary>
        /// Overloaded Constructor for a hero
        /// </summary>
        /// <param name="newName">Hero's Name</param>
        /// <param name="newTitle">Hero's Title</param>
        /// <param name="atkSpeed">Hero's AttackSpeed</param>
        /// <param name="hitPoints">Hero's Starting HP</param>
        /// <param name="startingPositionX">Hero's Starting X Position</param>
        /// <param name="startingPositionY">Hero's Starting Y Position</param>
        public Hero(String newName, String newTitle, int atkSpeed, int hitPoints, int HandAttackValue, 
            int experiancePoints, int levelOfHero, int TimesTheHeroCanRun, int startingPositionX, int startingPositionY)
            : base(newName, newTitle, atkSpeed, hitPoints, startingPositionX, startingPositionY) {
            Weapon = null;
            _handAttackValue = HandAttackValue;
            _LevelOfHero = levelOfHero;
            _AmountOfTimesAHeroCanRunAway = TimesTheHeroCanRun;
        }

        /// <summary>
        /// Get Hero's attack speed
        /// </summary>
        public override double AttackSpeed {
            get {
                if (HasWeapon) {
                    return base.AttackSpeed + Weapon.SpeedModifier;
                } else {
                    return base.AttackSpeed;
                }
            }
            set {
                _AttackSpeed = value;
            }
        }


        public int ExperiencePoints {
            get {
                return _experiancePoints;
            }

        }
        /// <summary>
        /// Get and set the Hero's weapon
        /// </summary>
        public Weapon Weapon {
            get {
                return _Weapon;
            }

            set {
                _Weapon = value;
            }
        }
        /// <summary>
        /// Check to see if the hero has a weapon equipped.
        /// </summary>
        public bool HasWeapon {
            get {
                return _Weapon != null;
            }
        }
        /// <summary>
        /// Checks to see if the hero is alive
        /// </summary>
        public bool IsHeroAlive {
            get {
                if (_CurrentHitPoints > 0) {
                    return true;
                } else {
                    return false;
                }
            }
        }
        /// <summary>
        /// Checks to see if the hero is wants to run
        /// </summary>
        public bool IsRunningAway {
            get {
                return _IsRunningAway;
            }

            set {
                _IsRunningAway = value;
            }
        }
        /// <summary>
        /// Gets the door key
        /// </summary>
        public DoorKey DoorKey {
            get {
                return _DoorKey;
            }
        }
        /// <summary>
        /// Gets the attack damage
        /// </summary>
        public int AttackDamage {
            get {
                if (_Weapon == null) {
                    return HandAttackValue;
                } else {
                    return HandAttackValue + Weapon.AffectValue;
                }
            }
            set {
               _handAttackValue = value;
            }
        }

        public string Title {
            get {
                return _Title;
            }
        }

        public int HandAttackValue {
            get {
                return _handAttackValue;
            }

        }

        public int LevelOfHero {
            get {
                return _LevelOfHero;
            }
        }

        public int AmountOfTimesAHeroCanRunAway {
            get {                
                return _AmountOfTimesAHeroCanRunAway;
            }
            set {
                _AmountOfTimesAHeroCanRunAway = value;
            }
        }

        /// <summary>
        /// Move the hero.
        /// </summary>
        /// <param name="dirToMove">Direction the hero will move.</param>
        public override void Move(Actor.Direction dirToMove) {
            base.Move(dirToMove);
        }
        /// <summary>
        /// Equip or Effect hero based on the item 
        /// </summary>
        public Item applyItem(Item i) {
            //Add Potion to hero
            if (i.GetType() == typeof(Potion)) {
                //Figure out what the spell is
                if (i.Name == "Small Healing Potion") {
                    //Heal hero
                    _CurrentHitPoints += i.AffectValue;
                } else if (i.Name == "Large Healing Potion") {
                    //Heal hero
                    _CurrentHitPoints += i.AffectValue;
                } else if (i.Name == "Mud") {
                    //Freeze Hero
                    _AttackSpeed += i.AffectValue;
                } else if (i.Name == "Poison") {
                    //Poison Hero
                    _CurrentHitPoints += i.AffectValue;
                } else if (i.Name == "Agility") {
                    _AttackSpeed += i.AffectValue;
                } else if (i.Name == "Spinach" && i != null) {

                }
                return null;
            }
            if (i.GetType() == typeof(Weapon)) {
                //Equip weapon
                Weapon oldWeapon = _Weapon;

                _Weapon = (Weapon)i;
                return oldWeapon;
            }
            if (i.GetType() == typeof(DoorKey)) {
                //equip door key to door key field 
                DoorKey oldKey = _DoorKey;

                _DoorKey = (DoorKey)i;
                return oldKey;
            }
            return i;

        }
        //bool IsLevel1 = false;
        bool IsLevel2 = false;
        bool IsLevel3 = false;
        bool IsLevel4 = false;
        bool IsLevel5 = false;

        public bool CheckLevelUp(Hero h) {
            //The monster has to be dead
            //has to be within a leveling up range
            bool shouldPopUp = false;
            if((h.ExperiencePoints > 100 && IsLevel2 == false)) { 
                _LevelOfHero++;
                IsLevel2 = true;
                shouldPopUp = true;
            } else if (h.ExperiencePoints > 200 && IsLevel3 == false) {
                _LevelOfHero++;
                IsLevel3 = true;
                shouldPopUp = true;
            } else if(h.ExperiencePoints > 300 && IsLevel4 == false) {
                _LevelOfHero++;
                IsLevel4 = true;
                shouldPopUp = true;

            } else if(h.ExperiencePoints > 500 &&  IsLevel5 == false) {
                _LevelOfHero++;
                IsLevel5 = true;
                shouldPopUp = true;
            } else {
                shouldPopUp = false;
            }
            return shouldPopUp;

        }

        /// <summary>
        /// Checks to see who gets to attack first
        /// </summary>
        /// <param name="h">Hero</param>
        /// <param name="m">Monster</param>
        /// <returns></returns>
        public static bool operator +(Hero h, Monster m) {

            if (!h.IsRunningAway) { 
                //If the hero is Faster
                if (h.AttackSpeed > m.AttackSpeed) {
                    m.damageMe((int)h.AttackDamage);

                    if (m.CurrentHitPoints > 0) {
                        h.damageMe((int)m.AttackValue);
                    }
                }
            //If monster is faster
            if (m.AttackSpeed > h.AttackSpeed) {
                h.damageMe((int)m.AttackValue);

                if (h.CurrentHitPoints > 0) {
                    m.damageMe((int)h.AttackDamage);
                }
            }
            //If they are the same
            if (m.AttackSpeed == h.AttackSpeed) {
                h.damageMe((int)m.AttackValue);

                m.damageMe((int)h.AttackDamage);
            }
                //If the hero tries to run
            } else if (h.IsRunningAway) {
                    //Check Speed
                    if (h.AttackSpeed > m.AttackSpeed) {
                        //Run away safely 
                        h.AmountOfTimesAHeroCanRunAway--;
                    } else if(m.AttackSpeed > h.AttackSpeed){
                        h.damageMe((int)m.AttackValue);
                        h.AmountOfTimesAHeroCanRunAway--;
                    } else {
                    //nothing
                }

                }
            

            //Check if hero is alive
            if(h.isAlive() && !m.isAlive()) {
                //Apply xp to level up
                 h._experiancePoints += m.ExperiancePointsGivenToHero;
                 //h.CheckLevelUp(h);
            }
            return h.isAlive();
        }

    }
}