using System;
using System.Collections.Generic;

namespace Exercise
{
    public enum Bread { Whole_wheat, Rye_Flour, Spelt_flour }
    public enum Meat { Chicken, Pork, Beef, None }
    public enum Cheese { Cheddar, Mozzarella, None }
    public enum Vegetables { Cabbage, Tomatoes, Cucumber }
    public enum Sauce { Mayo, Ketchup, Mustard }

    public class Sandwich
    {
        public Bread Bread { get; set; }
        public Meat Meat { get; set; }
        public Cheese Cheese { get; set; }
        public List<Vegetables> Vegetables { get; set; } = new();
        public Sauce Sauce { get; set; }

        public override string ToString()
        {
            var vegs = Vegetables.Any() ? string.Join(", ", Vegetables) : "None";
            return $"Bread: {Bread}\n" +
                       $"Meat: {(Meat == Meat.None ? "None" : Meat.ToString())}\n" +
                       $"Cheese: {(Cheese == Cheese.None ? "None" : Cheese.ToString())}\n" +
                       $"Vegetables: {vegs}\n" +
                       $"Sauce: {Sauce}";
        }
       
    }

    public abstract class SandwichBuilder
    {
        protected Sandwich _sandwich = new();

        public abstract void AddBread(Bread bread);
        public abstract void AddMeat(Meat meat);
        public abstract void AddCheese(Cheese cheese);
        public abstract void AddVegetables(params Vegetables[] vegetables);
        public abstract void AddSauce(Sauce sauces);
        public Sandwich GetSandwich() => _sandwich;
    }

    public class CustomSandwichBuilder : SandwichBuilder
    {
        public override void AddBread(Bread bread) => _sandwich.Bread = bread;
        public override void AddMeat(Meat meat) => _sandwich.Meat = meat;
        public override void AddCheese(Cheese cheese) => _sandwich.Cheese = cheese;
        public override void AddVegetables(params Vegetables[] vegetables) => _sandwich.Vegetables.AddRange(vegetables);
        public override void AddSauce(Sauce sauce) => _sandwich.Sauce = sauce;
    }

    public class SandwichDirector
    {
        private readonly SandwichBuilder _sandwichBuilder;

        public SandwichDirector(SandwichBuilder sandwichBuilder)
        {
            _sandwichBuilder = sandwichBuilder;
        }

        public Sandwich Construct(Bread bread, Meat meat, Cheese cheese, Vegetables vegetables, Sauce sauce)
        {
            _sandwichBuilder.AddBread(bread);
            _sandwichBuilder.AddMeat(meat);
            _sandwichBuilder.AddCheese(cheese);
            _sandwichBuilder.AddVegetables(vegetables);
            _sandwichBuilder.AddSauce(sauce);

            return _sandwichBuilder.GetSandwich();
        }
    }
}

