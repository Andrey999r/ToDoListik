using Microsoft.EntityFrameworkCore;

public class ToDoDbContext:DbContext{
    public ToDoDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Record> Records { get; set; }
}