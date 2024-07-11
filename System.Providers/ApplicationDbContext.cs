using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Configuration;
using System.Entities;
using System.Security.Principal;

namespace System.Provider;
public class ApplicationDbContext : DbContext
{
    public string ConnectionString { get; set; } = "Server=localhost;Database=CrudProducts;Uid=root;Pwd=admin";


    public ApplicationDbContext() { }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySQL(ConnectionString);
        }
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }


}



