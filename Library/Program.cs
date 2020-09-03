using System;
using Library;

namespace Library
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Library = new Library<Book>();
            PopulateLibrary();
            AllBooks();
        }
        public static Library<Book> Library { get; set; }
        public static Library<Book> BookBag { get; set; }

        static void AddBook(string title, string fName, string lName, Genre genre)
        {
            Book book = new Book();
            book.Title = title;

            Author author = new Author(fName, lName);

            book.Author = author;

            book.Genre = genre;

            Library.AddBook(book);

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
            foreach (Book book in Library)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author.Name()}");
                Console.WriteLine($"Genre: {book.Genre}");
            }
        }
    }
}
