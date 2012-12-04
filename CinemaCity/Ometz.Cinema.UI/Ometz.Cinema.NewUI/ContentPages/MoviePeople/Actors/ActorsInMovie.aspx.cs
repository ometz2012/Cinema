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
            switch(Request.QueryString["selector"])
            {
                case "actorsInMovie":                  
                    ActorsInMovieHandler();
                    break;
                case "actorFoundByName":
                    PeopleInMovie2.SetLabelText("Actor's Full Information");
                    ActorFoundByNameHandler();
                    break;
            }          
          
        }
        protected override void  OnPreRender(EventArgs e)
        {
            if (IsPostBack)
            {
                if (PeopleInMovie2.gridPeopleInMovie.SelectedIndex > -1)
                {
                    GetPersonInfo(PeopleInMovie2.gridPeopleInMovie.SelectedRow.Cells[(int)PeopleInMovie2.FirstName].Text, 
                        PeopleInMovie2.gridPeopleInMovie.SelectedRow.Cells[(int)PeopleInMovie2.LastName].Text);
                    PeopleInMovie2.SetLabelText("Actor's Full Information");
                }   
            }
        }
        private void ActorsInMovieHandler()
        {
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
            else
                return;
        }

        private void ActorFoundByNameHandler()
        {
               MoviePeopleServices personInfo = new MoviePeopleServices();
               List<MoviePersonDTO> actorToShow = new List<MoviePersonDTO>();
               MoviePersonDTO actor = personInfo.GetMoviePersonByName(Request.QueryString["personToShow"].ToString(), "Actor");
               if (actor != null)
               {

                   Guid personId = personInfo.GetMoviePersonIdByFirstAndLastName(actor.FirstName, actor.LastName);
                   actorToShow.Add(actor);
                   ShowPersonFullInfo(actorToShow, personId);
                  
               }
               
        }

        private void GetPersonInfo(string firstName, string lastName)
        {
            MoviePeopleServices personInfo = new MoviePeopleServices();
            List<MoviePersonDTO> actorToShow = new List<MoviePersonDTO>();
            MoviePersonDTO actor = personInfo.GetMoviePersonByName(firstName + " " + lastName, "Actor");
            Guid personId = personInfo.GetMoviePersonIdByFirstAndLastName(firstName, lastName);
            actorToShow.Add(actor);
            ShowPersonFullInfo(actorToShow, personId);
        }
        private void ShowPersonFullInfo(List<MoviePersonDTO> actorToShow, Guid personId)
        {
            GridView actorFoundByName = new GridView();
            actorFoundByName = PeopleInMovie2.gridPeopleInMovie;
            actorFoundByName.DataSource = actorToShow;
            actorFoundByName.DataBind();
            GetAppropriateView(actorFoundByName);
            PeopleInMovie2.PersonImage.ImageUrl = String.Format("~/ContentPages/MoviePeople/MoviePeopleUserControls/MoviePersonPhoto.ashx?personId=" + personId);
            PeopleInMovie2.PersonImage.Visible = true;
            actorFoundByName.HeaderRow.Cells[(int)PeopleInMovie2.SelectButton].Visible = false;
            foreach (GridViewRow row in actorFoundByName.Rows)
            {
                row.Cells[(int)PeopleInMovie2.SelectButton].Visible = false;
            }
        }
        private void GetAppropriateView(GridView actorsGrid)
        {
          //  actorsGrid.HeaderRow.Cells[(int)PeopleInMovie2.SelectButton].Visible = false;
            foreach (GridViewRow row in actorsGrid.Rows)
            {
               // row.Cells[(int)PeopleInMovie2.SelectButton].Visible = false;
                DateTime birthDate = Convert.ToDateTime(row.Cells[(int)PeopleInMovie2.BirthDate].Text);
                string result = birthDate.ToString("d/MM/yyyy");
                if (result == "1/01/9999")
                {
                    result = "Unknown";
                }
                row.Cells[(int)PeopleInMovie2.BirthDate].Text = result;              
            }
        }
    }
}