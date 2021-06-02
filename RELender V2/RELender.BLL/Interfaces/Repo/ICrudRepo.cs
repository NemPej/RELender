using RELender.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RELender.BLL.Interfaces.Repo
{
	public interface ICrudRepo<TEntity> where TEntity : Identifiable
	{
		TEntity Create(TEntity entity);
		TEntity Get(int id);
		IEnumerable<TEntity> GetAll();
		void Remove(int id);
		void Update(TEntity entity);
	}
}
