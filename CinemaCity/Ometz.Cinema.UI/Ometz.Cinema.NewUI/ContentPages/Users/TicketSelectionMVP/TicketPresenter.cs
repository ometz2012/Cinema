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
                TicketView.Model.CityList = new List<CityLine>();
                //Running loop in order to remove repeation of cities in the list
                foreach (var item in ListOfCities)
                {
                    if(!ListOfCitiesRevised.Contains(item))
                    {
                        ListOfCitiesRevised.Add(item);
                    }
                }

                TicketView.Model.CityList = new List<CityLine>();
                //Adding first value to CityList that will be dispalyed
                CityLine row1 = new CityLine();
                row1.CityID = "None";
                row1.CityName = "Select city...";
                TicketView.Model.CityList.Add(row1);
                //Loop to transfer data from City Revised to List that will be displayed= List<CityLine> 
                foreach (var item in ListOfCitiesRevised)
                {
                    CityLine row = new CityLine();
                    row.CityID = item;
                    row.CityName = item;
                    TicketView.Model.CityList.Add(row);
                }

                
                
            }
        }

        //Method that processes the City Selection
        private void CitySelection(SelectedParamterArgs esp)
        {
            IUser UserServices = new UserServices();
            IList <UserTheaterDTO> ListOfTheters = new List<UserTheaterDTO>();
            String SelectedCity = esp.SelectedValue;
            String SelectedMovie = esp.OptionalSlectedValue;
            int movieID = int.Parse(SelectedMovie);
            ListOfTheters = UserServices.GetTheatersByCity(SelectedCity,movieID);
            TicketView.Model.TheaterList = new List<TheaterLine>();
            foreach (var item in ListOfTheters)
            {
                TheaterLine row = new TheaterLine();
                row.TheaterID = item.TheaterID.ToString();
                row.TheaterName = item.TheaterName;
                row.Address = item.TheaterAddress;
                TicketView.Model.TheaterList.Add(row);
            }

        }

        //Method that processes Theater selection
        private void TheaterSelection(SelectedParamterArgs esp)
        {
            IUser UserServices = new UserServices();
            IList<UserPerformanceDTO> ListOfPerformances = new List<UserPerformanceDTO>();

            Guid TheaterID = new Guid();
            String SelectedTheaterID = esp.SelectedValue;
            bool isGuid = Guid.TryParse(SelectedTheaterID, out TheaterID);

            int movieID = 0;
            String SelectedMovieID = esp.OptionalSlectedValue;
            bool isInt = int.TryParse(SelectedMovieID, out movieID);

            if (isGuid&&isInt)
            {
                ListOfPerformances = UserServices.GetPerformancesByTheaterIDandMovieID(TheaterID, movieID);
                TicketView.Model.PerformanceList = new List<PerformanceLine>();
                foreach (var item in ListOfPerformances)
                {
                    PerformanceLine row = new PerformanceLine();
                    row.PerformanceID = item.performanceID.ToString();
                    row.PerformaceDate = item.Date;
                    row.StartingTime = item.StartingTime;
                    row.Duration = item.Duration;
                    row.Price = item.price.ToString();
                    TicketView.Model.PerformanceList.Add(row);
                }
            }


        }

        //Method that processes Performance selection and redirects to payment
        private void PerformanceSelection(SelectedParamterArgs esp)
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
    

    // --------EventArgs-------------------------

    public class SelectedParamterArgs : EventArgs
    {
        public String SelectedValue { get; set; }
        public String OptionalSlectedValue { get; set; }
        public SelectedParamterArgs(string selectedValue)
        {
            this.SelectedValue = selectedValue;
        }
        public SelectedParamterArgs(string selectedValue, string optionalSelectedValue)
        {
            this.SelectedValue = selectedValue;
            this.OptionalSlectedValue = optionalSelectedValue;
        }
    }

    

}