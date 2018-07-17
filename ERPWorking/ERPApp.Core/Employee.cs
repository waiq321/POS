using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApp.Core
{    
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
       
        [Column(TypeName = "varchar")]
        [MaxLength(10)]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(10)]
        public string LastName { get; set; }
       
              
        public int CityId { get; set; }

        public int Gender { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string RelationName { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(15)]
        public string NIC { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(15)]
        public string CellNo { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

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
              
    }
}
