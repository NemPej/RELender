using System;
using System.Collections.Generic;
using System.Text;

namespace RELender.BLL.Models
{
	public class RentingRights : Identifiable
	{
		public int OwnerCompensation { get; set; }
		public RealEstate RealEstate { get; set; }
		public Agency Agency { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}
