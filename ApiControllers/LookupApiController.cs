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
        public IActionResult GetProvincesList()
        {
            var provinces = dbcontext.Provinces.Select(p => p.ProvinceToDto())
                                                .ToList();
            if (provinces is null)
            {
                return NotFound("not found");
            }

            return Ok(provinces);
        }
        [HttpGet("districts/{id}")]
        public IActionResult GetDistrictsByProvinceId(int id)
        {
            var districts = dbcontext.Districts.Where(p => p.ProvinceId == id)
                                                .ToList();

            if (districts.Count == 0)
            {
                return NotFound($"no districts found for given id {id}");
            }

            return Ok(districts.Select(d => d.DistrictToDto()));


        }
    }
}
