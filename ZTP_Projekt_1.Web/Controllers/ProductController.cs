using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZTP_Projekt_1.Application.IServices;

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


	}
}
