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

            var result = _context.User.Where(user => user.UserName.Contains(req.KeyWord)
                                                     || user.Edu_highSchool.Contains(req.KeyWord)
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
                                                    ).Select(resultusers => new {
                                                        
                                                          Id = resultusers.Id,
                                                          UserName =resultusers.UserName,

                                                        Firstname =resultusers.Firstname,
                                                        Lastname = resultusers.Lastname,
                                                        Email = resultusers.Email,
                                                        PhoneNumber = resultusers.PhoneNumber,
                                                        ProfileImgUrl = resultusers.ProfileImgUrl,
                                                        PhoneVerifed = resultusers.PhoneVerifed,
                                                        SMSCode = resultusers.SMSCode,
                                                        EmailVerifed = resultusers.EmailVerifed,
                                                        EmailCode = resultusers.EmailCode,
                                                        StickerUrl1 = resultusers.StickerUrl1,
                                                        StickerUrl2 = resultusers.StickerUrl2,
                                                        StickerUrl3 = resultusers.StickerUrl3,
                                                        StickerUrl4 = resultusers.StickerUrl4,
                                                        StickerUrl5 = resultusers.StickerUrl5,
                                                        Edu_highSchool = resultusers.Edu_highSchool,
                                                        Edu_univercity = resultusers.Edu_univercity,
                                                        Edu_subject = resultusers.Edu_subject,
                                                        Work_job = resultusers.Work_job,
                                                        Work_company = resultusers.Work_company,
                                                        Location_motherTown = resultusers.Location_motherTown,
                                                        Location_livingCountry = resultusers.Location_livingCountry,
                                                        Location_livingTown = resultusers.Location_livingTown,
                                                        Languge_motherTongue = resultusers.Languge_motherTongue,
                                                        Languge_dialect = resultusers.Languge_dialect,
                                                        Languge_secondLangName = resultusers.Languge_secondLangName,
                                                        Languge_thirdLangName = resultusers.Languge_thirdLangName,
                                                        Languge_forthLangName = resultusers.Languge_forthLangName,
                                                        Relation = resultusers.Relation,
                                                        Sport_name = resultusers.Sport_name,
                                                        Sport_teamName = resultusers.Sport_teamName,
                                                        Sport_playerName = resultusers.Sport_playerName,
                                                        Movie_category1Name = resultusers.Movie_category1Name,
                                                        Movie_category2Name = resultusers.Movie_category2Name,
                                                        Book_category1Name = resultusers.Book_category1Name,
                                                        Book_category2Name = resultusers.Book_category2Name,
                                                        Music_category1Name = resultusers.Music_category1Name,
                                                        Music_category2Name = resultusers.Music_category2Name,
                                                        Skill_mainSkillName = resultusers.Skill_mainSkillName,
                                                        Skill_secondSkillName = resultusers.Skill_secondSkillName,
                                                        Teach_mainTeachName = resultusers.Teach_mainTeachName,
                                                        Teach_secondTeachName = resultusers.Teach_secondTeachName



                                                    });

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
