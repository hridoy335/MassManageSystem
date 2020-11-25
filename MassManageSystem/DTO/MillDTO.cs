using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassManageSystem.DTO
{
    public class MillDTO
    {
        public int MemberInfoId { get; set; }
        public int MillInfoId { get; set; }
        public string Name { get; set; }
        public double Morning { get; set; }
        public double Lunch { get; set; }
        public double Dinner { get; set; }
        public DateTime Date { get; set; } 


    }
}