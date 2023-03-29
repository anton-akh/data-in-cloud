using Microsoft.EntityFrameworkCore;
using System;
using StudentAccount.Dal.Student;

namespace StudentAccount.Dal;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<StudentDao> Students { get; set; }
}
