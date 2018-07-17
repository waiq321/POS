using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApp.Core
{
   
    public class ItemCategorySub
    {
        [Key]
        public int SubCategoryId { get; set; }
              
      
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string SubCategoryName { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(10)]
        public string Abb { get; set; }

        public bool Active { get; set; }

        [MaxLength(256)]
        public string EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }

        [MaxLength(256)]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        // Navigation Properties
        [ForeignKey("ItemCategoryMain")]
        public int CategoryId { get; set; }
        public ItemCategoryMain ItemCategoryMain { get; set; }

        public virtual ICollection<Item> Item { get; set; }
        

    }
}
