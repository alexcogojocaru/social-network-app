/**************************************************************************
 *                                                                        *
 *  File:        FriendController.cs                                      *
 *  Copyright:   (c) 2021, Negru Parascheva                               *
 *  E-mail:      parascheva.negru@gmail.com                               *
 *  Description: Describes the REST API routes for the friend data.       *
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

    public class FriendController : ControllerBase
    {
        private static IFriend _friendService = new FriendService();
        private static IUser _userService = new UserService();

        /// <summary>
        /// Return the friendship between 2 users
        /// </summary>
        /// <returns>
        /// An IActionResult object containing the response code and the friendship<para/>
        /// Status code - OK, if the friendship is valid<para/>
        /// Status code - NO CONTENT, if the friendship does not exist
        /// </returns>
        [HttpGet]
        public IActionResult GetFriendship(string username, string friendUsername)
        {
            FriendEntity friends = _friendService.GetFriendship(username, friendUsername);

            if (friends != null)
            {
                return Ok(friends);
            }

            return NoContent();

        }

        /// <summary>
        /// Gets the user's friends
        /// </summary>
        /// <param name="username">the user's name</param>
        /// <returns>
        /// Status code - OK, if the user was found
        /// Status code - NOT FOUND, if the user wasn't found
        /// </returns>
        [HttpGet("{username}")]
        public IActionResult GetFriends(string username)
        {
            List<FriendEntity> friends = _friendService.GetFriendList(username);

            if (friends == null)
            {
                return NotFound();
            }

            return Ok(friends);
        }

        /// <summary>
        /// Creates an friend
        /// </summary>
        /// <param name="username">the user's name</param>
        /// <param name="friend">the friend, taken from the body of the request</param>
        /// <returns>Status code - CREATED</returns>
        [HttpPost("{username}")]
        public IActionResult PostUser(string username, [FromBody] FriendEntity friend)
        {
            if ((friend == null) || (_userService.GetUser(friend.Username) == null))
            {
                return BadRequest();
            }

            _friendService.CreateFriend(username, friend);
            return CreatedAtAction(nameof(GetFriendship), new { friend = friend }, friend);
        }

        /// <summary>
        /// Delete one friend
        /// </summary>
        /// <param name="username">the user's name</param>
        /// <param name="friendUsername">the friend id</param>
        /// <returns>
        /// Status code - OK, if the friend was found
        /// Status code - NOT FOUND, if the friend wasn't found
        /// </returns>
        [HttpDelete("{username}")]
        public IActionResult DeleteFriend(string username, string friendUsername)
        {
            if (_friendService.DeleteFriend(username, friendUsername))
            {
                return Ok();
            }

            return NotFound();
        }
    }
}