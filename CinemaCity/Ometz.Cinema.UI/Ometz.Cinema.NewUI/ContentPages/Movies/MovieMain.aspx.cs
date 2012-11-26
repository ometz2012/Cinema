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
    public partial class MovieMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MovieServices listmovie = new MovieServices();
            MoviePeopleServices castlist = new MoviePeopleServices();

            ddlTitleMovie.DataSource = listmovie.GetAllMovies();
            ddlTitleMovie.DataBind();

            ddlYearMovie.DataSource = listmovie.GetAllYears();
            ddlYearMovie.DataBind();

            ddlActorMovie.DataSource = castlist.GetActors();
            ddlActorMovie.DataBind();

            ddlProducerMovie.DataSource = castlist.GetProducers();
            ddlProducerMovie.DataBind();

            //genre to bind

            //repeater to bind
            //RepeaterMovie.DataSource = listmovie.GetMovies();
            //RepeaterMovie.DataBind();
        }
    }
}