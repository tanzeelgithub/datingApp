using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
  
    public class UsersController:ControllerBase
    {
        //private const string V = "GetUsers";
        private readonly ApplicationDbContext dbContext;

        public UsersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() => await dbContext.Users.ToListAsync();

        [HttpGet("{Id}")]
        public async Task<ActionResult<AppUser>> GetUser(int Id)=>await dbContext.Users.FirstOrDefaultAsync(u=>u.Id==Id);
    }
}