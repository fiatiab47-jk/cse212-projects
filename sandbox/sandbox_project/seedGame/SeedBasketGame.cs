/*
What is a Namespace in C#?
A namespace is used to organize code and prevent naming
conflicts between classes. It groups related classes together, 
like folders organize files.
*/ 
using System;
using System.Collections.Generic;


namespace sandbox.sandbox_project.seedGame
{
    public class SeedBasketGame
    {
        public void Run()
        {
            var basket = new Stack<string>();
            Random rand = new Random();
            int score = 0;
            bool running = true;

            string[] seedTypes = { "Corn", "Tomato", "Beans", "Carrot", "Pepper" };

            Console.WriteLine("\n=== Seed Basket Game ===");

            while (running)
            {
                Console.WriteLine("\n1. Add random seed");
                Console.WriteLine("2. Remove seed");
                Console.WriteLine("3. Check basket");
                Console.WriteLine("4. Exit");

                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string newSeed = seedTypes[rand.Next(seedTypes.Length)];
                        basket.Push(newSeed);
                        Console.WriteLine($"{newSeed} added to the basket.");
                        break;

                    case "2":
                        if (basket != null && basket.Count > 0)
                        {
                            string removed = basket.Pop();
                            Console.WriteLine($"{removed} removed from the basket.");
                            score += 10;
                        }
                        else if (basket != null && basket.Count == 0)
                        {
                            Console.WriteLine("Basket is empty!");
                            score -= 5;
                        }
                        else
                        {
                            Console.WriteLine("Basket does not exist.");
                        }
                        break;

                    case "3":
                        Console.WriteLine($"Seeds in the basket: {basket.Count}");
                        if (basket.Count > 0)
                        {
                            Console.WriteLine($"Top seed: {basket.Peek()}");
                        }
                        else
                        {
                            Console.WriteLine("Basket is empty!");
                        }
                        break;

                    case "4":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        continue;

                }
                Console.WriteLine($"Score: {score}");
            }
            Console.WriteLine("Game Over!");
        }

    }
}