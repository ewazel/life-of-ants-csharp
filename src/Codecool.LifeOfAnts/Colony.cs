#nullable enable
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Schema;
using Codecool.LifeOfAnts.Ants;
using Codecool.LifeOfAnts.Utilities;

namespace Codecool.LifeOfAnts
{
    public class Colony
    {
        public readonly int Width;
        private List<Ant> listOfAnts = new List<Ant>();

        public Colony(int width, int amountOfSoldiers, int amountOfDrones, int amountOfWorkers)
        {
            Width = width - 1;
            Ant queen = new Queen(new Position(Width / 2, Width / 2), this);
            listOfAnts.Add(queen);
            GenerateRegularAnts<Soldier>(amountOfSoldiers);
            GenerateRegularAnts<Drone>(amountOfDrones);
            GenerateRegularAnts<Worker>(amountOfWorkers);
        }

        public bool ValidPosition(Position position)
        {
            Position topLeft = new Position(0, 0);
            Position bottomRight = new Position(Width, Width);

            return position.X >= topLeft.X && position.X <= bottomRight.X && position.Y >= topLeft.Y &&
                   position.Y <= bottomRight.Y;
        }
        
        public void Update()
        {
            foreach (var ant in listOfAnts)
            {
                ant.OnUpdate();
            }
            
            Display();
        }
        
        public void Display()
        {
            for (var y = 0; y <= Width; y++)
            {
                for (var x = 0; x <= Width; x++)
                {
                    var presentAnt = IsAnt(new Position(x, y));
                    if (presentAnt != null)
                    {
                        Console.ForegroundColor = presentAnt.Color;
                        Console.Write(presentAnt.Sign + "  ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(".  ");
                    }
                }
                Console.Write("\n");
            }
        }

        private void GenerateRegularAnts<T>(int amountOfAnts)
            where T : RegularAnt
        {
            for (int i = 0; i < amountOfAnts; i++)
            {
                Position randomPosition = new Position(Util.RandomInt(Width), Util.RandomInt(Width));
                var ant = Activator.CreateInstance(typeof(T), new object[] { randomPosition, this }) as T;
                listOfAnts.Add(ant);
            }
        }

        private Ant? IsAnt(Position position)
        {
            foreach (var ant in listOfAnts)
            {
                if (ant.Position.X == position.X && ant.Position.Y == position.Y)
                {
                    return ant;
                }
            }

            return null;
        }
    }
}