using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ZTP_Projekt_1.Domain
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MinPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MaxPrice { get; set; }

        public bool IsPriceValid(decimal price)
        {
            return price >= MinPrice && price <= MaxPrice;
        }
    }
}
