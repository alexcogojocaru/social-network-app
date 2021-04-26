using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Services;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class CommentServiceUnitTest
    {
        private CommentService commentService = new CommentService();
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

        [TestMethod]
        public void CreateANewComment()
        {
            // Arrange
            bool result;

            // Act
            result = commentService.CreateComment(commentPool[0]);

            // Assert
            Assert.IsTrue(result);
        }

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
        }

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
        }

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
        }

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
        }

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
        }

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
        }

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
        }
    }
}
