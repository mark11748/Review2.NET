using Microsoft.EntityFrameworkCore;

namespace Review2_NET.Models
{
    public class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=Review1-NET;uid=root;pwd=root;");
        }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}