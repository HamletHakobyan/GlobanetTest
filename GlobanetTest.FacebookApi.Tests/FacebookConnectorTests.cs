using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Collections;
using FluentAssertions.Equivalency;
using Xunit;

namespace GlobanetTest.FacebookApi.Tests
{
    public class FacebookConnectorTests
    {
        private string clientId = "1649782095313979";
        private string clientSecret = "b07f23c5fdcb125df2657084b37d28df";
        private string pageId = "695941003897570";
        private string postId = "695941003897570_695943363897334";

        private readonly FacebookConnector _connector;

        
        public FacebookConnectorTests()
        {
            _connector = new FacebookConnector(clientId, clientSecret);
        }

        [Fact]
        public async Task ShouldReturnPostsOfPageByGivenPageId()
        {
            var pageList = await _connector.GetPostsByPageIdAsync(pageId);
            var postData = ObjectMother.GetPostData();

            pageList.Data.ShouldBeEquivalentTo(postData);
        }

        [Fact]
        public async Task ShouldReturnCommentsOfPostByGivenPostId()
        {
            var commentList = await _connector.GetCommentsByPostIdAsync(postId);
            var commentData = ObjectMother.GetCommentData();

            commentList.Data.ShouldBeEquivalentTo(commentData);
        }
    }
}