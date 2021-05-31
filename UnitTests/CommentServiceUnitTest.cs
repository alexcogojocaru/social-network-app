/**************************************************************************
 *                                                                        *
 *  File:        CommentServiceUnitTest.cs                                *
 *  Copyright:   (c) 2021, Cojocaru Daniel-Alexandru                      *
 *  E-mail:      alex.cojocaru73@gmail.com                                *
 *  Description: Class that holds the test methods for the comment        *
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
    public class CommentServiceUnitTest
    {
        /// <summary>
        /// Instance of a CommentService class used for testing
        /// </summary>
        private CommentService commentService = new CommentService();

        /// <summary>
        /// Temporary comment pool with premade instances
        /// </summary>
        private List<CommentEntity> commentPool = new List<CommentEntity>()
        {
            new CommentEntity()
            {
                Id = 1,
                PostId = 1,
                Username = "example",
                Content = "this is a sample text"
            },
            new CommentEntity()
            {
                Id = 2,
                PostId = 1,
                Username = "subject",
                Content = "sample description"
            }
        };

        /// <summary>
        /// Tests if initially the list size is zero, as it should be
        /// </summary>
        [TestMethod]
        public void CommentListShouldBeZero()
        {
            // Arrange
            int commentsLength;
            int expectedLength = 0;

            // Act
            commentsLength = commentService.GetComments().Count;

            // Assert
            Assert.AreEqual(commentsLength, expectedLength);
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
            result = commentService.Exists(id);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Checks the ability to create a new comment, with an empty dataset
        /// </summary>
        [TestMethod]
        public void CreateANewComment()
        {
            // Arrange
            bool result;

            // Act
            result = commentService.CreateComment(commentPool[0]);

            // Assert
            Assert.IsTrue(result);

            commentService.PurgeData();
        }

        /// <summary>
        /// There cannot be 2 comments with the same id inside the dictionary
        /// </summary>
        [TestMethod]
        public void CannotCreateCommentsWithTheSameId()
        {
            // Arrange
            bool result;

            // Act
            commentService.CreateComment(commentPool[0]);
            result = commentService.CreateComment(commentPool[0]);

            // Assert
            Assert.IsFalse(result);

            commentService.PurgeData();
        }

        /// <summary>
        /// Checks if the user has rights for a comment
        /// </summary>
        [TestMethod]
        public void DoesTheUserHaveRightsForTheCommentPositive()
        {
            // Arrange
            uint id = 1;
            string username = "test";
            bool result;

            CommentEntity comment = new CommentEntity()
            {
                Id = id,
                Username = username
            };
            

            // Act
            commentService.CreateComment(comment);
            result = commentService.HasRights(id, username);

            // Assert
            Assert.IsTrue(result);

            commentService.PurgeData();
        }

        /// <summary>
        /// Tries to fetch a non-existing comment
        /// </summary>
        [TestMethod]
        public void GetACommentWithIdNull()
        {
            // Arrange
            uint id = 2;
            CommentEntity result;

            // Act
            result = commentService.GetComment(id);

            // Assert
            Assert.IsNull(result);
        }

        /// <summary>
        /// Fetch a comment that already exists in the service
        /// </summary>
        [TestMethod]
        public void GetACommentWithIdPositive()
        {
            // Arrange
            const int index = 0;
            string expectedString = commentPool[index].Content;
            CommentEntity result;

            // Act
            commentService.CreateComment(commentPool[index]);
            result = commentService.GetComment(commentPool[index].Id);

            // Assert
            Assert.AreEqual(result.Content, expectedString);

            commentService.PurgeData();
        }

        /// <summary>
        /// Trying to delete a comment that a user doesn't have rights to
        /// </summary>
        [TestMethod]
        public void DeleteCommentWithNoRights()
        {
            // Arrange
            const int index = 1;
            string username = "testing";
            bool result;

            // Act
            commentService.CreateComment(commentPool[index]);
            result = commentService.DeleteComment(commentPool[index].Id, username);

            // Assert
            Assert.IsFalse(result);

            commentService.PurgeData();
        }

        /// <summary>
        /// Trying to delete a comment that a user does have rights to
        /// </summary>
        [TestMethod]
        public void DeleteCommentWithRights()
        {
            // Arrange
            const int index = 1;
            string username = commentPool[index].Username;
            bool result;

            // Act
            commentService.CreateComment(commentPool[index]);
            result = commentService.DeleteComment(commentPool[index].Id, username);

            // Assert
            Assert.IsTrue(result);

            commentService.PurgeData();
        }

        /// <summary>
        /// Trying to edit a comment that a user doesn't have rights to
        /// </summary>
        [TestMethod]
        public void EditCommentWithNoRights()
        {
            // Arrange
            const int index = 1;
            string username = "no user";
            string content = "nothing";
            bool result;

            // Act
            commentService.CreateComment(commentPool[index]);
            result = commentService.EditComment(commentPool[index].Id, username, content);

            // Assert
            Assert.IsFalse(result);

            commentService.PurgeData();
        }

        /// <summary>
        /// Trying to delete a comment that a user does have rights to
        /// </summary>
        [TestMethod]
        public void EditCommentWitRights()
        {
            // Arrange
            const int index = 1;
            string username = commentPool[index].Username;
            string content = "nothing";
            bool result;

            // Act
            commentService.CreateComment(commentPool[index]);
            result = commentService.EditComment(commentPool[index].Id, username, content);

            // Assert
            Assert.IsTrue(result);

            commentService.PurgeData();
        }
    }
}
