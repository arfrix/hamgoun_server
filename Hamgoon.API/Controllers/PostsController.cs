﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hamgoon.API.Models;
using HamgoonAPI.DataContext;
using HamgoonAPI.processes;
using HamgoonAPI.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hamgoon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly HamgooonMySQLContext _context;

        public PostsController(HamgooonMySQLContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPost() =>
            Ok(await _context.Post.ToListAsync());

        [HttpGet("getPostByUrl/{url}")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostByUrl(string url) =>
            Ok(await _context.Post.FirstOrDefaultAsync(post => post.UniqueUrl == url));


        [Authorize]
        // GET: Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(long id) =>
            (ActionResult<Post>) await _context.Post.FindAsync(id) ?? NotFound();

        [Authorize]
        // GET: Posts/publish/5
        [HttpGet("publish/{id}")]
        public async Task<ActionResult<Post>> PublishPost(long id)
        {
            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound(Response(false, "not found post with that id"));
            }

            post.IsDrafted = false;
            var number = await (
                from p in _context.Post
                where p.PublisherId == post.PublisherId &&
                      p.MainCategory == post.MainCategory &&
                      p.SubCategory == post.SubCategory &&
                      p.IsDrafted == post.IsDrafted && p.Id == id
                select p).CountAsync();
            post.Number = number;
            var relation = from rel in _context.Relation
                where rel.FollowedId == post.PublisherId &&
                      rel.MainCategory == post.MainCategory &&
                      rel.SubCategory == post.SubCategory
                select rel;
            foreach (var rel in relation)
            {
                rel.TotalPostNumber = number;
            }

            await _context.SaveChangesAsync();

            return Ok(Response(true, "published"));
        }

        [Authorize]
        // POST: Posts
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            var lastPost = await _context.Post.OrderByDescending(postToDes => postToDes.Id).FirstOrDefaultAsync();
            var lastPostNumber = Base62Converter.BaseToLong(lastPost.UniqueUrl);
            post.UniqueUrl = Base62Converter.LongToBase(lastPostNumber + 1);
            _context.Post.Add(post);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new {id = post.Id}, post);
        }

        [Authorize]
        // POST: Posts
        [HttpPost("Update")]
        public async Task<ActionResult<Post>> UpdatePost(Post post)
        {
            Post postShouldToUpdate = await _context.Post.FindAsync(post.Id);
            if (postShouldToUpdate == null)
                return Ok(Response(false, "there is not such post with this id"));
            else
            {
                _context.Entry(postShouldToUpdate).CurrentValues.SetValues(post);
                // post.PostSummary = post.Body.Substring(0, (post.Body.Length <= 70 ? post.Body.Length : 70));
            }

            await _context.SaveChangesAsync();

            return Ok(postShouldToUpdate);
        }

        [Authorize]
        // POST: Posts
        [HttpPost("notSeenPostList")]
        public async Task<ActionResult<Post>> NotSeenPostList(ReqForNotSeenPostList req)
        {
            var bigestGap = 0;
            List<Post> postlist = new List<Post>();

            var relations = _context.Relation.Where(relation => relation.FollowerId == req.FollowerId
                                                                && relation.MainCategory == req.MainCategory
                                                                && relation.SubCategory == req.SubCategory)
                .OrderByDescending(rel => rel.EngagementRate);
            foreach (Relation rel in relations)
            {
                var tempGap = rel.TotalPostNumber - rel.LastSeenPostNumber;
                if (bigestGap < tempGap)
                    bigestGap = tempGap;
            }

            for (int i = 0; i < bigestGap; i++)
                foreach (Relation rel in relations)
                {
                    if (rel.LastSeenPostNumber < rel.TotalPostNumber)
                    {
                        rel.LastSeenPostNumber += 1;
                        IEnumerable<Post> toAdd = _context.Post.Where(post => post.PublisherId == rel.FollowedId
                                                                              && post.MainCategory == rel.MainCategory
                                                                              && post.SubCategory == rel.SubCategory
                                                                              && post.Number == rel.LastSeenPostNumber
                                                                              && post.IsDrafted == false);
                        postlist.AddRange(toAdd);
                    }
                }

            return Ok(postlist);
        }

        [Authorize]
        [HttpPost("followedNewPosts")]
        public async Task<ActionResult<Post>> followingNewPosts(ReqForFollowedNewPosts req)
        {
            List<Post> followedUserPostlist = new List<Post>();

            var relations = _context.Relation.Where(relation => relation.FollowerId == req.FollowerId
                                                                && relation.MainCategory == req.MainCategory
                                                                && relation.SubCategory == req.SubCategory)
                .OrderByDescending(rel => rel.EngagementRate);
            foreach (Relation rel in relations)
            {
                List<Post> postlist = _context.Post
                    .Where(postsToFind => postsToFind.PublisherId == rel.FollowedId && postsToFind.IsDrafted == false &&
                                          postsToFind.MainCategory == rel.MainCategory)
                    .OrderByDescending(pos => pos.Number).ToList();

                // alan post haye kasayi ke follow shon kardera ro poshet sar ham rihkte yany 10 ta post hassan bad 7 ta post mamad
                foreach (Post post in postlist)
                    followedUserPostlist.Add(post);
            }

            // hala miad posta ro bar hasb id moratab mikone tory ke  id bozorgtara aval bashan va intory engary darym be tartib jadid boodan moratab mikonim
            followedUserPostlist = followedUserPostlist.OrderByDescending(pos => pos.Id).ToList();

            if (followedUserPostlist.Count() > 0)
                return Ok(Response(true, "found sth", followedUserPostlist));
            else
                return Ok(Response(false, "!" + " پستی وجود نداره"));
        }


        // POST: Posts
        [Authorize]
        [HttpPost("myPostsList")]
        public async Task<ActionResult<Post>> myPostsList([FromBody]ReqForMyPostList req)
        {
            var postList = _context.Post
                .Where(pos =>
                    pos.PublisherId == req.PublisherId && pos.MainCategory == req.MainCategory &&
                    pos.IsDrafted == false).OrderBy(pos => pos.Number);
            if (postList.Count() == 0)
                return Ok(Response(false, "there is no post"));
            else
                return Ok(Response(true, "found sth", postList));
        }

        // POST: Posts
        [Authorize]
        [HttpPost("draftList")]
        public async Task<ActionResult<Post>> DraftList(ReqForDraftList req)
        {
            var draftedList = _context.Post.Where(pos =>
                pos.PublisherId == req.PublisherId && pos.MainCategory == req.MainCategory && pos.IsDrafted == true);
            if (draftedList.Count() == 0)
                return Ok(Response(false, "there is no drafted post"));
            else
                return Ok(draftedList);
        }


        [HttpPost("search")]
        public async Task<ActionResult<Post>> PostSearch(ReqForSearch req)
        {
            IQueryable<Post> result;

            if (req.MainCat == -1)
            {
                result = _context.Post
                    .Where(pos =>
                        pos.Title.Contains(req.KeyWord) || pos.FirstTag.Contains(req.KeyWord) ||
                        pos.SecondTag.Contains(req.KeyWord) || pos.ThirdTag.Contains(req.KeyWord) ||
                        pos.FourthTag.Contains(req.KeyWord)).Where(posts => posts.IsDrafted == false);
            }
            else
            {
                result = _context.Post.Where(pos => pos.MainCategory == req.MainCat && pos.IsDrafted == false).Where(
                    pos => pos.Title.Contains(req.KeyWord) || pos.FirstTag.Contains(req.KeyWord) ||
                           pos.SecondTag.Contains(req.KeyWord) || pos.ThirdTag.Contains(req.KeyWord) ||
                           pos.FourthTag.Contains(req.KeyWord));
            }


            if (!result.Any())
                return Ok(Response(false, "not found"));
            return Ok(Response(true, "found somthing", result));
        }

        [HttpGet("newestPosts/{mainCat}")]
        public async Task<ActionResult<Post>> NewestPosts(int mainCat) =>
            mainCat == -1
                ? Ok((await (_context.Post.Where(p => p.IsDrafted == false).OrderByDescending(p => p.Id)).ToListAsync())
                    .Take(10))
                : Ok((await _context.Post.Where(post => post.IsDrafted == false && post.MainCategory == mainCat)
                    .OrderByDescending(post => post.Id).ToListAsync()).Take(10));

        [HttpGet("mostCommentedPosts/{mainCat}")]
        public async Task<ActionResult<Post>> mostCommentedPosts(int mainCat)
            => mainCat == -1
                ? Ok((await (_context.Post.Where(p => p.IsDrafted == false).OrderByDescending(p => p.CommentCount)).ToListAsync())
                    .Take(10))
                : Ok((await _context.Post.Where(post => post.IsDrafted == false && post.MainCategory == mainCat)
                    .OrderByDescending(post => post.CommentCount).ToListAsync()).Take(10));

        [Authorize]
        [HttpPost("hamegyry")]
        public async Task<ActionResult<Post>> PostHamegyry(ReqForHamegyry req)
        {
            var resultPost = _context.Post.Where(post => post.Id == req.PostId).FirstOrDefault();

            //var postToFind = _context.Post.Where(postToQuery => postToQuery.Id == 1).FirstOrDefault();

            if (resultPost != null)
            {
                var publisher = _context.User.Where(user => user.Id == resultPost.PublisherId).FirstOrDefault();
                if (publisher != null)
                {
                    if (publisher.Hamegyry == null)
                    {
                        publisher.Hamegyry = 1;
                    }
                    else
                        publisher.Hamegyry += 1;
                }
            }

            await _context.SaveChangesAsync();

            return Ok();
        }


        /* [HttpPost("template")]
         public async Task<ActionResult<String>> PostTemplate(ReqForPostTemplates req)
         {
             //return templates[req.MainCategory][req.SubCategory];
         }
         */

        [Authorize]
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

        private object Response(bool status, string msg)
        {
            return new
            {
                status = status,
                massage = msg
            };
        }

        private object Response<T>(bool status, string msg, IQueryable<T> data)
        {
            return new
            {
                data = data,
                status = status,
                massage = msg
            };
        }

        private object Response<T>(bool status, string msg, List<T> data)
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