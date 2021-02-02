using System;
using System.Collections.Generic;
using Codecool.LifeOfAnts.Utilities;

namespace Codecool.LifeOfAnts.Ants
{
    public class Drone : Ant
    {
        private int MatingTime;
        private Random random = new Random();

        public Drone(Position position, Colony colony)
            : base(position, colony)
        {
            MatingTime = 0;
        }
        public override string Sign => "D";
        
        public override ConsoleColor Color => ConsoleColor.Blue;

        public override void OnUpdate()
        {
            if (CheckIfNextToQueen())
            {
                if (!TryToMate() && MatingTime == 0)
                {
                    KickOff();
                }
                
                if (MatingTime > 0)
                {
                    MatingTime--;
                }
            }
            else
            {
                Direction direction = DirectToQueen();
                Move(direction);
            }
            // Console.WriteLine("MatingTime:" + MatingTime);
            // Console.WriteLine("X, Y:" + Position.X + " " + Position.Y);
        }
        
        private Direction DirectToQueen()
        {
            // switch!
            if (Position.X < Queen.Singleton.Position.X)
            {
                return Direction.East;
            }
            
            if (Position.X > Queen.Singleton.Position.X)
            {
                return Direction.West;
            }
            
            if (Position.Y < Queen.Singleton.Position.Y)
            {
                return Direction.South;
            }
            
            return Direction.North;
        }
        
        private bool CheckIfNextToQueen()
        {
            // TODO skorzystaj z listy
            return Position.X >= Queen.Singleton.Position.X - 1 && Position.X <= Queen.Singleton.Position.X + 1 &&
                   Position.Y >= Queen.Singleton.Position.Y - 1 && Position.Y <= Queen.Singleton.Position.Y + 1;
        }

        private void KickOff()
        {
            // var borderList = new Tuple<int, int>(0, Colony._width);
            var borderList = new List<int> { 0, Colony._width};
            int X = random.Next(0, Colony._width + 1);
            int Y;
            if (borderList.Contains(X))
            // if (borderList.Item1 == X || borderList.Item2 == X)
            {
                Y = random.Next(0, Colony._width + 1);
            }
            else
            {
                int index = random.Next(borderList.Count);
                Y = borderList[index];
            }
            
            Position newPosition = new Position(X, Y);
            Position = newPosition;
        }
        
        private bool TryToMate()
        {
            bool succesfulMating = Queen.Singleton.TryMate();
            if (succesfulMating)
            {
                MatingTime = 10;
                Console.WriteLine("HURRRRRAY!");
                return true;
            }
            
            // Console.WriteLine("Maybe next time...");
            return false;
        }
    }
}