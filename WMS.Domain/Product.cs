namespace WMS.Domain
{
    public class Product :BaseEntity
    {
        public string Name { get; set; }
        public long BuyPrice { get; set; }
        public string Description { get; set; }
    }
}