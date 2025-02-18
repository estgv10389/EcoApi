using EcoApi.DTO;
using EcoApi.Models;
using EcoApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarbonGoalController : ControllerBase
    {
        private readonly ICarbonGoalService carbonGoalService;

        public CarbonGoalController(ICarbonGoalService carbonGoalService)
        {
            this.carbonGoalService = carbonGoalService;
        }

        // GET: api/<CarbonGoalController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CarbonGoalController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CarbonGoalController>
        [HttpPost]
        public async Task<IActionResult>Post([FromBody] CarbonGoalDTO carbonGoalDTO)
        {
            ApiResponse<CarbonGoalDTO> apiResponse = new ApiResponse<CarbonGoalDTO>();
            try {
               
                CarbonGoalDTO carbonGoalDTOResult = await carbonGoalService.AddCarbonGoal(carbonGoalDTO);
                if (carbonGoalDTOResult != null) {
                    apiResponse.Data = carbonGoalDTOResult;
                    return Ok(apiResponse);
                }
                else
                {
                    apiResponse.ErrorMessage = "Failed to create carbon goal.";
                    apiResponse.Success = false;
                    return BadRequest(apiResponse);
                }
            }
            catch (Exception e) {
                apiResponse.ErrorMessage = e.Message;
                apiResponse.Success = false;
                return BadRequest(apiResponse);
            }
        }

        // PUT api/<CarbonGoalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarbonGoalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
