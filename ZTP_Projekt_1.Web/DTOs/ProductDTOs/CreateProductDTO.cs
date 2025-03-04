using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ZTP_Projekt_1.Domain;

namespace ZTP_Projekt_1.Web.DTOs.ProductDTOs
{
    public class CreateProductDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        public bool IsAvailable { get; set; } = true;

        [Required]
        public int CategoryId { get; set; }
    }
}
