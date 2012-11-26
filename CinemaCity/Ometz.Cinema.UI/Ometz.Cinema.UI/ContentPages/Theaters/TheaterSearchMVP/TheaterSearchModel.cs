using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ometz.Cinema.UI.ContentPages.Theaters.TheaterSearchMVP
{
	public class TheaterSearchModel
	{
		public class TheaterLine
		{
			public String TheaterName { get; set; }
		}
		public String ChosenTheater { get; set; }

		public List<TheaterLine> ListOfTheaters { get; set; }
	}
}