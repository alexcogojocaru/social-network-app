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
        private Dictionary<uint, CommentEntity> _comments = new Dictionary<uint, CommentEntity>();
        
        public bool CreateComment(CommentEntity comment)
        {
            if (!Exists(comment.Id))
            {
                comment.Date = new DateTime();
                _comments.Add(comment.Id, comment);
                return true;
            }

            return false;
        }

        public bool DeleteComment(uint id, string username)
        {
            if (HasRights(id, username))
            {
                _comments.Remove(id);
                return true;
            }

            return false;
        }

        public bool EditComment(uint id, string username, string content)
        {
            if (HasRights(id, username))
            {
                _comments[id].Content = content;
                _comments[id].Date = new DateTime();
                return true;
            }

            return false;
        }

        public bool Exists(uint id)
        {
            return _comments.ContainsKey(id);
        }

        public CommentEntity GetComment(uint id)
        {
            return Exists(id) ? _comments[id] : null;
        }

        public List<CommentEntity> GetComments()
        {
            return _comments.Values.ToList();
        }

        public bool HasRights(uint id, string username)
        {
            return Exists(id) && _comments[id].Username.Equals(username);
        }

        public void PurgeData()
        {
            _comments.Clear();
        }
    }
}
