using Blog.NETCore.Application.Response;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Posts.Queries.GetPostDetailWithComments
{
    public class GetPostDetailQueryResponse : BaseResponse
    {
        public PostDetailWithCommentListViewModel Post { get; set; }
        public GetPostDetailQueryResponse(PostDetailWithCommentListViewModel post) : base()
        {
            Post = post;
        }

        public GetPostDetailQueryResponse() : base()
        {
        }

        public GetPostDetailQueryResponse(ValidationResult validationResult) : base(validationResult)
        {
        }

        public GetPostDetailQueryResponse(string message) : base(message)
        {
        }

        public GetPostDetailQueryResponse(string message, bool success) : base(message, success)
        {
        }
    }
}
