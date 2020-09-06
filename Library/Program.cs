using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using Library;

namespace Library
{
    public class Program
    {
        public static int IDNum = 1;
        public static Library<Book> Library = new Library<Book>();
        public static List<Book> BookBag = new List<Book>();
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to Phil's Lending Library!");
            Console.ReadKey();
            PopulateLibrary();
            UserInterface();
            
            
        }
       
        
        //User Interface
        static void UserInterface()
        {
            
        Menu:
            Console.Clear();
            Console.WriteLine("Select an option");
            Console.WriteLine("------------------");
            Console.WriteLine("1. - Checkout Book");
            Console.WriteLine("2. - Return Book");
            Console.WriteLine("3. - View Your Books");
            Console.WriteLine("4. - Phil's Menu");

            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    AvailableBooks();
                    CheckoutBook();
                    Console.ReadKey();
                    goto Menu;

                case "2":
                    ReturnBook();
                    goto Menu;

                case "3":
                    CheckBag();
                    goto Menu;

                case "4":
                    AllBooks();
                    goto Menu;
            }
            

        }
        // Add a book to the library
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
        // Starting books for library
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
        // List of all books for admin with checkedout status
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
            Console.ReadKey();
        }
        // Shows available books that arent checkedout
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

        // Admin add book
        static void AddABookToLibrary()
        {
            string inputTitle = SetTitle();
            string inputFirstName = SetFirstName();
            string inputLastName = SetLastName();
            Genre inputGenre = SelectGenre();

            AddBook(inputTitle,inputFirstName,inputLastName,inputGenre);

        }
        // Helper for AddABookToLibrary

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
        // Helper for AddABookToLibrary

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
        // Helper for AddABookToLibrary

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
        // Helper for AddABookToLibrary

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
        // Checkout book
        static void CheckoutBook()
        {
            Console.WriteLine();
            Console.WriteLine("Select book number to checkout");
            string inputString = Console.ReadLine();
            int input = Convert.ToInt32(inputString);
            
            foreach (Book book in Library)
            {
                
                if ( input == book.iD)
                {
                    book.CheckedOut = true;
                    BookBag.Add(book);
                    Console.Clear();
                    Console.WriteLine($"Checked out {book.Title}");
                }
            }
            
        }
        // Users bookbag
        static void CheckBag()
        {
            Console.Clear();
            Console.WriteLine("Book Bag");
            foreach (Book book in BookBag)
            {
                Lines();
                Console.WriteLine($"{book.iD}.    Title: {book.Title}");
                Console.WriteLine($"      Author: {book.Author.Name()}");
                Console.WriteLine($"      Genre: {book.Genre}");
            }
            Console.ReadKey();
        }
        static void ReturnBook()
        {
            Console.Clear();
            Console.WriteLine("Choose book to return");
            foreach (Book book in BookBag)
            {
                Lines();
                Console.WriteLine($"{book.iD}.    Title: {book.Title}");
                Console.WriteLine($"      Author: {book.Author.Name()}");
                Console.WriteLine($"      Genre: {book.Genre}");
            }
            string inputString = Console.ReadLine();
            int input = Convert.ToInt32(inputString);
            foreach (Book book in BookBag)
            {
                if (input == book.iD)
                {
                    BookBag.Remove(book);
                    break;
                }
            }
            foreach (Book book in Library)
            {
                if (input == book.iD)
                {
                    book.CheckedOut = false;
                }
            }

        }
    }
}
