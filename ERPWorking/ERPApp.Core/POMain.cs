using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApp.Core
{
   
    public class POMain
    {
        [Key]
        public int POId { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string PONO { get; set; }

        public DateTime PODate { get; set; }
              
        public int VID { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string PaymentMode { get; set; }

        public bool ISApproved { get; set; }
       

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

        [ForeignKey("Party")]
        public int PartyId { get; set; }
        public Party Party { get; set; }

        public virtual ICollection<POExpense> POExpense { get; set; }
        //public virtual ICollection<ExpenseType> ExpenseType { get; set; }
        public virtual ICollection<POSub> POSub { get; set; }
        public virtual ICollection<ReceiveMain> ReceiveMain { get; set; }
        public virtual ICollection<ReturnMain> ReturnMain { get; set; }
    }
}
