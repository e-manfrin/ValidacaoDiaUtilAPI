using DataAPI.Dtos;
using DataAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Spring.Objects.Factory.Attributes;

namespace DataAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        [Autowired]
        private DataService dataService = new DataService();

        [HttpGet]
        public IActionResult ValidacaoData([FromBody] DataRequest dataDto)
        {
            var dataResponse = dataService.VerificarDiaUtil(dataDto.Data);   

            if(dataResponse == null)
            {
                return NotFound();
            }
            return Ok(dataResponse);
        }
    }
}
