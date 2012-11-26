using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ometz.Cinema.BLL.Theaters;

namespace Ometz.Cinema.BLL.Addresses
{
	public abstract class AddressModelBase
	{
		public int AddressID { get; set; }
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string City { get; set; }
		public string PostalCode { get; set; }
		public string Province{ get; set; }
		public string Country { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public ObjectTypeBase ObjectTypeID { get; set; }
		public Guid ObjectID { get; set; }


		public List<TheaterModelDTO> Theater { get; set; }
	}

	public abstract class ObjectTypeBase
	{
		public Guid ObjectTypeID { get; set; }
		public String Description { get; set; }
	}

}
