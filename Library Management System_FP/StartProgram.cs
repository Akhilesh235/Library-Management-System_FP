using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class StartProgram
    {
        List<User> UsersInLibrary = new List<User>();
        List<Book> BooksInLibrary = new List<Book>();
        List<Librarian> LibrariansInLib = new List<Librarian>();


        Librarian Librarian1 = new Librarian()
        {
            LibrarianName = "Akhilesh",
            LibrarianID = 001
        };
        User user1 = new User()
        {
            UserName = "John",
            UserID = 101
        };
        Book book1 = new Book()
        {
            BookId = 700,
            BookName = "Harry Potter",
            Author = "J.K. Rowling",
            NumberOfCopies = 5
        };


        public void StartOption()
        {
            LibrariansInLib.Add(Librarian1);
            BooksInLibrary.Add(book1);
            UsersInLibrary.Add(user1);

            Console.WriteLine("Welcome to Library");
            Begin:
            Console.WriteLine("\nMAIN MENU");
            Console.WriteLine("1. Librarian");
            Console.WriteLine("2. User ");

            
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    {
                        Librarian librarian = new Librarian();
                        librarian.LibrarianStart();
                        break;
                    }

                case 2:
                    {
                        User user = new User();
                        user.UserStart();
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Invalid Input. Please Try Again");
                        goto Begin;
                    }
            }
        }

       
    }
}
