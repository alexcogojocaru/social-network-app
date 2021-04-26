using Interfaces;
using Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Services
{
    public class CommentService : IComment
    {
        private static Dictionary<uint, CommentEntity> _comments = new Dictionary<uint, CommentEntity>();
        
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
    }
}
