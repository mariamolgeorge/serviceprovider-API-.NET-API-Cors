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
    public class UsersServiceProviderController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();
        [HttpPost]
        public InsertReturn InsertUsersServiceProvider(UsersServiceProvider usp)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["GMMEP"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("spInsertUsersServiceProvider", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var table = new DataTable();
                    table.Columns.Add("Id", typeof(int));
                    table.Columns.Add("UsersServiceProviderId", typeof(int));
                    table.Columns.Add("ServiceId", typeof(int));
                    for (int i = 0; i < usp.ServiceProviderServiceMapping.Count; i++)
                    {
                        table.Rows.Add(usp.ServiceProviderServiceMapping[i].Id, usp.ServiceProviderServiceMapping[i].UsersServiceProviderId, usp.ServiceProviderServiceMapping[i].ServiceId);
                    }
                    cmd.Parameters.Add(new SqlParameter("@Id", usp.Id));
                    cmd.Parameters.Add(new SqlParameter("@Name", usp.Name));
                    cmd.Parameters.Add(new SqlParameter("@Mobile", usp.Mobile));
                    cmd.Parameters.Add(new SqlParameter("@Email", usp.Email));
                    cmd.Parameters.Add(new SqlParameter("@Address", usp.Address));
                    cmd.Parameters.Add(new SqlParameter("@PhoneNumber", usp.PhoneNumber));
                    cmd.Parameters.Add(new SqlParameter("@CityId", usp.CityId));
                    cmd.Parameters.Add(new SqlParameter("@Supervisorid", usp.SupervisorId));
                    cmd.Parameters.Add(new SqlParameter("@IsLive", usp.IsLive));
                    cmd.Parameters.Add(new SqlParameter("@status", usp.Status));
                    cmd.Parameters.Add(new SqlParameter("@Password", usp.Password));
                    cmd.Parameters.Add(new SqlParameter("@IsBill", usp.IsBill));
                    cmd.Parameters.Add(new SqlParameter("@IsBooking", usp.IsBooking));

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
        public IEnumerable<spGetAllServicesWithCityId_Result>GetAllServicesWithCityId(int cityid)
        {
            return GE.spGetAllServicesWithCityId(cityid).AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<spGetAllUsersServiceProviderDetails_Result> GetAllUsersServiceProviderDetails()
        {
            return GE.spGetAllUsersServiceProviderDetails().AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<spGetAllServicesWithSupervisorId_Result> GetAllServicesWithSupervisorId(int supervisorid)
        {
            return GE.spGetAllServicesWithSupervisorId(supervisorid).AsEnumerable();
        }
       
        [HttpGet]
        public IEnumerable<spGetAllServicesWithUsersServiceProviderId_Result> GetAllServicesWithUsersServiceProviderId(int serviceproviderid)
        {
            return GE.spGetAllServicesWithUsersServiceProviderId(serviceproviderid).AsEnumerable();
        }
       
    }
}
