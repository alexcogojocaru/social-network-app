/**************************************************************************
 *                                                                        *
 *  File:        UserService.cs                                           *
 *  Copyright:   (c) 2021, Cojocaru Daniel-Alexandru                      *
 *  E-mail:      alex.cojocaru73@gmail.com                                *
 *  Description: The service for the user management system               *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using Interfaces;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UserService : IUser
    {
        private static Dictionary<string, UserEntity> _users = new Dictionary<string, UserEntity>();

        #region Public Methods

        /// <summary>
        /// Creates an user
        /// </summary>
        /// <param name="user">a user object filled with the required properties</param>
        /// <returns>
        /// true if the user has been created<para/>
        /// false if the user wasn't created
        /// </returns>
        public bool CreateUser(UserEntity user)
        {
            if (!_users.ContainsKey(user.Username))
            {
                _users.Add(user.Username, user);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Deletes an user
        /// </summary>
        /// <param name="username">the id</param>
        /// <returns>
        /// true if the user has been deleted<para/>
        /// false if the user wasn't deleted
        /// </returns>
        public bool DeleteUser(string username)
        {
            if (_users.ContainsKey(username))
            {
                _users.Remove(username);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method that returns an user based on the username provided
        /// </summary>
        /// <param name="username">username of the searched user</param>
        /// <returns>the searched user</returns>
        public UserEntity GetUser(string username)
        {
            if (_users.ContainsKey(username))
            {
                return _users[username];
            }

            return null;
        }

        /// <summary>
        /// Returns all the users stored
        /// </summary>
        /// <returns>the list of requested users</returns>
        public List<UserEntity> GetUsers()
        {
            return _users.Values.ToList();
        }

        /// <summary>
        /// Updates an user
        /// </summary>
        /// <param name="username">the id</param>
        /// <param name="user">the user entity</param>
        /// <returns>
        /// true if the user has been updated<para/>
        /// false if the user wasn't updated
        /// </returns>
        public bool UpdateUser(string username, UserEntity user)
        {
            if (_users.ContainsKey(username))
            {
                _users[username] = user;
                return true;
            }

            return false;
        }

        #endregion
    }
}
