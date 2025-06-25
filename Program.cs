using Exercise;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Exemplu
{
   public class Book
   {
       public int Id { get; set; }
       public string Title { get; set; }
       public string Author { get; set; }
       public int Year { get; set; }
       public int CopiesAvailable { get; set; }
   }
   
    public class MyClass
    {
        static void Main(string[] args)
        {
            List <Book>  books = new List<Book> {
                new Book { Id = 1, Title = "C# in Depth", Author = "Jon Skeet", Year = 2019, CopiesAvailable = 5 },
                new Book { Id = 2, Title = "Pro C# 7", Author = "Andrew Troelsen", Year = 2018, CopiesAvailable = 2 },
                new Book { Id = 3, Title = "C# 6.0 and the .NET 4.6 Framework", Author = "Andrew Troelsen", Year = 2015, CopiesAvailable = 0 },
                new Book { Id = 4, Title = "Learning C# by Developing Games", Author = "Harrison Ferrone", Year = 2020, CopiesAvailable = 4 },
                new Book { Id = 5, Title = "CLR via C#", Author = "Jeffrey Richter", Year = 2012, CopiesAvailable = 1 }
            };

            var filter = books.Where(b => b.Author == "Andrew Troelsen");
            foreach (var item in filter)
            {
                Console.WriteLine($"{item.Title}");
            }
            Console.WriteLine();

            var order = from b in books
                        orderby b.Year descending
                        select b;
            foreach(var item in order)
            {
                Console.WriteLine($"{item.Title}");
            }
            Console.WriteLine();

            var projection = from b in books
                             where b.CopiesAvailable > 0
                             select b;

            foreach (var item in projection)
            {
                Console.WriteLine($"{item.Title}");
            }

            Console.WriteLine();
            var sum = books.Sum(b => b.CopiesAvailable);
            Console.WriteLine($"Sum of copies: {sum}");

            var distinct = from b in books                           
                           select b.Author.Distinct();
            Console.WriteLine();


            var result = books.OrderBy(b => b.Title).Skip(2).Take(2);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Title}");
            }
        }
    }
}
