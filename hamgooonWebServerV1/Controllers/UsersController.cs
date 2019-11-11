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
using System.Net.Mail;

namespace hamgooonWebServerV1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly HamgooonMySQLContext _context;

        public UsersController(HamgooonMySQLContext context)
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

        // GET: api/Users/5
        [HttpPost("login")]
        public async Task<ActionResult<long>> login(ReqForLogin req)
        {
            var user =  _context.User.Where(userToFind => userToFind.UserName == req.userName && userToFind.Pass == req.pass).Select(userToSelect => userToSelect.Id).FirstOrDefault();

            if (user == 0)
            {
                return Ok(Response(false, "not found anyone"));
            }

            return Ok(Response(true,"fount sb",user));
        }

        

        // POST: Users
        [HttpPost("register")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var sameUserUserName = _context.User.Where(usertoFind => usertoFind.UserName == user.UserName).Select(userToSelect => userToSelect.Id).FirstOrDefault();
            if (sameUserUserName != 0)
            {
                return Ok(Response(false, "اخه نام کاربریت تکراریه"));
            }
            var sameUserEmail = _context.User.Where(usertoFind => usertoFind.Email == user.Email).Select(userToSelect => userToSelect.Id).FirstOrDefault();
            if (sameUserEmail != 0)
            {
                return Ok(Response(false, "اخه ایمیلت تکراریه"));
            }
            if (sameUserEmail == 0 && sameUserUserName == 0)
            {
                _context.User.Add(user);
                await _context.SaveChangesAsync();
                return Ok(Response(true, "fount sb", CreatedAtAction("GetUser", new { id = user.Id }, user)));
            }
            else
                return Ok(Response(false, "something gose wrong"));





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
            // for global user search should assign -1 to bio

            System.Linq.IQueryable<User> result = null;

            if(req.Bio == -1)
            {
                result = _context.User.Where(user => user.UserName.Contains(req.KeyWord));
            }
            else
            {
                switch (req.Bio)
                {
                    case 0:
                        result = _context.User.Where(users => users.Edu_highSchool.Contains(req.KeyWord) || users.Edu_univercity.Contains(req.KeyWord) || users.Edu_subject.Contains(req.KeyWord));
                        break;
                    case 1:
                        result = _context.User.Where(user => user.Work_job.Contains(req.KeyWord) || user.Work_company.Contains(req.KeyWord));
                        break;
                    case 2:
                        result = _context.User.Where(user => user.Languge_motherTongue.Contains(req.KeyWord) || user.Languge_dialect.Contains(req.KeyWord) || user.Languge_secondLangName.Contains(req.KeyWord));
                        break;
                    case 3:
                        result = _context.User.Where(user => user.Location_motherTown.Contains(req.KeyWord) || user.Location_livingCountry.Contains(req.KeyWord) || user.Location_livingTown.Contains(req.KeyWord));
                        break;
                }   
            }

            


            if (result.Count() == 0)
                return Ok(Response(false, "not found"));
            else
                return Ok(Response(true,"found somthing",result));
        }

       [HttpPost("sendEmail")]
       public async Task<ActionResult<User>> sendEmail(ReqForEmail req)
        {



            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("hamgounteam@gmail.com");
            msg.To.Add("arfa.maddi1376@gmail.com");
            msg.Subject = "test";
            msg.Body = "Test Content";
            //msg.Priority = MailPriority.High;

            try
            {
                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("hamgounteam@gmail.com", "hamG0uN132");
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    client.Send(msg);
                }
            }catch(Exception ex)
            {
                return BadRequest();
            }
            
            return Ok(true);
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

        private object Response(bool status, string msg , IQueryable data)
        {
            return new
            {
                data = data,
                status = status,
                massage = msg
            };
        }
        private object Response(bool status, string msg, long data)
        {
            return new
            {
                data = data,
                status = status,
                massage = msg
            };
        }
        private object Response(bool status, string msg, CreatedAtActionResult data)
        {
            return new
            {
                data = data,
                status = status,
                massage = msg
            };
        }

    }
}
