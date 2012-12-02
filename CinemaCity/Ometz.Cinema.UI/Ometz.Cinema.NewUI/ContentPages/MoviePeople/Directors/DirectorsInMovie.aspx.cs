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
        protected override void OnPreRender(EventArgs e)
        {
            if (IsPostBack)
            {
                if (PeopleInMovie1.gridPeopleInMovie.SelectedIndex > -1)
                {
                    GetPersonInfo(PeopleInMovie1.gridPeopleInMovie.SelectedRow.Cells[(int)PeopleInMovie1.FirstName].Text,
                        PeopleInMovie1.gridPeopleInMovie.SelectedRow.Cells[(int)PeopleInMovie1.LastName].Text);
                    PeopleInMovie1.SetLabelText("Director's Full Information");
                }
            }
        }
        private void DirectorsInMovieHandler()
        {
            MoviePeopleServices directors = new MoviePeopleServices();
            GridView directorsInMovie = new GridView();
            directorsInMovie = PeopleInMovie1.gridPeopleInMovie;
            int movieId = Convert.ToInt32(Request.QueryString["movieId"]);
            List<MoviePersonDTO> person;
            person = directors.GetMoviePeopleByMovieId(movieId, "Director");
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
               List<MoviePersonDTO> directorToShow = new List<MoviePersonDTO>();
               MoviePersonDTO director = personInfo.GetMoviePersonByName(Request.QueryString["personToShow"].ToString(), "Director");
               if (director != null)
               {
                   Guid personId = personInfo.GetMoviePersonIdByFirstAndLastName(director.FirstName, director.LastName);
                   directorToShow.Add(director);
                   ShowPersonFullInfo(directorToShow, personId);
                   //GridView directorFoundByName = new GridView();
                   //directorFoundByName = PeopleInMovie1.gridPeopleInMovie;
                   //directorFoundByName.DataSource = directorToShow;
                   //directorFoundByName.DataBind();
                   //GetAppropriateView(directorFoundByName);
                   //PeopleInMovie1.PersonImage.ImageUrl = String.Format("~/ContentPages/MoviePeople/MoviePeopleUserControls/MoviePersonPhoto.ashx?personId=" + personId);
               }
               //actorToShow.Add(Request.QueryString["personToShow"]);
        }

        private void GetPersonInfo(string firstName, string lastName)
        {
            MoviePeopleServices personInfo = new MoviePeopleServices();
            List<MoviePersonDTO> directorToShow = new List<MoviePersonDTO>();
            MoviePersonDTO director = personInfo.GetMoviePersonByName(firstName + " " + lastName, "Director");
            Guid personId = personInfo.GetMoviePersonIdByFirstAndLastName(firstName, lastName);
            directorToShow.Add(director);
            ShowPersonFullInfo(directorToShow, personId);
        }

        private void ShowPersonFullInfo(List<MoviePersonDTO> directorToShow, Guid personId)
        {
            GridView actorFoundByName = new GridView();
            actorFoundByName = PeopleInMovie1.gridPeopleInMovie;
            actorFoundByName.DataSource = directorToShow;
            actorFoundByName.DataBind();
            GetAppropriateView(actorFoundByName);
            PeopleInMovie1.PersonImage.ImageUrl = String.Format("~/ContentPages/MoviePeople/MoviePeopleUserControls/MoviePersonPhoto.ashx?personId=" + personId);
            PeopleInMovie1.PersonImage.Visible = true;
            actorFoundByName.HeaderRow.Cells[(int)PeopleInMovie1.SelectButton].Visible = false;
            foreach (GridViewRow row in actorFoundByName.Rows)
            {
                row.Cells[(int)PeopleInMovie1.SelectButton].Visible = false;
            }
        }
        private void GetAppropriateView(GridView directorsGrid)
        {
           // directorsGrid.HeaderRow.Cells[(int)PeopleInMovie1.SelectButton].Visible = false;
            foreach (GridViewRow row in directorsGrid.Rows)
            {
              //  row.Cells[(int)PeopleInMovie1.SelectButton].Visible = false;
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
