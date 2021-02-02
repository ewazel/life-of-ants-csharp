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
        
        private Random random = new Random();
        public List<Position> QueenOffset = new List<Position>();
        
        public static Queen Singleton { get; private set; }

        public Queen(Position position, Colony colony)
            : base(position, colony)
        {
            Singleton = this;
            mood = false;
            moodCounter = random.Next(minMood, maxMood);
            MakeOffsetList();
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
            
            // Console.WriteLine("moodCounter:" + moodCounter);
            // Console.WriteLine("mood:" + mood);
        }

        public bool TryMate()
        {
            if (mood)
            {
                moodCounter = random.Next(minMood, maxMood);
                mood = false;
                return true;
            }

            return false;
        }

        private void MakeOffsetList()
        {
            QueenOffset.Add(new Position(Position.X + 1, Position.Y));
            QueenOffset.Add(new Position(Position.X + 1, Position.Y + 1));
            QueenOffset.Add(new Position(Position.X, Position.Y + 1));
            QueenOffset.Add(new Position(Position.X - 1, Position.Y));
            QueenOffset.Add(new Position(Position.X - 1, Position.Y - 1));
            QueenOffset.Add(new Position(Position.X, Position.Y - 1));
            QueenOffset.Add(new Position(Position.X + 1, Position.Y - 1));
            QueenOffset.Add(new Position(Position.X - 1, Position.Y + 1));
        }
    }
}