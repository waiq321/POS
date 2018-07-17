using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApp.Core
{
   
    public class ReceiveMain
    {
        [Key]
        public int RMId { get; set; }
             

        [MaxLength(256)]
        public string ReceiveBy { get; set; }
        public DateTime? ReceiveDate { get; set; }

        [MaxLength(256)]
        public string EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }

        [MaxLength(256)]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        // Navigation Properties
        [ForeignKey("POMain")]
        public int POId { get; set; }                
        public POMain POMain { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public virtual ICollection<ReceiveSub> ReceiveSub { get; set; }
    }
}
