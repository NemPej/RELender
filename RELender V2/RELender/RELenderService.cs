using RELender.BLL.Interfaces;
using RELender.BLL.Interfaces.Repo;
using RELender.BLL.Models;
using RELender.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RELender
{
	class RELenderService : IRELenderService
	{
		private readonly ApplicationDbContext context;

		public RELenderService(ApplicationDbContext context)
		{
			this.context = context;

			this.AgentsRepo = new CrudRepo<Agent>(context);
			this.ClientsRepo = new CrudRepo<Client>(context);
			this.RealEstateOwnersRepo = new RealEstateOwnerRepo(context);
			this.AgenciesRepo = new CrudRepo<Agency>(context);
			this.RealEstatesRepo = new CrudRepo<RealEstate>(context);
			this.RentingRightsRepo = new CrudRepo<RentingRights>(context);
		}
		public ICrudRepo<Agent> AgentsRepo { get; set; }
		public ICrudRepo<Client> ClientsRepo { get; set; }
		public ICrudRepo<RealEstateOwner> RealEstateOwnersRepo { get; set; }
		public ICrudRepo<Agency> AgenciesRepo { get; set; }
		//public ICrudRepo<Location> LocationsRepo { get; set; }
		public ICrudRepo<RealEstate> RealEstatesRepo { get; set; }
		public ICrudRepo<RentingRights> RentingRightsRepo { get; set; }

		public void Dispose()
		{
			this.context.Dispose();
		}

		public int SaveChanges()
		{
			return this.context.SaveChanges();
		}
	}
}
