using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ometz.Cinema.DAL;
using Ometz.Cinema.BLL.Theaters;

namespace Ometz.Cinema.BLL.Performances
{
	public class PerformanceServices:IPerformance
	{

		public IList<PerformanceModelDTO> GetPerformances(Guid theaterId)
		{
			IList<PerformanceModelDTO> performancesList = new List<PerformanceModelDTO>();
			IList<RoomModelDTO>roomsList=new List<RoomModelDTO>();


			using (var context1 = new CinemaEntities())
			{
				var rooms = (from room in context1.Rooms
										 where room.TheaterID == theaterId
										 select room).ToList();

				if (rooms.Count > 0)
				{
					foreach (var room in rooms)
					{
						var roomRow = new RoomModelDTO();
						roomRow.RoomNumber = room.RoomID;
						roomRow.RoomNumber = room.RoomNumber;
						roomsList.Add(roomRow);


						if (roomsList != null)
						{
							using (var context = new CinemaEntities())
							{
								var performances = (from performance in context.Perfomances
																		where performance.TheaterID == theaterId
																		select performance).ToList();


								foreach (var perform in performances)
								{
									var performanceRow = new PerformanceModelDTO();
									performanceRow.PerformanceID = perform.PerfomanceID;
									performanceRow.Tilte = perform.Movie.Title;
									performanceRow.Price = perform.Price;
									//performanceRow.Room.RoomNumber = perform.Room.RoomNumber;
									performanceRow.Duration = perform.Duration; ;
									performancesList.Add(performanceRow);

								}
							}
						}

					} 


				}
			} return performancesList;
		}
	}
}
