/**************************************************************************
 *                                                                        *
 *  File:        FriendService.cs                                         *
 *  Copyright:   (c) 2021, Negru Parascheva                               *
 *  E-mail:      parascheva.negru@gmail.com                               *
 *  Description: The service that manages the friends operations flow.    *
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
using System;
using System.Collections.Generic;

namespace Services
{
    public class FriendService : IFriend
    {
        private Dictionary<string, List<FriendEntity>> _friends = new Dictionary<string, List<FriendEntity>>();

        #region Public Methods

        /// <summary>
        /// Method that returns friend list of a user
        /// </summary>
        /// <param name="username">the user's name</param>
        /// <returns>the friendship list</returns>
        public List<FriendEntity> GetFriendList(string username)
        {
            if (_friends.ContainsKey(username))
            {
                return _friends[username];
            }
            return null;
        }

        /// <summary>
        /// Creates a new friend and links him to a user
        /// </summary>
        /// <param name="username">the user's name</param>
        /// <param name="friend">the friend entity that holds the data</param>
        /// <returns>
        /// true - if the friend was created<para/>
        /// false - if the friend wasn't created<para/>
        /// The friend can't be created if the user that requested the action doesn't exist
        /// </returns>
        public bool CreateFriend(string username, FriendEntity friend)
        {
            string friendshipTimestamp = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            friend.FriendshipDate = friendshipTimestamp;

            if (!_friends.ContainsKey(username))
            {
                _friends[username] = new List<FriendEntity>();
                _friends[username].Add(friend);
            }
            else
            {
                _friends[username].Add(friend);
            }

            if (!_friends.ContainsKey(friend.Username))
            {
                FriendEntity temp = new FriendEntity();

                temp.Username = username;
                temp.FriendshipDate = friendshipTimestamp;

                _friends[friend.Username] = new List<FriendEntity>();
                _friends[friend.Username].Add(temp);
            }
            else
            {
                FriendEntity temp = new FriendEntity();

                temp.Username = username;
                temp.FriendshipDate = friendshipTimestamp;
                _friends[friend.Username].Add(temp);
            }

            return true;
        }

        /// <summary>
        /// Deletes a friend 
        /// </summary>
        /// <param name="username">the user's name</param>
        /// <param name="friendUsername">the friend's name</param>
        /// <returns>true if the friend was deleted, false otherwise</returns>
        public bool DeleteFriend(string username, string friendUsername)
        {
            if (_friends.ContainsKey(username))
            {
                foreach (var friend in _friends[username])
                {
                    if (friend.Username.Equals(friendUsername))
                    {
                        _friends[username].Remove(friend);
                        break;
                    }
                }

                foreach (var friend in _friends[friendUsername])
                {
                    if (friend.Username.Equals(username))
                    {
                        _friends[friendUsername].Remove(friend);
                        break;
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns all the friends of a user
        /// </summary>
        /// <param name="username">the user's name</param>
        /// <param name="friendUsername">the friend's name</param>
        /// <returns>the friendship between the 2 users</returns>
        public FriendEntity GetFriendship(string username, string friendUsername)
        {
            if (_friends.ContainsKey(username))
            {
                foreach (var friend in _friends[username])
                {
                    if (friend.Username.Equals(friendUsername))
                    {
                        return friend;
                    }
                }
            }

            return null;
        }

        #endregion
    }
}