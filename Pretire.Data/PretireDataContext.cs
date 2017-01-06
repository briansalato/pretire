using Pretire.Data.Models;
using System.Data.Entity;

namespace Pretire.Data
{
    public class PretireDataContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<SimulationEntity> Simulations { get; set; }
        public DbSet<SalaryEntity> Salaries { get; set; }
        public DbSet<GrowthTypeEntity> GrowthTypes { get; set; }
        public DbSet<TaxCodeEntity> TaxCodes { get; set; }
        public DbSet<TaxBracketEntity> TaxBrackets { get; set; }
    }
}
