using Library_EFCore.NewFolder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_EFCore
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlServer("Data Source=(local);Initial Catalog=library_EFCORE; Integrated Security=true; TrustServerCertificate=True");
        }

        public DbSet<BorrowingTransactions> BorrowingTransactions { get; set;}
        public DbSet<PatronManagement> patronManagements { get; set;}
        public DbSet<BookManagement> bookManagements { get; set;}
    }
}
