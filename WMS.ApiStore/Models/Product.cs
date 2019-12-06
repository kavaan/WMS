using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.ApiStore.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long BuyPrice { get; set; }
        public string Description { get; set; }

    }
}
