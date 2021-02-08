using System;

namespace Codecool.LifeOfAnts.Utilities
{
    public static class Util
    {
        public static readonly Random Random = new Random();

        /// <summary>
        /// changes enum direction into vector (X,Y)
        /// </summary>
        /// <param name="dir"> direction as enum</param>
        /// <returns>direction changed into vector X,Y</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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