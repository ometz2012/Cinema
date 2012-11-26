using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ometz.Cinema.BLL;

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

       private void LoadData(EventArgs e)
       {
           //Method that extracts all data to populate the tables
           Myview.Model.TheaterName = "It works";

       }


	}
	public delegate void DataLoadHandler(EventArgs e);
}