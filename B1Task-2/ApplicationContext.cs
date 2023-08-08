using B1Task_2.Models;
using Microsoft.EntityFrameworkCore;

namespace B1Task_2;

public class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=B1-2;" +
                                    "Trusted_Connection=True;TrustServerCertificate=True");
    }
    
    public DbSet<AddedFile> AddedFiles { get; set; }
    public DbSet<BaseClassModel> Classes { get; set; }
}