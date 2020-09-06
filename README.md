# PhilsLibrary
![.NET Core](https://github.com/ArikMackenburg/PhilsLibrary/workflows/.NET%20Core/badge.svg?branch=master)
# Program Specifications
Your solution should include the following:

+ 2 properties in your Program.cs file
  + Library<Book> Library
  + List<Book> BookBag
+ Main method with the following:
  + Instantiates your new Library and Bookbag.
  + A method to LoadBooks() that adds books to your Library. Create a minimum of 5.
  + Call to the UserInterface that prompts the user with different options:
    + View all Books
    + Add a Book
    + Borrow a book
    + Return a book
    + View Book Bag
    + Exit
+ Create a Book class that has:
  + Title
  + Author (Make Author it’s own class with the appropriate properties)
  + Genre (This should be an enum)
+ Appropriate methods for each of the options that the user interface is prompting for
## Guidance
+ Create a custom generic collection named Library<T>.
+ As we learned, under the hood, generic collections are arrays. Utilizing this concept, create a new generic collection (Library<T>) that dynamically resizes an array for all the specified methods described below.
+ Your Generic collection should hold Books.
+ Create an Enum to hold the different genres of book types
+ The methods within your Library<T> class should contain at minimum:
  + Add
  + Remove
  + Count (the total number of books in the library)
+ In your Program.cs have a method named Borrow that gets called from the user interface.
  + The Borrow method should bring in the title of the book
  + Traverse through the library until you find the book that you are looking for
  + Add the book to your BookBag
  + Remove the item from the library
  + You could possibly use similar logic for this as you do in ReturnBook (see below)
+ In your Program.cs have a method named ReturnBook that gets called from the user interface
  + Create a Dictionary<int, Book> that adds each of the books in your BookBag into the dictionary with a counter as the key, and the book as the value. Output each of the titles to the console and have the user select which “number” they want to return. Add that Book back to your Library, and remove it from your BookBag.
