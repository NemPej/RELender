using System;
using System.Collections.Generic;
using System.Text;

namespace RELender.BLL.Models

{
	public class RealEstate : Identifiable
	{
		public int Area { get; set; }
		public int NoBeds { get; set; }
		public RealEstateOwner Owner { get; set; }
		public int OwnerId { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public string Address { get; set; }

		public override string ToString()
		{
			return this.Id.ToString();
		}
	}
}
