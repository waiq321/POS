using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApp.Core
{
   
    public class PartyType
    {
        [Key]
        public int PartyTypeId { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string PartyTypeName { get; set; }

       
        [MaxLength(256)]
        public string EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }

        [MaxLength(256)]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Party> Party { get; set; }
    }
}
