using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using WebAPIService.Repository;

namespace WebAPIService.Controllers
{
    public class ShowroomController : ApiController
    {

        [HttpGet]
        public JsonResult<List<Models.Product>> GetALLProducts()
        {
            EntityMapper<DataAccessLayer.Product, Models.Product> mapObj = new EntityMapper<DataAccessLayer.Product, Models.Product>();

            List<DataAccessLayer.Product> prodList = DAL.GetAllProducts();
            List<Models.Product> products = new List<Models.Product>();
            foreach (var item in prodList)
            {
                products.Add(mapObj.Translate(item));
            }

            return Json<List<Models.Product>>(products);

        }

        [HttpGet]
        public JsonResult<Models.Product> GetProduct(int id)
        {
            EntityMapper<DataAccessLayer.Product, Models.Product> mapObj = new EntityMapper<DataAccessLayer.Product, Models.Product>();

            DataAccessLayer.Product dalProduct = DAL.GetProduct(id);
            Models.Product product1 = new Models.Product();
            product1 = mapObj.Translate(dalProduct);


            return Json<Models.Product>(product1);

        }

        [HttpPost]
        public bool InsertProduct(Models.Product product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapper<Models.Product, DataAccessLayer.Product> mapObj = new EntityMapper<Models.Product, DataAccessLayer.Product>();

                DataAccessLayer.Product productObj = new DataAccessLayer.Product();

                productObj = mapObj.Translate(product);
                status = DAL.InsertProduct(productObj);

            }

            return status;

        }

        [HttpPut]
        public bool UpdateProduct(Models.Product product)
        {

            EntityMapper<Models.Product, DataAccessLayer.Product> mapObj = new EntityMapper<Models.Product, DataAccessLayer.Product>();

            DataAccessLayer.Product productObj = new DataAccessLayer.Product();

            productObj = mapObj.Translate(product);
            var status = DAL.UpdateProduct(productObj);

            return status;

        }

        [HttpDelete]
        public bool DeleteProduct(int id)
        {

            var status = DAL.DeleteProduct(id);

            return status;

        }




    }
}
