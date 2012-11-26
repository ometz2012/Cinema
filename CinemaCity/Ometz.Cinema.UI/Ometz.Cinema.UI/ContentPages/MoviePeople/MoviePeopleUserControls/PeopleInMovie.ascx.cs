using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ometz.Cinema.UI.ContentPages.MoviePeople.MoviePeopleUserControls
{
    public enum PersonInMovie {selectButton, firstName, lastName, birthDate, birthPlace };

    public partial class PeopleInMovie : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public PersonInMovie SelectButton
        {
            get { return PersonInMovie.selectButton; }
        }

        public PersonInMovie FirstName
        {
            get { return PersonInMovie.firstName; }
        }

        public PersonInMovie LastName
        {
            get { return PersonInMovie.lastName; }
        }

        public PersonInMovie BirthDate
        {
            get { return PersonInMovie.birthDate; }
         }

        public PersonInMovie BirthPlace
        {
            get { return PersonInMovie.birthPlace; }
        }

        public Label labelPeopleInMovie
        {
            get { return this.lblPersonInMovie; }
            set { }
        }

        public void SetLabelText(string message)
        {
           labelPeopleInMovie.Text = message;
        }

        public GridView gridPeopleInMovie
        {
            get { return this.gridPersonInMovie; }
            set { }
        }
    }
}