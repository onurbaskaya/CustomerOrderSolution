namespace CustomerOrder.Core.Entities
{
    public class Product
    {
        public int Id { get; set; } 
        public string Barcode { get; set; } 
        public string Description { get; set; } 
        public int Quantity { get; set; } 
        public decimal Price { get; set; } 
    }
}
