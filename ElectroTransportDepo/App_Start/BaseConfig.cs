using System.Data.Entity;

namespace ElectroTransportDepo.Models
{
    public class DepoContext : DbContext
	{
		public DepoContext()
            : base("DbConnection")
        {
			Database.SetInitializer<DepoContext>(new MyDbInitializer());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<City> Cities { get; set; }
        public DbSet<Depo> Depos { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<TransportsType> TransportsTypes { get; set; }
        public DbSet<RollingStock> RollingStocks { get; set; }
	}

	public class MyDbInitializer : DropCreateDatabaseIfModelChanges<DepoContext>
	{
		protected override void Seed(DepoContext context)
		{
			base.Seed(context);
		}
	}
}