    using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Domain.Entities
{
    public class Comment : AuditableEntity
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
