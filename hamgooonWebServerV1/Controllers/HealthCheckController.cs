using System.Collections.Generic;
using System.Threading.Tasks;
using hamgooonWebServerV1.Data;
using Microsoft.AspNetCore.Mvc;

namespace hamgooonWebServerV1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    class HealthCheckController : ControllerBase 
    {
        private readonly HamgooonMySQLContext _context;

        public HealthCheckController(HamgooonMySQLContext context)
        {
            _context = context;
        }
        [HttpGet("check")]
        public string Get()
        {
            return _context.User.Find(1).Firstname;
        }
    }
}