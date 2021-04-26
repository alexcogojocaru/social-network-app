using Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IComment
    {
        bool CreateComment(CommentEntity comment);

        List<CommentEntity> GetComments();

        CommentEntity GetComment(uint id);

        bool EditComment(uint id, string username, string content);

        bool DeleteComment(uint id, string username);

        bool Exists(uint id);

        bool HasRights(uint id, string username);
    }
}
