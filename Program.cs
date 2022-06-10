﻿using System;
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
                        var dino = new Dinosaur();
                        //public string Name { get; set; }
                        //public string DietType { get; set; }
                        //public DateTime WhenAcquired { get; set; }
                        //public int Weight { get; set; }
                        //public int EnclosureNumber { get; set; }
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
                        break;
                    case "S":
                        var carnivores = dinos.Count(dinos => dinos.DietType == "C");
                        Console.WriteLine($"The park contains {carnivores} carnivores.");
                        var herbivores = dinos.Count(dinos => dinos.DietType == "H");
                        Console.WriteLine($"The park contains {herbivores} herbivores.");
                        break;
                    case "R":
                        Console.WriteLine("What dino would you like to delete?");
                        var deletedDino = Console.ReadLine();
                        var landonEatsBananas = dinos.Find(dinos => dinos.Name == deletedDino);
                        dinos.Remove(landonEatsBananas);
                        break;
                    case "T":
                        Console.WriteLine("What dino would you like to update?");
                        var updatedDino = Console.ReadLine();
                        var landonEats = dinos.Find(dinos => dinos.Name == updatedDino);
                        Console.WriteLine("What is the new enclosure number?");
                        var newEnclosure = Int32.Parse(Console.ReadLine());
                        landonEats.EnclosureNumber = newEnclosure;
                        break;
                    case "V":
                        //  -in name or enclosure number order
                        //  -if no dinos print out special message
                        Console.WriteLine("Do you want to see the dinos by (E)nclosure number or (N)ame?");
                        var decision = Console.ReadLine();
                        var enclosureNumberOrderDino = dinos.OrderByDescending(dinosaur => dinosaur.EnclosureNumber).ToList();
                        var nameOrderDino = dinos.OrderByDescending(dinosaur => dinosaur.Name).ToList();
                        foreach (var dinoz in nameOrderDino)
                        {
                            Console.WriteLine(dinoz);
                        }
                        break;




                    default:
                        Console.WriteLine($"Sorry that is not an acceptable response please try again.");
                        break;



                }


                //View
                //  -in name or enclosure number order
                //  -if no dinos print out special message

                //Add
                //  -Name, diet type, weight, enclosure number 
                //    - when acquired supplied by code 


                //Remove
                //   - find and delete dino typed in by user 
                //Transfer 
                //  - Prompt user for dinos name 
                //  - Prompt for new enclosure number 
                //  -update the new info for the old
                //Summary 
                //  - display number of carnivores and herbivores  
                // Quit 
                //  -stop program 




            }






            //Create a class to represent your dinosaurs. The class should have the following properties

            //Create a class to represent your dinosaurs. The class should have the following properties
            //Name
            //DietType - This will be "carnivore" or "herbivore"
            //WhenAcquired - This will default to the current time when the dinosaur is created
            //Weight - How heavy the dinosaur is in pounds.
            //EnclosureNumber - the number of the pen the dinosaur is in
            //Add a method Description to your class to print out a description of the dinosaur to include all the properties. Create an output format of your choosing. Feel free to be creative.
            //Keep track of your dinosaurs in a List<Dinosaur>.

            //When the console application runs, it should let the user choose one of the following actions:

            //View
            //This command will ask the user if they wish to see the dinosaurs in Name or EnclosureNumber order. Based on that choice, the list of dinosaurs should be shown in the correct order. If there no dinosaurs in the park, print out a special message to the user.
            //Add
            //This command will let the user type in the information for a dinosaur and add it to the list. Prompt for the Name, Diet Type, Weight and Enclosure Number, but the WhenAcquired must be supplied by the code.
            //Remove
            //This command will prompt the user for a dinosaur name then find and delete the dinosaur with that name.
            //Transfer
            //This command will prompt the user for a dinosaur name and a new EnclosureNumber and update that dino's information.
            //Summary
            //This command will display the number of carnivores and the number of herbivores.
            //Quit
            //This will stop the program
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
