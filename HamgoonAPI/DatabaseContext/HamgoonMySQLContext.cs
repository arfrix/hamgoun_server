using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HamgoonAPI.Models;

namespace HamgoonAPI.DataContext
{
    
        public class HamgooonMySQLContext : DbContext
        {
            public HamgooonMySQLContext(DbContextOptions<HamgooonMySQLContext> options)
            : base(options)
        {
        }
            public DbSet<User> User { get; set; }
            public DbSet<Post> Post { get; set; }
            public DbSet<Relation> Relation { get; set; }
            public DbSet<Image> Image { get; set; }
            public DbSet<Comment> Comment { get; set; }
            public DbSet<Event> Event { get; set; }

        }
    }
