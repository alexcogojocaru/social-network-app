/**************************************************************************
 *                                                                        *
 *  File:        CommentEntity.cs                                         *
 *  Copyright:   (c) 2021, Cojocaru Daniel-Alexandru                      *
 *  E-mail:      alex.cojocaru73@gmail.com                                *
 *  Description: The description of a comment entity sent inside a request* 
 *               body.                                                    *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using Newtonsoft.Json;

namespace Models
{
    public class CommentEntity
    {
        [JsonProperty("id")]
        public uint Id { get; set; }

        [JsonProperty("postID")]
        public int PostId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; } 
    }
}
