using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ometz.Cinema.BLL.Users;

namespace Ometz.Cinema.UI.ContentPages.Users.TicketSelectionMVP
{
    public class TicketPresenter
    {
        public ITicketView TicketView { get; set; }

        public TicketPresenter(ITicketView MyView)
        {
            TicketView = MyView;
            TicketView.LoadData += LoadData;
            TicketView.MovieSelection += MovieSelection;
            TicketView.MovieWasSelected += MovieWasSelected;
            TicketView.CitySelection += CitySelection;
            TicketView.TheaterSelection += TheaterSelection;
            TicketView.PerformanceSelection += PerformanceSelection;
            TicketView.PageReset += PageReset;

        }

        //Method that load data, load movies list
        private void LoadData(EventArgs ex)
        {
            
            IUser UserServices = new UserServices();
            IList<UserFavoriteMovieDTO> ListOfMovies = UserServices.GetListOfMovies(); 
            TicketView.Model.MovieList = new List<MovieLine>();
            foreach (var item in ListOfMovies)
            {
                MovieLine row = new MovieLine();
                row.MovieID = item.movieID.ToString();
                row.MovieTitle = item.MovieTitle;
                TicketView.Model.MovieList.Add(row);
                
            }

            
        }

        //Method that processes Movie selection - presents short description of the movie
        private void MovieSelection(SelectedParamterArgs esp)
        {
            IUser UserServices = new UserServices();
            String Description = null;
            String SelectedMovieID = esp.SelectedValue;
            int movieID = 0;
            bool checkGuid= int.TryParse(SelectedMovieID, out movieID);
            if(checkGuid)
            Description = UserServices.GetMovieDescriptionByMovieID(movieID);
            TicketView.Model.MovieDescription = Description;
        }

        //Method that process Movie selection - the movie was selected by pressing the button
        private void MovieWasSelected(SelectedParamterArgs esp)
        {
            int movieID = 0;
            bool checkIfInt = int.TryParse(esp.SelectedValue.ToString(), out movieID);
            if (checkIfInt)
            {
                IUser UserServices = new UserServices();
                IList<String> ListOfCities = new List<String>();
                ListOfCities = UserServices.GetCitiesByMovieID(movieID);
                List<String> ListOfCitiesRevised = new List<String>();
                //Running loop in order to remove repeation of cities in the list
                foreach (var item in ListOfCities)
                {
                    if(!ListOfCitiesRevised.Contains(item))
                    {
                        ListOfCitiesRevised.Add(item);
                    }
                }

                TicketView.Model.CityList=new List<String>();
                TicketView.Model.CityList=ListOfCitiesRevised;
            }
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
        public String SelectedValue { get; set; }
        public SelectedParamterArgs(string selectedValue)
        {
            this.SelectedValue = selectedValue;
        }
    }

}