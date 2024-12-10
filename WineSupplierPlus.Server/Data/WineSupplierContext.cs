using Microsoft.EntityFrameworkCore;
using WineSupplierPlus.Server.Model;

namespace WineSupplierPlus.Server.Data
{
    public class WineSupplierContext:DbContext
    {

        public WineSupplierContext(DbContextOptions<WineSupplierContext> options):base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Vineyard> Wineiries { get; set; }



    }
}
