using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WMS.WcfStore.StoreServiceRef;

namespace WMS.WcfStore.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            using (var client = new MainServiceClient())
            {
                var result = client.GetProducts().ToList();
                client.Close();
                return View(result);
            }
        }
    }
}