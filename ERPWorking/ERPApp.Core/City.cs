using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApp.Core
{
   
    public class City
    {
        [Key]
        public int CityId { get; set; }
       
        public string CityName { get; set; }

        public int TehsilId { get; set; }
        public int DistrictId { get; set; }

        [MaxLength(256)]
        public string EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }

        [MaxLength(256)]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual ICollection<Company> Branch { get; set; }

    }
}
