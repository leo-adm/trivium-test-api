using System.ComponentModel.DataAnnotations.Schema;

namespace TriviumApiTest.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Column("Nome")]
        public string Name { get; set; }

        [Column("Preco")]
        public double Price { get; set; }
        public List<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
        public int TotalPurchasesIncluded => GetTotalPurchasesIncluded();
        public double TotalRaised => GetTotalRaised();

        private int GetTotalPurchasesIncluded()
        {
            return PurchaseItems.Count;
        }

        private double GetTotalRaised()
        {
            double totalRaised = 0;

            foreach (var item in PurchaseItems)
            {
                totalRaised += item.Product.Price * item.Quantity;
            }

            return totalRaised;
        }
    }
}
