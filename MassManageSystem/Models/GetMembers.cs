using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MassManageSystem.Models
{
    public class GetMembers
    {

        public IEnumerable<MemberInfoTbl> MemberInfoTbl 
        {
            get
            {
              //  var conn = ConfigurationManager.ConnectionStrings["RéceptionEntities_SQL"].ConnectionString;
               // var con = new SqlConnection(conn);

                string connectionString = ConfigurationManager.ConnectionStrings["MassConnection"].ConnectionString;
                List<MemberInfoTbl> employees = new List<MemberInfoTbl>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT MemberInfoId,Name,Contact,Email,Image,ParentContact,Status from MemberInfoTbl", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader(); 
                    while (rdr.Read())
                    {
                        MemberInfoTbl employee = new MemberInfoTbl();
                        employee.MemberInfoId =Convert.ToInt32(rdr["MemberInfoId"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Contact = rdr["Contact"].ToString();
                        employee.Email = rdr["Email"].ToString();
                        employee.Image = rdr["Image"].ToString();
                        employee.ParentContact = rdr["ParentContact"].ToString();
                        employee.Status = Convert.ToBoolean(rdr["Status"]);
                        employees.Add(employee);
                    }
                }
                return employees;
            }
        }


        public IEnumerable<MemberInfoTbl> MemberInfoTblforBazar 
        {
            get
            {
                //  var conn = ConfigurationManager.ConnectionStrings["RéceptionEntities_SQL"].ConnectionString;
                // var con = new SqlConnection(conn);

                string connectionString = ConfigurationManager.ConnectionStrings["MassConnection"].ConnectionString;
                List<MemberInfoTbl> employees = new List<MemberInfoTbl>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT MemberInfoId,Name,Contact,Email,Image,ParentContact,Status from MemberInfoTbl where Status=1", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        MemberInfoTbl employee = new MemberInfoTbl();
                        employee.Name = rdr["Name"].ToString();
                        employee.Contact = rdr["Contact"].ToString();
                        employee.Email = rdr["Email"].ToString();
                        employee.Image = rdr["Image"].ToString();
                        employee.ParentContact = rdr["ParentContact"].ToString();
                        employee.Status = Convert.ToBoolean(rdr["Status"]);
                        employees.Add(employee);
                    }
                }
                return employees;
            }
        }
    }
}