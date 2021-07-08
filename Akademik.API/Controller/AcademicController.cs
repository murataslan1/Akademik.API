using System.Threading.Tasks;
using Akademik.API.Classes;
using Akademik.API.Classes.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Akademik.API.Controller
{
    [JwtHandler]
    [Route("api/[controller]/[action]")]
    public class AcademicController : ControllerBase
    {
        private IAcademicClient _academicClient;
        private ITokenHandler _tokenHandler;

        [HttpGet]
        public IActionResult Test()
        {
            return Ok("Controller is seems good");
        }
        
        public AcademicController(ITokenHandler tokenHandler,IAcademicClient academicClient)
        {
            _tokenHandler = tokenHandler;
            _academicClient = academicClient;
        }
        
        [HttpGet]
        public async Task<IActionResult> SearchWId(string id)
        {
            
            return Ok(await _academicClient.SearchWResearcherID(rid: id));
            
        }

        [HttpGet]
        public async Task<IActionResult> Verify([FromQuery]string token)
        {
   
         
            var res = await _academicClient.Verify();
            return Ok(res);
        }
    }
}