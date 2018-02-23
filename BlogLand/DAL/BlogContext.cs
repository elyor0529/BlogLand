using BlogLand.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogLand.DAL
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("BlogContext")
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
           .HasMany(c => c.Tags).WithMany(i => i.Posts)
           .Map(t => t.MapLeftKey("PostID")
           .MapRightKey("TagID")
           .ToTable("PostTag"));
        }
    }
}