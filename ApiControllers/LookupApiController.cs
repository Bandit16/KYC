using System.Threading.Tasks;
using KYC.Data;
using KYC.Mapping;
using KYC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KYC.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupApiController(KycContext dbcontext) : ControllerBase
    {
        [HttpGet("provinces")]
        public async Task<IActionResult> GetProvincesList()
        {
            var provinces = await dbcontext.Provinces.Select(p => p.ProvinceToDto())
                                                .ToListAsync();
            if (provinces is null)
            {
                return NotFound("not found");
            }

            return Ok(provinces);
        }
        [HttpGet("districts/{id}")]
        public async Task<IActionResult> GetDistrictsByProvinceId(int id)
        {
            var districts = await dbcontext.Districts.Where(p => p.ProvinceId == id)
                                                .ToListAsync();

            if (districts.Count == 0)
            {
                return NotFound($"no districts found for given id {id}");
            }

            return Ok(districts.Select(d => d.DistrictToDto()));


        }
        [HttpGet("districts")]
        public async Task<IActionResult> GetDistricts()
        {
            var districts = await dbcontext.Districts.ToListAsync();
            if (districts.Count == 0)
            {
                return NotFound();
            }
            return Ok(districts.Select(d => d.DistrictToDto()));
        }
    }
}
