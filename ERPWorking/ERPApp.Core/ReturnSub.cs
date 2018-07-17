using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApp.Core
{
   
    public class ReturnSub
    {
        [Key]
        public int RSId { get; set; }        

        public int ReturnQty { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalAmount { get; set; }

        public float Discount { get; set; }

        public decimal NetDicountPrice { get; set; }

        public decimal NetAmount { get; set; }

        // Navigation Properties
        [ForeignKey("ReturnMain")]
        public int RMId { get; set; }
        public ReturnMain ReturnMain { get; set; }

        [ForeignKey("POSub")]
        public int POSId { get; set; }
        public POSub POSub { get; set; }


        [ForeignKey("SaleSub")]
        public int SSId { get; set; }
        public SaleSub SaleSub { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }
        
    }
}
