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
        private List<Ant> _listOfAnts = new List<Ant>();
        private Queen _queen;

        public Colony(int width, int amountOfSoldiers, int amountOfDrones, int amountOfWorkers)
        {
            Width = width;
            _queen = new Queen(new Position(Width / 2, Width / 2), this);
            _listOfAnts.Add(_queen);
            GenerateRegularAnts<Soldier>(amountOfSoldiers);
            GenerateRegularAnts<Drone>(amountOfDrones);
            GenerateRegularAnts<Worker>(amountOfWorkers);
        }

        public bool ValidPosition(Position position)
        {
            Position topLeft = new Position(0, 0);
            Position bottomRight = new Position(Width - 1, Width - 1);

            return position.X >= topLeft.X && position.X <= bottomRight.X && position.Y >= topLeft.Y &&
                   position.Y <= bottomRight.Y;
        }
        
        public void Update()
        {
            foreach (var ant in _listOfAnts)
            {
                ant.OnUpdate();
            }
            
            Display();
        }
        
        public void Display()
        {
            for (var y = 0; y <= Width - 1; y++)
            {
                for (var x = 0; x <= Width - 1; x++)
                {
                    var presentAnt = AntAtPosition(new Position(x, y));
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
                var randomPosition = new Position(Util.Random.Next(Width), Util.Random.Next(Width));
                if (Activator.CreateInstance(typeof(T), new object[] { randomPosition, this }) is T ant)
                {
                    _listOfAnts.Add(ant);
                }
                
            }
        }

        private Ant? AntAtPosition(Position position)
        {
            foreach (var ant in _listOfAnts)
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