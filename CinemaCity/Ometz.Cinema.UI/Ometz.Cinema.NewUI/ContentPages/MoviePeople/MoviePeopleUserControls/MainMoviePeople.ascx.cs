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
            //if (!IsPostBack)
            //{
            //    btnSearchPersonByName.Visible = false;
            //}
           
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

        //public GridView GridPersonName
        //{
        //    get { return this.gridPersonName; }
        //}

        public Label lblSearchMoviePersonType
        {
            get { return this.lblSearchByMovieName; }
            set {  }
        }
        public Label lblSearchMoviePersonByName
        {
            get { return this.lblSearchByPersonName; }
            set { }
        }
        public TextBox SearchPersonByName
        {
            get { return txtSearchPersonByName; }
            set { }
        }
        //public Button SearchPersonByNameButton
        //{
        //    get { return btnSearchPersonByName; }
        //    set { }
        //}
        public void SetLabelText(string messageMovieTitle, string messagePersonName)
        {          
            lblSearchMoviePersonType.Text = messageMovieTitle;
            lblSearchByPersonName.Text = messagePersonName;
        }

        protected void txtSearchPersonByName_TextChanged(object sender, EventArgs e)
        {

        }
       

       
        }
      
    }
