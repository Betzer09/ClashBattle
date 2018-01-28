/*
Potion.cs
CS 1182 
Written By: Austin Betzer
4/4/2017
Jon Holmes
Description - A potion is something that can heal a hero
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreObjects {
    [Serializable]
    public class Potion : Item, IRepeatable<Potion> {
        private Colors _Color;

        public enum Colors {
            Red,
            Green,
            Blue,
            Purple,
            Yellow,
            Pink
        }

        #region "Constructors"
        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="newName">Potion's Name</param>
        /// <param name="value">Value or Potency of the Potion</param>
        /// <param name="clr">Color of the Potion</param>
        public Potion(String newName, int value, Colors clr)
            : base(newName, value) {
            _Color = clr;
        }
        #endregion

        /// <summary>
        /// Get and Set the Potion's Color
        /// </summary>
        public Colors Color {
            get {
                return _Color;
            }

            set {
                _Color = value;
            }
        }
        /// <summary>
        /// Create a deep copy of this potion.
        /// </summary>
        /// <returns></returns>
        public Potion CreateCopy() {
            return new Potion(this._Name, this._AffectValue, this._Color);
        }
    }
}
