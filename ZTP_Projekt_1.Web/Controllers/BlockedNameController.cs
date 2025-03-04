using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZTP_Projekt_1.Application.IServices;

namespace ZTP_Projekt_1.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BlockedNameController : ControllerBase
    {
        private readonly IBlockedNameService _blockedNameService;
        private readonly IMapper _mapper;

        public BlockedNameController(IBlockedNameService blockedNameService, IMapper mapper)
        {
            _blockedNameService = blockedNameService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var blockedNames = await _blockedNameService.GetBlockedNamesAsync();
                return Ok(blockedNames);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(string name)
        {
            try
            {
                var newBlockedName = await _blockedNameService.AddAsync(name);
                return Ok(newBlockedName);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
