﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RELender.BLL.Models
{
	public class Log
	{
		public int Id { get; set; }
		public string Action { get; set; }
		public string ActionResId { get; set; }
		public DateTime DateTime { get; set; }
	}
}
