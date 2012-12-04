using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ometz.Cinema.BLL.Movies;
using Ometz.Cinema.BLL.MoviePeople;
using System.IO;

namespace Ometz.Cinema.NewUI.ContentPages.Movies
{
    public partial class MovieMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MovieServices listmovie = new MovieServices();
                MoviePeopleServices castlist = new MoviePeopleServices();


                ddlTitleMovie.DataSource = listmovie.GetAllMovies();
                ddlTitleMovie.DataBind();

                ddlYearMovie.DataSource = listmovie.GetAllYears().Distinct();
                ddlYearMovie.DataBind();

                //-----------------------------
                List<MoviePersonDTO> ListOfAcotrs = castlist.GetActors();
                List<MoviePersonDTO> ListOfActorsNames = new List<MoviePersonDTO>();
                foreach (var item in ListOfAcotrs)
                {
                    MoviePersonDTO row = new MoviePersonDTO();
                    row.FullName = string.Format("{0} {1}", item.FirstName, item.LastName);
                    row.LastName = item.LastName;
                    ListOfActorsNames.Add(row);

                }
                ddlActorMovie.DataSource = ListOfActorsNames;
                ddlActorMovie.DataBind();
                //----------------------------------------------


                List<MoviePersonDTO> ListOfProducers = castlist.GetProducers();
                List<MoviePersonDTO> ListOfProducersNames = new List<MoviePersonDTO>();
                foreach (var item in ListOfProducers)
                {
                    MoviePersonDTO row = new MoviePersonDTO();
                    row.FullName=string.Format("{0} {1}", item.FirstName, item.LastName);
                    row.LastName=item.LastName;
                    ListOfProducersNames.Add(row);
                }
                ddlProducerMovie.DataSource = ListOfProducersNames;
                ddlProducerMovie.DataBind();
                //-------------------------------------------------------

                //genre to bind
                ddlGenreMovie.DataSource = listmovie.GetAllGenres();
                ddlGenreMovie.DataBind();


                //repeater to bind
                List<MovieModelDTO> ListOfMovies = new List<MovieModelDTO>();
                ListOfMovies = listmovie.GetAllMovies();
                //List<MovieModelDTO> ListOfMoviesWithPhoto = new List<MovieModelDTO>();
                //foreach (var item in ListOfMovies)
                //{
                //    MovieModelDTO row = new MovieModelDTO();
                //    row.MovieID = item.MovieID;
                //    row.Title = item.Title;
                //    row.Description = item.Description;
                //    MoviePhotoHandler PhotoServices = new MoviePhotoHandler();
                //    row.Photo = PhotoServices.ProcessRequest(item.MovieID);
                //}
                RepeaterMovie.DataSource = ListOfMovies;
                RepeaterMovie.DataBind();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void RepeaterMovie_DataBinding(object sender, EventArgs e)
        {
           
        }

        protected void RepeaterMovie_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            var ctrl = e.Item.FindControl("Img1");
            string movieID=null;

            if (e.Item.DataItem is MovieModelDTO)
            {
                var currentMovie = e.Item.DataItem;
                MovieModelDTO CurrentMovie = new MovieModelDTO();
                CurrentMovie = (MovieModelDTO)currentMovie;
                movieID = CurrentMovie.MovieID.ToString();
            }
            if (ctrl is System.Web.UI.WebControls.Image)
            {
                string path = string.Format("~/ContentPages/Movies/MoviePhotoHandler.ashx?MovieID={0}",movieID);
                ((System.Web.UI.WebControls.Image)ctrl).ImageUrl = path;

            }
        }

        protected void ddlTitleMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            string movieID = ddlTitleMovie.SelectedItem.Value;
            string path=string.Format("~/ContentPages/Movies/Movie.aspx?MovieID={0}",movieID);
            Response.Redirect(path);
        }
    }

    

}