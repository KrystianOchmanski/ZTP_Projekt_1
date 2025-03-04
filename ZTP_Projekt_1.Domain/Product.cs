using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTP_Projekt_1.Domain
{
    public class Product
    {
        public int Id { get; set; }

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

        public Category Category { get; set; } = null!;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public void Update(Product product)
        {
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            StockQuantity = product.StockQuantity;
            IsAvailable = product.IsAvailable;
        }
    }
}
