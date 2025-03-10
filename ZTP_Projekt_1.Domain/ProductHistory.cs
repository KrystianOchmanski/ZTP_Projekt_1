using System.ComponentModel.DataAnnotations.Schema;

namespace ZTP_Projekt_1.Domain
{
    public class ProductHistory
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public bool IsAvailable { get; set; }

        public int CategoryId { get; set; }

        public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;

        public string ChangeType { get; set; } = "UPDATE"; // INSERT, UPDATE, DELETE

        public ProductHistory() { }

        public ProductHistory(Product product, string changeType)
        {
            ProductId = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            StockQuantity = product.StockQuantity;
            IsAvailable = product.IsAvailable;
            CategoryId = product.CategoryId;
            ModifiedAt = DateTime.UtcNow;
            ChangeType = changeType;
        }
    }
}
