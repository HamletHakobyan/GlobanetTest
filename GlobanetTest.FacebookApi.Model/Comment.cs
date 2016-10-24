using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GlobanetTest.FacebookApi.Model
{
    public class Comment : FacebookModelBase
    {
        [JsonProperty(PropertyName = "created_time")]
        public string CreatedTime { get; set; }

        [JsonProperty(PropertyName = "like_count")]
        public int? LikeCount { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "parent")]
        public Comment Parent { get; set; }
    }
}
