using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ometz.Cinema.BLL.Movies;

namespace Ometz.Cinema.UI.ContentPages.MoviePeople.MoviePeopleUserControls
{
    public enum MovieProperties {SelectButton, MovieId, Title, Description, Year, GenreName };

    public partial class MainMoviePeople : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public MovieProperties SelectButton
        {
            get { return MovieProperties.SelectButton; }
        }
        public MovieProperties MovieId
        {
            get { return MovieProperties.MovieId; }
        }
        public MovieProperties Title
        {
            get { return MovieProperties.Title; }
        }
        public MovieProperties Description
        {
            get { return MovieProperties.Description; }
        }
        public MovieProperties Year
        {
            get { return MovieProperties.Year; }
        }
        public MovieProperties GenreName
        {
            get { return MovieProperties.GenreName; }
        }
        public GridView GridMovieList
        {
            get { return this.gridMovies; }
        }
        public Label lblSearchMoviePersonType
        {
            get { return this.lblSearchByMovieName; }
            set {  }
        }
        public void SetLabelText(string message)
        {
           // lblSearchByMovieName.Text = message;
            lblSearchMoviePersonType.Text = message;
        }
        //public Button SearchByMovieName
        //{
        //    get {return this.btnSearchByMovieName; }
        //    set{}
        }
        //protected void btnSearchByMovieName_Click(object sender, EventArgs e)
        //{
        //    MovieServices moviestoGet = new MovieServices();
        //    GridMovieList.DataSource = moviestoGet.GetAllMovies();
        //    GridMovieList.DataBind();
        //}
    }
