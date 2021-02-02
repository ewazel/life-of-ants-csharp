using System;

namespace Codecool.LifeOfAnts.Utilities
{
    public static class Util
    {
        public static (int x, int y) ToVector(this Direction dir)
        {
            switch (dir)
            {
                case Direction.North:
                    return (0, -1);
                case Direction.South:
                    return (0, 1);
                case Direction.West:
                    return (-1, 0);
                case Direction.East:
                    return (1, 0);
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }
        }
    }
}