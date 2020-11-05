using MassManageSystem.DTO;
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
        public List<BazarDTO> bazarInfoTbls()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["MassConnection"].ConnectionString;
            List<BazarInfoTbl> bazarinfo = new List<BazarInfoTbl>();
            List<BazarDTO> info2 = new List<BazarDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT Name,BazarInfoTbl.MemberInfoId,BazarInfoId,TotalBazar,BazarInfoTbl.Image,Date from MemberInfoTbl RIGHT JOIN BazarInfoTbl ON MemberInfoTbl.MemberInfoId= BazarInfoTbl.MemberInfoId", con);
                // SqlCommand cmd = new SqlCommand("SELECT BazarInfoId,MemberInfoId,TotalBazar,Image,Date from BazarInfoTbl ", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    BazarDTO bazar = new BazarDTO();
                    //BazarInfoTbl employee = new BazarInfoTbl();
                    bazar.BazarInfoId = Convert.ToInt32(rdr["BazarInfoId"]);
                    bazar.Name = rdr["Name"].ToString();
                    bazar.MemberInfoId = Convert.ToInt32(rdr["MemberInfoId"]);
                    bazar.TotalBazar = Convert.ToInt32(rdr["TotalBazar"]);
                    bazar.Image = rdr["Image"].ToString();
                    bazar.Date = Convert.ToDateTime((rdr["Date"]));
                    // bazarinfo.Add(employee);



                    // bazar.Name = (rdr["Name"]);
                    //// info.Add(rdr["MemberInfoId"]);
                    // info.Add(rdr["BazarInfoId"]);

                    // info.Add(rdr["TotalBazar"]);
                    //// info.Add(rdr["Image"]);
                    // info.Add(rdr["Date"]);
                    // bazarinfo.Add(info);
                    info2.Add(bazar);

                }

                return info2;


            }
        }
    }
}