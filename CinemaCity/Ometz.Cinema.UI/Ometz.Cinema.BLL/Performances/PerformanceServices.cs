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
			
							using (var context = new CinemaEntities())
							{
								var performances = (from performance in context.Perfomances.Include("Room")
																		where performance.TheaterID == theaterId
																		select performance).ToList();


								foreach (var perform in performances)
								{
									var performanceRow = new PerformanceModelDTO();
									performanceRow.PerformanceID = perform.PerfomanceID;
									string date = perform.Date.ToString("yyyy'/'MM'/'dd");
									performanceRow.Date = date;//(DateTime)perform.Date;
									TimeSpan time = (TimeSpan)perform.StartingTime;
									performanceRow.StartingTime = string.Format("{0:hh\\:mm}", time);// (TimeSpan)perform.StartingTime;
									performanceRow.Title = perform.Movie.Title;
									performanceRow.Price = perform.Price;
									performanceRow.RoomNumber = perform.Room.RoomNumber;
									performanceRow.Duration = perform.Duration; ;
									performancesList.Add(performanceRow);

								}
							}
								return performancesList;
						}
			
	}
}
