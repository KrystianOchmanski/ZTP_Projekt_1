using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZTP_Projekt_1.Application.IServices;
using ZTP_Projekt_1.Domain;
using ZTP_Projekt_1.Web.DTOs.CategoryDTOs;

namespace ZTP_Projekt_1.Web.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public CategoryController(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync() 
		{
			try
			{
				return Ok(await _categoryService.GetAllAsync());
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
				var category = await _categoryService.GetByIdAsync(id);

				if (category == null)
					return NotFound("Category not found");
				return Ok(category);
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync([FromBody] CreateCategoryDTO categoryDTO)
		{
			try
			{
				var result = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDTO));
				return Ok(result);
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync(int id, [FromBody] EditCategoryDTO editCategoryDTO)
		{
			try
			{
				if (id != editCategoryDTO.Id)
					return BadRequest("ID mismatch");

				var category = await _categoryService.GetByIdAsync(id);
				if (category == null)
					return NotFound("Category not found");

				category.Update(_mapper.Map<Category>(editCategoryDTO));

				return Ok(await _categoryService.UpdateAsync(category));
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			try
			{
				var result = await _categoryService.RemoveAsync(id);

				if (!result)
					return BadRequest("Something went wrong when removing category");
				return NoContent();
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
