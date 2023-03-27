namespace WebAPI;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
         Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<TaskP>()
        .HasKey(t => t.TaskId);

    modelBuilder.Entity<User>()
        .HasKey(u => u.UserId);
}

    public DbSet<TaskP> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
   
}