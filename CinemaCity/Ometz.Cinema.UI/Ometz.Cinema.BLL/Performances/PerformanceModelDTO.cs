using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ometz.Cinema.BLL.Movies;
using Ometz.Cinema.BLL.Theaters;


namespace Ometz.Cinema.BLL.Performances
{
	public class PerformanceModelDTO : PerformanceModelBase
	{
		public PerformanceModelDTO()
		{
			base.Movie = new MovieModelDTO();
			base.Room = new RoomModelDTO();
		}
		
	}
}
