namespace CustomerOrder.Core.Entities
{
    public class CustomerOrders
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status {  get; set; }
        public List<Product> Products { get; set; }
    }
}