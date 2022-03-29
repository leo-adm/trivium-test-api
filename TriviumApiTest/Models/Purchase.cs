namespace TriviumApiTest.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        public List<PurchaseItem> Items { get; set; } = new List<PurchaseItem>();
        public double TotalPrice => GetTotalPrice();
        private double GetTotalPrice()
        {
            double totalPrice = 0;

            foreach (var item in Items)
            {
                totalPrice += item.Product.Price * item.Quantity;
            }

            return totalPrice;
        }
    }
}
