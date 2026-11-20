using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InventoryMS;

public class Bridge :IdentityDbContext
{
    public Bridge(DbContextOptions<Bridge> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; } 
}
