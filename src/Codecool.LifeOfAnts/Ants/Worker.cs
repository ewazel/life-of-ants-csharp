using System;
using System.Runtime.CompilerServices;
using Codecool.LifeOfAnts.Utilities;

namespace Codecool.LifeOfAnts.Ants
{
    public class Worker : Ant
    {
        public Worker(Position position, Colony colony) : base(position, colony)
        {
        }
        
        public override string Sign => "W";
        public override ConsoleColor Color => ConsoleColor.Green;

        public override void OnUpdate()
        {
            Array values = Enum.GetValues(typeof(Direction));
            Random random = new Random();
            Direction randomDirection = (Direction)values.GetValue(random.Next(values.Length));
            // TODO: faker nugg
            //var x = Faker.Enum<Direction>();
            Move(randomDirection);
        }
    }
}