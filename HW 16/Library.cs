using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.HW_16
{
    internal class Library
    {
        public List<LibraryItem> items = new List<LibraryItem>();

        public void AddItems(LibraryItem item)
        {
            items.Add(item);
        }

        public string BorrowItems(string Title)
        {

            foreach (LibraryItem item in items)
            {
                if (item.Title == Title)
                {
                    return item.Borrow();
                }
            }

            return $"Item with the title {Title} was not found";

        }

        public string ReturnItems(string Title)
        {
           
            foreach (LibraryItem item in items)
            {
                if (item.Title == Title)
                {
                    return item.Return();
                }
            }

            return $"Item with the title {Title} was not found";
           
        }


        public string[] DisplayLibrary()
        {
            List<string> result = new List<string>();
            foreach (LibraryItem item in items)
            {
                result.Add(item.ToString());
            }
            return result.ToArray();
        }


    }

    internal interface IBorrowable
    {
        string Borrow();
        string Return();
    }

    internal class LibraryItem : IBorrowable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublicationYear { get; set; }
        public bool IsBorrowed { get; private set; }

        public LibraryItem(string title, string author, string publicationYear)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            IsBorrowed = false;
        }

        public string Borrow()
        {
            if(IsBorrowed)
            {
                return $"The item {Title} is already borrowed";
            }
            else
            {
                IsBorrowed = true;
                return $"The item {Title} was successfuly borrowed";
            }
            
        }

        public string Return()
        {
            if(IsBorrowed)
            {
                IsBorrowed = false;
                return $"The item {Title} was successfuly returned";
            }
            else
            {
                return $"The item {Title} was not borrowed";
            }
        }

        public override string ToString()
        {
            return $"Item Title: {Title}, Author: {Author}, " + (IsBorrowed ? "This item is borowed" : "This item is available");
        }
    }

   

    internal class Book : LibraryItem
    {       
        public Book(string title, string author, string publicationYear) : base(title, author, publicationYear) { }
    }

    internal class Magazine : LibraryItem
    {
        public Magazine(string title, string author, string publicationYear) : base(title, author, publicationYear) { }
    }

    internal class DVD : LibraryItem
    {
        public DVD(string title, string author, string publicationYear) : base(title, author, publicationYear) { }

    }
}
