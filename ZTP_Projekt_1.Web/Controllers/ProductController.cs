using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ZTP_Projekt_1.Application.IServices;
using ZTP_Projekt_1.Domain;
using ZTP_Projekt_1.Web.DTOs.ProductDTOs;

namespace ZTP_Projekt_1.Web.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public ProductController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			try
			{
				return Ok(_mapper.Map<List<ProductDTO>>(await _productService.GetProductsAsync()));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			try
			{
				var product = await _productService.GetByIdAsync(id);

				if (product == null)
					return NotFound("Product not found.");
				return Ok(_mapper.Map<ProductDTO>(product));
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync([FromBody] CreateProductDTO productDTO)
		{
			try
			{
				var result = await _productService.AddAsync(_mapper.Map<Product>(productDTO));
				return Ok(result);
            }
            catch (SqlException ex)
            {
                return BadRequest($"Database error: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync(int id, [FromBody] EditProductDTO editProductDTO)
		{
			try
			{
				if (id != editProductDTO.Id)
					return BadRequest("Product ID mismatch");

				var result = await _productService.UpdateAsync(_mapper.Map<Product>(editProductDTO));
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveAsync(int id)
		{
			try
			{
				var result = await _productService.RemoveAsync(id);

				if (!result)
					return BadRequest("Something went wrong when removing product");
				
				return NoContent();
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
