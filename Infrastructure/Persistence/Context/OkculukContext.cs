using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class OkculukContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=OkculukProjesi;User=TestUser;Password=321321;TrustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User - Role relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            // Event - User relationship (Event creator)
            modelBuilder.Entity<Event>()
                .HasOne(e => e.User)
                .WithMany(u => u.Events)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // EventUser relationships
            modelBuilder.Entity<EventUser>()
                .HasOne(eu => eu.Event)
                .WithMany(e => e.EventsAndUsers)
                .HasForeignKey(eu => eu.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EventUser>()
                .HasOne(eu => eu.User)
                .WithMany(u => u.EventsAndUsers)
                .HasForeignKey(eu => eu.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // EventUser Status default value
            modelBuilder.Entity<EventUser>()
                .Property(eu => eu.Status)
                .HasDefaultValue("Pending");

            modelBuilder.Entity<Event>()
                .Property(e => e.IsActive)
                .HasDefaultValue(true);


        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventUser> EventsAndUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<VisibleEvent> VisibleEvents { get; set; }
    }
}
