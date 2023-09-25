using Library_EFCore.NewFolder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_EFCore
{
    public class TransactionServices
    {
        public void CreateBorrowingTransaction(int patronId, int bookId,ApplicationDbContext _context)
        {
            PatronManagement patron = _context.patronManagements.FirstOrDefault(p => p.Pat_ID == patronId);
            BookManagement book = _context.bookManagements.FirstOrDefault(b => b.B_ID == bookId);

            if (patron == null || book == null || !book.is_Available)
            {
                Console.WriteLine("Patron or Book not found");
                return;
            }

            BorrowingTransactions transaction = new BorrowingTransactions
            {
                Pat_ID = patronId,
                B_ID = bookId,
                borrowing_date = DateTime.Now,
                return_date = null // after two weeks
            };

            _context.BorrowingTransactions.Add(transaction);
             book.is_Available = false; // Mark the book as unavailable.
            _context.SaveChanges();
        }

        public void MarkBookAsReturned(int transactionId,ApplicationDbContext _context)
        {
            var transaction = _context.BorrowingTransactions.FirstOrDefault(t => t.TraID == transactionId);

            if (transaction == null || transaction.return_date != null)
            {
                // Handle error, e.g., transaction not found or book is already returned.
                return;
            }

            transaction.return_date = DateTime.Now;
            var book = _context.bookManagements.FirstOrDefault(b => b.B_ID == transaction.B_ID);

            if (book != null)
            {
                book.is_Available = true; // Mark the book as available.
            }

            _context.SaveChanges();
        }
    }
}
