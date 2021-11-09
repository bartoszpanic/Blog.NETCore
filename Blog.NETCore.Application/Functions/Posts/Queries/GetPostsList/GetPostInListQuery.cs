using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Posts.Queries.GetPostsList
{
    public class GetPostInListQuery : IRequest<List<PostInListViewModel>>
    {
    }
}
