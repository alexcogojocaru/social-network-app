using Interfaces;
using Models;
using System.Collections.Generic;
using System.Linq;
namespace Services
{

    public class FriendService : IFriend
    {
        private Dictionary<string, FriendEntity> _friends = new Dictionary<string, FriendEntity>();

        #region Public Methods

        public FriendEntity GetFriend(string friendUsername)
        {
            if (_friends.ContainsKey(friendUsername))
            {
                return _friends[friendUsername];
            }
            return null;
        }

        public List<FriendEntity> GetFriends()
        {
            return _friends.Values.ToList();
        }

        public bool CreateFriend(FriendEntity friend)
        {
            if (!_friends.ContainsKey(friend.Username))
            {
                _friends.Add(friend.Username, friend);
                return true;
            }

            return false;
        }

        public bool UpdateFriend(string username, FriendEntity friend)
        {
            if (_friends.ContainsKey(username))
            {
                _friends[username] = friend;
                return true;
            }

            return false;
        }

        public bool DeleteFriend(string friendUsername)
        {
            if (_friends.ContainsKey(friendUsername))
            {
                _friends.Remove(friendUsername);
                return true;
            }

            return false;
        }

        #endregion
    }
}