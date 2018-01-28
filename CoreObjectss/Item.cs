/*
Item.cs
CS 1182 
Written By: Austin Betzer
4/4/2017
Jon Holmes
Description - Description - Items in the game that can heal or damage actors.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreObjects {
    [Serializable]
    public abstract class Item {
        protected String _Name;
        protected int _AffectValue;
        /// <summary>
        /// Overloaded contstructor to create an Item.
        /// </summary>
        /// <param name="myName">Name of the item</param>
        /// <param name="value"></param>
        public Item(String myName, int value) {
            Name = myName;
            AffectValue = value;
        }

        /// <summary>
        /// Get and Set Item Name
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }

        /// <summary>
        /// Get and Set Item Affect Value; this is the value of how
        ///  much can cause as an effect.
        /// </summary>
        public int AffectValue
        {
            get
            {
                return _AffectValue;
            }

            set
            {
                _AffectValue = value;
            }
        }
    }
}
