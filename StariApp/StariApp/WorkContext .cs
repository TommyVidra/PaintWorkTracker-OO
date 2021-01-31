using System.Data.Entity;

namespace StariApp
{
    class WorkContext : DbContext
    {

        public WorkContext() : base("DbConnection") { this.Configuration.AutoDetectChangesEnabled = true; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Note> Notes { get; set; }

    }
}
