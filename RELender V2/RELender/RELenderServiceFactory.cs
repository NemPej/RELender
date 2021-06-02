using RELender.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RELender
{
	public class RELenderServiceFactory : IRELenderServiceFactory
	{
		private readonly string connString;

		public RELenderServiceFactory(string connString = "DefaultConnection")
		{
			this.connString = connString;
		}

		public IRELenderService Create()
		{
			var context = new ApplicationDbContext(connString);
			//return 
			return new RELenderService(context);
		}

		public void Initialize()
		{
			//using (var context = new ApplicationDbContext)
			throw new NotImplementedException();
		}
	}
}
