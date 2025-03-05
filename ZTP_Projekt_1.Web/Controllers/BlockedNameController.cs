using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using ZTP_Projekt_1.Application.IServices;

namespace ZTP_Projekt_1.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BlockedNameController : ControllerBase
    {
        private readonly IBlockedNameService _blockedNameService;

        public BlockedNameController(IBlockedNameService blockedNameService)
        {
            _blockedNameService = blockedNameService;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var name = await _blockedNameService.GetById(id);

                if (name == null)
                    return NotFound("BlockedName not found");
                return Ok(name);
            }
            catch(Exception ex)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _blockedNameService.RemoveAsync(id);
                
                if(!result)
                    return BadRequest($"Something went wrong when removing blocked name.");

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
