using Blog.NETCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Persistence.EF.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.Author)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(c => c.Content)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.PostId)
                .IsRequired();
        }
    }
}
