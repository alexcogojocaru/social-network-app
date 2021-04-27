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
        /// Method that returns an friend based on the friendUsername provided
        /// </summary>
        /// <param name="friendUsername">friendUsername of the searched friend</param>
        /// <returns>the searched friend</returns>
        FriendEntity GetFriend(string friendUsername);

        /// <summary>
        /// Returns all the friends
        /// </summary>
        /// <returns>a list with FriendEntity objects</returns>
        List<FriendEntity> GetFriends();

        /// <summary>
        /// Creates a new friend
        /// </summary>
        /// <param name="friend">the friend entity that holds the data</param>
        /// <returns>
        /// true - if the friend was created<para/>
        /// false - if the friend wasn't created<para/>
        /// The friend can't be created if the user that requested the action doesn't exist
        /// </returns>
        bool CreateFriend(FriendEntity firend);

        /// <summary>
        /// Updates an friend
        /// </summary>
        /// <param name="username">the id</param>
        /// <param name="friend">the friend entity</param>
        /// <returns>
        /// true if the friend has been updated<para/>
        /// false if the friend wasn't updated
        /// </returns>
        bool UpdateFriend(string username, FriendEntity firend);

        /// <summary>
        /// Deletes a friend 
        /// </summary>
        /// <param name="friendUsername"></param>
        /// <returns>true if the friend was deleted, false otherwise</returns>
        bool DeleteFriend(string friendUsername);

    }
}