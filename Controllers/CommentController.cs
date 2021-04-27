using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Collections.Generic;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private static IComment _commentService = new CommentService();
        private static IUser _userService = new UserService();

        [HttpGet]
        public IActionResult GetComments()
        {
            List<CommentEntity> comments = _commentService.GetComments();

            return (comments.Count != 0) ? Ok(comments) : NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(uint id)
        {
            CommentEntity comment = _commentService.GetComment(id);

            return (comment != null) ? Ok(comment) : NotFound();
        }

        [HttpPost]
        public IActionResult PostComment([FromBody] CommentEntity comment)
        {
            if ((comment == null) || (_userService.GetUser(comment.Username) == null))
            {
                return BadRequest();
            }

            _commentService.CreateComment(comment);
            return CreatedAtAction(nameof(GetComment), new { comment = comment }, comment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateComment(uint id, [FromBody] CommentEntity comment)
        {
            if (_userService.GetUser(comment.Username) == null)
            {
                return BadRequest();
            }

            return _commentService.EditComment(id, comment.Username, comment.Content) ? Ok() : NotFound();
        }

        [HttpDelete]
        public IActionResult DeleteComment(uint id, string username)
        {
            if (_commentService.DeleteComment(id, username))
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
