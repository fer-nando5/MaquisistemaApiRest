namespace Maquisistema.Fondos.Dominio.Entity
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public Boolean Status { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        
    }
}
