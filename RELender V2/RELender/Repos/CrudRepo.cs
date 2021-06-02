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
	class CrudRepo<TEntity> : ICrudRepo<TEntity> where TEntity : Identifiable
	{
		private readonly DbContext context;

		public CrudRepo(DbContext context)
		{
			this.context = context;
		}

		public TEntity Create(TEntity entity)
		{
			var added = this.context.Set<TEntity>().Add(entity);
			//this.context.SaveChanges();
			return added;
		}

		public TEntity Get(int id)
		{
			return this.context.Set<TEntity>().FirstOrDefault(e => e.Id == id);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return this.context.Set<TEntity>();
		}

		public void Remove(int id)
		{
			var ent = Get(id);

			if (ent != null)
			{
				this.context.Set<TEntity>().Remove(Get(id));
			}
		}

		public void Update(TEntity entity)
		{
			throw new NotImplementedException();
		}
	}
}
