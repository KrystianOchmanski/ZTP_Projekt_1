using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using ZTP_Projekt_1.Web.DTOs.ProductDTOs;

namespace IntegrationTests
{
    public class ProductControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private string _url = "api/v1/product";

        public ProductControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task AddProduct_WithDuplicateName_ReturnsBadRequest()
        {
            var newProduct = new CreateProductDTO
            {
                Name = "Laptop99", // Name exists
                Price = 1000,
                StockQuantity = 5,
                IsAvailable = true,
                CategoryId = 1
            };

            var response = await _client.PostAsJsonAsync(_url, newProduct);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
            var errorMessage = await response.Content.ReadAsStringAsync();
            errorMessage.Should().Contain("Product with name Laptop99 already exist.");
        }

        [Fact]
        public async Task AddProduct_WithInvalidName_ReturnsBadRequest()
        {
            var newProduct = new CreateProductDTO
            {
                Name = "Laptop@123", // Invalid char "@"
                Price = 1000,
                StockQuantity = 5,
                IsAvailable = true,
                CategoryId = 1
            };

            var response = await _client.PostAsJsonAsync(_url, newProduct);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
            var errorMessage = await response.Content.ReadAsStringAsync();
            errorMessage.Should().Contain("Product name can only contain letters and numbers.");
        }

        [Fact]
        public async Task AddProduct_WithPriceOutOfRange_ReturnsBadRequest()
        {
            var newProduct = new CreateProductDTO
            {
                Name = "Smartphone99",
                Price = 100000,
                StockQuantity = 5,
                IsAvailable = true,
                CategoryId = 1
            };

            var response = await _client.PostAsJsonAsync(_url, newProduct);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
            var errorMessage = await response.Content.ReadAsStringAsync();
            //errorMessage.Should().Contain("Price is outside the acceptable range for this category.");
        }

        [Fact]
        public async Task AddProduct_WithNegativeStockQuantity_ReturnsBadRequest()
        {
            var newProduct = new CreateProductDTO
            {
                Name = "Smartwatch99",
                Price = 200,
                StockQuantity = -5,
                IsAvailable = true,
                CategoryId = 1
            };

            var response = await _client.PostAsJsonAsync(_url, newProduct);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
            var errorMessage = await response.Content.ReadAsStringAsync();
            //errorMessage.Should().Contain("Stock quantity can not be nagative.");
        }

        [Fact]
        public async Task AddProduct_WithBlockedName_ReturnsBadRequest()
        {
            var newProduct = new CreateProductDTO
            {
                Name = "Bomba",
                Price = 1000,
                StockQuantity = 5,
                IsAvailable = true,
                CategoryId = 1
            };

            var response = await _client.PostAsJsonAsync(_url, newProduct);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
            var errorMessage = await response.Content.ReadAsStringAsync();
            errorMessage.Should().Contain("Name Bomba is blocked.");
        }

        [Fact]
        public async Task AddProduct_WithValidData_ReturnsCreated()
        {
            var newProduct = new CreateProductDTO
            {
                Name = "NewLaptop",
                Price = 1500,
                StockQuantity = 10,
                IsAvailable = true,
                CategoryId = 1
            };

            var response = await _client.PostAsJsonAsync(_url, newProduct);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var product = await response.Content.ReadFromJsonAsync<ProductDTO>();
            product.Should().NotBeNull();
            product.Name.Should().Be("NewLaptop");
            product.Price.Should().Be(1500);
        }
    }
}