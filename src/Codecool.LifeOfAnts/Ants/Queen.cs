using System;
using System.Collections.Generic;
using Codecool.LifeOfAnts.Utilities;

namespace Codecool.LifeOfAnts.Ants
{
    public class Queen : Ant
    {
        private const int MinMood = 50;
        private const int MaxMood = 100;
        
        private bool _mood => _moodCounter == 0;
        private int _moodCounter;

        public static Queen Singleton { get; private set; }

        public Queen(Position position, Colony colony)
            : base(position, colony)
        {
            Singleton = this;
            // _mood = false;
            _moodCounter = Util.Random.Next(MinMood, MaxMood);
        }
        
        public override string Sign => "Q";
        public override ConsoleColor Color => ConsoleColor.Yellow;


        public override void OnUpdate()
        {
            if (_moodCounter > 0)
            {
                _moodCounter--;
            }
            // else if (_moodCounter == 0)
            // {
            //     _mood = true;
            // }

            switch (_mood)
            {
                case true:
                    Console.WriteLine($"The Queen is in mood. She is waiting!");
                    break;
                case false:
                    Console.WriteLine($"The Queen is resting now. She will be in mood in {_moodCounter} steps.");
                    break;
            } 
        }

        public bool TryMate()
        {
            if (_mood)
            {
                _moodCounter = Util.Random.Next(MinMood, MaxMood);
                return true;
            }

            return false;
        }
    }
}