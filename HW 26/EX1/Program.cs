using Exercise;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Exemplu
{
   
    public class MyClass
    {
        static TEnum Option<TEnum>(string message) where TEnum : Enum
        {
            var values = Enum.GetValues(typeof(TEnum));
            while (true)
            {
                Console.WriteLine($"\n{message}");
                int i = 1;
                foreach (var val in values)
                {
                    Console.WriteLine($"{i++}. {val}");
                }

                Console.Write("Choose the option number: ");
                if (int.TryParse(Console.ReadLine(), out int result) &&
                    result >= 1 && result <= values.Length)
                {
                    return (TEnum)values.GetValue(result - 1);
                }
                else
                {
                    Console.WriteLine("Invalid option, please try again.");
                }
            }
        }


        static void Main(string[] args)
        {
            SandwichBuilder builder = new CustomSandwichBuilder();

            Bread bread = Option<Bread>("Choose the bread type: ");
            builder.AddBread(bread);

            Meat meat = Option<Meat>("Choose the meat type: ");
            builder.AddMeat(meat);

            Cheese cheese = Option<Cheese>("Choose the cheese type: ");
            builder.AddCheese(cheese);

            var vegOptions = Enum.GetValues(typeof(Vegetables));
            List<Vegetables> selectedVeggies = new();

            while (true)
            {
                Console.WriteLine("\nChoose vegetables (e.g., 1,3):");
                int i = 1;
                foreach (var val in vegOptions)
                {
                    Console.WriteLine($"{i++}. {val}");
                }

                string input = Console.ReadLine();
                var parts = input.Split(',', StringSplitOptions.RemoveEmptyEntries);
                bool allValid = true;

                foreach (var part in parts)
                {
                    if (int.TryParse(part.Trim(), out int num) &&
                        num >= 1 && num <= vegOptions.Length)
                    {
                        selectedVeggies.Add((Vegetables)vegOptions.GetValue(num - 1));
                    }
                    else
                    {
                        Console.WriteLine($"Invalid vegetable option: '{part.Trim()}'");
                        allValid = false;
                        selectedVeggies.Clear();
                        break;
                    }
                }

                if (allValid && selectedVeggies.Any())
                    break;
                else
                    Console.WriteLine("Please try again.\n");
            }

            foreach (var veg in selectedVeggies)
            {
                builder.AddVegetables(veg);
            }

            Sauce sauce = Option<Sauce>("Choose the sauce: ");
            builder.AddSauce(sauce);

            Sandwich sandwich = builder.GetSandwich();
            Console.WriteLine();
            Console.WriteLine("Your Sandwich");
            Console.WriteLine(sandwich);


        }    
    }
}
