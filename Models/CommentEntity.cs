using Newtonsoft.Json;
using System;

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
        public DateTime Date { get; set; } 
    }
}
