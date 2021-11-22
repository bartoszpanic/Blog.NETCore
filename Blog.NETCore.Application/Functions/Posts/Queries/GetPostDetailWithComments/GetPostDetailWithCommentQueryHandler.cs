using AutoMapper;
using Blog.NETCore.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.NETCore.Application.Functions.Posts.Queries.GetPostDetailWithComments
{
    public class GetPostDetailWithCommentQueryHandler : IRequestHandler<GetPostDetailWithCommentsQuery, GetPostDetailQueryResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public GetPostDetailWithCommentQueryHandler(IPostRepository postRepository, ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<GetPostDetailQueryResponse> Handle(GetPostDetailWithCommentsQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.PostId);
            var postDetail = _mapper.Map<PostDetailWithCommentListViewModel>(post);

            var comments = await _commentRepository.GetAllCommentsFromPost(postDetail.PostId);

            postDetail.Comments = _mapper.Map<List<PostCommentDto>>(comments);

            return new GetPostDetailQueryResponse(postDetail);
        }
    }
}
