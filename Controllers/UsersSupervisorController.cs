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
    public class UsersSupervisorController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();
        //[HttpPost]
        //public IEnumerable<spInsertUsersSupervisor_Result> InsertUsersSupervisor(UsersSupervisor us)
        //{
        //    try
        //    {
        //        return GE.spInsertUsersSupervisor(us.Id, us.Name, us.Mobile, us.Email, us.Address, us.PhoneNumber, us.CityId, us.Status, us.Password, us.ServiceId, us.IsBill, us.IsAuthorise, us.IsBooking).AsEnumerable();
        //    }
        //    catch (Exception ex)
        //    {
        //        string val = ex.Message;
        //        string innex = ex.InnerException.Message;
        //        return null;
        //    }
        //}

        [HttpPost]
        public InsertReturn InsertUsersSupervisor(UsersSupervisor us)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["GMMEP"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("spInsertUsersSupervisor", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var table = new DataTable();

                    //table.Columns.Add("Id", typeof(int));
                    table.Columns.Add("SupervisorId", typeof(int));
                    table.Columns.Add("LocationId", typeof(int));
                    table.Columns.Add("ServiceId", typeof(int));
                    table.Columns.Add("CityServiceMappingId", typeof(int));
                    for (int i = 0; i < us.LocationServiceMapping.Count; i++)
                    {
                        table.Rows.Add( us.LocationServiceMapping[i].SupervisorId, us.LocationServiceMapping[i].LocationId, us.LocationServiceMapping[i].ServiceId, us.LocationServiceMapping[i].CityServiceMappingId);
                    }
                    cmd.Parameters.Add(new SqlParameter("@Id", us.Id));
                    cmd.Parameters.Add(new SqlParameter("@Name", us.Name));
                    cmd.Parameters.Add(new SqlParameter("@Mobile", us.Mobile));
                    cmd.Parameters.Add(new SqlParameter("@Email", us.Email));
                    cmd.Parameters.Add(new SqlParameter("@Address", us.Address));
                    cmd.Parameters.Add(new SqlParameter("@PhoneNumber", us.PhoneNumber));
                    cmd.Parameters.Add(new SqlParameter("@CityId", us.CityId));
                    cmd.Parameters.Add(new SqlParameter("@status", us.Status));
                    cmd.Parameters.Add(new SqlParameter("@password ", us.Password));
                    cmd.Parameters.Add(new SqlParameter("@serviceid", us.ServiceId));
                    cmd.Parameters.Add(new SqlParameter("@isbill", us.IsBill));
                    cmd.Parameters.Add(new SqlParameter("@isbooking", us.IsBooking));
                    cmd.Parameters.Add(new SqlParameter("@isauthorise", us.IsAuthorise));
                    cmd.Parameters.Add(new SqlParameter("@Items", table));
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
        public IEnumerable<spGetAllUsersSupervisor_Result> GetAllUsersSupervisor()
        {
            return GE.spGetAllUsersSupervisor().AsEnumerable();
        }


        [HttpGet]
        public IEnumerable<spGetAllSupervisorsWithCityIdAndServiceId_Result> GetAllSupervisorsWithCityIdAndServiceId(int cityid,int serviceid)

        {
            return GE.spGetAllSupervisorsWithCityIdAndServiceId(cityid,serviceid).AsEnumerable();
        }
    }
}
