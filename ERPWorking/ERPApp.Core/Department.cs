using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApp.Core
{
   
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string DepartmentName { get; set; }

        
        public bool Active { get; set; }

        [MaxLength(256)]
        public string EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }

        [MaxLength(256)]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
       
        // Navigation Properties
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<ItemCategoryMain> ItemCategoryMain { get; set; }

        public virtual ICollection<ItemPromotion> ItemPromotion { get; set; }

        public virtual ICollection<POMain> POMain { get; set; }
        public virtual ICollection<ReceiveMain> ReceiveMain { get; set; }
       public virtual ICollection<ReturnMain> ReturnMain { get; set; }
        public virtual ICollection<SaleMain> SaleMain { get; set; }
        public virtual ICollection<Voucher> Voucher { get; set; }
    }
}
