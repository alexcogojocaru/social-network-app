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
using System.Collections.Generic;
using System.Linq;
namespace Services
{

    public class FriendService : IFriend
    {
        private Dictionary<string, FriendEntity> _friends = new Dictionary<string, FriendEntity>();

        #region Public Methods

        /// <summary>
        /// Method that returns an friend based on the friendUsername provided
        /// </summary>
        /// <param name="friendUsername">friendUsername of the searched friend</param>
        /// <returns>the searched friend</returns>
        public FriendEntity GetFriend(string friendUsername)
        {
            if (_friends.ContainsKey(friendUsername))
            {
                return _friends[friendUsername];
            }
            return null;
        }

        /// <summary>
        /// Returns all the friends stored
        /// </summary>
        /// <returns>the list of requested friends</returns>
        public List<FriendEntity> GetFriends()
        {
            return _friends.Values.ToList();
        }

        /// <summary>
        /// Creates an friend
        /// </summary>
        /// <param name="friend">a friend object filled with the required properties</param>
        /// <returns>
        /// true if the freind has been created<para/>
        /// false if the friend wasn't created
        /// </returns>
        public bool CreateFriend(FriendEntity friend)
        {
            if (!_friends.ContainsKey(friend.Username))
            {
                _friends.Add(friend.Username, friend);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Updates an friend
        /// </summary>
        /// <param name="username">the id</param>
        /// <param name="friend">the friend entity</param>
        /// <returns>
        /// true if the friend has been updated<para/>
        /// false if the friend wasn't updated
        /// </returns>
        public bool UpdateFriend(string username, FriendEntity friend)
        {
            if (_friends.ContainsKey(username))
            {
                _friends[username] = friend;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Deletes an friend
        /// </summary>
        /// <param name="friendUsername">the id</param>
        /// <returns>
        /// true if the friend has been deleted<para/>
        /// false if the friend wasn't deleted
        /// </returns>
        public bool DeleteFriend(string friendUsername)
        {
            if (_friends.ContainsKey(friendUsername))
            {
                _friends.Remove(friendUsername);
                return true;
            }

            return false;
        }

        #endregion
    }
}