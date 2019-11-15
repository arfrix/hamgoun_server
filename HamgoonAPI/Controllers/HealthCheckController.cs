using System.Threading.Tasks;
using HamgoonAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace HamgoonAPI.Controllers
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