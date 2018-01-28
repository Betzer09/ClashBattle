/*
DoorKey.cs
CS 1182 
Written By: Austin Betzer
4/4/2017
Jon Holmes
Description - DooryKey class which makes key for the door. 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreObjects {
    [Serializable]
    public class DoorKey:Item {
        string _Code;

        public DoorKey(string name, int value, string code):base(name, value) {
            _Code = code;
        }

        public string Code {
            get {
                return _Code;
            }
        }
    }
}
