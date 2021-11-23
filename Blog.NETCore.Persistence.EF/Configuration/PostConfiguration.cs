using Blog.NETCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Persistence.EF.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(p => p.Content)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
