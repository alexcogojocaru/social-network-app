using Models;
using System.Collections.Generic;

namespace Interfaces
{

    public interface IFriend
    {

        FriendEntity GetFriend(string friendUsername);

        List<FriendEntity> GetFriends();

        bool CreateFriend(FriendEntity firend);

        bool UpdateFriend(string username, FriendEntity firend);

        bool DeleteFriend(string friendUsername);

    }
}