using System;
using System.Collections.Generic;
namespace csharp_library.Models
{
  public class Library
  {
    public string Location { get; set; }
    public string Name { get; set; }
    private List<Book> Books { get; set; }

    public List<Book> CheckedOut { get; set; }

    // public List<Book> AvailableBooks { get; set; }

    public Library(string location, string name) //constructor
    {
      Location = location;
      Name = name;
      Books = new List<Book>();
      CheckedOut = new List<Book>();

    }


    public void PrintBooks()
    {
      Console.WriteLine("\nSelect a book number to checkout (Q)uit, or (R)eturn a book \n");
      for (int i = 0; i < Books.Count; i++)
      {
        Console.WriteLine($"{i + 1} {Books[i].Title} - {Books[i].Author}");
      }
    }
    public void AddBook(Book book)
    {
      Books.Add(book);
    }
    public void AddBook(Book[] books)
    {
      Books.AddRange(books);
    }

    private Book ValidateBook(string selection, List<Book> bookList)
    {
      int bookIndex = 0;
      bool valid = Int32.TryParse(selection, out bookIndex);
      if (!valid || bookIndex < 1 || bookIndex > bookList.Count)
      {
        return null;
      }
      return bookList[bookIndex - 1];
    }
    public void Checkout(string selection)
    {
      Book selectedBook = ValidateBook(selection, Books);
      if (selectedBook == null)
      {
        Console.Clear();
        System.Console.WriteLine(@"Invalid Selction");
        return;
      }
      selectedBook.Available = false;
      CheckedOut.Add(selectedBook);
      Books.Remove(selectedBook);
      Console.WriteLine("checkout was successful");
    }
    public void ReturnBook(string selection)
    {
      Book selectedBook = ValidateBook(selection, CheckedOut);

      if (selectedBook == null)
      {
        System.Console.WriteLine(@"Invalid Selection, please make a valid selection.
        ");
        return;
      }

      selectedBook.Available = true;
      Books.Add(selectedBook);
      CheckedOut.Remove(selectedBook);
      Console.Clear();
      Console.WriteLine("Successfully Returned Book!");

    }
    public void PrintCheckedOut()
    {
      for (int i = 0; i < CheckedOut.Count; i++)
      {
        Console.WriteLine($"{i + 1} - {CheckedOut[i].Title}");
      }
      Console.WriteLine("\nType (A)vailable to see the list of available books");
    }
  }
}