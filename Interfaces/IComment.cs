/**************************************************************************
 *                                                                        *
 *  File:        IComment.cs                                         *
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
        bool CreateComment(CommentEntity comment);

        List<CommentEntity> GetComments();

        CommentEntity GetComment(uint id);

        bool EditComment(uint id, string username, string content);

        bool DeleteComment(uint id, string username);

        bool Exists(uint id);

        bool HasRights(uint id, string username);
    }
}
