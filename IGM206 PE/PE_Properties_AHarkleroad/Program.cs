namespace PE_Properties_AHarkleroad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // variable declaration
            string title;
            string author;
            int numberOfPages;
            string owner;
            Book book;
            string userInput = "";
            
            // prompts the user to enter data needed to instantiate a Book object
            Console.Write("What is the book's title? ");
            title = Console.ReadLine();
            Console.Write("Who is the book's author? ");
            author = Console.ReadLine();
            Console.Write("How many pages does it have? ");
            numberOfPages = int.Parse(Console.ReadLine());
            Console.Write("Who is the book's current owner? ");
            owner = Console.ReadLine();
            // constructs new book
            book = new Book(title, author, numberOfPages, owner);
            Console.WriteLine();

            // has the user get and change data, read the book, and print its info until they enter "done"
            while (userInput.Trim() != "done")
            {
                Console.Write("What would you like to do? ");
                userInput = Console.ReadLine().Trim().ToLower();
                // performs an action based on user input
                switch (userInput)
                {
                    case "title":
                        Console.WriteLine("The title is " + book.Title);
                        break;
                    case "author":
                        Console.WriteLine("The author is " + book.Author);
                        break;
                    case "pages":
                        Console.WriteLine("The book has " + book.NumberOfPages + " pages");
                        break;
                    // allows the user to change or only print the owner based on user input
                    case "owner":
                        Console.Write("Would you like to change the owner (yes/no)? ");
                        userInput = Console.ReadLine().Trim().ToLower();
                        if (userInput == "yes")
                        {
                            Console.Write("Who is the new owner? ");
                            userInput = Console.ReadLine();
                            book.Owner = userInput;
                            Console.WriteLine("The new owner is " + book.Owner);
                            // prevents the program from ending if the name of the owner is "Done"
                            if (book.Owner.Trim().ToLower() == "done")
                            {
                                userInput = "";
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ok. " + book.Owner + " is still the owner.");
                        }
                        break;
                    case "read":
                        book.TimesRead += 1;
                        Console.WriteLine("The total times read is now " + book.TimesRead);
                        break;
                    case "print":
                        book.Print();
                        break;
                    // stops the loop
                    case "done":
                        Console.WriteLine("Goodbye");
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
