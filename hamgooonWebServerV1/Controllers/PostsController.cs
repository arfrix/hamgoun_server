﻿using System;
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
    public class PostsController : ControllerBase
    {
        private readonly HamgooonContext _context;

        public PostsController(HamgooonContext context)
        {
            _context = context;
        }

        // GET: Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPost()
        {
            return await _context.Post.ToListAsync();
        }

        // GET: Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(long id)
        {
            var post = await _context.Post.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // GET: Posts/5
        [HttpGet("publish/{id}")]
        public async Task<ActionResult<Post>> PublishPost(long id)
        {
            var post = await _context.Post.FindAsync(id);

            if (post != null)
            {
                post.IsDrafted = false;
                var number = _context.Post.Where(po => po.PublisherId == post.PublisherId && po.MainCategory == post.MainCategory && po.SubCategory == post.SubCategory && po.IsDrafted == false && po.Id != id).Count() + 1;
                post.Number = number;
                var relation = _context.Relation.Where(rel => rel.FollowedId == post.PublisherId && rel.MainCategory == post.MainCategory && rel.SubCategory == post.SubCategory);
                foreach (Relation rel in relation)
                {
                    rel.TotalPostNumber = number;
                }



                await _context.SaveChangesAsync();
                return Ok(Response(true , "published"));
            }
            else
            return Ok(Response(false, "not found post with that id"));
        }


        // POST: Posts
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            post.UniqueUrl = Guid.NewGuid().ToString();
            _context.Post.Add(post);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }







        // POST: Posts
        [HttpPost("Update")]
        public async Task<ActionResult<Post>> UpdatePost(Post post)
        {

            Post postShouldToUpdate = _context.Post.Find(post.Id);
            if (postShouldToUpdate == null)
                return Ok(Response(false, "there is not such post with this id"));
            else
            {
                _context.Entry(postShouldToUpdate).CurrentValues.SetValues(post);
                post.PostSummary = post.Body.Substring(0, (post.Body.Length <= 70 ? post.Body.Length : 70));
            }
            await _context.SaveChangesAsync();

            return Ok(postShouldToUpdate);
        }


        // POST: Posts
        [HttpPost("notSeenPostList")]
        public async Task<ActionResult<Post>> NotSeenPostList(ReqForNotSeenPostList req)
        {
            var bigestGap=0;
            List<Post> postlist = new List<Post>();
            
            var relations = _context.Relation.Where(relation => relation.FollowerId == req.FollowerId
                                                        && relation.MainCategory == req.MainCategory
                                                        && relation.SubCategory == req.SubCategory).OrderByDescending(rel => rel.EngagementRate);
            foreach(Relation rel in relations)
            {
                                          var tempGap = rel.TotalPostNumber - rel.LastSeenPostNumber;
                if (bigestGap < tempGap)
                    bigestGap = tempGap;
            }

            for(int i =0; i<bigestGap; i++)
            foreach(Relation rel in  relations )
            {
                if(rel.LastSeenPostNumber < rel.TotalPostNumber)
                {
                        rel.LastSeenPostNumber += 1;
                        IEnumerable<Post> toAdd = _context.Post.Where(post => post.PublisherId == rel.FollowedId 
                                                                && post.MainCategory == rel.MainCategory 
                                                                && post.SubCategory == rel.SubCategory 
                                                                && post.Number == rel.LastSeenPostNumber);
                        postlist.AddRange(toAdd);
                       
                       
                }
            }

            return Ok(postlist);
            
        }


        // POST: Posts
        [HttpPost("myPostsList")]
        public async Task<ActionResult<Post>> myPostsList(ReqForMyPostList req)
        {

            var postList = _context.Post.Where(pos => pos.PublisherId == req.PublisherId && pos.MainCategory == req.MainCategory && pos.SubCategory == req.SubCategory).OrderBy(pos => pos.Number);
            if (postList.Count() == 0)
                return Ok(Response(false, "there is no post"));
            else
                return Ok(postList);
        }

        // POST: Posts
        [HttpPost("draftList")]
        public async Task<ActionResult<Post>> DraftList(ReqForDraftList req)
        {

            var draftedList = _context.Post.Where(pos => pos.PublisherId == req.PublisherId && pos.MainCategory == req.MainCategory && pos.SubCategory == req.SubCategory && pos.IsDrafted == true);
            if (draftedList.Count() == 0)
                return Ok(Response(false, "there is no drafted post"));
            else
            return Ok(draftedList);
        }
        
        
        [HttpPost("search")]
        public async Task<ActionResult<Post>> PostSearch(ReqForSearch req)
        {

            var result = _context.Post.Where(pos => pos.Title.Contains(req.KeyWord) || pos.FirstTag.Contains(req.KeyWord) || pos.SecondTag.Contains(req.KeyWord) || pos.ThirdTag.Contains(req.KeyWord) || pos.FourthTag.Contains(req.KeyWord));

            if (result.Count() == 0)
                return Ok(Response(false, "not found"));
            else
                return Ok(result);
        }




        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(long id)
        {
            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Post.Remove(post);
            await _context.SaveChangesAsync();

            return post;
        }

        private bool PostExists(long id)
        {
            return _context.Post.Any(e => e.Id == id);
        }
        private object Response(bool status , string msg)
        {
            return new
            {
                status = status,
                massage = msg
            };
        }
    }
}