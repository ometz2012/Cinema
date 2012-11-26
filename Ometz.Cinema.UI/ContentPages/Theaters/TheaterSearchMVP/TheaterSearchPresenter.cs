using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
           //Method that extracts all data to populate the tables
				 Myview.Model.ChosenTheater = "It works";

       }


	}
	public delegate void DataLoadHandler(EventArgs e);
}