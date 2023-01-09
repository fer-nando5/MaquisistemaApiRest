namespace Maquisistema.Fondos.Application.DTO
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public Boolean Status { get; set; }
        public string? StatusName { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public byte Discount { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
