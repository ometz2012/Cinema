using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ometz.Cinema.BLL.Theaters;
using Ometz.Cinema.BLL.Addresses;
using Ometz.Cinema.BLL.Performances;

namespace Ometz.Cinema.UI.ContentPages.Theaters.TheaterMVP
{
	public class TheaterPresenter
	{
		public ITheaterView Myview { get; set; }

		
				 
		public TheaterPresenter(ITheaterView myView)
       {
           Myview = myView;

           Myview.LoadData += LoadData;
       }


		//Method that extracts all data to populate the Labels and the table Performance
       private void LoadData(Guid theaterId)
       {

				 //Data extraction from database

				 IPerformance performanceServices = new PerformanceServices();
				 IList<PerformanceModelDTO> ListOfPerformances = performanceServices.GetPerformances(theaterId);

				 ITheater showTheater = new TheaterServices();
				 String currentTheater = showTheater.GetTheater(theaterId);

				 IAddress showAddress = new AddressServices();
				 AddressModelDTO currentAddress = showAddress.GetAddress(theaterId);
 
				 
				 
				 //Data transfer to Theater Model
				 Myview.Model.ListOfPerformances = new List<PerformanceLine>();

				 foreach(var item in ListOfPerformances)
				 {
					 PerformanceLine row=new PerformanceLine();
					 row.PerformanceID = item.PerformanceID.ToString();
					 row.Title = item.Title;
					 row.Date = item.Date;
					 row.StartingTime = item.StartingTime;
					 row.RoomNumber = item.RoomNumber.ToString();
					 row.Duration = item.Duration;
					 row.Price = item.Price.ToString();
					 Myview.Model.ListOfPerformances.Add(row);
				 }

				 Myview.Model.TheaterName = currentTheater;
				 Myview.Model.AddressLine1 = currentAddress.AddressLine1;
				 Myview.Model.City = currentAddress.City;
				 Myview.Model.Country = currentAddress.Country;
				 Myview.Model.Province = currentAddress.Province;
				 Myview.Model.PostalCode = currentAddress.PostalCode;
				 Myview.Model.Phone = currentAddress.Phone;
				 Myview.Model.Email = currentAddress.Email;

      }

	}
	public delegate void DataLoadHandler(Guid theaterId);
}