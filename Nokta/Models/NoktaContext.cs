using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Nokta.Models
{
    public class NoktaContext: DbContext
    {
        public DbSet<Nokat> Nokats { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comments> Commentses { get; set; }
        public DbSet<Votes> Voteses { get; set; }

       
    }


}