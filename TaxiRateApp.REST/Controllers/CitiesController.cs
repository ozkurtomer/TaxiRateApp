using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxiRateApp.Business.Abstract;
using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        public ICitiesService _citiesService;

        public CitiesController(ICitiesService citiesService)
        {
            _citiesService = citiesService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Cities cities)
        {
            try
            {
                var result = await _citiesService.Add(cities);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Cities cities)
        {
            try
            {
                var result = await _citiesService.Update(cities);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Cities cities)
        {
            try
            {
                var result = await _citiesService.Delete(cities);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _citiesService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int cityId)
        {
            try
            {
                var result = await _citiesService.GetById(cityId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("getbyname")]
        public async Task<IActionResult> GetByName(string cityName)
        {
            try
            {
                var result = await _citiesService.GetByName(cityName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
