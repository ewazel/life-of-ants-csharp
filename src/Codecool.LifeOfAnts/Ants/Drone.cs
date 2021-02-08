using System;
using System.Collections.Generic;
using Codecool.LifeOfAnts.Utilities;

namespace Codecool.LifeOfAnts.Ants
{
    public class Drone : RegularAnt
    {
        private int _matingTime;

        public Drone(Position position, Colony colony)
            : base(position, colony)
        {
            _matingTime = 0;
            ChangeDirection();
        }
        public override string Sign => "D";
        
        public override ConsoleColor Color => ConsoleColor.Blue;

        public override void OnUpdate()
        {
            if (CheckIfNextToQueen())
            {
                if (_matingTime == 0 && !TryToMate())
                {
                    KickOff();
                }
                
                if (_matingTime > 0)
                {
                    _matingTime--;
                }
            }
            else
            {
                Move();
                ChangeDirection();
            }
        }
        
        protected sealed override void ChangeDirection()
        {
            if (Position.X < Queen.Singleton.Position.X)
            {
                direction = Direction.East;
            }
            else if (Position.X > Queen.Singleton.Position.X)
            {
                direction = Direction.West;
            }
            else if (Position.Y < Queen.Singleton.Position.Y)
            {
                direction = Direction.South;
            }
            else
            {
                direction = Direction.North;
            }
        }
        
        private bool CheckIfNextToQueen()
        {
            return Position.X >= Queen.Singleton.Position.X - 1 && Position.X <= Queen.Singleton.Position.X + 1 &&
                   Position.Y >= Queen.Singleton.Position.Y - 1 && Position.Y <= Queen.Singleton.Position.Y + 1;
        }

        private void KickOff()
        {
            var borderList = new List<int> { 0, colony.Width};
            int X = Util.Random.Next(colony.Width + 1);
            int Y;
            if (borderList.Contains(X))
            {
                Y = Util.Random.Next(colony.Width + 1);
            }
            else
            {
                int index = Util.Random.Next(borderList.Count);
                Y = borderList[index];
            }
            
            Position newPosition = new Position(X, Y);
            Position = newPosition;
        }
        
        private bool TryToMate()
        {
            bool successfulMating = Queen.Singleton.TryMate();
            if (successfulMating)
            {
                _matingTime = 10;
                Console.WriteLine("Drone: HURRRRRAY! I did it!");
                return true;
            }
            
            Console.WriteLine("Drone: Well, maybe next time...");
            return false;
        }
    }
}