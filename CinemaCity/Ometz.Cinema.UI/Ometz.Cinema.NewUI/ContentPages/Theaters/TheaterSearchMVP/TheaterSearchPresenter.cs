using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ometz.Cinema.BLL.Theaters;
using Ometz.Cinema.BLL.Addresses;

namespace Ometz.Cinema.UI.ContentPages.Theaters.TheaterSearchMVP
{
	public class TheaterSearchPresenter
	{
		public ITheaterSearchView TheaterSearchView { get; set; }

		public TheaterSearchPresenter(ITheaterSearchView myView)
		{
			TheaterSearchView = myView;
			TheaterSearchView.LoadData += LoadData;
			TheaterSearchView.LoadCity += LoadCity;
			TheaterSearchView.LoadTheaters += LoadTheaters;
		}

		private void LoadData(EventArgs e)
		{


		}

		public void LoadCity(EventArgs e)
		{
			//Populate Cities from database
			IAddress citiesList = new AddressServices();
			IList<String> listOfCities = new List<String>();
			listOfCities=citiesList.GetCities();
			
			//Transfer to Model
			TheaterSearchView.Model.ListOfCities =new List<String>();
			TheaterSearchView.Model.ListOfCities = listOfCities;
		
		}

		public void LoadTheaters(String city)
		{
			//Method that extracts data to populate the table
			ITheater theaterServices = new TheaterServices();
			IList<TheaterModelDTO> listOfTheaters = theaterServices.GetTheaters(city);
			

			//Transfer to Model
			TheaterSearchView.Model.ListOfTheaters = new List<TheaterLine>();

			foreach (var item in listOfTheaters)
			{
				TheaterLine row = new TheaterLine();
				row.TheaterID = item.TheaterID.ToString();
				row.TheaterName = item.Name;

				TheaterSearchView.Model.ListOfTheaters.Add(row);
			}
			
		}

	}

		public delegate void DataLoadHandler(EventArgs e);
		public delegate void LoadCityHandler(EventArgs e);
		public delegate void LoadTheatersHandler(String city);
}