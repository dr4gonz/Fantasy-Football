using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Fantasy_Football.Models;

namespace Fantasy_Football.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Team> Team { get; set; }

        public DbSet<Player> Player { get; set; }
        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<NflGame> NflGames { get; set; }
        public DbSet<NflNews> NflNews { get; set; }
        public DbSet<PlayersTeams> PlayersTeams { get; set; }
    }
}
