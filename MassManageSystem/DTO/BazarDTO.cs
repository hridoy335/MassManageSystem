using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassManageSystem.DTO
{
    public class BazarDTO
    {
        public int MemberInfoId { get; set; }
        public int BazarInfoId { get; set; }
        public string Name { get; set; }
        public double TotalBazar { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }

    }
}