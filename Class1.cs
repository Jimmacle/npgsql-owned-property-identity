using Microsoft.EntityFrameworkCore;

namespace NpgsqlOwnedIdentityColumn;

public class OwningEntity
{
    public int Id { get; set; }
    
    public OwnedEntity Owned { get; set; }
}

public class OwnedEntity
{
    public int ThisShouldBeIdentity { get; set; }
}

public class TestDbContext : DbContext
{
    public DbSet<OwningEntity> OwningEntities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var owning = modelBuilder.Entity<OwningEntity>();
        owning.Property(x => x.Id).UseIdentityAlwaysColumn();
        owning.OwnsOne(
            x => x.Owned,
            owned =>
            {
                owned.Property(x => x.ThisShouldBeIdentity)
                    .UseIdentityAlwaysColumn();
            });
    }
}
