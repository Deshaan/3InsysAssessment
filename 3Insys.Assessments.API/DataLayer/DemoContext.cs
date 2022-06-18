using Microsoft.EntityFrameworkCore;
using _3Insys.Assessments.API.Data.Entities;

namespace _3Insys.Assessments.API.Data
{
    public class DemoContext : DbContext
    {
        public DbSet<TShirt> TShirts { get; set; }

        public DemoContext(DbContextOptions options) : base(options)
        {
        }
    }
}
