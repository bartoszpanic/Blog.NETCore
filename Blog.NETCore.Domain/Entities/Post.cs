﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Domain.Entities
{
    public class Post : AuditableEntity
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
