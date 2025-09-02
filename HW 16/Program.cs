using Exercise.H15;
using Exercise.HW_16;
using Exercise.HW_17;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Threading;
using System.Transactions;

namespace Exercise
{

    class Program
    {
        
        static void Main()
        {
            Library library = new Library();

            DVD dvd = new DVD("Inception", "Christopher Nolan", "2010");
            HW_16.Book book = new HW_16.Book("1984", "George Orwell", "1949");

            library.AddItems(dvd);
            library.AddItems(book);



            Console.WriteLine(library.BorrowItems("sfvgb"));
            Console.WriteLine();

            foreach (var item in library.DisplayLibrary())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine(library.ReturnItems("1984"));


        }


    }
}