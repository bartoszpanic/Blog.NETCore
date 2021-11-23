using Blog.NETCore.Application.Interfaces;
using Blog.NETCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.NETCore.Persistence.EF.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogNETCoreContext context) : base(context)
        {
        }
        public async Task<List<Comment>> GetAllCommentsFromPost(int postId)
        {
            var allComments = await _context.Comments.Include(p => p.Post).ToListAsync();
            allComments = allComments.Where(p => p.PostId == postId).ToList();

            return allComments;
        }
    }
}
