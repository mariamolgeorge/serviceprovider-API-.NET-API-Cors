using InIT.API.GMMEP.Class;
using InIT.API.GMMEP.Models;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;

namespace InIT.API.GMMEP.Controllers
{
    public class CityServiceMapingController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();

        [HttpPost]
        public int InsertCityServiceMaping(CityWiseService cws)
        {
            try
            {
                //string cs = ConfigurationManager.ConnectionStrings["GMMEPEntities"].ConnectionString;
                //SqlConnection con = new SqlConnection(cs);
                //using (con)
                //{
                //    SqlCommand cmd = new SqlCommand("spInsertCityServiceMapping", con);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    var table = new DataTable();
                // table.Columns.Add("CityId", typeof(int));
                //table.Columns.Add("ServiceId", typeof(int));
                //table.Columns.Add("Rules", typeof(string));
                //table.Columns.Add("RateChart", typeof(string));
                //table.Columns.Add("Description", typeof(string));
                //table.Columns.Add("IsLive", typeof(int));
                //table.Columns.Add("SupervisorId", typeof(int));
                     GE.spDeleteServiceMapingWithCityId(cws.CityServiceMapping[0].CityId);

                    for (int i = 0; i < cws.CityServiceMapping.Count; i++)
                    {
                        GE.spInsertCityServiceMapingRowWise(cws.CityServiceMapping[i].Id, cws.CityServiceMapping[i].CityId, cws.CityServiceMapping[i].ServiceId, cws.CityServiceMapping[i].IsLive, cws.CityServiceMapping[i].Rules, cws.CityServiceMapping[i].RateChart, cws.CityServiceMapping[i].Description, cws.CityServiceMapping[i].SupervisorId);
                        //table.Rows.Add(
                        //    cws.CityServiceMaping[i].Id,
                        //    cws.CityServiceMaping[i].CityId,
                        //    cws.CityServiceMaping[i].ServiceId, 
                        //    cws.CityServiceMaping[i].Rules,
                        //    cws.CityServiceMaping[i].RateChart,
                        //    cws.CityServiceMaping[i].Description,
                        //    cws.CityServiceMaping[i].IsLive,
                        //    cws.CityServiceMaping[i].SupervisorId
                        //    );

                    }
                return 1;
            //        cmd.Parameters.Add(new SqlParameter("@Id", cws.Id));
            //        cmd.Parameters.Add(new SqlParameter("@items", table));
            //        con.Open();
            //        SqlDataReader reader = cmd.ExecuteReader();

            //        InsertReturn insertreturn = new InsertReturn();

            //        while (reader.Read())
            //        {
            //            insertreturn = new InsertReturn(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]));

            //        }
            //        return insertreturn;
            //    }
            }
            catch (Exception ex)
            {
                string val = ex.Message;
                return 0;
            }
        }
        [HttpGet]
        public IEnumerable<spGetAllSupervisorsWithCityId_Result> GetAllSupervisorsWithCityId(int cityid)
        {
            return GE.spGetAllSupervisorsWithCityId(cityid).AsEnumerable();
        }

        [HttpGet]
        public IEnumerable<spGetAllLocationServiceMappingDetails_Result>GetAllLocationServiceMappingDetails()

        {
            return GE.spGetAllLocationServiceMappingDetails().AsEnumerable();
        }


        [HttpGet]
        public IEnumerable<spGetAllServicesWithLocationId_Result> GetAllServicesWithLocationId(int locationid)
        {
            return GE.spGetAllServicesWithLocationId(locationid).AsEnumerable();
        }
    }
}
