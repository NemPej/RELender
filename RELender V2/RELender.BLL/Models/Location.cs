using System;
using System.Collections.Generic;
using System.Text;

namespace RELender.BLL.Models
{
	public class Location : Identifiable
	{
		public string Country { get; set; }
		public string City { get; set; }
		public string Address { get; set; }
	}
}
