using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MassManageSystem.Models
{
    [MetadataType(typeof(MetadataPaymentReportForMill))]
    public partial class PaymentReportForMill
    {
    }
    public class MetadataPaymentReportForMill
    {
        [Display(Name = "Name")]
        public int MemberInfoId { get; set; }

        //[Required(ErrorMessage = "Mill Amount is required")]
        //[Display(Name = "Mill Account")]
        public int TotalMillInfoId { get; set; }

        [Required(ErrorMessage = "Total Mill Price is required")]
        [Display(Name = "Tota Mill Price")]
        public double TotalMillPrice { get; set; }

        [Required(ErrorMessage = "Total Due is required")]
        [Display(Name = "TotalDue")]
        public double TotalDue { get; set; }

        [Required(ErrorMessage = "Total Return is required")]
        [Display(Name = "Total Return")]
        public double TotalReturn { get; set; }

        [Required(ErrorMessage = "Calculating Month is required")]
        [Display(Name = "Calculating Month")]
        public System.DateTime CalculatingMonth { get; set; }

        [Required(ErrorMessage = "DueStatus is required")]
        [Display(Name = "DueStatus")]
        public bool DueStatus { get; set; }

        [Required(ErrorMessage = "Total Payment is required")]
        [Display(Name = "Total Payment")]
        public double PaymentTotal { get; set; }

        [Required(ErrorMessage = "Due Total is required")]
        [Display(Name = "Due Total")]
        public double DueTotal { get; set; }
    }
}