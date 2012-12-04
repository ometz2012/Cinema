using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ometz.Cinema.BLL.MoviePeople;


namespace Ometz.Cinema.NewUI.ContentPages.MoviePeople.Composers
{
    public partial class ComposersInMovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PeopleInMovie1.SetLabelText("Composers in " + "\"" + Request.QueryString["movieTitle"] + "\"" + " Movie");

            }
            switch (Request.QueryString["selector"])
            {
                case "composersInMovie":
                    ComposersInMovieHandler();
                    break;
                case "composerFoundByName":
                    PeopleInMovie1.SetLabelText("Composer's Full Information");
                    ComposerFoundByNameHandler();
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
                    PeopleInMovie1.SetLabelText("Composer's Full Information");
                }
            }
        }
        private void ComposersInMovieHandler()
        {
            MoviePeopleServices composers = new MoviePeopleServices();
            GridView composersInMovie = new GridView();
            composersInMovie = PeopleInMovie1.gridPeopleInMovie;
            int movieId = Convert.ToInt32(Request.QueryString["movieId"]);
            List<MoviePersonDTO> person;
            person = composers.GetMoviePeopleByMovieId(movieId, "Composer");
            if (person != null)
            {
                composersInMovie.DataSource = person;
                composersInMovie.DataBind();
                GetAppropriateView(composersInMovie);
            }
            else
                return;
        }
        private void ComposerFoundByNameHandler()
        {
            MoviePeopleServices personInfo = new MoviePeopleServices();
            List<MoviePersonDTO> composerToShow = new List<MoviePersonDTO>();
            MoviePersonDTO composer = personInfo.GetMoviePersonByName(Request.QueryString["personToShow"].ToString(), "Composer");
            if (composer != null)
            {

                Guid personId = personInfo.GetMoviePersonIdByFirstAndLastName(composer.FirstName, composer.LastName);
                composerToShow.Add(composer);
                ShowPersonFullInfo(composerToShow, personId);

            }

        }

        private void GetPersonInfo(string firstName, string lastName)
        {
            MoviePeopleServices personInfo = new MoviePeopleServices();
            List<MoviePersonDTO> composerToShow = new List<MoviePersonDTO>();
            MoviePersonDTO composer = personInfo.GetMoviePersonByName(firstName + " " + lastName, "Composer");
            Guid personId = personInfo.GetMoviePersonIdByFirstAndLastName(firstName, lastName);
            composerToShow.Add(composer);
            ShowPersonFullInfo(composerToShow, personId);
        }
        private void ShowPersonFullInfo(List<MoviePersonDTO> composerToShow, Guid personId)
        {
            GridView composerFoundByName = new GridView();
            composerFoundByName = PeopleInMovie1.gridPeopleInMovie;
            composerFoundByName.DataSource = composerToShow;
            composerFoundByName.DataBind();
            GetAppropriateView(composerFoundByName);
            PeopleInMovie1.PersonImage.ImageUrl = String.Format("~/ContentPages/MoviePeople/MoviePeopleUserControls/MoviePersonPhoto.ashx?personId=" + personId);
            PeopleInMovie1.PersonImage.Visible = true;
            composerFoundByName.HeaderRow.Cells[(int)PeopleInMovie1.SelectButton].Visible = false;
            foreach (GridViewRow row in composerFoundByName.Rows)
            {
                row.Cells[(int)PeopleInMovie1.SelectButton].Visible = false;
            }
        }
        private void GetAppropriateView(GridView actorsGrid)
        {            
            foreach (GridViewRow row in actorsGrid.Rows)
            {                
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