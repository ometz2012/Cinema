using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ometz.Cinema.BLL.MoviePeople;

namespace Ometz.Cinema.UI.ContentPages.MoviePeople.Actors
{
    public partial class ActorsInMovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PeopleInMovie2.SetLabelText("Actors in " + "\"" + Request.QueryString["movieTitle"] + "\"" + " Movie");
               
            }
            MoviePeopleServices actors = new MoviePeopleServices();
            GridView actorsInMovie = new GridView();
            actorsInMovie = PeopleInMovie2.gridPeopleInMovie;
            int movieId = Convert.ToInt32(Request.QueryString["movieId"]);
            List<MoviePersonDTO> person;
            person = actors.GetMoviePeopleByMovieId(movieId, "Actor");
            if (person != null)
            {
                actorsInMovie.DataSource = person;
                actorsInMovie.DataBind();
                GetAppropriateView(actorsInMovie);
            }
           // actorsInMovie.DataSource = actors.GetMoviePeopleByMovieId(movieId, "Actor");
          
        }
        private void GetAppropriateView(GridView actorsGrid)
        {
            actorsGrid.HeaderRow.Cells[(int)PeopleInMovie2.SelectButton].Visible = false;
            foreach (GridViewRow row in actorsGrid.Rows)
            {
                row.Cells[(int)PeopleInMovie2.SelectButton].Visible = false;
            }
        }
    }
}