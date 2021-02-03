using System;

namespace Codecool.LifeOfAnts.Utilities
{
    public static class Util
    {
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
        
        /// <summary>
        /// Returns random int within given limits
        /// </summary>
        /// <param name="max">max limit</param>
        /// <param name="min">min limit</param>
        /// <returns></returns>
        public static int RandomInt(int max, int min = 0)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}