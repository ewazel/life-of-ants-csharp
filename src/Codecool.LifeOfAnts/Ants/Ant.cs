using System;
using System.Xml.Schema;
using Codecool.LifeOfAnts.Utilities;

namespace Codecool.LifeOfAnts.Ants
{
    public abstract class Ant
    {
        public Position Position;
        protected Colony Colony;

        public abstract string Sign { get; }
        public abstract ConsoleColor Color { get; }

        public Ant(Position position, Colony colony)
        {
            Position = position;
            Colony = colony;
        }

        public abstract void OnUpdate();
    }
}