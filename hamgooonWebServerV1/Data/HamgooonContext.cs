using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hamgooonWebServerV1.Models;

namespace hamgooonWebServerV1.Data
{
    
        public class HamgooonContext : DbContext
        {
            public HamgooonContext(DbContextOptions<HamgooonContext> options)
            : base(options)
        {
        }

            public DbSet<User> User { get; set; }
            public DbSet<Post> Post { get; set; }
            public DbSet<hamgooonWebServerV1.Models.Relation> Relation { get; set; }
            public DbSet<hamgooonWebServerV1.Models.Image> Image { get; set; }
            public DbSet<hamgooonWebServerV1.Models.Comment> Comment { get; set; }

        }
    }
