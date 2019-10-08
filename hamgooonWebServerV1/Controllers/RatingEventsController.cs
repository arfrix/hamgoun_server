﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hamgooonWebServerV1.Data;
using hamgooonWebServerV1.Models;

namespace hamgooonWebServerV1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RatingEventsController : ControllerBase
    {
        private readonly HamgooonContext _context;

        public RatingEventsController(HamgooonContext context)
        {
            _context = context;
        }

        // GET: api/RatingEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingEvent>>> GetRatingEvent()
        {
            return await _context.RatingEvent.ToListAsync();
        }

        // GET: api/RatingEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RatingEvent>> GetRatingEvent(long id)
        {
            var ratingEvent = await _context.RatingEvent.FindAsync(id);

            if (ratingEvent == null)
            {
                return NotFound();
            }

            return ratingEvent;
        }

       




        // POST: api/RatingEvents
        [HttpPost("Mizoun")]
        public async Task<ActionResult<RatingEvent>> PostMizoun(RatingEvent ratingEvent)
        {
            RatingEvent emty;
            var relatedEvent = _context.RatingEvent.Where(ratingEventToFind => ratingEventToFind.CommentId == ratingEvent.CommentId && ratingEventToFind.JudgeId == ratingEvent.JudgeId).FirstOrDefault();
            if(relatedEvent!= null)
            {
                if (relatedEvent.IsNamizoun)
                {
                    relatedEvent.IsMizoun = true;
                    relatedEvent.IsNamizoun = false;
                    var comment = _context.Comment.Where(commentToFind => commentToFind.Id == ratingEvent.CommentId).First();
                    comment.Mizoun += 1;
                    comment.Namizoun -= 1;
                }
            }
            else
            {
                var comment = _context.Comment.Where(commentToFind => commentToFind.Id == ratingEvent.CommentId).First();
                comment.Mizoun += 1;
                ratingEvent.IsNamizoun = false;
                _context.RatingEvent.Add(ratingEvent);

               
            }


            await _context.SaveChangesAsync();





            
            return Ok(Response(true ,""));
        }




        // POST: api/RatingEvents
        [HttpPost("Namizoun")]
        public async Task<ActionResult<RatingEvent>> PostNamizoun(RatingEvent ratingEvent)
        {
            var relatedEvent = _context.RatingEvent.Where(ratingEventToFind => ratingEventToFind.CommentId == ratingEvent.CommentId && ratingEventToFind.JudgeId == ratingEvent.JudgeId).FirstOrDefault();
            if (relatedEvent != null)
            {
                if (relatedEvent.IsMizoun)
                {
                    relatedEvent.IsMizoun = false;
                    relatedEvent.IsNamizoun = true;
                    var comment = _context.Comment.Where(commentToFind => commentToFind.Id == ratingEvent.CommentId).First();
                    comment.Mizoun -= 1;
                    comment.Namizoun += 1;
                }
            }
            else
            {
                var comment = _context.Comment.Where(commentToFind => commentToFind.Id == ratingEvent.CommentId).First();
                comment.Namizoun += 1;
                ratingEvent.IsMizoun = false;
                _context.RatingEvent.Add(ratingEvent);


            }


            await _context.SaveChangesAsync();






            return Ok(Response(true, ""));
        }




        // POST: api/RatingEvents
        [HttpPost("PostRating")]
        public async Task<ActionResult<RatingEvent>> PostPostRating(RatingEvent ratingEvent)
        {

            var post = await _context.Post.FindAsync(ratingEvent.PostId);

            if(post!= null)
            {
                var relatedEvent = _context.RatingEvent.Where(ratingEventToFind => ratingEventToFind.PostId == ratingEvent.PostId && ratingEventToFind.JudgeId == ratingEvent.JudgeId).FirstOrDefault();
                if(relatedEvent == null)
                {
                    _context.RatingEvent.Add(ratingEvent);
                    post.PostRate = ((post.JudgesCount * post.PostRate) + ratingEvent.PostRate) / (post.JudgesCount + 1);

                    post.JudgesCount += 1;
                }
                else
                {
                    return Ok(Response(false, "شما قبلا رای دادین !"));
                }
            }
            else{
                return Ok(Response(false, "اصن چنین پستی وجود نداره که بخوای رای بدی بهش!"));
            }


            
             
            
            await _context.SaveChangesAsync();

            return Ok(Response(true, "",post.PostRate));
        }





        // DELETE: api/RatingEvents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RatingEvent>> DeleteRatingEvent(long id)
        {
            var ratingEvent = await _context.RatingEvent.FindAsync(id);
            if (ratingEvent == null)
            {
                return NotFound();
            }

            _context.RatingEvent.Remove(ratingEvent);
            await _context.SaveChangesAsync();

            return ratingEvent;
        }

        private bool RatingEventExists(long id)
        {
            return _context.RatingEvent.Any(e => e.Id == id);
        }
        private object Response(bool status, string msg)
        {
            return new
            {
                status = status,
                massage = msg
            };
        }
        private object Response(bool status, string msg, double data)
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