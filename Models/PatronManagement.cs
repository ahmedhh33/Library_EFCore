using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_EFCore.NewFolder
{
    public class PatronManagement
    {
        [Key]
        public int Pat_ID { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress] 
        public string EmailAddress { get; set;}

        public List<BorrowingTransactions> borrowingTransactions { get; set; }

    }
}
