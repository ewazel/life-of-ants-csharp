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
            var borderList = new List<int> { 0, colony.Width - 1 };
            int x = Util.Random.Next(colony.Width);
            int y;
            if (borderList.Contains(x))
            {
                y = Util.Random.Next(colony.Width);
            }
            else
            {
                int index = Util.Random.Next(borderList.Count);
                y = borderList[index];
            }
            
            Position newPosition = new Position(x, y);
            Position = newPosition;
        }
        
        private bool TryToMate()
        {
            bool successfulMating = Queen.Singleton.AllowToMate();
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