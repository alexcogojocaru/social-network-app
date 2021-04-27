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
        [HttpGet]

        public IActionResult GetFriends()
        {

            List<FriendEntity> friends = _friendService.GetFriends();

            if (friends.Count != 0)
            {
                return Ok(friends);
            }

            return NoContent();

        }

        [HttpGet("{friendUsername}")]
        public IActionResult GetFriend(string friendUsername)
        {
            FriendEntity friend = _friendService.GetFriend(friendUsername);

            if (friend == null)
            {
                return NotFound();
            }

            return Ok(friend);
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] FriendEntity friend)
        {
            if (friend == null)
            {
                return BadRequest();
            }

            _friendService.CreateFriend(friend);
            return CreatedAtAction(nameof(GetFriend), new { friend = friend }, friend);
        }

        [HttpPut("{username}")]
        public IActionResult UpdateUser(string username, [FromBody] FriendEntity friend)
        {
            if (_friendService.UpdateFriend(username, friend))
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{friendUsername}")]
        public IActionResult DeleteFriend(string friendUsername)
        {
            if (_friendService.DeleteFriend(friendUsername))
            {
                return Ok();
            }

            return NotFound();
        }
    }

}