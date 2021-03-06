﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApp.Core
{
   
    public class ItemCategoryMain
    {
        [Key]
        public int CategoryId { get; set; }


        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string CategoryName { get; set; }
            

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
        [ForeignKey("Branch")]
        public int BranchId { get; set; }        
        public Branch Branch { get; set; }

       
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<ItemCategorySub> ItemCategorySub { get; set; }
    }
}
