using Library_EFCore.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_EFCore
{
    public class CRUDPatronFunctions
    {
        public static void AddBook(PatronManagement patron, ApplicationDbContext _context)
        {
            _context.patronManagements.Add(patron);
            _context.SaveChanges();
        }

        public static void Remove(int ID, ApplicationDbContext _context)
        {
            PatronManagement patrnmanagement = _context.patronManagements.SingleOrDefault(x => x.Pat_ID == ID);

            if (patrnmanagement != null)
            {
                _context.patronManagements.Remove(patrnmanagement);
                _context.SaveChanges();

                Console.WriteLine("PATRON Removes SUccessfully");
            }
            else
            {
                Console.WriteLine("Book Not Found");
            }
        }

        public static void UpdateBook(int ID, string Name, string EmailAdress, ApplicationDbContext _context)
        {
            PatronManagement patrnmanagement = _context.patronManagements.SingleOrDefault(x => x.Pat_ID == ID);

            if (patrnmanagement != null)
            {
                patrnmanagement.Name = Name;
                patrnmanagement.EmailAddress = EmailAdress;
                _context.Update(patrnmanagement);
                _context.SaveChanges();

                Console.WriteLine("Patron updated SUccessfully");
            }
            else
            {
                Console.WriteLine("Book Not Found");
            }
        }


        public static PatronManagement GetPatronByName(string Name, ApplicationDbContext _context)
        {
            PatronManagement patrnmanagement = _context.patronManagements.SingleOrDefault(x => x.Name == Name);
            return patrnmanagement;
        }

        public static PatronManagement GetPatronByEmail(string EmailAdress, ApplicationDbContext _context)
        {
            PatronManagement patrnmanagement = _context.patronManagements.SingleOrDefault(x => x.EmailAddress == EmailAdress);
            return patrnmanagement;

        }

        
    }
}
