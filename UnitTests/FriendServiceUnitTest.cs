/**************************************************************************
 *                                                                        *
 *  File:        FriendServiceUnitTest.cs                                 *
 *  Copyright:   (c) 2021, Negru Parascheva                               *
 *  E-mail:      parascheva.negru@gmail.com                               *
 *  Description: Class that holds the test methods for the friend         *
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
using Services;

namespace UnitTests
{
    [TestClass]
    public class FriendServiceUnitTest
    {
        private FriendService friendService = new FriendService();

        /// <summary>
        /// Tests if initially the list size is zero, as it should be
        /// </summary>
        [TestMethod]
        public void FriendsListSizeShouldBeZero()
        {
            // Arrange
            int friendsListSize;
            int expectedSize = 0;

            // Act
            friendsListSize = friendService.GetFriends().Count;

            // Assert
            Assert.AreEqual(expectedSize, friendsListSize);
        }
    }
}