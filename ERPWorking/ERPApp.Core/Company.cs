using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApp.Core
{
   
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string CompanyName { get; set; }
               
        
        [Column(TypeName = "varchar")]        
        [MaxLength(15)]
        public string Phone { get; set; }

        //[Column(TypeName = "varbinary")]
        //public string CompanyLogo { get; set; }
        public string WebsiteURL { get; set; }

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
        [ForeignKey("Cities")]
        public int CityId { get; set; }
        public City Cities { get; set; }

        //public virtual ICollection<Branch> Branch { get; set; }

        public virtual ICollection<ExpenseType> ExpenseType { get; set; }
    }
}
