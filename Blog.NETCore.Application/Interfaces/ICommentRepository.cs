using Blog.NETCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Interfaces
{
    public interface ICommentRepository : IAsyncRepository<Comment>
    {
    }
}
