using CoreObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverable6 {
    public static class Game {
        static private State _GameState;
        static private Map _Map;
        static private int _height;
        static private int _width;
        public enum State { Lost, Running, Won }
        public static State GameState {
            get {
                if (_Map != null && _Map.Adventurer != null &&
                    _Map.Adventurer != null && _Map.Adventurer.CurrentHitPoints <= 0)
                    _GameState = State.Lost;
                return _GameState;
            }

            set {
                _GameState = value;
            }
        }

        public static Map Map {
            get {
                return _Map;
            }
            set {
                _Map = value;
            }
        }

        public static int Height {
            get {
                return _height;
            }

            set {
                _height = value;
            }
        }

        public static int Width {
            get {
                return _width;
            }

            set {
                _width = value;
            }
        }

        public static void ResetGame(int height, int width, Hero a) {
            Width = width;
            Height = height;
            _Map = new Map(height, width);
            int newX, newY;
            Random rnd = new Random();
            do {
                newX = rnd.Next(0, height);
                newY = rnd.Next(0, width);
            } while (_Map.Cells[newX, newY].HasMonster || _Map.Cells[newX, newY].HasItem);

            //if (_Map != null && _GameState == State.Lost) {
            //    _Map.Adventurer = new Hero(Game.Map.Adventurer.Name(), "",
            //    (int)Game.Map.Adventurer.AttackSpeed, Game.Map.Adventurer.MaximumHitPoints,
            //    Game.Map.Adventurer.HandAttackValue,
            //    Game.Map.Adventurer.ExperiencePoints, Game.Map.Adventurer.LevelOfHero,
            //    Game.Map.Adventurer.AmountOfTimesAHeroCanRunAway, newX, newY);
            //} else {
                _Map.Adventurer = new Hero(a.Name(), "",
                    (int)a.AttackSpeed, a.MaximumHitPoints, a.HandAttackValue,
                    a.ExperiencePoints, a.LevelOfHero, a.AmountOfTimesAHeroCanRunAway, newX, newY);

            //}

            Map.LocationOfAdventurer.HasBeenSeen = true;
            _GameState = State.Running;

        }
        public static void ResetGame() {
            ResetGame(Height, Width, Game.Map.Adventurer);
        }
    }
}
