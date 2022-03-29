namespace TriviumApiTest.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public List<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
