using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MassManageSystem.Models.Validation
{
    [MetadataType(typeof(MetadataTotalMillExpenseInfoTbl))]
    public partial class TotalMillExpenseInfoTbl
    {
    }
    public class MetadataTotalMillExpenseInfoTbl
    {
        [Required(ErrorMessage = "Total Mill is required")]
        [Display(Name = "Total Mill")]
        public double TotalMill { get; set; }

        [Required(ErrorMessage = "Total Expense is required")]
        [Display(Name = "Total Expense")]
        public double TotalExpense { get; set; }

        [Required(ErrorMessage = "Par Mill is required")]
        [Display(Name = "Par Mill")]
        public string ParMill { get; set; }
    }
}