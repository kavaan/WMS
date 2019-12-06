using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WMS.ApiStore.Models;

namespace WMS.ApiStore.Controllers
{
    public class ProductsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/v1/");
                var result = await client.GetAsync("Products");
                var productsAsString = await result.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(productsAsString);
                return View(products);
            }
        }
    }
}