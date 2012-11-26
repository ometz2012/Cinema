using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ometz.Cinema.BLL.Performances;

namespace Ometz.Cinema.BLL.Theaters
{
	public abstract class RoomModelBase
	{
		public int RoomID { get; set; }
		public int RoomNumber { get; set; }
		public int NumberOfSeats { get; set; }
		public TheaterModelBase Theater { get; set; }

		public List<PerformanceModelDTO> Performance { get; set; }


	}
}
