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
    public class SupervisorLocationServiceMappingController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();

        [HttpPost]

       
        public List<spGetAllServicesForSupervisorWithLocationId_Result> GetAllServicesForSupervisorWithLocationId(UsersSupervisor supr)
        {
            try
            {

                string cs = ConfigurationManager.ConnectionStrings["GMMEP"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                using (con)
                {
                    DataTable dt = new DataTable();
                    List<spGetAllServicesForSupervisorWithLocationId_Result> details = new List<spGetAllServicesForSupervisorWithLocationId_Result>();

                    SqlCommand cmd = new SqlCommand("spGetAllServicesForSupervisorWithLocationId", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var table = new DataTable();
                    table.Columns.Add("Id", typeof(int));
                    for (int i = 0; i < supr.ListOfId.Count; i++)
                    {
                        table.Rows.Add(supr.ListOfId[i].Id);
                    }

                    cmd.Parameters.Add(new SqlParameter("@LocationId", table));
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        spGetAllServicesForSupervisorWithLocationId_Result sa = new spGetAllServicesForSupervisorWithLocationId_Result();
                        if (!dr.IsNull("ServiceId")) { sa.ServiceId = Convert.ToInt32(dr["ServiceId"]); }
                        if (!dr.IsNull("CityId")) { sa.CityId = Convert.ToInt32(dr["CityId"]);
                            if (!dr.IsNull("Id")) { sa.Id = Convert.ToInt32(dr["Id"]); }
                            if (!dr.IsNull("Name")) { sa.Name = Convert.ToString(dr["Name"]); }
                            if (!dr.IsNull("LocationName")) { sa.LocationName = Convert.ToString(dr["LocationName"]); }
                            if (!dr.IsNull("CityServiceMappingId")) { sa.CityServiceMappingId = Convert.ToInt32(dr["CityServiceMappingId"]); }
                            //if (!dr.IsNull("Narration")) { sa.Narration = Convert.ToString(dr["Narration"]); }
                            //if (!dr.IsNull("Code")) { sa.Code = Convert.ToString(dr["Code"]); }
                            //if (!dr.IsNull("ItemTypeId")) { sa.ItemTypeId = Convert.ToInt32(dr["ItemTypeId"]); }
                            //if (!dr.IsNull("Status")) { sa.Status = Convert.ToInt32(dr["Status"]); }
                            //if (!dr.IsNull("Rate")) { sa.Rate = Convert.ToInt32(dr["Rate"]); }
                            //if (!dr.IsNull("Unit")) { sa.Unit = Convert.ToString(dr["Unit"]); }
                            //if (!dr.IsNull("SubCategoryId")) { sa.SubCategoryId = Convert.ToInt32(dr["SubCategoryId"]); }

                            details.Add(sa);
                        }
                      

                    }
                    return details;
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                string inexc = ex.InnerException.Message;
                return null;

            }
        }


        [HttpGet]
        public IEnumerable<spGetAllSupervisorLocationServiceMappingWithSupervisorId_Result> GetAllSupervisorLocationServiceMappingWithSupervisorId(int supervisorid)
        {
            return GE.spGetAllSupervisorLocationServiceMappingWithSupervisorId(supervisorid).AsEnumerable();
        }


       
    }
}
