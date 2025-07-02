using Exercise;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Exemplu
{
   
    public class MyClass
    {
        static void Main(string[] args)
        {
            FactoryManager woodManager = new FactoryManager(new WoodenDoorFactory());
            Console.WriteLine("Wooden Door");
            woodManager.ShowDoor("180x70", "Oak");

            Console.WriteLine();

            FactoryManager metalManager = new FactoryManager(new MetalDoorFactory());
            Console.WriteLine("Metal Door");
            metalManager.ShowDoor("195x85", "Black");


        }
    }
}
