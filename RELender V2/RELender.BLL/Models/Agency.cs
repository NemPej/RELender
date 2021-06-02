using System;
using System.Collections.Generic;
using System.Text;

namespace RELender.BLL.Models
{
	public class Agency : Identifiable
	{
		List<Agent> Staff { get; set; }
		public string Name { get; set; }


		public override string ToString()
		{
			return Name;
		}
	}
}
