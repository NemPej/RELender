using RELender.BLL.Interfaces.Repo;
using RELender.BLL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RELender.Repos
{
	public class RealEstateOwnerRepo : ICrudRepo<RealEstateOwner>
	{
		private readonly DbContext context;

		public RealEstateOwnerRepo(DbContext context)
		{
			this.context = context;
		}
		public RealEstateOwner Create(RealEstateOwner entity)
		{
			var added = this.context.Set<RealEstateOwner>().Add(entity);
			//this.context.SaveChanges();
			return added;
		}

		public RealEstateOwner Get(int id)
		{
			return this.context.Set<RealEstateOwner>().FirstOrDefault(e => e.Id == id);

		}

		public IEnumerable<RealEstateOwner> GetAll()
		{
			return this.context.Set<RealEstateOwner>();

		}

		public async void Remove(int id)
		{
			var ent = Get(id);

			if (ent != null)
			{
				// removing rentingRights
				//await this.context.Set<RentingRights>().Where(rr => this.context.Set<RealEstate>().Where(re => re.OwnerId == id).Select(re => re.Id).Contains(rr.Id)).ForEachAsync(rr => this.context.Set<RentingRights>().Remove(rr));

				var toDelRR = this.context.Set<RentingRights>().Where(rr => this.context.Set<RealEstate>().Where(re => re.OwnerId == id).Select(re => re.Id).Contains(rr.RealEstate.Id));
				foreach (var item in toDelRR)
				{
					this.context.Set<RentingRights>().Remove(item);
				}

				// removing realEstates
				//await this.context.Set<RealEstate>().Where(re => re.OwnerId == id).ForEachAsync(re => this.context.Set<RealEstate>().Remove(re));
				var toDelRE = this.context.Set<RealEstate>().Where(re => re.OwnerId == id);
				foreach (var item in toDelRE)
				{
					this.context.Set<RealEstate>().Remove(item);
				}

				//this.context.SaveChanges();

				this.context.Set<RealEstateOwner>().Remove(ent);
				//this.context.SaveChanges();
			}
		}

		public void Update(RealEstateOwner entity)
		{
			throw new NotImplementedException();
		}
	}
}
