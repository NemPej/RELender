using RELender.BLL.Interfaces.Repo;
using RELender.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RELender.BLL.Interfaces
{
	public interface IRELenderService : IDisposable
	{
		ICrudRepo<Agent> AgentsRepo { get; set; }
		ICrudRepo<Client> ClientsRepo { get; set; }
		ICrudRepo<RealEstateOwner> RealEstateOwnersRepo { get; set; }
		ICrudRepo<Agency> AgenciesRepo { get; set; }
		ICrudRepo<RealEstate> RealEstatesRepo { get; set; }
		ICrudRepo<RentingRights> RentingRightsRepo { get; set; }
		int SaveChanges();
	}
}
