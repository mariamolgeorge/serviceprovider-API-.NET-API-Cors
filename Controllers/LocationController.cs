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
    public class LocationController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();



        [HttpPost]
        public InsertReturn InsertLocation(Location com)
        {

            try
            {
                string cs = ConfigurationManager.ConnectionStrings["GMMEP"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("spInsertLocation", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var table = new DataTable();

                    table.Columns.Add("AreaName", typeof(string));
                    table.Columns.Add("LocationId", typeof(int));
                    table.Columns.Add("FromPincode", typeof(string));
                    table.Columns.Add("ToPincode", typeof(string));
                    table.Columns.Add("Code", typeof(string));


                    for (int i = 0; i < com.AvailablePincodeList.Count; i++)
                    {
                        table.Rows.Add(com.AvailablePincodeList[i].AreaName, com.AvailablePincodeList[i].LocationId, com.AvailablePincodeList[i].FromPincode, com.AvailablePincodeList[i].ToPincode, com.AvailablePincodeList[i].Code);
                    }

                    cmd.Parameters.Add(new SqlParameter("@Id", com.Id));
                    cmd.Parameters.Add(new SqlParameter("@name", com.Name));
                    cmd.Parameters.Add(new SqlParameter("@Code", com.Code));
                    cmd.Parameters.Add(new SqlParameter("@userId", com.UserId));
                    cmd.Parameters.Add(new SqlParameter("@status", com.Status));
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
        public IEnumerable<spGetAllLocation_Result> GetAllLocation()
        {
            return GE.spGetAllLocation().AsEnumerable();
        }

        [HttpGet]
        public IEnumerable<spGetAreaWithLocationId_Result> GetAreaWithLocationId(int locationId)
        {
           return GE.spGetAreaWithLocationId(locationId).AsEnumerable();
        }
    }
}
