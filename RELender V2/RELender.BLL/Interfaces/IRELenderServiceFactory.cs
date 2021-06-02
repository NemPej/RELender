using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RELender.BLL.Interfaces
{
	public interface IRELenderServiceFactory
	{
		void Initialize();
		IRELenderService Create();
	}
}
