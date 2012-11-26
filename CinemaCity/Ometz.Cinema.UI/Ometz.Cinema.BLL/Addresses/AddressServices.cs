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



		//public IList<String> GetCities()
		//{
		//  List<String> citiesList = new List<String>();
		//  using (var context = new CinemaEntities())
		//  {
		//    var cities = (from city in context.Addresses
		//                  where city.ObjectType.Description == "Theater"
		//                  select city).ToList();
		//    if (cities.Count > 0)
		//    {
		//      foreach (var city in cities)
		//      {
		//        AddressModelDTO cityRow = new AddressModelDTO();
		//        cityRow.City = city.City;

						

		//        citiesList.Add(cityRow);
		//      }
		//    }


		//    return citiesList;
		//  }
		//}



		public IList<AddressModelDTO> GetCities()
		{
			IList<AddressModelDTO> citiesList = new List<AddressModelDTO>();
			using (var context = new CinemaEntities())
			{
				var cities = (from city in context.Addresses.Distinct()
											where city.ObjectType.Description == "Theater"
											select city).ToList();
				if (cities.Count > 0)
				{
					foreach (var city in cities)
					{
						var cityRow = new AddressModelDTO();
						cityRow.City = city.City;
						citiesList.Add(cityRow);
						List<AddressModelDTO> newCitiesList = new List<AddressModelDTO>();

						foreach (var item in citiesList)
						{
							if (!newCitiesList.Contains(item))
							{ newCitiesList.Add(item);}
							
						}


						//if (citiesList != null)
						//{
						//  foreach (var cit in citiesList)
						//  {
						//    if (cit.City != cityRow.City)
						//    { citiesList.Add(cityRow); }

						//  //if (cityRow.City != city.City)
						//  //{
						//  //  citiesList.Add(cityRow);
						//  //}
						//    else
						//    {
						//      return citiesList;
						//    }
					}
				}
			}
			return citiesList;
		}



		public AddressModelDTO GetObject(string city)
		{
			throw new NotImplementedException();
		}
	}

}
