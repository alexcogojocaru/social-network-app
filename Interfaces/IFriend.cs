/**************************************************************************
 *                                                                        *
 *  File:        IFriend.cs                                               *
 *  Copyright:   (c) 2021, Negru Parascheva                               *
 *  E-mail:      parascheva.negru@gmail.com                               *
 *  Description: The interface for the friend service.                    *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using Models;
using System.Collections.Generic;

namespace Interfaces
{

    public interface IFriend
    {
        /// <summary>
        /// Method that returns friend list of a user
        /// </summary>
        /// <param name="username">the user's name</param>
        /// <returns>the friendship list</returns>
        List<FriendEntity> GetFriendList(string username);

        /// <summary>
        /// Returns all the friends of a user
        /// </summary>
        /// <param name="username">the user's name</param>
        /// <param name="friendUsername">the friend's name</param>
        /// <returns>the friendship between the 2 users</returns>
        FriendEntity GetFriendship(string username, string friendUsername);

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
        bool CreateFriend(string username, FriendEntity friend);

        /// <summary>
        /// Deletes a friend 
        /// </summary>
        /// <param name="username">the user's name</param>
        /// <param name="friendUsername">the friend's name</param>
        /// <returns>true if the friend was deleted, false otherwise</returns>
        bool DeleteFriend(string username, string friendUsername);

    }
}