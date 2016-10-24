using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GlobanetTest.FacebookApi.Model
{
    public abstract class FacebookModelBase
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}
