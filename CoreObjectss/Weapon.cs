/*
Weapon.cs
CS 1182 
Written By: Austin Betzer
4/4/2017
Jon Holmes
Description - A weapon item is something that a hero can equip and attack with.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreObjects {
    [Serializable]
    public class Weapon : Item, IRepeatable<Weapon> {
        private int _SpeedModifier;
        private int _Durability;
        #region "Constructors"
        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="wName">Name of the Weapon</param>
        /// <param name="wValue">Amount of damage the weapon can do</param>
        /// <param name="wSpeedModifier">How much this weapon affects the hero's attack speed.</param>
        public Weapon(String wName, int wValue, int wSpeedModifier, int durabiltiy) : base(wName, wValue) {
            _SpeedModifier = wSpeedModifier;
            _Durability = durabiltiy;
        }
        #endregion
        /// <summary>
        /// How much the hero's speed is modified when this weapon is equipped
        /// </summary>
        public int SpeedModifier {
            get {
                return _SpeedModifier;
            }
        }

        public int Durability {
            get {
                return _Durability;
            }

            set {
                _Durability = value;
            }
        }
        /// <summary>
        /// Create a deep copy of this weapon.
        /// </summary>
        /// <returns></returns>
        public Weapon CreateCopy() {
            return new Weapon(this.Name, this.AffectValue, this.SpeedModifier, this.Durability);
        }
    }
}
