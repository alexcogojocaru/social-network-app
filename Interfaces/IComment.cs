/**************************************************************************
 *                                                                        *
 *  File:        IComment.cs                                              *
 *  Copyright:   (c) 2021, Cojocaru Daniel-Alexandru                      *
 *  E-mail:      alex.cojocaru73@gmail.com                                *
 *  Description: The interface for the comment service.                   *
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
    public interface IComment
    {
        /// <summary>
        /// Creates a new comment
        /// </summary>
        /// <param name="comment">the comment entity that holds the data</param>
        /// <returns>
        /// true - if the comment was created<para/>
        /// false - if the comment wasn't created<para/>
        /// The comment can't be created if the user that requested the action doesn't exist
        /// </returns>
        bool CreateComment(CommentEntity comment);

        /// <summary>
        /// Returns all the comments
        /// </summary>
        /// <returns>a list with CommentEntity objects</returns>
        List<CommentEntity> GetComments();

        /// <summary>
        /// Gets a specific comment with the id provided
        /// </summary>
        /// <param name="id">the id of the requested comment</param>
        /// <returns>the comment or null if it doesn't exist</returns>
        CommentEntity GetComment(uint id);

        /// <summary>
        /// Changes the content of a comment and the timestamp only if the 
        /// specified user has edit rights
        /// </summary>
        /// <param name="id">the id of the comment</param>
        /// <param name="username"></param>
        /// <param name="content">the new content of the comment</param>
        /// <returns>true if the comment was changed, false otherwise</returns>
        bool EditComment(uint id, string username, string content);

        /// <summary>
        /// Deletes a comment if the user has rights
        /// </summary>
        /// <param name="id">the id of the comment</param>
        /// <param name="username"></param>
        /// <returns>true if the comment was deleted, false otherwise</returns>
        bool DeleteComment(uint id, string username);

        /// <summary>
        /// Checks if a comment exists
        /// </summary>
        /// <param name="id">the id of the comment</param>
        /// <returns>true if it exists, false otherwise</returns>
        bool Exists(uint id);

        /// <summary>
        /// Checks if an user has rights for a comment
        /// </summary>
        /// <param name="id">the id of the comment</param>
        /// <param name="username"></param>
        /// <returns>true if the user has rights, false otherwise</returns>
        bool HasRights(uint id, string username);
    }
}
