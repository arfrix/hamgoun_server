﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using HamgoonAPI.Data;
using HamgoonAPI.Models;
using HamgoonAPI.Request;

namespace HamgoonAPI.Controllers
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
                return Ok(Models.Response.NewResponse(false, "not found"));
            else
                return Ok(Models.Response.NewResponse(true,"found somthing",result));
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

    }
}