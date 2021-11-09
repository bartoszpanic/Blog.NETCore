using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.NETCore.Application.Functions.Posts.Queries.GetPostsList
{
    public class GetPostsListQueryHandler : IRequestHandler<GetPostInListQuery, List<PostInListViewModel>>
    {
        public Task<List<PostInListViewModel>> Handle(GetPostInListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
