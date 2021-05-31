/**************************************************************************
 *                                                                        *
 *  File:        PostService.cs                                           *
 *  Copyright:   (c) 2021, Barbu Bogdan-Cosmin                            *
 *  E-mail:      barbubogdan1337@gmail.com                                *
 *  Description: The service that manages the posts operations flow.      *
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
    public class PostService : IPost, IGenericService
    {
        private static Dictionary<uint, PostEntity> _posts = new Dictionary<uint, PostEntity>();
<<<<<<< HEAD

=======
        private static uint index = 1;
>>>>>>> 49ef69843662febb419015cdb55ddad669af2b4e

        /// <summary>
        /// Constructor for the class, to inherit the database connector
        /// </summary>
        public PostService() : base()
        {

        }

        /// <summary>
        /// Creates a new post
        /// </summary>
        /// <param name="post">the post entity that holds the data</param>
        /// <returns>
        /// true - if the post was created<para/>
        /// false - if the post wasn't created<para/>
        /// The post can't be created if the user that requested the action doesn't exist
        /// </returns>
        public bool CreatePost(PostEntity post)
        {
<<<<<<< HEAD
            if (!Exists(post.Id))
            {
                post.Date = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
                _posts.Add(post.Id, post);
                return true;
            }

            return false;
=======
            post.Id = index++;
            post.Date = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            _posts.Add(post.Id, post);

            return true;
            //if (!Exists(post.Id))
            //{
            //    post.Date = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            //    _posts.Add(post.Id, post);
            //    return true;
            //}

            //return false;
>>>>>>> 49ef69843662febb419015cdb55ddad669af2b4e
        }

        /// <summary>
        /// Deletes a post if the user has rights
        /// </summary>
        /// <param name="id">the id of the post</param>
        /// <param name="username"></param>
        /// <returns>true if the post was deleted, false otherwise</returns>
        public bool DeletePost(uint id, string username)
        {
            if (HasRights(id, username))
            {
                _posts.Remove(id);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Changes the content of a post and the timestamp only if the 
        /// specified user has edit rights
        /// </summary>
        /// <param name="id">the id of the post</param>
        /// <param name="username"></param>
        /// <param name="content">the new content of the post</param>
        /// <returns>true if the post was changed, false otherwise</returns>
        public bool EditPost(uint id, string username, string content)
        {
            if (HasRights(id, username))
            {
                _posts[id].Content = content;
                _posts[id].Date = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if a post exists
        /// </summary>
        /// <param name="id">the id of the post</param>
        /// <returns>true if it exists, false otherwise</returns>
        public bool Exists(uint id)
        {
            return _posts.ContainsKey(id);
        }

        /// <summary>
        /// Gets a specific post with the id provided
        /// </summary>
        /// <param name="id">the id of the requested post</param>
        /// <returns>the post or null if it doesn't exist</returns>
        public PostEntity GetPost(uint id)
        {
            return Exists(id) ? _posts[id] : null;
        }

        /// <summary>
        /// Returns all the posts
        /// </summary>
        /// <returns>a list with PostEntity objects</returns>
        public List<PostEntity> GetPosts()
        {
            return _posts.Values.ToList();
        }

        /// <summary>
        /// Checks if an user has rights for a post
        /// </summary>
        /// <param name="id">the id of the post</param>
        /// <param name="username"></param>
        /// <returns>true if the user has rights, false otherwise</returns>
        public bool HasRights(uint id, string username)
        {
            return Exists(id) && _posts[id].Username.Equals(username);
        }

        /// <summary>
        /// Deletes all data that a service holds
        /// </summary>
        public void PurgeData()
        {
            _posts.Clear();
        }
    }
}