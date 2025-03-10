namespace ZTP_Projekt_1.Web.DTOs.ProductDTOs
{
	public class ProductDTO
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string? Description { get; set; }
		public decimal Price { get; set; }
		public int StockQuantity { get; set; }
		public bool IsAvailable { get; set; }
		public string CategoryName { get; set; } = string.Empty; 
		public DateTime CreatedAt { get; set; }
	}
}
