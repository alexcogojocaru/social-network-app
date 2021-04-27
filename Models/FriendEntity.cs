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