/**************************************************************************
 *                                                                        *
 *  File:        PostController.cs                                        *
 *  Copyright:   (c) 2021, Barbu Bogdan-Cosmin                            *
 *  E-mail:      barbubogdan1337@gmail.com                                *
 *  Description: Describes the REST API routes for the post data.         *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using Microsoft.AspNetCore.Mvc;
using Services;
using Models;
using System.Collections.Generic;
using Interfaces;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private static IPost _postService = new PostService();

        /// <summary>
        /// Get method
        /// </summary>
        /// <returns>
        /// An IActionResult object containing the response code and a list of users <para/>
        /// Status code - OK, if there are posts<para/>
        /// Status code - NO CONTENT, if the there are no posts
        /// </returns>
        [HttpGet]
        public IActionResult GetPosts()
        {
            List<PostEntity> posts = _postService.GetPosts();

            return (posts.Count != 0) ? Ok(posts) : NoContent();
        }

        /// <summary>
        /// Gets one post
        /// </summary>
        /// <param name="id">the post id</param>
        /// <returns>
        /// Status code - OK, if the post was found
        /// Status code - NOT FOUND, if the post wasn't found
        /// </returns>
        [HttpGet("{id}")]
        public IActionResult GetPost(uint id)
        {
            PostEntity post = _postService.GetPost(id);

            return (post != null) ? Ok(post) : NotFound();
        }

        /// <summary>
        /// Creates a post
        /// </summary>
        /// <param name="post">the post, taken from the body of the request</param>
        /// <returns>Status code - CREATED</returns>
        [HttpPost]
        public IActionResult PostPost([FromBody] PostEntity post)
        {
            if (post == null) 
            {
                return BadRequest();
            }

            _postService.CreatePost(post);
            return CreatedAtAction(nameof(GetPost), new { post = post }, post);
        }

        /// <summary>
        /// Updates a post
        /// </summary>
        /// <param name="post">the post, taken from the body of the request</param>
        /// <returns>
        /// Status code - UPDATED, if the post was found
        /// Status code - NOT FOUND, if the post wasn't found
        /// </returns>
        [HttpPut("{id}")]
        public IActionResult UpdatePost(uint id, [FromBody] PostEntity post)
        {
            if (_postService.GetPost(post.Id) == null)
            {
                return BadRequest();
            }

            return _postService.EditPost(id, post.Username, post.Content) ? Ok() : NotFound();
        }

        /// <summary>
        /// Deletes a post
        /// </summary>
        /// <param name="post">deletes the post, taken from the body of the request</param>
        /// <returns>
        /// Status code - OK, if the post was deleted
        /// Status code - NOT FOUND, if the post wasn't found
        /// </returns>
        [HttpDelete("{id}")]
        public IActionResult DeletePost(uint id, string username)
        {
            if (_postService.DeletePost(id, username))
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
