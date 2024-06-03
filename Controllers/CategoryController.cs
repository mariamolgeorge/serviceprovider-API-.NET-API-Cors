using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InIT.API.GMMEP.Models;
using InIT.API.GMMEP.Class;

namespace InIT.API.GMMEP.Controllers
{
    public class CategoryController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();
        [HttpPost]
        public spInsertCategory_Result InsertCategory(Category category)
        {
            // return GE.spInsertCategory(category.Id,category.Name,category.ImagePath,category.UserId,category.Description).AsEnumerable();
            spInsertCategory_Result dt = GE.spInsertCategory(category.Id, category.Name, category.ImagePath, category.UserId, category.Description,category.Status).SingleOrDefault();
            if (dt.Id > 0 && dt.Error == 0)
            {
                if (!String.IsNullOrEmpty(category.ImagePath))
                {
                    if (category.ImagePath.Length > 1)
                    {
                        
                        Utils.SaveImage("~/assets/images/CategoryImages/" + dt.Id.ToString() + ".jpg", category.ImagePath);
                       
                    }
                }
            }

            return dt;
        }
        
        [HttpGet]
        public IEnumerable<spGetAllCategories_Result> GetAllCategories()
        {
            return GE.spGetAllCategories().AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<spGetMastersCount_Result> GetMastersCount(int id)
        {
            return GE.spGetMastersCount().AsEnumerable();
        }

        [HttpGet]
        public IEnumerable<spGetAllCategoryWithPincode_Result> GetAllCategoryWithPincode(string pincode)
        {
            return GE.spGetAllCategoryWithPincode(pincode).AsEnumerable();
        }

    }
}
