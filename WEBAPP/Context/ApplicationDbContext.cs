using Microsoft.EntityFrameworkCore;
using System.Collections;
using WEBAPP.Models;

namespace WEBAPP.Context
{
    public class ApplicationDbContext : DbContext
    {
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Theater> theaters { get; set; }

        public DbSet<Movie> movies { get; set; }

        public DbSet<Showtime> showtimes { get; set; }

        public DbSet<Genre> genres { get; set; }
    }
}
