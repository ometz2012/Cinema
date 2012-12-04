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
                ddlTitleMovie.DataTextField = "Title";
                ddlTitleMovie.DataValueField = "MovieId";              
                ddlTitleMovie.DataBind();
                ddlTitleMovie.Items.Insert(0, new ListItem("<Select Movie>", "0"));

                ddlYearMovie.DataSource = listmovie.GetAllYears();               
                ddlYearMovie.DataTextField = "Year";                
                ddlYearMovie.DataBind();
                ddlYearMovie.Items.Insert(0, new ListItem("<Select>", "0"));

                ddlActorMovie.DataSource = castlist.GetActors();
                ddlActorMovie.DataTextField = "FirstName";
                ddlActorMovie.DataBind();
                ddlActorMovie.Items.Insert(0, new ListItem("<Select>", "0"));
                    
                ddlProducerMovie.DataSource = castlist.GetProducers();
                ddlProducerMovie.DataTextField = "FirstName";
                ddlProducerMovie.DataBind();
                ddlProducerMovie.Items.Insert(0, new ListItem("<Select>", "0"));
              

                //genre to bind
                ddlGenreMovie.DataSource = listmovie.GetAllGenres();
                ddlGenreMovie.DataTextField = "GenreName";                
                ddlGenreMovie.DataBind();
                ddlGenreMovie.Items.Insert(0, new ListItem("<Select Genre>", "0"));

                //repeater to bind
                RepeaterMovie.DataSource = listmovie.GetAllMovies();
                RepeaterMovie.DataBind();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlGenreMovie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}