using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ometz.Cinema.BLL.MoviePeople;


namespace Ometz.Cinema.NewUI.ContentPages.MoviePeople.Producers
{
    public partial class ProducersInMovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PeopleInMovie1.SetLabelText("Producer(s) in " + "\"" + Request.QueryString["movieTitle"] + "\"" + " Movie");

            }
            switch (Request.QueryString["selector"])
            {
                case "producersInMovie":
                   ProducersInMovieHandler();
                    break;
                case "producerFoundByName":
                    PeopleInMovie1.SetLabelText("Producer's Full Information");
                    producerFoundByNameHandler();
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
                    PeopleInMovie1.SetLabelText("Producer's Full Information");
                }
            }
        }
        private void ProducersInMovieHandler()
        {
            MoviePeopleServices producers = new MoviePeopleServices();
            GridView producersInMovie = new GridView();
            producersInMovie = PeopleInMovie1.gridPeopleInMovie;
            int movieId = Convert.ToInt32(Request.QueryString["movieId"]);
            List<MoviePersonDTO> person;
            person = producers.GetMoviePeopleByMovieId(movieId, "Producer");
            if (person != null)
            {
                producersInMovie.DataSource = person;
                producersInMovie.DataBind();
                GetAppropriateView(producersInMovie);
            }
            else
                return;
        }
        private void producerFoundByNameHandler()
        {
            MoviePeopleServices personInfo = new MoviePeopleServices();
            List<MoviePersonDTO> producerToShow = new List<MoviePersonDTO>();
            MoviePersonDTO producer = personInfo.GetMoviePersonByName(Request.QueryString["personToShow"].ToString(), "Producer");
            if (producer != null)
            {

                Guid personId = personInfo.GetMoviePersonIdByFirstAndLastName(producer.FirstName, producer.LastName);
               producerToShow.Add(producer);
                ShowPersonFullInfo(producerToShow, personId);

            }

        }

        private void GetPersonInfo(string firstName, string lastName)
        {
            MoviePeopleServices personInfo = new MoviePeopleServices();
            List<MoviePersonDTO> actorToShow = new List<MoviePersonDTO>();
            MoviePersonDTO actor = personInfo.GetMoviePersonByName(firstName + " " + lastName, "Producer");
            Guid personId = personInfo.GetMoviePersonIdByFirstAndLastName(firstName, lastName);
            actorToShow.Add(actor);
            ShowPersonFullInfo(actorToShow, personId);
        }
        private void ShowPersonFullInfo(List<MoviePersonDTO> producerToShow, Guid personId)
        {
            GridView producerFoundByName = new GridView();
            producerFoundByName = PeopleInMovie1.gridPeopleInMovie;
            producerFoundByName.DataSource = producerToShow;
            producerFoundByName.DataBind();
            GetAppropriateView(producerFoundByName);
            PeopleInMovie1.PersonImage.ImageUrl = String.Format("~/ContentPages/MoviePeople/MoviePeopleUserControls/MoviePersonPhoto.ashx?personId=" + personId);
            PeopleInMovie1.PersonImage.Visible = true;
            producerFoundByName.HeaderRow.Cells[(int)PeopleInMovie1.SelectButton].Visible = false;
            foreach (GridViewRow row in producerFoundByName.Rows)
            {
                row.Cells[(int)PeopleInMovie1.SelectButton].Visible = false;
            }
        }
        private void GetAppropriateView(GridView producersGrid)
        {
            //  actorsGrid.HeaderRow.Cells[(int)PeopleInMovie2.SelectButton].Visible = false;
            foreach (GridViewRow row in producersGrid.Rows)
            {
                // row.Cells[(int)PeopleInMovie2.SelectButton].Visible = false;
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