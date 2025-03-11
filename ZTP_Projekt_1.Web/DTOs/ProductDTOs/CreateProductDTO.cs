namespace ZTP_Projekt_1.Web.DTOs.ProductDTOs
{
    public class CreateProductDTO
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public bool IsAvailable { get; set; } = true;

        public int CategoryId { get; set; }
    }
}
