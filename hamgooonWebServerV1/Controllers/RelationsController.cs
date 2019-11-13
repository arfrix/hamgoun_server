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
    public class RelationsController : ControllerBase
    {
        private readonly HamgooonContext _context;

        public RelationsController(HamgooonContext context)
        {
            _context = context;
        }

        // GET: api/Relations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Relation>>> GetRelation()
        {
            return await _context.Relation.ToListAsync();
        }

        // GET: api/Relations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Relation>> GetRelation(long id)
        {
            var relation = await _context.Relation.FindAsync(id);

            if (relation == null)
            {
                return NotFound();
            }

            return relation;
        }

        
        [HttpGet("whoFollowMe/{id}")]
        public async Task<ActionResult<Relation>> whoFollowMe(long id)
        {
            List<User> followers = new List<User>();
           
            var followersId =  _context.Relation.Where(rel => rel.FollowedId == id).Select(rel => rel.FollowerId);
            foreach(long followerId  in followersId)
            {
                
                IEnumerable<User> toAdd = _context.User.Where(user => user.Id == followerId);
               
                followers.AddRange(toAdd);
                
            }
            
            return Ok(followers);
        }


        // POST: api/Relations
        [HttpPost]
        public async Task<ActionResult<Relation>> PostRelation(Relation relation)
        {
            var foundSameRelation = _context.Relation.Where(rel => rel.FollowedId == relation.FollowedId && rel.FollowerId == relation.FollowerId && rel.MainCategory == relation.MainCategory).FirstOrDefault();
            
            if(foundSameRelation == null)
            {
                _context.Relation.Add(relation);
                await _context.SaveChangesAsync();
                return Ok(Response(true,"پیگیرش شدی"));
            }
            else
            {
                return Ok(Response(false, "قبلا پیگیرش شدی"));
            }
           

            
        }
        // POST: api/Relations
        [HttpPost("/delete")]
        public async Task<ActionResult<Relation>> DeleteRelation(Relation relation)
        {
            var relationtoDelete = _context.Relation.Where(rel => rel.FollowedId == relation.FollowedId
                                                                    && rel.FollowerId == relation.FollowerId
                                                                    && rel.MainCategory == relation.MainCategory
                                                                    && rel.SubCategory == relation.SubCategory);

            if(relationtoDelete.Count() != 0)
            {
                _context.Relation.RemoveRange(relationtoDelete);
                await _context.SaveChangesAsync();
                return Ok(Response(true, "delete that relation"));
            }
            else
            {
                return Ok(Response(false, "not found that relation"));
            }

        }
        // POST: Relations
        [HttpPost("IncreaseLastSeen")]
        public async Task<ActionResult<Relation>> IncreaseLastSeen(Relation relation)
        {
            var relationToFind = _context.Relation.Where(rel => rel.FollowedId == relation.FollowedId && rel.FollowerId == relation.FollowerId && rel.MainCategory == relation.MainCategory && rel.SubCategory == relation.SubCategory).FirstOrDefault();

            relationToFind.LastSeenPostNumber += 1;


                await _context.SaveChangesAsync();

            return Ok(true);
        }
        [HttpPost("IncreaseEngagement")]
        public async Task<ActionResult<Relation>> IncreaseEngagement(Relation relation)
        {
            var relationToFind = _context.Relation.Where(rel => rel.FollowedId == relation.FollowedId && rel.FollowerId == relation.FollowerId && rel.MainCategory == relation.MainCategory && rel.SubCategory == relation.SubCategory).FirstOrDefault();

            relationToFind.EngagementRate += 1;


            await _context.SaveChangesAsync();

            return Ok(true);
        }

        // DELETE: api/Relations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Relation>> DeleteRelation(long id)
        {
            var relation = await _context.Relation.FindAsync(id);
            if (relation == null)
            {
                return NotFound();
            }

            _context.Relation.Remove(relation);
            await _context.SaveChangesAsync();

            return relation;
        }

        private bool RelationExists(long id)
        {
            return _context.Relation.Any(e => e.Id == id);
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
