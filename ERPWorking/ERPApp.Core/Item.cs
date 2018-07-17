using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApp.Core
{
    [Table("Items")]
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [MaxLength(25)]
        public string ItemCode { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string ItemName { get; set; }

     
        [MaxLength(100)]
        public string Description { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string BarCode { get; set; }

        public decimal SalePrice { get; set; }

        public int Discount { get; set; }

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

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [ForeignKey("ItemCategoryMain")]
        public int CategoryId { get; set; }
        public ItemCategoryMain ItemCategoryMain { get; set; }

        [ForeignKey("ItemCategorySub")]
        public int SubCategoryId { get; set; }
        public ItemCategorySub ItemCategorySub { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public virtual ICollection<ItemPromotion> ItemPromotion { get; set; }

        public virtual ICollection<POSub> POSub { get; set; }
        public virtual ICollection<ReceiveSub> ReceiveSub { get; set; }

        public virtual ICollection<ReturnSub> ReturnSub { get; set; }
        public virtual ICollection<SaleSub> SaleSub { get; set; }
    }
}
