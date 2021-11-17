using Blog.NETCore.Application.Response;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Posts.Queries.GetPostsList
{
    public class GetPostInListQueryResponse : BaseResponse
    {
        public List<PostInListViewModel> List { get; }

        public GetPostInListQueryResponse(List<PostInListViewModel> list) : base()
        {
            List = list;
        }

        public GetPostInListQueryResponse() : base()
        {
        }

        public GetPostInListQueryResponse(ValidationResult validationResult) : base(validationResult)
        {
        }

        public GetPostInListQueryResponse(string message) : base(message)
        {
        }

        public GetPostInListQueryResponse(string message, bool success) : base(message, success)
        {
        }
    }
}
