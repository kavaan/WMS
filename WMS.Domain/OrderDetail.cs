using System;

namespace WMS.Domain
{
    public class OrderDetail :BaseEntity
    {
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }
        public int Count { get; set; }
        public long UnitPrice { get; set; }
    }
}