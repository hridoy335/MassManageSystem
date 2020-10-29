using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MassManageSystem.Models.DataLayer
{
    public class GetBazarInfo
    {
        public IEnumerable<BazarInfoTbl> bazarInfoTbls
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MassConnection"].ConnectionString;
                List<BazarInfoTbl> bazarinfo  = new List<BazarInfoTbl>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Name,BazarInfoId,TotalBazar,Date from MemberInfoTbl RIGHT JOIN BazarInfoTbl ON MemberInfoTbl.MemberInfoId= BazarInfoTbl.MemberInfoId", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        BazarInfoTbl employee = new BazarInfoTbl(); 
                        employee.BazarInfoId = Convert.ToInt32(rdr["BazarInfoId"]);
                        employee.MemberInfoId = Convert.ToInt32(rdr["MemberInfoId"]);
                        employee.TotalBazar = Convert.ToInt32(rdr["TotalBazar"]);
                        employee.Image = rdr["Image"].ToString();
                        employee.Date = Convert.ToDateTime((rdr["Date"]));
                        bazarinfo.Add(employee);
                    }
                }
                return bazarinfo;
            }
        }
    }
}