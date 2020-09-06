using System;
using System.Collections.Generic;
using System.Data;
using Library;

namespace Library
{
    public class Program
    {
        public static int IDNum = 1;
        static void Main(string[] args)
        {
            PopulateLibrary();
            UserInterface();
            
            
        }
        public static Library<Book> Library = new Library<Book>();
        public static List<Book> BookBag = new List<Book>();
        
        static void UserInterface()
        {
            
            Console.WriteLine("Welcome to Phil's Lending Library!");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Select an option");
            Console.WriteLine("------------------");
            Console.WriteLine("1. - Checkout Book");
            Console.WriteLine("2. - Return Book");
            Console.WriteLine("3. - Phil's Menu");

            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    AvailableBooks();
                    CheckoutBook();
                    CheckBag();
                    
                    break;

                case "2":
                    AddABookToLibrary();
                    break;
            }
            

        }
        static void AddBook(string title, string fName, string lName, Genre genre)
        {
            Book book = new Book();
            book.Title = title;

            Author author = new Author(fName, lName);

            book.Author = author;

            book.Genre = genre;

            book.iD = IDNum++;

            Library.AddBook(book);

        }
        static void Lines()
        {
            Console.WriteLine("---------------------------------------------------");
        }

        static void PopulateLibrary()
        {
            AddBook("Harry Potter and the Sorcerer's Stone","J.K.","Rowling",Genre.Fantasy);
            AddBook("Harry Potter and the Chamber of Secrets","J.K.","Rowling",Genre.Fantasy);
            AddBook("Harry Potter and the Prisoner of Azkaban","J.K.","Rowling",Genre.Fantasy);
            AddBook("Harry Potter and the Goblet of Fire","J.K.","Rowling",Genre.Fantasy);
            AddBook("Harry Potter and the Order of the Phoenix","J.K.","Rowling",Genre.Fantasy);
            AddBook("Harry Potter and the Half Blood Prince","J.K.","Rowling",Genre.Fantasy);
            AddBook("Harry Potter and the Deathly Hallows","J.K.","Rowling",Genre.Fantasy);         
            
        }

        static void AllBooks()
        {
            Console.Clear();
            foreach (Book book in Library)
            {

                Lines();
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author.Name()}");
                Console.WriteLine($"Genre: {book.Genre}");
                if (book.CheckedOut == true) {
                    Console.WriteLine("  - Checked Out");
                }
            }
        }
        static void AvailableBooks()
        {
            
            Console.Clear();
            Console.WriteLine("Choose book to checkout");
            foreach (Book book in Library)
            {
                
                if (book.CheckedOut == false)
                {

                    Lines();
                    Console.WriteLine($"{book.iD}.    Title: {book.Title}");
                    Console.WriteLine($"      Author: {book.Author.Name()}");
                    Console.WriteLine($"      Genre: {book.Genre}");
                }

            }
        }
        static void AddABookToLibrary()
        {
            string inputTitle = SetTitle();
            string inputFirstName = SetFirstName();
            string inputLastName = SetLastName();
            Genre inputGenre = SelectGenre();

            AddBook(inputTitle,inputFirstName,inputLastName,inputGenre);

        }

        static Genre SelectGenre()
        {
            Console.Clear();
            Console.WriteLine("Enter Genre");
            Lines();
            int num = 1;
            foreach (var i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{num++}: {i}");
            }
            Console.Write("Genre: ");
            string input = Console.ReadLine();

            if (input == "1" || input.ToLower() == "nonfiction")
            {
                return Genre.NonFiction;
            }
            if (input == "2" || input.ToLower() == "fantasy")
            {
                return Genre.Fantasy;
            }
            if (input == "3" || input.ToLower() == "Mystery")
            {
                return Genre.Mystery;
            }
            if (input == "4" || input.ToLower() == "Romance")
            {
                return Genre.Romance;
            }
            if (input == "5" || input.ToLower() == "adult")
            {
                return Genre.Adult;
            }
            if (input == "6" || input.ToLower() == "comic")
            {
                return Genre.Comic;
            }
            return Genre.Unknown;
            //1: NonFiction
            //2: Fantasy
            //3: Mystery
            //4: Romance
            //5: Adult
            //6: Comic

        }

        static string SetTitle()
        {
        title:
            Console.Clear();
            Console.WriteLine("Enter Title");
            Lines();
            Console.Write("Title: ");
            string inputTitle = Console.ReadLine();
            if (inputTitle == "")
            {
                goto title;
            }
            return inputTitle;
        }
        static string SetFirstName()
        {
        author:
            Console.Clear();
            Console.WriteLine("Enter Author");
            Lines();
            Console.Write("First Name: ");
            string inputFirstName = Console.ReadLine();
            if (inputFirstName == "")
            {
                goto author;
            }
            return inputFirstName;
        }
        static string SetLastName()
        {
        author:
            Console.Write("Last Name: ");
            string inputLastName = Console.ReadLine();
            if (inputLastName == "")
            {
                goto author;
            }
            return inputLastName;
        }
        
        static void CheckoutBook()
        {
            Console.WriteLine();
            Console.WriteLine("Select book number to checkout");
            string inputString = Console.ReadLine();
            int input = Convert.ToInt32(inputString);
            Console.WriteLine(input);
            foreach (Book book in Library)
            {
                Console.WriteLine(book.iD);
                if ( input == book.iD)
                {
                    book.CheckedOut = true;
                    BookBag.Add(book);    
                }
            }
        }
        
        static void CheckBag()
        {
            foreach (Book book in BookBag)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
