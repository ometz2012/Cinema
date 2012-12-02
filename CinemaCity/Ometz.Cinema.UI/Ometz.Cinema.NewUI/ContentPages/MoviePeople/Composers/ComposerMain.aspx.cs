using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ometz.Cinema.BLL.Movies;
using Ometz.Cinema.BLL.MoviePeople;

namespace Ometz.Cinema.NewUI.ContentPages.MoviePeople.Composers
{
    public partial class ComposerMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MainMoviePeople1.SetLabelText("Search Composers by Movie Title", "Search Composer by Name");
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
                if (MainMoviePeople1.GridMovieList.SelectedIndex > -1)
                {
                    int movieId = Convert.ToInt32(MainMoviePeople1.GridMovieList.SelectedRow.Cells[(int)MainMoviePeople1.MovieId].Text);
                    string movieTitle = MainMoviePeople1.GridMovieList.SelectedRow.Cells[(int)MainMoviePeople1.Title].Text;
                    string url = "ComposersInMovie.aspx?movieId=" + movieId + "&movieTitle=" + movieTitle + "&selector=composersInMovie";
                    Response.Redirect(url);
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (MainMoviePeople1.SearchPersonByName.Text == "")
            {
                return;
            }


            MoviePeopleServices personInfo = new MoviePeopleServices();
            string personToShow = MainMoviePeople1.SearchPersonByName.Text;
            string url = "ComposersInMovie.aspx?personToShow=" + personToShow + "&selector=composerFoundByName";
            Response.Redirect(url);
            MainMoviePeople1.SearchPersonByName.Text = "";
        }

        private void GetAppropriateView(GridView movies)
        {
            movies.HeaderRow.Cells[(int)MainMoviePeople1.MovieId].Visible = false;
            movies.HeaderRow.Cells[(int)MainMoviePeople1.Description].Visible = false;
            movies.HeaderRow.Cells[(int)MainMoviePeople1.Year].Visible = false;
            movies.HeaderRow.Cells[(int)MainMoviePeople1.GenreName].Visible = false;
            foreach (GridViewRow row in movies.Rows)
            {
                row.Cells[(int)MainMoviePeople1.MovieId].Visible = false;
                row.Cells[(int)MainMoviePeople1.Description].Visible = false;
                row.Cells[(int)MainMoviePeople1.Year].Visible = false;
                row.Cells[(int)MainMoviePeople1.GenreName].Visible = false;
            }
        }
    }
}