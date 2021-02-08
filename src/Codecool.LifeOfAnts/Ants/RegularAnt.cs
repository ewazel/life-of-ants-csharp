using Codecool.LifeOfAnts.Utilities;

namespace Codecool.LifeOfAnts.Ants
{
    public abstract class RegularAnt : Ant
    {
        protected Direction direction;

        protected RegularAnt(Position position, Colony colony)
            : base(position, colony)
        {
        }

        protected void Move()
        {
            (int x, int y) movementCoordinates = Util.ToVector(direction);
            Position newPosition = new Position(Position.X + movementCoordinates.x, Position.Y + movementCoordinates.y);
            if (colony.ValidPosition(newPosition))
            {
                Position = newPosition;
            }
        }

        protected abstract void ChangeDirection();
    }
}