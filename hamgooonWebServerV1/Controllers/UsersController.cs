using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hamgooonWebServerV1.Data;
using hamgooonWebServerV1.Models;
using hamgooonWebServerV1.Request;

namespace hamgooonWebServerV1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly HamgooonContext _context;

        public UsersController(HamgooonContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }
        [HttpGet("test")]
        public ActionResult<IEnumerable<string>> test()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        

        // POST: Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }


        // POST: Users/Update
        [HttpPost("Update")]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            User userToUpdate = await _context.User.FindAsync(user.Id);
            _context.Entry(userToUpdate).CurrentValues.SetValues(user);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpPost("search")]
        public async Task<ActionResult<Post>> UserSearch(ReqForSearch req)
        {

            var result = _context.User.Where(user => user.Edu_highSchool.Contains(req.KeyWord)
                                                     || user.Edu_univercity.Contains(req.KeyWord)
                                                     || user.Edu_subject.Contains(req.KeyWord)
                                                     || user.Work_job.Contains(req.KeyWord)
                                                     || user.Work_company.Contains(req.KeyWord)
                                                     || user.Location_motherTown.Contains(req.KeyWord)
                                                     || user.Location_livingCountry.Contains(req.KeyWord)
                                                     || user.Location_livingTown.Contains(req.KeyWord)
                                                     || user.Languge_motherTongue.Contains(req.KeyWord)
                                                     || user.Languge_dialect.Contains(req.KeyWord)
                                                     || user.Languge_secondLangName.Contains(req.KeyWord)
                                                     || user.Languge_thirdLangName.Contains(req.KeyWord)
                                                     || user.Languge_forthLangName.Contains(req.KeyWord)
                                                     || user.Relation.Contains(req.KeyWord)
                                                     || user.Sport_name.Contains(req.KeyWord)
                                                     || user.Sport_teamName.Contains(req.KeyWord)
                                                     || user.Sport_playerName.Contains(req.KeyWord)
                                                     || user.Movie_category1Name.Contains(req.KeyWord)
                                                     || user.Movie_category2Name.Contains(req.KeyWord)
                                                     || user.Book_category1Name.Contains(req.KeyWord)
                                                     || user.Book_category2Name.Contains(req.KeyWord)
                                                     || user.Music_category1Name.Contains(req.KeyWord)
                                                     || user.Music_category2Name.Contains(req.KeyWord)
                                                     || user.Skill_mainSkillName.Contains(req.KeyWord)
                                                     || user.Skill_secondSkillName.Contains(req.KeyWord)
                                                     || user.Teach_mainTeachName.Contains(req.KeyWord)
                                                     || user.Teach_secondTeachName.Contains(req.KeyWord)
                                                    );

            if (result.Count() == 0)
                return Ok(Response(false, "not found"));
            else
                return Ok(result);
        }



        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(long id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(long id)
        {
            return _context.User.Any(e => e.Id == id);
        }

        

        private object Response(bool status, string msg)
        {
            return new
            {
                status = status,
                massage = msg
            };
        }

    }
}
