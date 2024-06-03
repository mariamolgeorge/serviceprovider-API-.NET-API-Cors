using InIT.API.GMMEP.Class;
using InIT.API.GMMEP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InIT.API.GMMEP.Controllers
{
    public class UsersAdminController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();
        //[HttpPost]
        //public IEnumerable<spInsertUsersAdmin_Result> InsertUsersAdmin(UsersAdmin ua)
        //{
        // return GE.spInsertUsersAdmin(ua.Id,ua.Name,ua.Mobile,ua.Email,ua.Address,ua.PhoneNumber,ua.CityId,ua.UserType).AsEnumerable();
        //}

        [HttpPost]
        public InsertReturn InsertUsersAdmin(UsersAdmin ua)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["GMMEP"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("spInsertUsersAdmin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var table = new DataTable();
                    table.Columns.Add("UserId", typeof(int));
                    table.Columns.Add("PageId", typeof(int));
                    for (int i = 0; i < ua.AdminUserRights.Count; i++)
                    {
                        table.Rows.Add(ua.AdminUserRights[i].UserId, ua.AdminUserRights[i].PageId);
                    }
                    cmd.Parameters.Add(new SqlParameter("@Id", ua.Id));
                    cmd.Parameters.Add(new SqlParameter("@Name", ua.Name));
                    cmd.Parameters.Add(new SqlParameter("@Mobile", ua.Mobile));
                    cmd.Parameters.Add(new SqlParameter("@Email", ua.Email));
                    cmd.Parameters.Add(new SqlParameter("@Address", ua.Address));
                    cmd.Parameters.Add(new SqlParameter("@PhoneNumber", ua.PhoneNumber));
                    cmd.Parameters.Add(new SqlParameter("@CityId", ua.CityId));
                    cmd.Parameters.Add(new SqlParameter("@Status", ua.Status));
                    cmd.Parameters.Add(new SqlParameter("@Password", ua.Password));

                    //cmd.Parameters.Add(new SqlParameter("@UserType", ua.UserType));
                    cmd.Parameters.Add(new SqlParameter("@items", table));
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    InsertReturn insertreturn = new InsertReturn();

                    while (reader.Read())
                    {
                        insertreturn = new InsertReturn(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]));

                    }
                    return insertreturn;
                }
            }
            catch (Exception ex)
            {
                string val = ex.Message;
                return null;
            }
        }

        [HttpGet]
        public IEnumerable<spGetAllUsersAdmin_Result> GetAllUsersAdmin()
        {
            return GE.spGetAllUsersAdmin().AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<spGetAllPagesWithUserAdminId_Result> GetAllPagesWithUserId(int userid)
        {
            return GE.spGetAllPagesWithUserAdminId(userid).AsEnumerable();
        }

    }

}
