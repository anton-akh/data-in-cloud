using Microsoft.EntityFrameworkCore;
using System;
using StudentAccount.Dal.Student;

namespace StudentAccount.Dal;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {
    }

    public DbSet<StudentDao> Students { get; set; }
}
