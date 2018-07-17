using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApp.Core
{
   
    public class ReceiveSub
    {
        [Key]
        public int RSId { get; set; }       

        public int ReceiveQty { get; set; }

        public int SoldQty { get; set; }

        public int ReturnQty { get; set; }

        public int Stock { get; set; }

        public DateTime? ExpiryDate { get; set; }

        // Navigation Properties
        [ForeignKey("ReceiveMain")]
        public int RMId { get; set; }        
        public ReceiveMain ReceiveMain { get; set; }

        [ForeignKey("POSub")]
        public int POSubId { get; set; }
        public POSub POSub { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public virtual ICollection<SaleSub> SaleSub { get; set; }
    }
}
