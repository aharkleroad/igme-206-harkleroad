using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Properties_AHarkleroad
{
    internal class Book
    {
        // variable declaration
        private string title;
        private string author;
        private int numberOfPages;
        private string owner;
        private int timesRead;

        // Book constructor
        public Book(string title, string author, int numberOfPages, string owner)
        {
            this.title = title;
            this.author = author;
            this.numberOfPages = numberOfPages;
            this.owner = owner;
            timesRead = 0;
        }

        // returns the title of a Book
        public string Title
        {
            get { return title; }
        }

        // returns the author of a Book
        public string Author
        {
            get { return author; }
        }

        // returns the number of pages a Book has
        public int NumberOfPages
        {
            get { return numberOfPages; }
        }

        // returns the owner of a book
        public string Owner
        {
            get { return owner; }
            set 
            {
                if (value != "")
                {
                    owner = value;
                }
            }
        }

        // returns or sets the number of times a book has been read (if it's been read more times than before)
        public int TimesRead
        {
            get { return timesRead; }
            set 
            {
                if (value > timesRead)
                {
                    timesRead = value;
                } 
            }
        }

        // prints all of a Books information
        public void Print()
        {
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Author: " + author);
            Console.WriteLine("Number of pages: " + numberOfPages);
            Console.WriteLine("Owner: " + owner);
            Console.WriteLine("Number of times read: " + timesRead);
        }
    }
}
