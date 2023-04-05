using Microsoft.EntityFrameworkCore;
using StudentAccount.Dal.Class;

namespace StudentAccount.Dal;

public class CosmosDbContext : DbContext
{
    public CosmosDbContext(DbContextOptions<CosmosDbContext> options) : base(options)
    {
    }

    public DbSet<ClassDao> Classes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultContainer("Items");
    }
}