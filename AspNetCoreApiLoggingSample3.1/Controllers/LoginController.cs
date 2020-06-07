using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApiLoggingSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public class LoginDto
        {
            public string Username { get; set; }

            public string Password { get; set; }
        }

        [HttpPost]
        public IActionResult Post(LoginDto loginDto)
        {
            // DO NOT log the request and response for this method anywhere!
            return Ok("RETURN SECRET TOKEN HERE");
        }
    }
}