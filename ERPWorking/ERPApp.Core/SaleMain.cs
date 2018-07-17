using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApp.Core
{

    public class SaleMain
    {
        [Key]
        public int SMId { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string InvoiceNo { get; set; }

        public DateTime? InvoiceDate { get; set; }

        [MaxLength(256)]
        public string InvoiceBy { get; set; }       

        public float GST { get; set; }

        // Navigation Properties

        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [ForeignKey("Voucher")]
        public int VoucherId { get; set; }
        public Voucher Voucher { get; set; }

        [ForeignKey("Party")]
        public int CustomerId { get; set; }
        public Party Party { get; set; }

        public virtual ICollection<ReturnMain> ReturnMain { get; set; }
        public virtual ICollection<SaleSub> SaleSub { get; set; }
    }
    }
