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

                List<MovieModelDTO> ListOfAllMovies = new List<MovieModelDTO>();
                ListOfAllMovies = listmovie.GetAllMovies();
                ddlTitleMovie.DataSource = ListOfAllMovies;
                ddlTitleMovie.DataBind();
                ddlTitleMovie.Items.Insert(0, new ListItem("<-Choose Movie->", "0"));
                //-------------------------------------------------------------------------
               
                List<MovieModelDTO>ListOfYears = listmovie.GetAllYears();
               
                List<string> Years = new List<string>();
                foreach (var item in ListOfYears)
                {
                    string year = item.Year;
                    Years.Add(year);
                }
                ddlYearMovie.DataSource = Years.ToList().Distinct();
                ddlYearMovie.DataBind();
                ddlYearMovie.Items.Insert(0, new ListItem("<-Choose Year->", "0"));

                //-----------------------------
                List<MoviePersonDTO> ListOfAcotrs = castlist.GetActors();
          
                ddlActorMovie.DataTextField = "FirstName";
                ddlActorMovie.DataValueField = "LastName";
                ddlActorMovie.DataSource = ListOfAcotrs;
                ddlActorMovie.DataBind();
                ddlActorMovie.Items.Insert(0, new ListItem("<-Choose Actor->", "0"));
                //----------------------------------------------


                List<MoviePersonDTO> ListOfProducers = castlist.GetProducers();
             
                ddlProducerMovie.DataTextField = "FirstName";
                ddlProducerMovie.DataValueField = "LastName";
                ddlProducerMovie.DataSource = ListOfProducers;
                ddlProducerMovie.DataBind();
                ddlProducerMovie.Items.Insert(0, new ListItem("<-Choose Producer->", "0"));
                //-------------------------------------------------------

                //genre to bind
                ddlGenreMovie.DataSource = listmovie.GetAllGenres();
                ddlGenreMovie.DataBind();
                ddlGenreMovie.Items.Insert(0,new ListItem("<-Choose Genre->","0"));


                //repeater to bind
                List<MovieModelDTO> ListOfMovies = new List<MovieModelDTO>();
                ListOfMovies = listmovie.GetAllMovies();
                RepeaterMovie.DataSource = ListOfMovies;
                RepeaterMovie.DataBind();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
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