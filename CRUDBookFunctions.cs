using Library_EFCore.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_EFCore
{
    public class CRUDBookFunctions
    {
        public static void AddBook(BookManagement Book,ApplicationDbContext _context)
        {
            _context.bookManagements.Add(Book);
            _context.SaveChanges();
        }

        public static void Remove(int ID, ApplicationDbContext _context)
        {
            BookManagement bookManagement = _context.bookManagements.SingleOrDefault(x=>x.B_ID == ID);

            if (bookManagement != null)
            {
                _context.bookManagements.Remove(bookManagement);
                _context.SaveChanges();

                Console.WriteLine("Book Removes SUccessfully");
            }
            else 
            {
                Console.WriteLine("Book Not Found");
            }
        }

        public static void UpdateBook(int ID,string title,string author, int publication_year, ApplicationDbContext _context)
        {
            BookManagement bookManagement = _context.bookManagements.SingleOrDefault(x => x.B_ID == ID);

            if (bookManagement != null)
            {
               bookManagement.title = title;
               bookManagement.author = author;
               bookManagement.publication_year = publication_year;
               _context.Update(bookManagement);
               _context.SaveChanges();

                Console.WriteLine("Book updated SUccessfully");
            }
            else
            {
                Console.WriteLine("Book Not Found");
            }
        }


        public static BookManagement GetBookByTitle(string title, ApplicationDbContext _context)
        {
            BookManagement bookManagement = _context.bookManagements.SingleOrDefault(b=>b.title == title);
            return bookManagement;
        } 

        public static List<BookManagement> GetBookByAuthor(string Author, ApplicationDbContext _context)
        {
            List<BookManagement> bookManagement = _context.bookManagements.Where(b => b.author == Author).ToList();
            return bookManagement;

        }

        public static List<BookManagement> GetBookByPublisherDate(int Date, ApplicationDbContext _context)
        {
            List<BookManagement> bookManagement = _context.bookManagements.Where(b => b.publication_year == Date).ToList();
            return bookManagement;

        }


    }
}
