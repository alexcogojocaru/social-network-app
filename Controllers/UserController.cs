/**************************************************************************
 *                                                                        *
 *  File:        UserController.cs                                        *
 *  Copyright:   (c) 2021, Cojocaru Daniel-Alexandru                      *
 *  E-mail:      alex.cojocaru73@gmail.com                                *
 *  Description: Describes the REST API routes for the user data.         *
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
    public class UserController : ControllerBase
    {
        private static IUser _userService = new UserService();

        /// <summary>
        /// Get method
        /// </summary>
        /// <returns>
        /// An IActionResult object containing the response code and a list of users <para/>
        /// Status code - OK, if there are users<para/>
        /// Status code - NO CONTENT, if the there are no users
        /// </returns>
        [HttpGet]
        public IActionResult GetUsers()
        {
            List<UserEntity> users = _userService.GetUsers();
            
            if (users.Count != 0)
            {
                return Ok(users);
            }

            return NoContent();
        }

        /// <summary>
        /// Gets one user
        /// </summary>
        /// <param name="username">the user id</param>
        /// <returns>
        /// Status code - OK, if the user was found
        /// Status code - NOT FOUND, if the user wasn't found
        /// </returns>
        [HttpGet("{username}")]
        public IActionResult GetUser(string username)
        {
            UserEntity user = _userService.GetUser(username);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        /// <summary>
        /// Creates an user
        /// </summary>
        /// <param name="user">the user, taken from the body of the request</param>
        /// <returns>Status code - CREATED</returns>
        [HttpPost]
        public IActionResult PostUser([FromBody] UserEntity user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new { user = user }, user);
        }

        [HttpPut("{username}")]
        public IActionResult UpdateUser(string username, [FromBody] UserEntity user)
        {
            if (_userService.UpdateUser(username, user))
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{username}")]
        public IActionResult DeleteUser(string username)
        {
            if (_userService.DeleteUser(username))
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
