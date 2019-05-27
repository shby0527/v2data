using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataWeb.Controllers
{
    [Route("api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost("data")]
        public object RevecData([FromForm(Name = "data")]IFormFile data, [FromForm(Name = "key")]IFormFile key)
        {

            return null;
        }
    }
}
