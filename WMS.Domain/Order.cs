using System;
using System.Collections.Generic;

namespace WMS.Domain
{
    public class Order : BaseEntity
    {
        public long Number { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
        public DateTime DateTime { get; set; }
        public int Discount { get; set; }
    }
}