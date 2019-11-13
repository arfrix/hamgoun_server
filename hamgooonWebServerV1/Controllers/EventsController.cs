using System;
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
    public class EventsController : ControllerBase
    {
        private readonly HamgooonContext _context;

        public EventsController(HamgooonContext context)
        {
            _context = context;
        }

        // GET: api/RatingEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetRatingEvent()
        {
            return await _context.Event.ToListAsync();
        }

        // GET: api/RatingEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetRatingEvent(long id)
        {
            var ratingEvent = await _context.Event.FindAsync(id);

            if (ratingEvent == null)
            {
                return NotFound();
            }

            return ratingEvent;
        }

        [HttpGet("notif/{whoseNotif}")]
        public async Task<ActionResult<Event>> GetNotif(long whoseNotif)
        {
            var notif = _context.Event.Where(notifToFind => notifToFind.ReactorId == whoseNotif);

            if (notif.Count() == 0)
            {
                return Ok(Response(false,"چیزی موجود نبود"));
            }

            return Ok(Response(true,"",notif));
        }




        // POST: api/RatingEvents
        [HttpPost("Mizoun")]
        public async Task<ActionResult<Event>> PostMizoun(Event ratingEvent)
        {
            Event emty;
            var relatedEvent = _context.Event.Where(ratingEventToFind => ratingEventToFind.CommentId == ratingEvent.CommentId && ratingEventToFind.ActorId == ratingEvent.ActorId).FirstOrDefault();
            if(relatedEvent!= null)
            {
                if (relatedEvent.IsNamizoun)
                {
                    relatedEvent.IsMizoun = true;
                    relatedEvent.IsNamizoun = false;
                    var comment = _context.Comment.Where(commentToFind => commentToFind.Id == ratingEvent.CommentId).FirstOrDefault();
                    comment.Mizoun += 1;
                    comment.Namizoun -= 1;
                }
            }
            else
            {
                var comment = _context.Comment.Where(commentToFind => commentToFind.Id == ratingEvent.CommentId).FirstOrDefault();
                comment.Mizoun += 1;
                ratingEvent.IsNamizoun = false;
                _context.Event.Add(ratingEvent);

               
            }


            await _context.SaveChangesAsync();





            
            return Ok(Response(true ,""));
        }




        // POST: api/RatingEvents
        [HttpPost("Namizoun")]
        public async Task<ActionResult<Event>> PostNamizoun(Event ratingEvent)
        {
            var relatedEvent = _context.Event.Where(ratingEventToFind => ratingEventToFind.CommentId == ratingEvent.CommentId && ratingEventToFind.ActorId == ratingEvent.ActorId).FirstOrDefault();
            if (relatedEvent != null)
            {
                if (relatedEvent.IsMizoun)
                {
                    relatedEvent.IsMizoun = false;
                    relatedEvent.IsNamizoun = true;
                    var comment = _context.Comment.Where(commentToFind => commentToFind.Id == ratingEvent.CommentId).FirstOrDefault();
                    comment.Mizoun -= 1;
                    comment.Namizoun += 1;
                }
            }
            else
            {
                var comment = _context.Comment.Where(commentToFind => commentToFind.Id == ratingEvent.CommentId).FirstOrDefault();
                comment.Namizoun += 1;
                ratingEvent.IsMizoun = false;
                _context.Event.Add(ratingEvent);


            }


            await _context.SaveChangesAsync();






            return Ok(Response(true, ""));
        }




        // POST: api/RatingEvents
        [HttpPost("PostRating")]
        public async Task<ActionResult<Event>> PostPostRating(Event ratingEvent)
        {

            var post = await _context.Post.FindAsync(ratingEvent.PostId);

            if(post!= null)
            {
                var relatedEvent = _context.Event.Where(ratingEventToFind => ratingEventToFind.PostId == ratingEvent.PostId && ratingEventToFind.ActorId == ratingEvent.ActorId).FirstOrDefault();
                if(relatedEvent == null)
                {
                    _context.Event.Add(ratingEvent);
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
        public async Task<ActionResult<Event>> DeleteRatingEvent(long id)
        {
            var ratingEvent = await _context.Event.FindAsync(id);
            if (ratingEvent == null)
            {
                return NotFound();
            }

            _context.Event.Remove(ratingEvent);
            await _context.SaveChangesAsync();

            return ratingEvent;
        }

        private bool RatingEventExists(long id)
        {
            return _context.Event.Any(e => e.Id == id);
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
        private object Response(bool status, string msg, IQueryable data)
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
