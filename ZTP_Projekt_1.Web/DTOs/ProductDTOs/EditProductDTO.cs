using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ZTP_Projekt_1.Web.DTOs.ProductDTOs
{
	public class EditProductDTO
	{
        [Required]
		public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Product name must have 3-20 characters.")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Product name can only contain letters and numbers.")]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity can not be nagative.")]
        public int StockQuantity { get; set; }

        public bool IsAvailable { get; set; } = true;

        [Required]
        public int CategoryId { get; set; }
    }
}
