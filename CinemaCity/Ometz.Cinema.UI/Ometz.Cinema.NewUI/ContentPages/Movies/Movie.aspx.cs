using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ometz.Cinema.BLL.Movies;
using Ometz.Cinema.BLL.MoviePeople;

namespace Ometz.Cinema.NewUI.ContentPages.Movies
{
    public partial class Movie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["MovieID"] != null)
            {
                string selectedMovieID = Request.QueryString["MovieID"];
                int movieID;
                bool isInt = int.TryParse(selectedMovieID, out movieID);
                if (isInt)
                {
                    string pathToImage = string.Format("~/ContentPages/Movies/MoviePhotoHandler.ashx?MovieID={0}", selectedMovieID);
                    imgMoviePicture.ImageUrl = pathToImage;
                    MovieModelDTO SelectedMovie = new MovieModelDTO();
                    MovieServices MovieServices = new MovieServices();
                    SelectedMovie = MovieServices.GetMovieByID(movieID);
                    lblGenreType.Text = SelectedMovie.GenreName;
                    lblMovieTitle.Text = SelectedMovie.Title;
                    blYear.Text = SelectedMovie.Year;
                    lblDescriptionDetails.Text = SelectedMovie.Description;
                    
                }

            }
        }
    }
}