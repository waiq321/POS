using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPApp.Core
{
   
    public class ExpenseType
    {
        [Key]
        public int ExpenseTypeId { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string ExpenseTypeName { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Type { get; set; }

       
        public bool IsCostPart { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }


        [MaxLength(256)]
        public string EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }

        [MaxLength(256)]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        // Navigation Properties
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public virtual ICollection<POExpense> POExpense { get; set; }

    }
}
