using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ometz.Cinema.DAL;

namespace Ometz.Cinema.BLL.Theaters
{
	public class TheaterServices : ITheater
	{
		public TheaterModelDTO GetTheater(Guid theaterId)
		{

			Theater spesificTheater = new Theater();

			using (var context = new CinemaEntities())
			{
				spesificTheater = (from theater in context.Theaters
													 where theater.TheaterID == theaterId
													 select theater).FirstOrDefault();
			}

			TheaterModelDTO theaterToReturn = new TheaterModelDTO();
			theaterToReturn.TheaterID = spesificTheater.TheaterID;
			theaterToReturn.Name = spesificTheater.Name;



			return theaterToReturn;
		}


		public IList<TheaterModelDTO> GetTheaters(string city)
		{
			IList<TheaterModelDTO> theaterList = new List<TheaterModelDTO>();
			IList<Addresses.AddressModelDTO> addressList = new List<Addresses.AddressModelDTO>();
			using (var context = new CinemaEntities())
			{
				var adddresses = (from address in context.Addresses
													where address.City == city
													select address).ToList();
				if (adddresses.Count > 0)
				{
					foreach (var address in adddresses)
					{
						var addressRow = new Addresses.AddressModelDTO();
						addressRow.AddressID = address.AddressID;
						addressRow.ObjectID = address.ObjectID;
						addressList.Add(addressRow);

						Guid currentTheater = addressRow.ObjectID;
						if (addressList != null)
						{
							using (var context1 = new CinemaEntities())
							{
								var theaters = (from theater in context1.Theaters
																where theater.TheaterID == currentTheater
																select theater).ToList();

								//if (theaters.Count>0)
								//{
									foreach (var theater in theaters)
									{
										var theaterRow = new TheaterModelDTO();
										theaterRow.Name = theater.Name;
										theaterRow.TheaterID = theater.TheaterID;
										theaterList.Add(theaterRow);

									}
								//}
							}						
						}
					}
				}
			}
			return theaterList;
		}

		public TheaterModelDTO GetTheater(string city)
		{
			throw new NotImplementedException();
		}

		public IList<TheaterModelDTO> GetTheaters(Guid objectId)
		{
			throw new NotImplementedException();
		}
	}
}

