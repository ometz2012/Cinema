using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ometz.Cinema.BLL.Theaters
{
	public interface ITheater
	{
		//Method that gets Theater Information by TheaterID
		TheaterModelDTO GetTheater(Guid theaterId);

			//Method that gets list of Theaters by City
		IList<TheaterModelDTO> GetTheaters(string city);
	}
}
