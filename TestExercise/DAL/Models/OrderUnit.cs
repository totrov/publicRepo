namespace DAL.Models
{
    public class OrderUnit
    {
        public int OrderUnitId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}