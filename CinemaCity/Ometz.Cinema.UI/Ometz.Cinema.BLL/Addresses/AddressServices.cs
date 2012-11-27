using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ometz.Cinema.DAL;

namespace Ometz.Cinema.BLL.Addresses
{
	public class AddressServices:IAddress
	{

		public AddressModelDTO GetAddress(Guid objectId)
		{
			Address spesificAddress = new Address();
			
			using (var context = new CinemaEntities())
			{
				spesificAddress = (from address in context.Addresses
													 where address.ObjectID == objectId
													 select address).FirstOrDefault();
			}

			AddressModelDTO addressToReturn = new AddressModelDTO();
			addressToReturn.AddressID = spesificAddress.AddressID;
			addressToReturn.AddressLine1 = spesificAddress.AddressLine1;
			addressToReturn.City = spesificAddress.City;
			addressToReturn.PostalCode = spesificAddress.PostalCode;
			addressToReturn.Province = spesificAddress.Province;
			addressToReturn.Country = spesificAddress.Country;
			addressToReturn.Phone = spesificAddress.Phone;
			addressToReturn.Email = spesificAddress.Email;

			return addressToReturn;
		}

		public IList<String> GetCities()
		{
			IList<String> citiesList = new List<String>();
			using (var context = new CinemaEntities())
			{
				var cities = (from ct in context.Addresses
											select new { City = ct.City }).Distinct();
				foreach (var item in cities)
				{
					String cityRow = null;
					cityRow = item.City;
					citiesList.Add(cityRow);
				}
			}
			return citiesList;
		}

		
	}

}
