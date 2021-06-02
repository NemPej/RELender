using System;
using System.Collections.Generic;
using System.Text;

namespace RELender.BLL.Models
{
	public class Person : Identifiable
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string PhoneNo { get; set; }

		public Person(Person per)
		{
			this.Name = per.Name;
			this.Surname = per.Surname;
			this.Email = per.Email;
			this.PhoneNo = per.PhoneNo;
		}

		public Person()
		{

		}

		public override string ToString()
		{
			return $"{Name} {Surname}";
		}
	}
}
