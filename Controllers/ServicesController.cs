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
    public class ServicesController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();
        [HttpPost]
        //public spInsertServices_Result InsertServices(Services service)
        //{
        //    spInsertServices_Result dt = GE.spInsertServices(service.Id, service.Name, service.Code, service.ImagePath, service.Description, service.Rules, service.CategoryId,service.Status, service.UserId,service.AdvanceAmount, service.RateChart).SingleOrDefault();
        //    if (dt.Id > 0 && dt.Error == 0)
        //    {
        //        if (!String.IsNullOrEmpty(service.ImagePath))
        //        {
        //            if (service.ImagePath.Length > 1)
        //            {

        //                Utils.SaveImage("~/assets/images/ServicesImages/" + dt.Id.ToString() + ".jpg", service.ImagePath);

        //            }
        //        }
        //    }

        //    return dt;
        //}

        public InsertReturn InsertServices(Services ser)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["GMMEP"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("spInsertServices", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var table = new DataTable();
                    table.Columns.Add("Name", typeof(string));
                    table.Columns.Add("ServiceId", typeof(int));
                    table.Columns.Add("UptoHours", typeof(DateTime));
                    table.Columns.Add("Amount", typeof(float));
                    for (int i = 0; i < ser.ServiceRateChartMappingList.Count; i++)
                    {
                        table.Rows.Add(ser.ServiceRateChartMappingList[i].Name, ser.ServiceRateChartMappingList[i].ServiceId, ser.ServiceRateChartMappingList[i].UptoHours, ser.ServiceRateChartMappingList[i].Amount);
                    }
                    
                    cmd.Parameters.Add(new SqlParameter("@Id", ser.Id));
                    cmd.Parameters.Add(new SqlParameter("@Name", ser.Name));
                    cmd.Parameters.Add(new SqlParameter("@Code", ser.Code));
                    cmd.Parameters.Add(new SqlParameter("@ImagePath", ser.ImagePath));
                    cmd.Parameters.Add(new SqlParameter("@Description", ser.Description));
                    cmd.Parameters.Add(new SqlParameter("@Rules", ser.Rules));
                    cmd.Parameters.Add(new SqlParameter("@CategoryId", ser.CategoryId));
                    cmd.Parameters.Add(new SqlParameter("@status",ser.Status));
                    cmd.Parameters.Add(new SqlParameter("@UserId", ser.UserId));
                    cmd.Parameters.Add(new SqlParameter("@advanceamount",ser.AdvanceAmount));
                    cmd.Parameters.Add(new SqlParameter("@additionalrate", ser.AdditionalRate));

                    cmd.Parameters.Add(new SqlParameter("@RateChart", ser.RateChart));
                    cmd.Parameters.Add(new SqlParameter("@rate",table));
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    InsertReturn insertreturn = new InsertReturn();
                    while (reader.Read())
                    {
                        insertreturn = new InsertReturn(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]));
                        if (!String.IsNullOrEmpty(ser.ImagePath))
                        {
                            if (ser.ImagePath.Length > 1)
                            {

                                Utils.SaveImage("~/assets/images/ServicesImages/" + insertreturn.Id.ToString() + ".jpg", ser.ImagePath);

                            }
                        }
                    }
                    return insertreturn;
                }
            }
            catch (Exception ex)
            {
                string val = ex.Message;
                string innex = ex.InnerException.Message;
                return null;
            }
        }

        [HttpGet]
        public IEnumerable<spGetAllServices_Result> GetAllServices()
        {
            return GE.spGetAllServices().AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<spGetAllServiceWithServiceId_Result>GetAllServiceWithServiceId(int id)
        {
            return GE.spGetAllServiceWithServiceId(id).AsEnumerable();
        }

        [HttpGet]
        public IEnumerable<spGetAllServicesWithPincode_Result> GetAllServicesWithPincode(string pincode)
        {
            return GE.spGetAllServicesWithPincode(pincode).AsEnumerable();
        }

        [HttpGet]
        public IEnumerable<spGetTopTwelveServicesWithPincode_Result> GetTopTwelveServicesWithPincode(string code,int num)
        {
            return GE.spGetTopTwelveServicesWithPincode(code).AsEnumerable();
        }

        [HttpGet]
        public IEnumerable<spGetServiceRateChartmappingWithServiceId_Result> GetServiceRateChartmappingWithServiceId(int serviceid)
        {
            return GE.spGetServiceRateChartmappingWithServiceId(serviceid).AsEnumerable();
        }
    }
}
