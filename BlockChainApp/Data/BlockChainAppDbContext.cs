using BlockChainApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlockChainApp.Data
{
    public class BlockChainAppDbContext : DbContext
    {
        public BlockChainAppDbContext(DbContextOptions<BlockChainAppDbContext> context): base(context)
        {

        }

        public DbSet<FarmerData> FarmerData { get; set; }
        public DbSet<Login> Login { get; set; }
    }
}
