using AutoMapper;
using Blog.NETCore.Application.Interfaces;
using Blog.NETCore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.NETCore.Application.Functions.Comments.Commands
{
    public class CreatedCommentCommandHandler : IRequestHandler<CreatedCommentCommand, int>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CreatedCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatedCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = _mapper.Map<Comment>(request);
            comment = await _commentRepository.AddAsync(comment);

            return comment.CommentId;
        }
    }
}
