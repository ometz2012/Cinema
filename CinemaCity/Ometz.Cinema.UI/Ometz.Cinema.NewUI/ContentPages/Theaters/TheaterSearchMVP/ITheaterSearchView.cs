using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ometz.Cinema.UI.ContentPages.Theaters.TheaterSearchMVP
{
	public interface ITheaterSearchView
	{
		event DataLoadHandler LoadData;
		event LoadCityHandler LoadCity;
		event LoadTheatersHandler LoadTheaters;

		TheaterSearchModel Model { get; set; }
		TheaterSearchPresenter Presenter { get; set; }
	}
}