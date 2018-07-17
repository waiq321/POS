using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApp.Core
{

    public class SaleSub
    {
        [Key]
        public int SSId { get; set; }
       
        public int Qty { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalAmount { get; set; }

        public float Discount { get; set; }
        public decimal NetDicountPrice { get; set; }
        public decimal NetAmount { get; set; }


        // Navigation Properties
        [ForeignKey("SaleMain")]
        public int SMId { get; set; }                
        public SaleMain SaleMain { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }

        [ForeignKey("ReceiveSub")]
        public int RSId { get; set; }
        public ReceiveSub ReceiveSub { get; set; }

        public virtual ICollection<ReturnSub> ReturnSub { get; set; }
    }
    }
