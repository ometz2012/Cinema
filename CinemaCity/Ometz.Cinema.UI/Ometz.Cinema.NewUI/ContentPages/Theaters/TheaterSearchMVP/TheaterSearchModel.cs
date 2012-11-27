using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ometz.Cinema.UI.ContentPages.Theaters.TheaterSearchMVP
{
	public class TheaterSearchModel
	{
		
		public String ChosenTheater { get; set; }

		public IList<String> ListOfCities { get; set; }

		public IList<TheaterLine> ListOfTheaters { get; set; }
	}
	public class TheaterLine
		{
			public String TheaterID { get; set; }
			public String TheaterName { get; set; }
		}

	
}