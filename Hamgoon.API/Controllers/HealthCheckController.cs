using HamgoonAPI.DataContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hamgoon.API.Controllers
{
    [Route("health")]
    [Authorize]
    public class HealthCheckController
    {
        private readonly HamgooonMySQLContext _context;
        public HealthCheckController(HamgooonMySQLContext context)
        {
            _context = context;
        }
        
        [HttpGet("check")]
        public object HealthCheck()
        {
            return new
            {
                Status = "Ok"
            };
        }
    }
    
    
}