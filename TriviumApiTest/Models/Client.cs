using System.ComponentModel.DataAnnotations.Schema;

namespace TriviumApiTest.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Column("Nome")]
        public string Name { get; set; }

        [Column("Telefone")]
        public string PhoneNumber { get; set; }

        [Column("Endereco")]
        public string Address { get; set; }
        public List<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
