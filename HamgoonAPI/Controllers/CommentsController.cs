using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HamgoonAPI.Data;
using HamgoonAPI.Models;
using HamgoonAPI.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HamgoonAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly HamgooonMySQLContext _context;

        public CommentsController(HamgooonMySQLContext context)
        {
            _context = context;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComment()
        {
            return await _context.Comment.ToListAsync();
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(long id)
        {
            var comment = await _context.Comment.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        [HttpGet("GetCommentofPosts/{id}")]
        public async Task<ActionResult<Comment>> GetCommentofPosts(long id)
        {
            var comments = await _context.Comment.Where(c => c.PostId == id).ToListAsync();
            var orderedComments = new LinkedList<Comment>();
            var linkedListNodes = new List<LinkedListNode<Comment>>();
            foreach (var comment in comments)
            {
                if (!comment.IsReply)
                {
                    var node = orderedComments.AddLast(comment);
                    linkedListNodes.Add(node);
                    continue;
                }

                var parent = comments.FirstOrDefault(c => c.Id == comment.ParentCommentId);
                if (parent == null)
                {
                    continue;
                }

                var parentNode = linkedListNodes.FirstOrDefault(c => c.Value.Id == parent.Id);
                if (parentNode == null)
                {
                    continue;
                }
                orderedComments.AddAfter(parentNode, comment);
            }

            return Ok(orderedComments);
        }

        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(long id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Comments
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(ReqForPostComment req)
        {
            Event eventToAdd = new Event();
            _context.Comment.Add(req.Comment);


            if (req.Comment.IsReply)
            {

                eventToAdd.IsCommentReply = true;
                eventToAdd.ReactorId = req.ParentCommentPublisherId;
                //eventToAdd.CommentId = req.Comment.Id;
                eventToAdd.ActorId = req.Comment.PublisherId;
                eventToAdd.PostId = req.Comment.PostId;
                eventToAdd.ActorUsername = req.Comment.PublisherUsername;
                eventToAdd.ActorImgUrl = req.Comment.PublisherImg;

                //!! we must add another event to aware postpublisher of reply becaause reply is another comment for his/her post

                _context.Event.Add(eventToAdd);
            }
            else
            {
                eventToAdd.IsComment = true;
                eventToAdd.ReactorId = req.PostPublisherId;
                //eventToAdd.CommentId = req.Comment.Id;
                eventToAdd.ActorId = req.Comment.PublisherId;
                eventToAdd.PostId = req.Comment.PostId;
                eventToAdd.ActorUsername = req.Comment.PublisherUsername;
                eventToAdd.ActorImgUrl = req.Comment.PublisherImg;

                _context.Event.Add(eventToAdd);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComment", new { id = req.Comment.Id }, req.Comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comment>> DeleteComment(long id)
        {
            var comment = await _context.Comment.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        private bool CommentExists(long id)
        {
            return _context.Comment.Any(e => e.Id == id);
        }
    }
}
