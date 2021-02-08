using System;
using System.Xml.Schema;
using Codecool.LifeOfAnts.Utilities;

namespace Codecool.LifeOfAnts.Ants
{
    public abstract class Ant
    {
        public Position Position;
        protected Colony colony;
        
        protected Ant(Position position, Colony colony)
        {
            Position = position;
            this.colony = colony;
        }

        public abstract string Sign { get; }
        public abstract ConsoleColor Color { get; }

        public abstract void OnUpdate();
    }
}