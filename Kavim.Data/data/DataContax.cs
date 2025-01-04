
using Kavim.Core.classes;
using Kavim.Data.data;
using Microsoft.EntityFrameworkCore;

public class DataContext: DbContext,IData
{
    public DbSet<Bus> buses  { get; set; }

    public DbSet<Street> streets { get; set; }

    public DbSet<Station> stations { get; set; }

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Kavim327860508_db");
    }

}