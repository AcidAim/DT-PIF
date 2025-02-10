using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using XE908.Areas.Identity.Data;
using XE908.Models;

namespace XE908.Data;

public class DataContext : IdentityDbContext<XE908User>
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<ConferenceRoom> ConferenceRooms { get; set; } = null!;
    public DbSet<Controller> Controllers { get; set; } = null!;
    public DbSet<Reservation> Reservations { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedRoles(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    private static void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole() {Name = "Administrator", ConcurrencyStamp = "1", NormalizedName = "ADMINISTRATOR"},
            new IdentityRole() {Name = "Employee",ConcurrencyStamp = "2", NormalizedName = "EMPLOYEE"}
        );
    }
}
