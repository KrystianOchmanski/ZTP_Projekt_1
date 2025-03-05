using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ZTP_Projekt_1.Domain
{
    public class Category
    {
		private decimal _minPrice;
		private decimal _maxPrice;

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		[Range(0, double.MaxValue, ErrorMessage = "Min price cannot be negative.")]
		public decimal MinPrice
		{
			get => _minPrice;
			set
			{
				if (value < 0) throw new ArgumentOutOfRangeException(nameof(MinPrice), "Min price cannot be negative.");
				_minPrice = value;
			}
		}

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		[Range(0, double.MaxValue, ErrorMessage = "Max price cannot be negative.")]
		public decimal MaxPrice
		{
			get => _maxPrice;
			set
			{
				if (value < 0) throw new ArgumentOutOfRangeException(nameof(MaxPrice), "Max price cannot be negative.");
				_maxPrice = value;
			}
		}

		[JsonIgnore]
        public List<Product> Products { get; set; } = new List<Product>();

        public void ValidatePrice(decimal price)
        {
            if (price < MinPrice || price > MaxPrice)
            {
                throw new ArgumentOutOfRangeException(nameof(price), $"Price:{price} is invalid. Valid price for category {Name} is between {MinPrice} and {MaxPrice}");
            }
        }

        public void Update(Category category)
        {
            Name = category.Name;
            MinPrice = category.MinPrice;
            MaxPrice = category.MaxPrice;
        }
    }
}
