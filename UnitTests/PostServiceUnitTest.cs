/**************************************************************************
 *                                                                        *
 *  File:        PostServiceUnitTest.cs                                   *
 *  Copyright:   (c) 2021, Barbu Bogdan-Cosmin                            *
 *  E-mail:      barbubogdan1337@gmail.com                                *
 *  Description: Class that holds the test methods for the post           *
 *               service.                                                 *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Services;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class PostServiceUnitTest
    {
<<<<<<< HEAD
        /// <summary>
        /// Instance of a PostService class used for testing
        /// </summary>
        private PostService postService = new PostService();

        /// <summary>
        /// Temporary post pool with premade instances
        /// </summary>
        private List<PostEntity> postPool = new List<PostEntity>()
        {
            new PostEntity()
            {
                Id = 1,
                Username = "WE TESTING",
                Content = "THIS IS MY POST BERBERITA"
            },
            new PostEntity()
            {
                Id = 2,
                Username = "TESTING NR 2 LETS GOO",
                Content = "Turn into a convertible"
            }
        };

        /// <summary>
        /// Tests if initially the list size is zero, as it should be
        /// </summary>
        [TestMethod]
        public void PostListShouldBeZero()
        {
            // Arrange
            int postsLength;
            int expectedLength = 0;

            // Act
            postsLength = postService.GetPosts().Count;

            // Assert
            Assert.AreEqual(postsLength, expectedLength);
        }

        /// <summary>
        /// Tests if the key with id 1 exists inside the service, without adding an entity
        /// </summary>
        [TestMethod]
        public void DoesTheKeyExist()
        {
            // Arrange
            uint id = 1;
            bool result;

            // Act
            result = postService.Exists(id);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Checks the ability to create a new post, with an empty dataset
        /// </summary>
        [TestMethod]
        public void CreateANewPost()
        {
            // Arrange
            bool result;

            // Act
            result = postService.CreatePost(postPool[0]);

            // Assert
            Assert.IsTrue(result);

            postService.PurgeData();
        }

        /// <summary>
        /// There cannot be 2 posts with the same id inside the dictionary
        /// </summary>
        [TestMethod]
        public void CannotCreatePostsWithTheSameId()
        {
            // Arrange
            bool result;

            // Act
            postService.CreatePost(postPool[0]);
            result = postService.CreatePost(postPool[0]);

            // Assert
            Assert.IsFalse(result);

            postService.PurgeData();
        }

        /// <summary>
        /// Checks if the user has rights for a post
        /// </summary>
        [TestMethod]
        public void DoesTheUserHaveRightsForThePostPositive()
        {
            // Arrange
            uint id = 1;
            string username = "test";
            bool result;

            PostEntity post = new PostEntity()
            {
                Id = id,
                Username = username
            };


            // Act
            postService.CreatePost(post);
            result = postService.HasRights(id, username);

            // Assert
            Assert.IsTrue(result);

            postService.PurgeData();
        }

        /// <summary>
        /// Tries to fetch a non-existing post
        /// </summary>
        [TestMethod]
        public void CannotCreatePostsWithTheSameId()
        {
            // Arrange
            bool result;

            // Act
            postService.CreatePost(postPool[0]);
            result = postService.CreatePost(postPool[0]);

            // Assert
            Assert.IsFalse(result);

            postService.PurgeData();
        }

        /// <summary>
        /// Checks if the user has rights for a post
        /// </summary>
        [TestMethod]
        public void DoesTheUserHaveRightsForThePostPositive()
        {
            // Arrange
            uint id = 1;
            string username = "test";
            bool result;

            PostEntity post = new PostEntity()
            {
                Id = id,
                Username = username
            };


            // Act
            postService.CreatePost(post);
            result = postService.HasRights(id, username);

            // Assert
            Assert.IsTrue(result);

            postService.PurgeData();
        }

        /// <summary>
        /// Tries to fetch a non-existing post
        /// </summary>
        [TestMethod]
        public void GetAPostWithIdNull()
        {
            // Arrange
            uint id = 2;
            PostEntity result;

            // Act
            result = postService.GetPost(id);

            // Assert
            Assert.IsNull(result);
        }

        /// <summary>
        /// Fetch a post that already exists in the service
        /// </summary>
        [TestMethod]
        public void GetAPostWithIdPositive()
        {
            // Arrange
            const int index = 0;
            string expectedString = postPool[index].Content;
            PostEntity result;

            // Act
            postService.CreatePost(postPool[index]);
            result = postService.GetPost(postPool[index].Id);

            // Assert
            Assert.AreEqual(result.Content, expectedString);

            postService.PurgeData();
        }

        /// <summary>
        /// Trying to delete a post that a user doesn't have rights to
        /// </summary>
        [TestMethod]
        public void DeletePostWithNoRights()
        {
            // Arrange
            const int index = 1;
            string username = "testing";
            bool result;

            // Act
            postService.CreatePost(postPool[index]);
            result = postService.DeletePost(postPool[index].Id, username);

            // Assert
            Assert.IsFalse(result);

            postService.PurgeData();
        }

        /// <summary>
        /// Trying to delete a post that a user does have rights to
        /// </summary>
        [TestMethod]
        public void DeletePostWithRights()
        {
            // Arrange
            const int index = 1;
            string username = postPool[index].Username;
            bool result;

            // Act
            postService.CreatePost(postPool[index]);
            result = postService.DeletePost(postPool[index].Id, username);

            // Assert
            Assert.IsTrue(result);

            postService.PurgeData();
        }

        /// <summary>
        /// Trying to edit a post that a user doesn't have rights to
        /// </summary>
        [TestMethod]
        public void EditPostWithNoRights()
        {
            // Arrange
            const int index = 1;
            string username = "no user";
            string content = "nothing";
            bool result;

            // Act
            postService.CreatePost(postPool[index]);
            result = postService.EditPost(postPool[index].Id, username, content);

            // Assert
            Assert.IsFalse(result);

            postService.PurgeData();
        }

        /// <summary>
        /// Trying to delete a post that a user does have rights to
        /// </summary>
        [TestMethod]
        public void EditPostWitRights()
        {
            // Arrange
            const int index = 1;
            string username = postPool[index].Username;
            string content = "nothing";
            bool result;

            // Act
            postService.CreatePost(postPool[index]);
            result = postService.EditPost(postPool[index].Id, username, content);

            // Assert
            Assert.IsTrue(result);

            postService.PurgeData();
        }
    }
}