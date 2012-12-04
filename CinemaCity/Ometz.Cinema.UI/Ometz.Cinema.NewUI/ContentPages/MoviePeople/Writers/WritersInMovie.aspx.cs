using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ometz.Cinema.BLL.MoviePeople;

namespace Ometz.Cinema.NewUI.ContentPages.MoviePeople.Writers
{
    public partial class WritersInMovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PeopleInMovie1.SetLabelText("Writer(s) in " + "\"" + Request.QueryString["movieTitle"] + "\"" + " Movie");

            }
            switch (Request.QueryString["selector"])
            {
                case "writersInMovie":
                    WritersInMovieHandler();
                    break;
                case "writerFoundByName":
                    PeopleInMovie1.SetLabelText("Writer's Full Information");
                    WriterFoundByNameHandler();
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
                    PeopleInMovie1.SetLabelText("Writer's Full Information");
                }
            }
        }
        private void WritersInMovieHandler()
        {
            MoviePeopleServices writers = new MoviePeopleServices();
            GridView writersInMovie = new GridView();
            writersInMovie = PeopleInMovie1.gridPeopleInMovie;
            int movieId = Convert.ToInt32(Request.QueryString["movieId"]);
            List<MoviePersonDTO> person;
            person = writers.GetMoviePeopleByMovieId(movieId, "Writer");
            if (person != null)
            {
                writersInMovie.DataSource = person;
                writersInMovie.DataBind();
                GetAppropriateView(writersInMovie);
            }
            else
                return;
        }

        private void WriterFoundByNameHandler()
        {
            MoviePeopleServices personInfo = new MoviePeopleServices();
            List<MoviePersonDTO> writerToShow = new List<MoviePersonDTO>();
            MoviePersonDTO writer = personInfo.GetMoviePersonByName(Request.QueryString["personToShow"].ToString(), "Writer");
            if (writer != null)
            {

                Guid personId = personInfo.GetMoviePersonIdByFirstAndLastName(writer.FirstName, writer.LastName);
                writerToShow.Add(writer);
                ShowPersonFullInfo(writerToShow, personId);
            }
        }

        private void GetPersonInfo(string firstName, string lastName)
        {
            MoviePeopleServices personInfo = new MoviePeopleServices();
            List<MoviePersonDTO> writerToShow = new List<MoviePersonDTO>();
            MoviePersonDTO writer = personInfo.GetMoviePersonByName(firstName + " " + lastName, "Writer");
            Guid personId = personInfo.GetMoviePersonIdByFirstAndLastName(firstName, lastName);
            writerToShow.Add(writer);
            ShowPersonFullInfo(writerToShow, personId);
        }
        private void ShowPersonFullInfo(List<MoviePersonDTO> actorToShow, Guid personId)
        {
            GridView actorFoundByName = new GridView();
            actorFoundByName = PeopleInMovie1.gridPeopleInMovie;
            actorFoundByName.DataSource = actorToShow;
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
        private void GetAppropriateView(GridView writersGrid)
        {
            //  actorsGrid.HeaderRow.Cells[(int)PeopleInMovie2.SelectButton].Visible = false;
            foreach (GridViewRow row in writersGrid.Rows)
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