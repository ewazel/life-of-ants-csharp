using System;
using System.Collections.Generic;
using Codecool.LifeOfAnts.Utilities;

namespace Codecool.LifeOfAnts.Ants
{
    public class Drone : RegularAnt
    {
        private int MatingTime;

        public Drone(Position position, Colony colony)
            : base(position, colony)
        {
            MatingTime = 0;
            ChangeDirection();
        }
        public override string Sign => "D";
        
        public override ConsoleColor Color => ConsoleColor.Blue;

        public override void OnUpdate()
        {
            if (CheckIfNextToQueen())
            {
                if (MatingTime == 0 && !TryToMate())
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
                Move();
                ChangeDirection();
            }
        }
        
        protected override void ChangeDirection()
        {
            if (Position.X < Queen.Singleton.Position.X)
            {
                Direction = Direction.East;
            }
            else if (Position.X > Queen.Singleton.Position.X)
            {
                Direction = Direction.West;
            }
            else if (Position.Y < Queen.Singleton.Position.Y)
            {
                Direction = Direction.South;
            }
            else
            {
                Direction = Direction.North;
            }
        }
        
        private bool CheckIfNextToQueen()
        {
            return Position.X >= Queen.Singleton.Position.X - 1 && Position.X <= Queen.Singleton.Position.X + 1 &&
                   Position.Y >= Queen.Singleton.Position.Y - 1 && Position.Y <= Queen.Singleton.Position.Y + 1;
        }

        private void KickOff()
        {
            var borderList = new List<int> { 0, Colony.Width};
            int X = Util.RandomInt(Colony.Width + 1);
            int Y;
            if (borderList.Contains(X))
            {
                Y = Util.RandomInt(Colony.Width + 1);
            }
            else
            {
                int index = Util.RandomInt(borderList.Count);
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
                Console.WriteLine("Drone: HURRRRRAY! I did it!");
                return true;
            }
            
            Console.WriteLine("Drone: Well, maybe next time...");
            return false;
        }
    }
}