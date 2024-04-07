using Microsoft.EntityFrameworkCore;

namespace FluentValidationSample.Models.ORM
{
    public class AkademiIstanbulContext : DbContext
    {
   
        public AkademiIstanbulContext(DbContextOptions<AkademiIstanbulContext> options) :base(options)
        { 
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; }
    }
}
