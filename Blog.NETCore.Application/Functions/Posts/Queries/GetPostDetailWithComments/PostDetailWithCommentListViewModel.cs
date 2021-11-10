using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Posts.Queries.GetPostDetailWithComments
{
    public class PostDetailWithCommentListViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public List<PostCommentDto> Comments { get; set; }
    }
}
