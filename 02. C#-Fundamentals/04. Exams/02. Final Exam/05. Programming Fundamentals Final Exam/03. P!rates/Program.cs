﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> towns = new Dictionary<string, Dictionary<string, int>>();

            string command = Console.ReadLine();

            while (command != "Sail")
            {
                string[] tokens = command.Split("||");
                string city = tokens[0];
                int population = int.Parse(tokens[1]);
                int gold = int.Parse(tokens[2]);


                if (!towns.ContainsKey(city))
                {
                    towns.Add(city, new Dictionary<string, int>()
                    {

                        {"population" ,population},// purviq population e za key, a drugoto e Value
                        {"gold" ,gold }
                    });
                }




                else
                {
                    towns[city]["population"] += population;
                    towns[city]["gold"] += gold;
                }



                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split("=>");
                string name = tokens[0];
                string town = tokens[1];


                switch (name)
                {

                    case "Plunder":
                        int people = int.Parse(tokens[2]);
                        int gold = int.Parse(tokens[3]);


                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                        towns[town]["population"] -= people;
                        towns[town]["gold"] -= gold;

                        if (towns[town]["population"] <= 0 || towns[town]["gold"] <= 0)
                        {
                            Console.WriteLine($"{town} has been wiped off the map!");
                            towns.Remove(town);

                        }
                        break;

                    case "Prosper":
                        gold = int.Parse(tokens[2]);
                        if (gold < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                            continue;
                        }
                        towns[town]["gold"] += gold;

                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {towns[town]["gold"]} gold.");


                        break;
                }



                command = Console.ReadLine();
            }


            if (towns.Count > 0)
            {
                towns = towns.OrderByDescending(t => t.Value["gold"])
                    .ThenBy(t => t.Key)
                    .ToDictionary(k => k.Key, v => v.Value);

                Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");

                foreach (var town in towns)
                {
                    int population = town.Value["population"];
                    int gold = town.Value["gold"];
                    Console.WriteLine($"{town.Key} -> Population: {population} citizens, Gold: {gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}

