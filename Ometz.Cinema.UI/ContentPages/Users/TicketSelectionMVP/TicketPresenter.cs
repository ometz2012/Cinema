using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.UserControl;
using System.Drawing;
using Ometz.Cinema.BLL;


namespace Ometz.Cinema.UI.ContentPages.Users.TicketSelectionMVP
{
    public class TicketPresenter
    {
        public ITicketView TicketView { get; set; }

        public TicketPresenter(ITicketView MyView)
        {
            TicketView = MyView;
            MyView.LoadData += LoadData;
            MyView.MovieSelection += MovieSelection;
            MyView.MovieWasSelected += MovieWasSelected;
            MyView.CitySelection += CitySelection;
            MyView.TheaterSelection += TheaterSelection;
            MyView.PerformanceSelection += PerformanceSelection;
            MyView.PageReset += PageReset;

        }

        //Method that load data, load movies list
        private void LoadData(EventArgs ex)
        {

        }

        //Method that processes Movie selection - presents short description of the movie
        private void MovieSelection(SelectedParamterArgs esp)
        {

        }

        //Method that process Movie selection - the movie was selected by pressing the button
        private void MovieWasSelected(SelectedParamterArgs esp)
        {

        }

        //Method that processes the City Selection
        private void CitySelection(SelectedParamterArgs esp)
        {

        }

        //Method that processes Theater selection
        private void TheaterSelection(SelectedParamterArgs esp)
        {

        }

        //Method that processes Performance selection and redirects to payment
        private void PerformanceSelection(SelectedParamterArgs esp)
        {
 
        }

        //Method Reset the page
        private void PageReset(EventArgs e)
        {
           

        }

        private void MethodToDelete()
        {
 
        }




    }

    //-------------Delegates-------------------

    public delegate void DataLoadHandler(EventArgs e);
    public delegate void MovieSelectionHandler(SelectedParamterArgs espa);
    public delegate void MovieIsSelectedHadler(SelectedParamterArgs espa);
    public delegate void CitySelectionHandler(SelectedParamterArgs espa);
    public delegate void TheaterSelectionHandler(SelectedParamterArgs espa);
    public delegate void PerformanceSelectionHandler(SelectedParamterArgs espa);
    public delegate void PageReset (EventArgs e);

    // --------EventArgs-------------------------

    public class SelectedParamterArgs : EventArgs
    {
        String SelectedValue { get; set; }
        public SelectedParamterArgs(string selectedValue)
        {
            this.SelectedValue = selectedValue;
        }
    }

}