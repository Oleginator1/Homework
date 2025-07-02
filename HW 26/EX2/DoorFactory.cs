using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    public interface IDoor
    {
        string Material {  get; }
        string Size { get; }
        string Color { get; }
        void Display();
    }

    public class WoodenDoor : IDoor
    {
        public string Material => "Wood";
        public string Size { get; set; }
        public string Color { get; set; }

        public WoodenDoor(string size, string color)
        {
            Size = size;
            Color = color;
        }
        public void Display()
        {
            Console.WriteLine($"Material: {Material}");
            Console.WriteLine($"Size: {Size}");
            Console.WriteLine($"Color: {Color}");
        }
    }

    public class MetalDoor : IDoor
    {
        public string Material => "Metal";
        public string Size { get; set; }
        public string Color { get; set; }

        public MetalDoor(string size, string color)
        {
            Size = size;
            Color = color;
        }

        public void Display()
        {
            Console.WriteLine($"Material: {Material}");
            Console.WriteLine($"Size: {Size}");
            Console.WriteLine($"Color: {Color}");
        }
    }


    public interface IDoorFacotory
    {
        IDoor CreateDoor(string size, string color);
    }

    public class WoodenDoorFactory : IDoorFacotory
    {
        public IDoor CreateDoor(string size, string color)
        {
            return new WoodenDoor(size, color);
        }
    }

    public class MetalDoorFactory : IDoorFacotory
    {
        public IDoor CreateDoor(string size, string color)
        {
            return new MetalDoor(size, color);
        }
    }

    public class FactoryManager
    {
        private readonly IDoorFacotory doorFacotry;
        public FactoryManager(IDoorFacotory doorFacotry)
        {
            this.doorFacotry = doorFacotry;
        }

        public void ShowDoor(string size, string color)
        {
            var door = doorFacotry.CreateDoor(size, color);
            door.Display();
        }

    }

}
