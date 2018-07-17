using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApp.Core
{
   
    public class Party
    {
        [Key]
        public int PartyId { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string PartyName { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string ContactPerson { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(15)]
        public string ContactNo { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }
       

        public bool Active { get; set; }

        [MaxLength(256)]
        public string EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }

        [MaxLength(256)]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        
        // Navigation Properties
        [ForeignKey("PartyType")]
        public int PartyTypeId { get; set; }
        public PartyType PartyType { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public virtual ICollection<POMain> POMain { get; set; }
        public virtual ICollection<ReturnMain> ReturnMain { get; set; }
        public virtual ICollection<SaleMain> SaleMain { get; set; }
    }
}
