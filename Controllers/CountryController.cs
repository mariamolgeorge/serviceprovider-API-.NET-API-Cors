using InIT.API.GMMEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InIT.API.GMMEP.Controllers
{
    public class CountryController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();
        [HttpGet]
        public IEnumerable<spGetAllCityWithCountryId_Result> GetAllCityWithCountryId(int countryid)
        {
            return GE.spGetAllCityWithCountryId(countryid).AsEnumerable();
        }

        [HttpGet]
        public IEnumerable<spGetAllCities_Result> GetAllCities()
        {
            return GE.spGetAllCities().AsEnumerable();
        }

        [HttpGet]
        public IEnumerable<spGetCityDetailsWithCityId_Result> GetCityDetailsWithCityId(int CityId)
        {
            return GE.spGetCityDetailsWithCityId(CityId).AsEnumerable();
        }
        

    }
}
