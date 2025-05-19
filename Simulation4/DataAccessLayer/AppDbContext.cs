
using Microsoft.EntityFrameworkCore;
using Simulation4.Models;

namespace Simulation4.DataAccessLayer
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
