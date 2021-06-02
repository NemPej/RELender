using System;
using System.Collections.Generic;
using System.Text;

namespace RELender.BLL.Models
{
	public class RealEstateOwner : Person
	{
		public RealEstateOwner()
		{

		}

		public RealEstateOwner(Person person) : base(person)
		{

		}

		public override string ToString()
		{
			return $"{Name} {Surname}";
		}
	}
}
