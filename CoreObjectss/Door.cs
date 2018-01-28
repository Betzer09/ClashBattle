/*
Door.cs
CS 1182 
Written By: Austin Betzer
4/4/2017
Jon Holmes
Description - Door class that creates a certin code for the door making it so it needs a key.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreObjects {
    [Serializable]
    public  class Door:Item {
        string _Code;
       public Door(String name, int value, String code):base(name, value) {
            _Code = code;
        }

        public bool isMatch(DoorKey key) {
            return key.Code == _Code;
        }

        
    }
}
