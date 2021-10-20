using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public int NumberOfCopies { get; set; }

        public void RetreiveBookDetails()
        {
            Console.WriteLine("\nBook ID : " + BookId);
            Console.Write(" Title of Book : " + BookName);
            Console.Write(" Author : " + Author);
            Console.Write(" Number of Copies: " + NumberOfCopies);
            
        }

    }
}
