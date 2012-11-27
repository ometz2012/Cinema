using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ometz.Cinema.UI.ContentPages.Theaters.TheaterMVP
{
	public class TheaterModel
	{
			public String TheaterName { get; set; }
			public String AddressLine1 { get; set; }
			public String City{ get; set; }
		  public String Country{ get; set; }
			public String Email{ get; set; }
			public String Phone{ get; set; }
			public String PostalCode{ get; set; }
			public String Province{ get; set; }


		public List<PerformanceLine> ListOfPerformances { get; set; }
	}

	public class PerformanceLine
	{
			public String PerformanceID { get; set; }
			public String Title { get; set; }
			public String TheaterName { get; set; }
			public String RoomNumber { get; set; }
			public String Date { get; set; }
			public String StartingTime { get; set; }
			public String Duration { get; set; }
			public String Price { get; set; }
	}
}