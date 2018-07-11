using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Core.HospitalAdminGeneral
{
    public class Hospital
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Hospital Name is Required")]
        [StringLength(100, ErrorMessage = "Maximum 100 Characters Allowed")]
        public string Name { get; set; }

        [StringLength(20)]
        public string PhoneNo { get; set; }

        [StringLength(100, ErrorMessage = "Maximum 100 Characters Allowed", MinimumLength = 4)]        
        public string Location { get; set; }
        [StringLength(20, ErrorMessage = "Maximum 100 Characters Allowed", MinimumLength = 4)]
        
        public string Email { get; set; }
        
        public int CreatedBy { get; set; }
        
        public DateTime? CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
