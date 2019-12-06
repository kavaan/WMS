using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WMS.TestClientWeb.Controllers
{
    public class WcfProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}