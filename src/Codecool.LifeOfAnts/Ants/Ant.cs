using System;
using System.Xml.Schema;
using Codecool.LifeOfAnts.Utilities;

namespace Codecool.LifeOfAnts.Ants
{
    public abstract class Ant
    {
        public Position Position;
        //protected Direction Direction;
        protected Colony Colony;

        public abstract string Sign { get; }
        public abstract ConsoleColor Color { get; }

        public Ant(Position position, Colony colony)
        {
            Position = position;
            //Direction = direction;
            Colony = colony;
        }

        // public string ReturnSignIfPresent(Position position)
        // {
        //     if (Position.X == position.X && Position.Y == position.Y)
        //     {
        //         return Sign;
        //     }
        //     return null;
        // }

        public abstract void OnUpdate();

        public void Move(Direction direction)
        {
            (int, int) movementCoordinates = Util.ToVector(direction);
            Position newPosition = new Position(Position.X + movementCoordinates.Item1, Position.Y + movementCoordinates.Item2);
            if (Colony.ValidPosition(newPosition))
            {
                Position = newPosition;
            }
        }
    }
}