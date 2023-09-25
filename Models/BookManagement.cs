using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_EFCore.NewFolder
{
    public class BookManagement
    {
        [Key]
        public int B_ID { get; set; }

        [Required]
        public string title { get; set; }
        [Required]
        public string author { get; set; }
        [Required]
        public int publication_year { get; set; }

        public bool is_Available = true;

        public List<BorrowingTransactions> borrowingTransactions { get; set; }


    }
}
