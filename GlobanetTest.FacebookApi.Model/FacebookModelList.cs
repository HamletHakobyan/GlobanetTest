using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GlobanetTest.FacebookApi.Model
{
    public class FacebookModelList<T> where T: FacebookModelBase
    {
        [JsonProperty(PropertyName = "data")]
        public List<T> Data { get; set; }
    }
}
