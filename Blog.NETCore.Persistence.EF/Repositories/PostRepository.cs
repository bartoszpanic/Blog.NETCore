using Blog.NETCore.Application.Interfaces;
using Blog.NETCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Persistence.EF.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(BlogNETCoreContext context) : base(context)
        {
        }
    }
}
