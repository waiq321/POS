using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApp.Core
{
   
    public class POExpense
    {
        [Key]
        public int POExpenseId { get; set; }
                
        public decimal Amount { get; set; }
    
        public DateTime ExpenseDate { get; set; }
        public string ExpenseBy { get; set; }

        public int VoucherId { get; set; }

        [MaxLength(256)]
        public string EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }

        // Navigation Properties
        [ForeignKey("ExpenseType")]
        public int ExpenseTypeId { get; set; }        
        public ExpenseType ExpenseType { get; set; }

        [ForeignKey("POMain")]
        public int POId { get; set; }
        public POMain POMain { get; set; }
    }
}
