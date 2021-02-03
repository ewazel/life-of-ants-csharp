using System;
using Codecool.LifeOfAnts.Utilities;

namespace Codecool.LifeOfAnts.Ants
{
    public class Soldier : RegularAnt
    {
        public Soldier(Position position, Colony colony) 
            : base(position, colony)
        {
            Direction = Direction.North;
        }
        
        public override string Sign => "S";
        public override ConsoleColor Color => ConsoleColor.Red;

        public override void OnUpdate()
        {
            Move();
            ChangeDirection();
        }

        protected override void ChangeDirection()
        {
            Direction = ChooseDirection();
        }
        
        private Direction ChooseDirection()
        {
            switch (Direction)
            {
                case Direction.North:
                    return Direction.West;
                case Direction.South:
                    return Direction.East;
                case Direction.West:
                    return Direction.South;
                case Direction.East:
                    return Direction.North;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Direction), Direction, null);
            }
        }
    }
}