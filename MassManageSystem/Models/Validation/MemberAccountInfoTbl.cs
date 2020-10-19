using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MassManageSystem.Models
{
    [MetadataType(typeof(MetadataMemberAccountInfoTbl))]
    public partial class MemberAccountInfoTbl
    {
    }
    public class MetadataMemberAccountInfoTbl
    {
        [Display(Name = "Name")]
        public int MemberInfoId { get; set; }

        [Required(ErrorMessage = "Mill Amount is required")]
        [Display(Name = "Mill Account")]
        public double AccountForMill { get; set; }

        [Required(ErrorMessage = "Flat Amount is required")]
        [Display(Name = "Flat Amount")]
        public Nullable<double> AccountForFlat { get; set; }

        [Required(ErrorMessage = "Payment Date is required")]
        [Display(Name = "Payment Date")]
        public System.DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "Payment Month is required")]
        [Display(Name = "Payment Month")]
        public System.DateTime PaymentForMonth { get; set; }
    }
}