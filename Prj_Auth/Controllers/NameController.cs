using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prj_Auth.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    {
        private readonly IJwtAuthenticationMgr jwtAuthenticationMgr;
        public NameController(IJwtAuthenticationMgr jwtAuthenticationMgr)
        {
            this.jwtAuthenticationMgr = jwtAuthenticationMgr;
        }

        // GET: api/hihi
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Miri", "Bintulu" };
        }

   

        // GET api/<NameController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value1111";
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {

            var token = jwtAuthenticationMgr.Authenticate(userCred.Username, userCred.Password);
            
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
