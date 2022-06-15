using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicPark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the coolest group!");
            var dinos = new List<Dinosaur>();
            var programIsAlive = true;

            while (programIsAlive)
            {
                Console.WriteLine("What do you want to do? These are your options:");
                Console.WriteLine("(V)iew\n(R)emove\n(A)dd\n(T)ransfer\n(S)ummary");
                Console.Write("(Q)uit\n");
                var choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "A":
                        AddDino(dinos);
                        break;
                    case "S":
                        SummaryDino(dinos);
                        break;
                    case "R":
                        RemoveDino(dinos);
                        break;
                    case "T":
                        TransferDino(dinos);
                        break;
                    case "V":
                        ViewDino(dinos);
                        break;
                    default:
                        Console.WriteLine($"Sorry that is not an acceptable response please try again.");
                        break;
                }
            }
        }

        private static void ViewDino(List<Dinosaur> dinos)
        {
            Console.WriteLine("Do you want to see the dinos by (E)nclosure number or (N)ame?");
            var decision = Console.ReadLine();
            var enclosureNumberOrderDino = dinos.OrderByDescending(dinosaur => dinosaur.EnclosureNumber).ToList();
            var nameOrderDino = dinos.OrderByDescending(dinosaur => dinosaur.Name).ToList();
            foreach (var dinoz in nameOrderDino)
            {
                dinoz.Description();
            }
        }

        private static void TransferDino(List<Dinosaur> dinos)
        {
            Console.WriteLine("What dino would you like to update?");
            var updatedDino = Console.ReadLine();
            var landonEats = dinos.Find(dinos => dinos.Name == updatedDino);
            Console.WriteLine("What is the new enclosure number?");
            var newEnclosure = Int32.Parse(Console.ReadLine());
            landonEats.EnclosureNumber = newEnclosure;
        }

        private static void RemoveDino(List<Dinosaur> dinos)
        {
            Console.WriteLine("What dino would you like to delete?");
            var deletedDino = Console.ReadLine();
            var landonEatsBananas = dinos.Find(dinos => dinos.Name == deletedDino);
            dinos.Remove(landonEatsBananas);
        }

        private static void SummaryDino(List<Dinosaur> dinos)
        {
            var carnivores = dinos.Count(dinos => dinos.DietType == "C");
            Console.WriteLine($"The park contains {carnivores} carnivores.");
            var herbivores = dinos.Count(dinos => dinos.DietType == "H");
            Console.WriteLine($"The park contains {herbivores} herbivores.");
        }

        private static void AddDino(List<Dinosaur> dinos)
        {
            var dino = new Dinosaur();
            Console.WriteLine("Please enter your dino's name");
            dino.Name = Console.ReadLine();
            Console.WriteLine("Please enter your dino's diet: (C)arnivore or (H)erbivore.");
            dino.DietType = Console.ReadLine();
            Console.WriteLine("Please enter your dino's weight.");
            dino.Weight = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please enter your dino's enclosure number.");
            dino.EnclosureNumber = Int32.Parse(Console.ReadLine());
            dino.WhenAcquired = DateTime.Now;
            dinos.Add(dino);
        }
    }
    class Dinosaur
    {
        public string Name { get; set; }
        public string DietType { get; set; }
        public DateTime WhenAcquired { get; set; }
        public int Weight { get; set; }
        public int EnclosureNumber { get; set; }
        public void Description()
        {
            Console.WriteLine($"{Name} is a {DietType}, weighing {Weight} lbs and lives in {EnclosureNumber}. {Name} was entered on {WhenAcquired}.");
        }
    }
}
