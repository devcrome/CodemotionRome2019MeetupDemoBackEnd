
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BackEnd
{
    public class BlogPost
    {
        [Key]
        public int BlogId{get;set;}
        public string Title {get;set;}

        public string Content {get;set;}

        public DateTime date {get;set;}

    }

     public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        { }

        public DbSet<BlogPost> BlogPosts { get; set; }
    }

}