using System.ComponentModel.DataAnnotations.Schema;

namespace TriviumApiTest.Models
{
    public class PurchaseItem
    {
        public int Id { get; set; }

        [Column("IdCompra")]
        public int PurchaseId { get; set; }

        [Column("IdProduto")]
        public int ProductId { get; set; }

        [Column("Quantidade")]
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public Purchase Purchase { get; set; }
    }
}
