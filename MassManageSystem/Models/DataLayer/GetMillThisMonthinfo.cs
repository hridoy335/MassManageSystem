using System;
using MassManageSystem.DTO;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MassManageSystem.Models.DataLayer
{
    public class GetMillThisMonthinfo 
    {
        public List<MillDTO> MillInfoTbl()
         {
                //  var conn = ConfigurationManager.ConnectionStrings["RéceptionEntities_SQL"].ConnectionString;
                // var con = new SqlConnection(conn);

                string connectionString = ConfigurationManager.ConnectionStrings["MassConnection"].ConnectionString;
                List<MillDTO> MillInfos = new List<MillDTO>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                DateTime now = DateTime.Now;
                var startDate = new DateTime(now.Year, now.Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);
                var s = startDate.ToString("yyyy-MM-dd");
                var d = endDate.ToString("yyyy-MM-dd");

                //  SqlCommand cmd = new SqlCommand("SELECT MillInfoId,MemberInfoId,Morning,Lunch,Dinner,Date from MillInfoTbl", con);
                SqlCommand cmd = new SqlCommand("SELECT Name,MillInfoTbl.MemberInfoId,MillInfoId,Morning,Lunch,Dinner,Date from MemberInfoTbl RIGHT JOIN MillInfoTbl ON  MillInfoTbl.MemberInfoId=MemberInfoTbl.MemberInfoId where Date between ' "+s+" ' and '"+d+"' ", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                    MillDTO millDTO = new MillDTO();
                    var i = rdr["MemberInfoId"];
                    millDTO.MemberInfoId= Convert.ToInt32(rdr["MemberInfoId"]);
                    millDTO.MillInfoId= Convert.ToInt32(rdr["MillInfoId"]);
                    millDTO.Name= rdr["Name"].ToString();
                    millDTO.Morning = Convert.ToInt32(rdr["Morning"]);
                    millDTO.Lunch = Convert.ToInt32(rdr["Lunch"]);
                    millDTO.Dinner = Convert.ToInt32(rdr["Dinner"]);
                    millDTO.Date = Convert.ToDateTime((rdr["Date"]));
                    MillInfos.Add(millDTO);
                    }
                }
                    return MillInfos;

        }
    }
}