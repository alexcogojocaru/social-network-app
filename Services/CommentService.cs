/**************************************************************************
 *                                                                        *
 *  File:        CommentService.cs                                        *
 *  Copyright:   (c) 2021, Cojocaru Daniel-Alexandru                      *
 *  E-mail:      alex.cojocaru73@gmail.com                                *
 *  Description: The service that manages the comments operations flow.   *
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
using System;

namespace Services
{
    public class CommentService : IComment, IGenericService
    {
        private static Dictionary<uint, CommentEntity> _comments = new Dictionary<uint, CommentEntity>();

        /// <summary>
        /// Creates a new comment
        /// </summary>
        /// <param name="comment">the comment entity that holds the data</param>
        /// <returns>
        /// true - if the comment was created<para/>
        /// false - if the comment wasn't created<para/>
        /// The comment can't be created if the user that requested the action doesn't exist
        /// </returns>
        public bool CreateComment(CommentEntity comment)
        {
            if (!Exists(comment.Id))
            {
                comment.Date = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
                _comments.Add(comment.Id, comment);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Deletes a comment if the user has rights
        /// </summary>
        /// <param name="id">the id of the comment</param>
        /// <param name="username"></param>
        /// <returns>true if the comment was deleted, false otherwise</returns>
        public bool DeleteComment(uint id, string username)
        {
            if (HasRights(id, username))
            {
                _comments.Remove(id);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Changes the content of a comment and the timestamp only if the 
        /// specified user has edit rights
        /// </summary>
        /// <param name="id">the id of the comment</param>
        /// <param name="username"></param>
        /// <param name="content">the new content of the comment</param>
        /// <returns>true if the comment was changed, false otherwise</returns>
        public bool EditComment(uint id, string username, string content)
        {
            if (HasRights(id, username))
            {
                _comments[id].Content = content;
                _comments[id].Date = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if a comment exists
        /// </summary>
        /// <param name="id">the id of the comment</param>
        /// <returns>true if it exists, false otherwise</returns>
        public bool Exists(uint id)
        {
            return _comments.ContainsKey(id);
        }

        /// <summary>
        /// Gets a specific comment with the id provided
        /// </summary>
        /// <param name="id">the id of the requested comment</param>
        /// <returns>the comment or null if it doesn't exist</returns>
        public CommentEntity GetComment(uint id)
        {
            return Exists(id) ? _comments[id] : null;
        }

        /// <summary>
        /// Returns all the comments
        /// </summary>
        /// <returns>a list with CommentEntity objects</returns>
        public List<CommentEntity> GetComments()
        {
            return _comments.Values.ToList();
        }

        /// <summary>
        /// Checks if an user has rights for a comment
        /// </summary>
        /// <param name="id">the id of the comment</param>
        /// <param name="username"></param>
        /// <returns>true if the user has rights, false otherwise</returns>
        public bool HasRights(uint id, string username)
        {
            return Exists(id) && _comments[id].Username.Equals(username);
        }

        /// <summary>
        /// Deletes all data that a service holds
        /// </summary>
        public void PurgeData()
        {
            _comments.Clear();
        }
    }
}
