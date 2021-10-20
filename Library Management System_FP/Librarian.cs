using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LibraryManagementSystem
{
    class Librarian 
    {
        public string LibrarianName { get; set; }
        public int LibrarianID { get; set; }
        public int LibrarianPassword { get; set; }

        public List<Book> BooksInLibrary
        {
            get;
            set;
        }
        public List<User> UsersInLibrary
        {
            get;
            set;
        }
        public List<Librarian> LibrariansInLib
        {
            get;
            set;
        }



        public void LibrarianStart()
        {
            Console.WriteLine("Enter your Librarian Login ID :");
            int LibLoginID = int.Parse(Console.ReadLine());

            if(LibLoginID == LibrarianID)
            {
                Console.WriteLine("Enter your 5 Digit Password : ");
                int LibLoginPW = int.Parse(Console.ReadLine());
                if (LibLoginPW == LibrarianPassword)
                {
                    Console.WriteLine("Welcome Librarian " + LibrarianName);
                }
                else
                {
                    Console.WriteLine("Invalid Password. Try Again");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID. Please Try Again");
            }

            bool loop = true;
            while (loop)
            {
                Console.WriteLine("\n Choose the following Options : ");
                Console.WriteLine("1. Enter Book Details");
                Console.WriteLine("2. Search for books ");
                Console.WriteLine("3. Rretreive all book details");
                Console.WriteLine("4. Retreive all user details");
                Console.WriteLine("5. Exit");
            
                int choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        {
                            Console.WriteLine("\nEnter book details");

                            Console.WriteLine("\nEnter Book ID :");
                            int tempID = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Book Name :");
                            string tempBookName = Console.ReadLine();

                            Console.WriteLine("Enter Author Name :");
                            string tempAuthorName = Console.ReadLine();

                            Console.WriteLine("Enter Number of Copies:");
                            int tempNumberOfCopies = int.Parse(Console.ReadLine());

                            Book tempbook = new Book
                            {
                                BookId = tempID,
                                BookName = tempBookName,
                                Author = tempAuthorName,
                                NumberOfCopies = tempNumberOfCopies,
                            };

                            foreach (Book book in BooksInLibrary)
                            {
                                if (book.BookId == tempID)
                                {
                                    Console.WriteLine("Duplicate Book Details found, Please try again");
                                    break;
                                }
                            }
                            BooksInLibrary.Add(tempbook);
                            string BookList = JsonConvert.SerializeObject(BooksInLibrary);
                            File.WriteAllText("Books In Library.json", BookList);
                           
                            break;
                        }

                    case 2:
                        {
                            
                            Console.WriteLine("User selected to Search a book");


                            Console.WriteLine("\nEnter Book ID :");
                            var tempbookID = int.Parse(Console.ReadLine());

                            var bookfound = SearchForBookID(BooksInLibrary, tempbookID);

                            if (bookfound == null)
                            {
                                Console.WriteLine("No book details found for the ID provided");
                            }

                            else
                            {
                                Console.WriteLine("Book details as follows");
                                bookfound.RetreiveBookDetails();
                            }
                            Console.WriteLine("\nBook does not exist\n");
                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine("Showing all Book Details");                            
                            foreach (var bk in BooksInLibrary)
                            {
                                bk.RetreiveBookDetails();
                            }
                            break;
                        }

                    case 4:
                        {
                            Console.WriteLine("Showing all user details");
                            foreach(User usr in UsersInLibrary)                            
                            {
                                usr.retreiveUserDetails();
                            }
                            break;
                        }
                    case 5:
                        {
                            loop = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Input, Please Try Again");
                            break;
                        }
                }          
            }
        }
        private User SearchForUserID(List<User> UsersInLibrary, int userId)
        {
            foreach (User user in UsersInLibrary)
            {
                if (user.UserID == userId)
                {
                    return user;
                }
            }
            return null;

        }

        private Book SearchForBookID(List<Book> BooksInLibrary, int bookId)
        {
            foreach (Book book in BooksInLibrary)
            {
                if (book.BookId == bookId)
                {
                    return book;
                }
            }
            return null;
        }
    }
}
