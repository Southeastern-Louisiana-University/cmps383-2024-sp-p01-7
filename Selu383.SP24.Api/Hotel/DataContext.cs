using Microsoft.EntityFrameworkCore;

namespace Selu383.SP24.Api.Hotel
{
    public class DataContext : DbContext
    {
        public DbSet<Hotel> Hotel { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>()
                .Property(x => x.Name)
                .HasMaxLength(150);

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "Super 8", Address = "200 Westin Oaks dr." },
                new Hotel { Id = 2, Name = "Hampton Inn", Address = "401 Westin Oak dr." },
                new Hotel { Id = 3, Name = "Comfort Inn", Address = "110 Westin Oaks dr." },
                new Hotel { Id = 4, Name = "Econo Lodge", Address = "408 Westin Oaks dr."}
   
            );
        }

    }
}
