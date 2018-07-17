using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApp.Core
{
   
    public class ReturnMain
    {
        [Key]
        public int RMId { get; set; }            

        [MaxLength(256)]
        public string ReturnBy { get; set; }
        public DateTime? ReturnDate { get; set; }
        
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string ReturnType { get; set; }

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

        [ForeignKey("SaleMain")]
        public int SMId { get; set; }
        public SaleMain SaleMain { get; set; }

        [ForeignKey("POMain")]
        public int POId { get; set; }
        public POMain POMain { get; set; }

        [ForeignKey("Voucher")]       
        public int VoucherId { get; set; }
        public Voucher Voucher { get; set; }

        [ForeignKey("Party")]        
        public int CustomerId { get; set; }
        public Party Party { get; set; }

        public virtual ICollection<ReturnSub> ReturnSub { get; set; }
    }
}
