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
        
        protected override void ChangeDirection()
        {
            Array values = Enum.GetValues(typeof(Direction));
            Direction = (Direction)values.GetValue(Util.RandomInt(values.Length));
        }
        
        public override void OnUpdate()
        {
            Move();
            ChangeDirection();
        }
    }
}