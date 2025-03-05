using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZTP_Projekt_1.Domain
{
    public class Product
    {
        private int _stockQuantity;

        public int Id { get; set; }

		[Required]
		[StringLength(20, MinimumLength = 3, ErrorMessage = "Product name must have 3-20 characters.")]
		[RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Product name can only contain letters and numbers.")]
		public string Name { get; set; } = null!;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
		[Range(0, int.MaxValue, ErrorMessage = "Stock quantity can not be nagative.")]
		public int StockQuantity 
        {
            get => _stockQuantity; 
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(StockQuantity), "Stock quantity cannot be negative.");
                _stockQuantity = value;
            } 
        }

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
