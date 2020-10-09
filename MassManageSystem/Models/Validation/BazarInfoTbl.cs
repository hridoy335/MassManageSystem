using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MassManageSystem.Models.Validation
{
    [MetadataType(typeof(MetadataBazarInfoTbl))] 
    public partial class BazarInfoTbl
    {
    }
    public class MetadataBazarInfoTbl
    {
        [Display(Name = "Name")]
        public int MemberInfoId { get; set; }

        [Required(ErrorMessage = "Total Bazar is required")]
        [Display(Name = "Total Bazar")]
        public double TotalBazar { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [Display(Name = "Image")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [Display(Name = "Date")]
        public System.DateTime Date { get; set; }
    }
}