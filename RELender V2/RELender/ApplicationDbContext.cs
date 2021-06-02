using RELender.BLL.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace RELender
{
	public class ApplicationDbContext : DbContext
	{

		public ApplicationDbContext()
			: base("DefaultConnection")
		{
		}

		public ApplicationDbContext(string connString) : base(connString)
		{

		}

		public DbSet<Agent> Agents { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<RealEstateOwner> RealEstateOwners { get; set; }
		public DbSet<Agency> Agencies { get; set; }
		public DbSet<RealEstate> RealEstates { get; set; }
		public DbSet<RentingRights> RentingRights { get; set; }
		public DbSet<Log> Logs { get; set; }

	}

}