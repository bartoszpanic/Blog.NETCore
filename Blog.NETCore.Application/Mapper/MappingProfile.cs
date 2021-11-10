using AutoMapper;
using Blog.NETCore.Application.Functions.Posts.Commands.CreatePost;
using Blog.NETCore.Application.Functions.Posts.Commands.UpdatePost;
using Blog.NETCore.Application.Functions.Posts.Queries.GetPostDetailWithComments;
using Blog.NETCore.Application.Functions.Posts.Queries.GetPostsList;
using Blog.NETCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostInListViewModel>().ReverseMap();
            CreateMap<Post, PostDetailWithCommentListViewModel>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Comment, PostCommentDto>().ReverseMap();
            CreateMap<PostCommentDto, Post>().ReverseMap();
            CreateMap<Post, CreatedPostCommand>().ReverseMap();
            CreateMap<Post, UpdatePostCommand>().ReverseMap();
        }
    }
}
