using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ometz.Cinema.BLL.Movies;

namespace Ometz.Cinema.UI.ContentPages.MoviePeople.Actors
{
    public partial class ActorMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MainMoviePeople1.SetLabelText("Search Actors by Movie Title");
            }
            MovieServices movieList = new MovieServices();
            GridView MovieGrid = new GridView();
            MovieGrid = MainMoviePeople1.GridMovieList;
            MovieGrid.DataSource = movieList.GetAllMovies();
            MovieGrid.DataBind();
            GetAppropriateView(MovieGrid);
           

        }
        protected override void OnPreRender(EventArgs e)
        {
            if (IsPostBack)
            {
                int movieId = Convert.ToInt32(MainMoviePeople1.GridMovieList.SelectedRow.Cells[(int)MainMoviePeople1.MovieId].Text);
                string movieTitle = MainMoviePeople1.GridMovieList.SelectedRow.Cells[(int)MainMoviePeople1.Title].Text;
                string url = "ActorsInMovie.aspx?movieId=" + movieId +"&movieTitle=" + movieTitle;
                Response.Redirect(url);
            }
        }
        private void GetAppropriateView(GridView movies)
        {
            movies.HeaderRow.Cells[(int)MainMoviePeople1.MovieId].Visible = false;
            foreach (GridViewRow row in movies.Rows )
            {
                row.Cells[(int)MainMoviePeople1.MovieId].Visible = false;
            }
        }
        
    }
}