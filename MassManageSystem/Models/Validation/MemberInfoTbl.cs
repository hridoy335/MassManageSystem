using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MassManageSystem.Models
{
    [MetadataType(typeof(MetadataMemberInfoTbl))]
    public partial class MemberInfoTbl
    {
    }
    public class MetadataMemberInfoTbl
    {
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Contact is required")]
        [Display(Name = "Contact")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [Display(Name = "Image")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Parent Contact is required")]
        [Display(Name = "Parent Contact")]
        public string ParentContact { get; set; }

        // [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}