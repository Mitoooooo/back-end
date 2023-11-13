using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SportType> SportTypes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<FieldCluster> FieldClusters { get; set; }
        public DbSet<SportField> SportFields { get; set; }
        public DbSet<SportFieldType> SportFieldType { get; set; }
        public DbSet<SportFieldTypeSchedule> SportFieldTypeSchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}