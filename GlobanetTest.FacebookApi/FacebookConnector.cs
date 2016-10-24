using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Facebook;
using GlobanetTest.FacebookApi.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GlobanetTest.FacebookApi
{
    /// <summary>
    /// Represents the access point to the Facebook infractructue
    /// </summary>
    public class FacebookConnector
    {
        private const string GrantType = "client_credentials";
        private const string OauthEndpoint = "oauth/access_token";

        private FacebookClient _client;
        private readonly Task _initialization;

        /// <summary>
        /// Initializes a new instance of the <see cref="FacebookConnector"/> class.
        /// </summary>
        /// <param name="appId">Facebook app Id.</param>
        /// <param name="appSecret">Facebook app secret.</param>
        public FacebookConnector(string appId, string appSecret)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            _initialization = InitAsync(appId, appSecret);
        }

        /// <summary>
        /// Get Facebook post's comments by given post Id.
        /// </summary>
        /// <param name="postId">Given post Id.</param>
        /// <returns>Returns the Task which will resolves to Comments list.</returns>
        public async Task<FacebookModelList<Comment>> GetCommentsByPostIdAsync(string postId)
        {
            await _initialization;

            return await _client.GetTaskAsync<FacebookModelList<Comment>>(
                $"{postId}/comments", new { filter = "stream", fields = new[] { "message", "created_time", "like_count", "parent{id}" } }
            );
        }

        /// <summary>
        /// Get Facebook page's posts by given page Id.
        /// </summary>
        /// <param name="pageId">Given page Id</param>
        /// <returns>Returns the Task which will resolves to Posts list.</returns>
        public async Task<FacebookModelList<Post>> GetPostsByPageIdAsync(string pageId)
        {
            await _initialization;

            return await _client.GetTaskAsync<FacebookModelList<Post>>(
                $"{pageId}/posts", new { fields = new[] { "message", "created_time" } }
            );
        }

        protected virtual FacebookClient InitFacebookClient()
        {
            var client = new FacebookClient();
            client.SetJsonSerializers(JsonConvert.SerializeObject, JsonConvert.DeserializeObject);
            return client;
        }

        private async Task InitAsync(string appId, string appSecret)
        {
            _client = InitFacebookClient();
            var token = await _client.GetTaskAsync<Token>(
                OauthEndpoint,
                new
                {
                    grant_type = GrantType,
                    client_id = appId,
                    client_secret = appSecret
                }
            );

            _client.AccessToken = token.AccessToken;
        }
    }
}
