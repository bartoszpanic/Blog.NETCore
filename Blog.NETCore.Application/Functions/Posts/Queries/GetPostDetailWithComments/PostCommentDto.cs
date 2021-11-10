using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Posts.Queries.GetPostDetailWithComments
{
    public class PostCommentDto
    {
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
    }
}
