using Blog.NETCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.NETCore.Application.Interfaces
{
    public interface ICommentRepository : IAsyncRepository<Comment>
    {
        Task<List<Comment>> GetAllCommentsFromPost(int postId);
    }
}
