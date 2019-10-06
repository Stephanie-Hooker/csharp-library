using System;
using csharp_library.Models;

namespace csharp_library
{

  static class Program
  {
    static void Main(string[] args)
    {
      bool inLibrary = true;
      Console.WriteLine($"Welcome to The Library! \n");
      Book sidewalk = new Book("Where the Sidewalk Ends", "Shel Silverstein");
      Book hobbit = new Book("The Hobbit", "J.R.R. Tolkein");
      Book lion = new Book("The Lion, The Witch, and the Wardrobe", "C.S. Lewis");
      Book hP = new Book(" Harry Potter and the Sorcerer's Stone", "J.K. Rowling");

      Enum activeMenu = Menus.CheckoutBook;

      Library myLibrary = new Library("Boise", "Boise Library");
      myLibrary.AddBook(new Book[] { sidewalk, hobbit, lion, hP }); //adding all the books from my library

      while (inLibrary)
      {


        switch (activeMenu)
        {
          case Menus.CheckoutBook:
            myLibrary.PrintBooks();
            break;
          case Menus.ReturnBook:
            Console.WriteLine("--Checked out books");
            myLibrary.PrintCheckedOut();
            break;
        }

        string selection = Console.ReadLine();
        switch (selection.ToUpper())
        {
          case "Q":
            inLibrary = false;
            Console.WriteLine($"Thank you for visiting the {myLibrary.Name} in {myLibrary.Location}");
            return;
          case "R":
            Console.Clear();
            activeMenu = Menus.ReturnBook;
            break;
          case "A":
            Console.Clear();
            activeMenu = Menus.CheckoutBook;
            break;
          default:
            if (activeMenu.Equals(Menus.CheckoutBook))
            {
              myLibrary.Checkout(selection);
            }
            else
            {
              myLibrary.ReturnBook(selection);
            }
            break;
        }
      }
    }

    public enum Menus
    {
      CheckoutBook,
      ReturnBook
    }
  }
}
