using System;
using Codecool.LifeOfAnts.Ants;
using Codecool.LifeOfAnts.Utilities;

namespace Codecool.LifeOfAnts
{
    /// <summary>
    ///     Simulation main class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main method
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Hello, Ants!");

            int minSize = 20;
            int maxSize = 30;
            int maxAmountOfSoldiers = 20;
            int maxAmountOfWorkers = 20;
            int maxAmountOfDrones = 10;

            Colony colony = new Colony(Util.RandomInt(maxSize, minSize), Util.RandomInt(maxAmountOfSoldiers), Util.RandomInt(maxAmountOfDrones), Util.RandomInt(maxAmountOfWorkers));
            colony.Display();
            
            Console.WriteLine("Press ENTER to update simulation or Q to stop it...");
            while (Console.ReadKey().Key != ConsoleKey.Q)
            { 
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    colony.Update();
                }
                Console.WriteLine("Press ENTER to update simulation or Q to stop it...");
            } 
            Console.WriteLine("The simulation is stopped.");
        }
    }
}
