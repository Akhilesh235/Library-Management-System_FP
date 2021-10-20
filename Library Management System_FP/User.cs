using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class User 
    {
        public string UserName { get; set; }
        public int UserID { get; set; }
        public double finePaid { get; set; }

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

        public void UserStart()
        {
            Console.WriteLine("Enter your UserName and Login ID :");
            string username = Console.ReadLine();
            int UserLoginID = int.Parse(Console.ReadLine());

            if (UserLoginID == UserID)
            {
                Console.WriteLine("Welcome Librarian {0}" , username);
            }
            else
            {
                Console.WriteLine("Invalid ID. Please Try Again");
            }
            Console.WriteLine("Choose the Following Options");
            Console.WriteLine("1. Borrow a Book");
            Console.WriteLine("2. Return a Book");
            Console.WriteLine("3. Add New User");
            Console.WriteLine("4. Pay Fine");   //COME BACK TO THIS

            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    {
                        Console.WriteLine("Enter Details of book to be borrowed");  //after this need to check how many books he has borrowed
                        Console.WriteLine("Enter Book ID : ");
                        int tempId = int.Parse(Console.ReadLine());                        
                        var validBook = SearchForBookID(BooksInLibrary, tempId);
                        if (validBook == null)
                        {
                            Console.WriteLine("invalid bookId, please try again");
                            break;
                        }
                        else if (validBook.NumberOfCopies <= 0)
                        {
                            Console.WriteLine("Currently that book is not available in library");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Enter User ID");
                            int usrId = int.Parse(Console.ReadLine());
                            var validId = SearchForUserID(UsersInLibrary, usrId);
                            if (validId == null)
                            {
                                Console.WriteLine("Invalid User ID, Please Try Again");
                                break;
                            }
                            else
                            {
                                validId.BooksInLibrary.Add(validBook);
                                validBook.NumberOfCopies--;
                            }
                        }
                        break;
                    }

                case 2:
                    {
                        Console.WriteLine("Enter User ID");
                        int usrId = int.Parse(Console.ReadLine());
                        var validId = SearchForUserID(UsersInLibrary, usrId);
                        if (validId == null)
                        {
                            Console.WriteLine("Invalid User ID, Please Try Again");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Book ID that you would like to return");
                            int tempId = int.Parse(Console.ReadLine());
                            var validBook = SearchForBookID(BooksInLibrary, tempId);
                            validId.BooksInLibrary.Remove(validBook);
                            validBook.NumberOfCopies++;
                        }
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("\nEnter User details");
                        Console.WriteLine("\nEnter User ID :");
                        int tempID = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter User Name :");
                        string tempName = Console.ReadLine();

                        User newUser = new User
                        {
                            UserID = tempID,
                            UserName = tempName,
                        };

                        foreach(User user in UsersInLibrary)
                        {
                            if(user.UserID == tempID)
                            {
                                Console.WriteLine("Duplicate User Details found, Please try again");
                                break;
                            }
                            UsersInLibrary.Add(newUser);
                            Console.WriteLine("User Added!");
                        }

                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid Input. Please try again");
                        break;
                    }
            }
        }

        public void retreiveUserDetails()
        {
            Console.WriteLine("UserID : " + UserID);
            Console.WriteLine("Username : " + UserName);
            Console.WriteLine("Borrowed books by the user : ");
            foreach (var bk in BooksInLibrary)
            {
                Console.WriteLine(bk.BookName);
            }

        }

         private static User SearchForUserID(List<User> UsersInLibrary, int userId)
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

        private static Book SearchForBookID(List<Book> BooksInLibrary, int bookId)
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


