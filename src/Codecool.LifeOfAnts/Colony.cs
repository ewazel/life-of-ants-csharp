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
        public readonly int _width;
        private List<Ant> _listOfAnts = new List<Ant>();

        public Colony(int width, int amountOfSoldiers, int amountOfDrones, int amountOfWorkers)
        {
            _width = width - 1;
            GenerateAnts(amountOfSoldiers, amountOfDrones, amountOfWorkers);
            // TODO: jak zrezygnowac z parametru dziedziczonego z wyzszej klasy?
            Queen queen = new Queen(new Position(_width / 2, _width / 2), this);
            _listOfAnts.Add(queen);
        }

        public bool ValidPosition(Position position)
        {
            Position topLeft = new Position(0, 0);
            Position bottomRight = new Position(_width, _width);

            return position.X >= topLeft.X && position.X <= bottomRight.X && position.Y >= topLeft.Y &&
                   position.Y <= bottomRight.Y;
        }

        private Position RandomPosition()
        {
            Random random = new Random();
            return new Position(random.Next(_width), random.Next(_width));
        }

        private void GenerateAnts(int amountOfSoldiers, int amountOfDrones, int amountOfWorkers)
        {
            for (int i = 0; i < amountOfSoldiers; i++)
            {
                Ant soldier = new Soldier(RandomPosition(), this);
                _listOfAnts.Add(soldier);
            }
            
            for (int i = 0; i < amountOfDrones; i++)
            {
                Ant drone = new Drone(RandomPosition(), this);
                _listOfAnts.Add(drone);
            }
            
            for (int i = 0; i < amountOfWorkers; i++)
            {
                Ant worker = new Worker(RandomPosition(), this);
                _listOfAnts.Add(worker);
            }
        }
        
        // private void GenerateAnts2<T>(int amountOfAnts) where T: Ant
        // {
        //     for (int i = 0; i < amountOfAnts; i++)
        //     {
        //         // TODO: IAnt powinna być interfejsem i by przeszło!
        //         T soldier = new T (RandomPosition(), this);
        //         _listOfAnts.Add(soldier);
        //     }
        // }

        public void Update()
        {
            // Console.WriteLine("update");
            foreach (var ant in _listOfAnts)
            {
                ant.OnUpdate();
            }
            
            Display();
        }
        
        public void Display()
        {
            for (var y = 0; y <= _width; y++)
            {
                for (var x = 0; x <= _width; x++)
                {
                    Ant presentAnt = IsAnt(new Position(x, y));
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
        
        private Ant? IsAnt(Position position)
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