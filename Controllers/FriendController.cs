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

        /// <summary>
        /// Get method
        /// </summary>
        /// <returns>
        /// An IActionResult object containing the response code and a list of friends <para/>
        /// Status code - OK, if there are friends<para/>
        /// Status code - NO CONTENT, if the there are no freinds
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
        /// Gets one friend
        /// </summary>
        /// <param name="friendUsername">the friend id</param>
        /// <returns>
        /// Status code - OK, if the friend was found
        /// Status code - NOT FOUND, if the friend wasn't found
        /// </returns>
        [HttpGet("{username}")]
        public IActionResult GetFriends(string username)
        {
            //FriendEntity friend = _friendService.GetFriend(friendUsername);

            //if (friend == null)
            //{
            //    return NotFound();
            //}

            //return Ok(friend);
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
        /// <param name="friend">the friend, taken from the body of the request</param>
        /// <returns>Status code - CREATED</returns>
        [HttpPost("{username}")]
        public IActionResult PostUser(string username, [FromBody] FriendEntity friend)
        {
            if (friend == null)
            {
                return BadRequest();
            }

            //_friendService.CreateFriend(friend);
            _friendService.CreateFriend(username, friend);
            return CreatedAtAction(nameof(GetFriendship), new { friend = friend }, friend);
        }

        /// <summary>
        /// Update one friend
        /// </summary>
        ///<param name="username"></param>
        /// <param name="friend">the friend, taken from the body of the request</param>
        /// <returns>
        /// Status code - OK, if the friend was found
        /// Status code - NOT FOUND, if the friend wasn't found
        /// </returns>
        //[HttpPut("{username}")]
        //public IActionResult UpdateUser(string username, [FromBody] FriendEntity friend)
        //{
        //    if (_friendService.UpdateFriend(username, friend))
        //    {
        //        return Ok();
        //    }

        //    return NotFound();
        //}

        /// <summary>
        /// Delete one friend
        /// </summary>
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