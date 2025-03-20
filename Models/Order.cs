namespace OrderManagement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Product { get; set; }
        public string Status { get; set; } = "В ожидании";
    }
}
