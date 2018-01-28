/*
Actor.cs
CS 1182 
Written By: Austin Betzer
4/4/2017
Jon Holmes
Description - // Interface for Repeatable Items.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreObjects {
     /// <summary>
     /// Interface for a Object that needs to be copied
     /// </summary>
     /// <typeparam name="T"></typeparam>
     interface IRepeatable<T> {
         /// <summary>
         /// Create a copy of this object
         /// </summary>
         /// <returns>copy of the object</returns>
         T CreateCopy();
    }
}
