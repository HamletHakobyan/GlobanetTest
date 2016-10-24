using System;
using System.Collections.Generic;
using GlobanetTest.FacebookApi.Model;

namespace GlobanetTest.FacebookApi.Tests
{
    static class ObjectMother
    {
        public static IEnumerable<Post> GetPostData()
        {
            yield return new Post
            {
                Id = "695941003897570_695943363897334",
                Message = "Some post",
                CreatedTime = DateTime.Parse("10/23/2016 7:28:52 PM")
            };
            yield return new Post
            {
                Id = "695941003897570_695942660564071",
                CreatedTime = DateTime.Parse("10/23/2016 7:27:31 PM")
            };
        }

        public static IEnumerable<Comment> GetCommentData()
        {

            yield return new Comment
            {
                Id = "695943363897334_695944823897188",
                Message = "Comment 1 for Some post",
                CreatedTime = DateTime.Parse("2016-10-23T15:29:24+0000"),
                LikeCount = 1
            };

            yield return new Comment
            {
                Id = "695943363897334_695945517230452",
                Message = "Comment 2 for Some post",
                CreatedTime = DateTime.Parse("2016-10-23T15:29:36+0000"),
                LikeCount = 0
            };

            yield return new Comment
            {
                Id = "695943363897334_695946200563717",
                Message = "Comment 3 for Some post",
                CreatedTime = DateTime.Parse("2016-10-23T15:29:52+0000"),
                LikeCount = 0
            };
        }
    }
}