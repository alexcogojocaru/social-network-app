/**************************************************************************
 *                                                                        *
 *  File:        FriendEntity.cs                                          *
 *  Copyright:   (c) 2021, Negru Parascheva                               *
 *  E-mail:      parascheva.negru@gmail.com                               *
 *  Description: The description of a friend entity sent inside a request *
 *               body.                                                    *
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
    public class FriendEntity
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("friendUsername")]
        public string FriendUsername { get; set; }

        [JsonProperty("friendshipDate")]
        public string FriendshipDate { get; set; }
    }
}