using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MassManageSystem.Models
{
    [MetadataType(typeof(MetadataMillInfoTbl))] 
    public partial class MillInfoTbl
    {
    }

    public class MetadataMillInfoTbl
    {
        [Display(Name = "Name")]
        public int MemberInfoId { get; set; }

        [Required(ErrorMessage = "Morning is required")]
        [Display(Name = "Morning")]
        public double Morning { get; set; }

        [Required(ErrorMessage = "Lunch is required")]
        [Display(Name = "Lunch")]
        public double Lunch { get; set; }

        [Required(ErrorMessage = "Dinner is required")]
        [Display(Name = "Dinner")]
        public double Dinner { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [Display(Name = "Date")]
        public System.DateTime Date { get; set; }
    }
}