using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_EFCore.NewFolder
{
    public class BorrowingTransactions
    {
        [Key]
        public int TraID { get; set; }
        [Required]
        public DateTime borrowing_date { get; set; }
        [Required]
        public DateTime return_date { get; set; }


        [ForeignKey("BookManagement")]
        public int B_ID { get; set; }
        public BookManagement BookManagement { get; set; }

        [ForeignKey("PatronManagement")]
        public int Pat_ID { get; set; }
        public PatronManagement PatronManagement { get; set; }

    }
}
