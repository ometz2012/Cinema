using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ometz.Cinema.BLL.Addresses;

namespace Ometz.Cinema.BLL.Theaters
{
	public abstract class TheaterModelBase
	{
		public Guid TheaterID { get; set; }
		public string Name { get; set; }
		
	}

	
}
