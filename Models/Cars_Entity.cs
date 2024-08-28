using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Grade_Project_.Models
{
    public class Cars_Entity:IdentityDbContext<Users,Roles,int>
    {
        public Cars_Entity() { }
        public Cars_Entity(DbContextOptions options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Car_Model> Car_Models { get; set; }
        public DbSet<Car_Brand> Cars_Brands { get; set; }
        public DbSet<Car_Images> Cars_Images { get; set; }
        public DbSet<Reports> reports { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Grade_Proj;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
