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
    public class CityServiceMapingRowController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();
        //
        //public IEnumerable<spInsertCityServiceMapingRowWise_Result> InsertCityServiceMapingRowWise(CityServiceMaping csm)
        //{
        //    return GE.spInsertCityServiceMapingRowWise(csm.Id,csm.CityId,csm.ServiceId,csm.IsLive,csm.Rules,csm.RateChart,csm.Description,csm.SupervisorId).AsEnumerable();
        //}
        [HttpPost]
        public List<spGetAllSupervisorWithLocationId_Result> GetAllSupervisorWithLocationId(UsersServiceProvider supr)
        {
            try
            {

                string cs = ConfigurationManager.ConnectionStrings["GMMEP"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                using (con)
                {
                    DataTable dt = new DataTable();
                    List<spGetAllSupervisorWithLocationId_Result> details = new List<spGetAllSupervisorWithLocationId_Result>();

                    SqlCommand cmd = new SqlCommand("spGetAllSupervisorWithLocationId", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var table = new DataTable();
                    table.Columns.Add("Id", typeof(int));
                    for (int i = 0; i < supr.ListOfId.Count; i++)
                    {
                        table.Rows.Add(supr.ListOfId[i].Id);
                    }
                    cmd.Parameters.Add(new SqlParameter("@locationid",supr.CityId));
                    cmd.Parameters.Add(new SqlParameter("@items",table));
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        spGetAllSupervisorWithLocationId_Result sa = new spGetAllSupervisorWithLocationId_Result();
                        if (!dr.IsNull("ServiceId")) { sa.ServiceId = Convert.ToInt32(dr["ServiceId"]); }
                        if (!dr.IsNull("LocationId")) sa.LocationId = Convert.ToInt32(dr["LocationId"]);
                            if (!dr.IsNull("SupervisorId")) { sa.SupervisorId = Convert.ToInt32(dr["SupervisorId"]); }
                            if (!dr.IsNull("Name")) { sa.Name = Convert.ToString(dr["Name"]); }
                            if (!dr.IsNull("Email")) { sa.Email = Convert.ToString(dr["Email"]); }
                            if (!dr.IsNull("Mobile")) { sa.Mobile = Convert.ToString(dr["Mobile"]); }
                            //if (!dr.IsNull("Narration")) { sa.Narration = Convert.ToString(dr["Narration"]); }
                            //if (!dr.IsNull("Code")) { sa.Code = Convert.ToString(dr["Code"]); }
                            //if (!dr.IsNull("ItemTypeId")) { sa.ItemTypeId = Convert.ToInt32(dr["ItemTypeId"]); }
                            //if (!dr.IsNull("Status")) { sa.Status = Convert.ToInt32(dr["Status"]); }
                            //if (!dr.IsNull("Rate")) { sa.Rate = Convert.ToInt32(dr["Rate"]); }
                            //if (!dr.IsNull("Unit")) { sa.Unit = Convert.ToString(dr["Unit"]); }
                            //if (!dr.IsNull("SubCategoryId")) { sa.SubCategoryId = Convert.ToInt32(dr["SubCategoryId"]); }

                            details.Add(sa);
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
        public IEnumerable<spDeleteServiceMapingWithCityId_Result> DeleteServiceMapingWithCityId(int CityId)
        {
            return GE.spDeleteServiceMapingWithCityId(CityId).AsEnumerable();
        }
    }
}
