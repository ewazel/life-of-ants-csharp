using System;
using System.Collections.Generic;
using Codecool.LifeOfAnts.Utilities;

namespace Codecool.LifeOfAnts.Ants
{
    public class Queen : Ant
    {
        private bool mood;
        private int moodCounter;
        private int minMood = 50;
        private int maxMood = 100;
        
        public static Queen Singleton { get; private set; }

        public Queen(Position position, Colony colony)
            : base(position, colony)
        {
            Singleton = this;
            mood = false;
            moodCounter = Util.RandomInt(maxMood, minMood);
        }
        
        public override string Sign => "Q";
        public override ConsoleColor Color => ConsoleColor.Yellow;


        public override void OnUpdate()
        {
            if (moodCounter > 0)
            {
                moodCounter--;
            }
            else if (moodCounter == 0)
            {
                mood = true;
            }

            switch (mood)
            {
                case true:
                    Console.WriteLine($"The Queen is in mood. She is waiting!");
                    break;
                case false:
                    Console.WriteLine($"The Queen is resting now. She will be in mood in {moodCounter} steps.");
                    break;
            } 
        }

        public bool TryMate()
        {
            if (mood)
            {
                moodCounter = Util.RandomInt(maxMood, minMood);
                mood = false;
                return true;
            }

            return false;
        }
    }
}