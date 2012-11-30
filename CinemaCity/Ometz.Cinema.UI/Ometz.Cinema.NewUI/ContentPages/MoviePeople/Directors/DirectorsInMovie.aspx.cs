using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ometz.Cinema.BLL.MoviePeople;

namespace Ometz.Cinema.NewUI.ContentPages.MoviePeople.Directors
{
    public partial class DirectorsInMovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {             
            if (!IsPostBack)
            {
                PeopleInMovie1.SetLabelText("Directors in " + "\"" + Request.QueryString["movieTitle"] + "\"" + " Movie");
               
            }
            switch(Request.QueryString["selector"])
            {
                case "directorInMovie":
                    DirectorsInMovieHandler();
                    break;
                case "directorFoundByName":
                    PeopleInMovie1.SetLabelText("Director Full Information");
                    DirectorFoundByNameHandler();
                    break;
            }          
          
        }
        private void DirectorsInMovieHandler()
        {
            MoviePeopleServices actors = new MoviePeopleServices();
            GridView directorsInMovie = new GridView();
            directorsInMovie = PeopleInMovie1.gridPeopleInMovie;
            int movieId = Convert.ToInt32(Request.QueryString["movieId"]);
            List<MoviePersonDTO> person;
            person = actors.GetMoviePeopleByMovieId(movieId, "Director");
            if (person != null)
            {
                directorsInMovie.DataSource = person;
                directorsInMovie.DataBind();
                GetAppropriateView(directorsInMovie);
            }
            else
                return;
        }
        private void DirectorFoundByNameHandler()
        {
               MoviePeopleServices personInfo = new MoviePeopleServices();
               List<MoviePersonDTO> actorToShow = new List<MoviePersonDTO>();
               MoviePersonDTO actor = personInfo.GetMoviePersonByName(Request.QueryString["personToShow"].ToString(), "Director");
               if (actor != null)
               {
                   actorToShow.Add(actor);
                   GridView actorFoundByName = new GridView();
                   actorFoundByName = PeopleInMovie1.gridPeopleInMovie;
                   actorFoundByName.DataSource = actorToShow;
                   actorFoundByName.DataBind();
                   GetAppropriateView(actorFoundByName);

               }
               //actorToShow.Add(Request.QueryString["personToShow"]);
        }
        private void GetAppropriateView(GridView actorsGrid)
        {
            actorsGrid.HeaderRow.Cells[(int)PeopleInMovie1.SelectButton].Visible = false;
            foreach (GridViewRow row in actorsGrid.Rows)
            {
                row.Cells[(int)PeopleInMovie1.SelectButton].Visible = false;
                DateTime birthDate = Convert.ToDateTime(row.Cells[(int)PeopleInMovie1.BirthDate].Text);
                string result = birthDate.ToString("d/MM/yyyy");
                if (result == "1/01/9999")
                {
                    result = "Unknown";
                }
                row.Cells[(int)PeopleInMovie1.BirthDate].Text = result;              
            }
        }
        }
    }
