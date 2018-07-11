using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Core
{
    public class StoreItems
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50,ErrorMessage="Too Large Item Code",MinimumLength=1)]
        public string  ItemCode { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Max. 200 Character Allowed", MinimumLength = 5)]
        public string ItemName { get; set; }
        
        
        public String Type { get; set; }

        [ForeignKey("itemCatageorys")]
        public int? ItemCatageory { get; set; }
        public virtual ItemCatageory itemCatageorys { get; set; }

        [ForeignKey("PharmacyItemManufacturer")]
        public int? Manufacturer { get; set; }
        public virtual ItemManufacturer PharmacyItemManufacturer { get; set; }

        [ForeignKey("itemtypes")]
        public int? ItemType { get; set; }
        public virtual ItemType itemtypes { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? CreateBy {get;set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? IsActive { get; set; }

    }
}
