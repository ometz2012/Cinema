using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ometz.Cinema.UI.ContentPages.Users.TicketSelectionMVP
{
    public interface ITicketView
    {
        event DataLoadHandler LoadData;
        event MovieSelectionHandler MovieSelection;
        event MovieIsSelectedHadler MovieWasSelected;
        event CitySelectionHandler CitySelection;
        event TheaterSelectionHandler TheaterSelection;
        event PerformanceSelectionHandler PerformanceSelection;
        

        TicketModel Model { get; set; }
        TicketPresenter Presenter { get; set; }
    }
}
