/*
Monster.cs
CS 1182 
Written By: Austin Betzer
4/4/2017
Jon Holmes
Description - A monster is an actor that can attack and be attacked by a hero.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreObjects {
    [Serializable]
    public class Monster:Actor {
        private int _AttackValue = 0;
        private int _ExperiancePointsGivenToHero;
        #region "Constructors"
        /// <summary>
        /// OverLoaded Constructor
        /// </summary>
        /// <param name="newName">Monster's Name</param>
        /// <param name="newTitle">Monster's Title, if any</param>
        /// <param name="myAttackSpeed">How faster the Monster can attack</param>
        /// <param name="hitPoints">Amount of life</param>
        /// <param name="startingPositionX">Starting Position x Coordinate</param>
        /// <param name="startingPositionY">Starting Position y Coordinate</param>
        /// <param name="attackDamage">How much damage the monster can do</param>
        public Monster(String newName, String newTitle, double myAttackSpeed, int hitPoints, int startingPositionX,
            int startingPositionY, int attackDamage, int experiancePoints) 
            :base(newName,newTitle,myAttackSpeed,hitPoints,startingPositionX,startingPositionY ){
            _AttackValue = attackDamage;
            _ExperiancePointsGivenToHero = experiancePoints;
        }
        #endregion
        /// <summary>
        /// Amount of damage done by the monster
        /// </summary>
        public int AttackValue {
            get {
                return _AttackValue;
            }
        }

        public int ExperiancePointsGivenToHero {
            get {
                return _ExperiancePointsGivenToHero;
            }

            set {
                _ExperiancePointsGivenToHero = value;
            }
        }

        /// <summary>
        /// Create a deep copy of this monster
        /// </summary>
        /// <returns></returns>
        public Monster CreateCopy() {
            return new Monster(this._Name, this._Title, this._AttackSpeed, this._MaximumHitPoints, this._PositionX, 
                this._PositionY, this._AttackValue,this._ExperiancePointsGivenToHero);
        }
    }
}
