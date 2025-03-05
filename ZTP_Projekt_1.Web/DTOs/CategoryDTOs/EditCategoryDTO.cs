namespace ZTP_Projekt_1.Web.DTOs.CategoryDTOs
{
	public class EditCategoryDTO
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public decimal MinPrice { get; set; }

		public decimal MaxPrice { get; set; }
	}
}
