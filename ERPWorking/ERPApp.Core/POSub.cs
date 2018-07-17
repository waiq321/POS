using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApp.Core
{
   
    public class POSub
    {
        [Key]
        public int POSId { get; set; }      

        public decimal UnitPrice { get; set; }

        public int Qty { get; set; }

        public decimal TotalAmount { get; set; }
        
        public float Discount { get; set; }
        
        public decimal NetDicountPrice { get; set; }
       
        public decimal Expense { get; set; }

        public decimal UnitExpense { get; set; }

        public decimal NetAmount { get; set; }


        [MaxLength(256)]
        public string EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }


        // Navigation Properties
        [ForeignKey("POMain")]
        public int POId { get; set; }        
        public POMain POMain { get; set; }

        [ForeignKey("Items")]
        public int ItemId { get; set; }
        public Item Items { get; set; }

        public virtual ICollection<ReceiveSub> ReceiveSub { get; set; }
        public virtual ICollection<ReturnSub> ReturnSub { get; set; }
    }
}
