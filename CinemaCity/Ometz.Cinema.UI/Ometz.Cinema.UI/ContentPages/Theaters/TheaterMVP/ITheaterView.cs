using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ometz.Cinema.UI.ContentPages.Theaters.TheaterMVP
{
	public interface ITheaterView
	{
		event DataLoadHandler LoadData;

		TheaterModel Model { get; set; }
		TheaterPresenter Presenter { get; set; }
	}
}
