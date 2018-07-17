using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApp.Core
{
   
    public class Manufacturer
    {
        [Key]
        public int ManufacturerId { get; set; }


        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string ManufacturerName { get; set; }

        public bool Active { get; set; }

        [MaxLength(256)]
        public string EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }


        [MaxLength(256)]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Item> Item { get; set; }
    }
}
