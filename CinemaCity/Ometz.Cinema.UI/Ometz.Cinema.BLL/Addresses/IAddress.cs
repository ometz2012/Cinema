using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ometz.Cinema.BLL.Addresses
{
	public interface IAddress
	{
		//Method that gets Specific Address by objectId
		AddressModelDTO GetAddress(Guid objectId);

		//Method that gets ObjectID by City
		AddressModelDTO GetObject(string city);

		//Method that gets all Cities
		IList<AddressModelDTO> GetCities();
		
	}
}
