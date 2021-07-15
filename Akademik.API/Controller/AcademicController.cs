using System.Linq;
using System.Threading.Tasks;
using Akademik.API.Classes;
using Akademik.API.Classes.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Akademik.API.Controller
{
    [AllowAnonymous]
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
            var token = HttpContext.Request.Headers.FirstOrDefault(b => b.Key.ToLower().Equals("authorization")).Value.ToString();
            
            return Ok(await _academicClient.SearchWResearcherID(rid: id,token));
            
        }

        [HttpGet]
        public async Task<IActionResult> Verify([FromQuery]string token)
        {
   
         
            var res = await _academicClient.Verify(token);
            return Ok(res);
        }
    }
}