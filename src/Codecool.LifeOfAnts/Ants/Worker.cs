using System;
using System.Runtime.CompilerServices;
using Codecool.LifeOfAnts.Utilities;

namespace Codecool.LifeOfAnts.Ants
{
    public class Worker : RegularAnt
    {
        public Worker(Position position, Colony colony) 
            : base(position, colony)
        {
            ChangeDirection();
        }
        
        public override string Sign => "W";
        public override ConsoleColor Color => ConsoleColor.Green;
        
        protected sealed override void ChangeDirection()
        {
            Array values = Enum.GetValues(typeof(Direction));
            var nextDirection = values.GetValue(Util.Random.Next(values.Length));
            if (nextDirection != null)
            {
                direction = (Direction)nextDirection;
            }
        }
        
        public override void OnUpdate()
        {
            Move();
            ChangeDirection();
        }
    }
}