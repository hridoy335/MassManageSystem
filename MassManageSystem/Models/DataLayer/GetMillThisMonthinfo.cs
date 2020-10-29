using System;
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
        public IEnumerable<MillInfoTbl> MillInfoTbl
         {
            get
            {
                //  var conn = ConfigurationManager.ConnectionStrings["RéceptionEntities_SQL"].ConnectionString;
                // var con = new SqlConnection(conn);

                string connectionString = ConfigurationManager.ConnectionStrings["MassConnection"].ConnectionString;
                List<MillInfoTbl> MillInfos = new List<MillInfoTbl>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                  //  SqlCommand cmd = new SqlCommand("SELECT MillInfoId,MemberInfoId,Morning,Lunch,Dinner,Date from MillInfoTbl", con);
                    SqlCommand cmd = new SqlCommand("SELECT Name,MillInfoId,Morning,Lunch,Dinner,Date from MemberInfoTbl RIGHT JOIN MillInfoTbl ON  MillInfoTbl.MemberInfoId=MemberInfoTbl.MemberInfoId", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        MillInfoTbl employee = new MillInfoTbl();
                        employee.MillInfoId = Convert.ToInt32(rdr["MillInfoId"]);
                        var name = rdr["Name"];
                       // employee.MemberInfoId = Convert.ToInt32(rdr["Name"]);
                        employee.Morning = Convert.ToInt32(rdr["Morning"]);
                        employee.Lunch = Convert.ToInt32(rdr["Lunch"]);
                        employee.Dinner = Convert.ToInt32(rdr["Dinner"]);
                        employee.Date =Convert.ToDateTime((rdr["Date"]));
                      //  employee.Date34 = Convert.ToDateTime("20/12/2020");
                        //employee.Date =Convert.ToDateTime(Date.ToString("MMM dd, yyyy"));
                        MillInfos.Add(employee);
                    }
                }
                    return MillInfos;
                     


            }
        }
    }
}