using Microsoft.EntityFrameworkCore;

namespace InventoryMS;

public class Bridge :DbContext
{
    public Bridge(DbContextOptions<Bridge> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; } 
}
