using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ometz.Cinema.BLL.Theaters;

namespace Ometz.Cinema.UI.ContentPages.Theaters.TheaterSearchMVP
{
	public class TheaterSearchPresenter
	{
	public ITheaterSearchView Myview { get; set; }

		public TheaterSearchPresenter(ITheaterSearchView myView)
       {
           Myview = myView;

           Myview.LoadData += LoadData;
       }

       private void LoadData(EventArgs e)
       {
				 //Extraction DropDownList from the database

				 string cityTemp = "Montreal";

           //Method that extracts all data to populate the table
				 Myview.Model.ChosenTheater = "It works";

				 ITheater theaterServices=new TheaterServices();
				 IList<TheaterModelDTO> listOfTheaters = theaterServices.GetTheaters(cityTemp);
				 //Data transfer to TheaterSearch MODEL
				 Myview.Model.ListOfTheaters = new List<TheaterLine>();

				 foreach (var item in listOfTheaters)
				 {
					 TheaterLine row = new TheaterLine();
					 row.TheaterName = item.Name;

					 Myview.Model.ListOfTheaters.Add(row);
				 }

       }


	}
	public delegate void DataLoadHandler(EventArgs e);
}