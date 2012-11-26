using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ometz.Cinema.BLL.Theaters;
using Ometz.Cinema.BLL.Movies;

namespace Ometz.Cinema.BLL.Performances
{
  public	class PerformanceModelBase:MovieModelBase
	{
		public int PerformanceID { get; set; }
		public DateTime Date { get; set; }
		public DateTime StartingTime { get; set; }
		public String Duration { get; set; }
		public Decimal Price { get; set; }
		public RoomModelDTO Room { get; set; }
		public TheaterModelDTO Theater { get; set; }
		public MovieModelDTO Movie { get; set; }
	}

}
