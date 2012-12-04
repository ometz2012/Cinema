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
                RepeaterMovie.DataSource = listmovie.GetAllMovies();
                RepeaterMovie.DataBind();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}