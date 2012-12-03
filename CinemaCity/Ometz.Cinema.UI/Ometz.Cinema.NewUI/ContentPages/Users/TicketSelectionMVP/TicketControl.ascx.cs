using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ometz.Cinema.UI.ContentPages.Users.TicketSelectionMVP
{
    public partial class TicketControl : System.Web.UI.UserControl, ITicketView
    {
        public event DataLoadHandler LoadData;
        public event MovieSelectionHandler MovieSelection;
        public event MovieIsSelectedHadler MovieWasSelected;
        public event CitySelectionHandler CitySelection;
        public event TheaterSelectionHandler TheaterSelection;
        public event PerformanceSelectionHandler PerformanceSelection;


        public TicketModel Model { get; set; }
        public TicketPresenter Presenter { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.Model = new TicketModel();
            this.Presenter = new TicketPresenter(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (LoadData != null)
                {
                    var ex = new EventArgs();
                    LoadData(ex);
                    ListBoxMovies.DataSource = this.Model.MovieList;
                    ListBoxMovies.DataTextField = "MovieTitle";
                    ListBoxMovies.DataValueField = "MovieID";
                    ListBoxMovies.DataBind();
                    //lblMovieDescription.Text = this.Model.MovieDescription;

                }
            }
        }

        //Method that takes the selected movie and presents movie description
        protected void MovieListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String SlectedMovieID = ListBoxMovies.SelectedItem.Value.ToString();
            SelectedParamterArgs esp = new SelectedParamterArgs(SlectedMovieID);
            if (MovieSelection != null)
            {
                MovieSelection(esp);
                //lblMovieDescription.Text = Model.MovieDescription;
                inputContainer.InnerText = Model.MovieDescription;
            }
        }

        //This method peresents list of cities according to movie choice
        protected void btnSelectMovie_Click(object sender, EventArgs e)
        {
            String SelectedMovieID = ListBoxMovies.SelectedItem.Value.ToString();
            String SelectedMovieName = ListBoxMovies.SelectedItem.Text;
            SelectedParamterArgs esp = new SelectedParamterArgs(SelectedMovieID);
            if (MovieWasSelected != null)
            {
                MovieWasSelected(esp);
                ddlCityList.DataSource = Model.CityList;
                ddlCityList.DataBind();
                lblMovie.Text = "Selected movie: ";
                lblSelectedMovie.Text = string.Format("{0}.", SelectedMovieName);
                lblMovieID.Text = SelectedMovieID;
                //btnSelectMovie.Enabled = false;
            }
        }

        //This method presents List of theaters according to city and movie choice
        protected void ddlCityList_SelectedIndexChanged(object sender, EventArgs e)
        {
            String SelectedCity = ddlCityList.SelectedItem.Value.ToString();
            String SelectedMovie = lblMovieID.Text;
            if (SelectedCity != "None")
            {
                SelectedParamterArgs esp = new SelectedParamterArgs(SelectedCity, SelectedMovie);
                if (CitySelection != null)
                {
                    CitySelection(esp);
                    GridViewTheater.DataSource = Model.TheaterList;
                    GridViewTheater.DataBind();
                    lblCity.Text = "Selected city: ";
                    lblSelectedCity.Text = string.Format("{0}.", SelectedCity);
                    btnSelectMovie.Enabled = false;
                }
            }

        }


        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ContentPages/Users/TicketSelection.aspx");
            btnSelectMovie.Enabled = true;
            ddlCityList.Enabled = true;
        }


        //Working with GridViewTheater - making ID colomn invisible and extracting the data
        #region GridViewTheater
        protected void GridViewTheater_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
            }

        }

        protected void GridViewTheater_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridViewTheater.Rows[index];

                String SelectedTheaterID = row.Cells[0].Text;
                String SelectedTheaterName = row.Cells[1].Text;

                String SelectedMovieID = lblMovieID.Text;

                SelectedParamterArgs esp = new SelectedParamterArgs(SelectedTheaterID, SelectedMovieID);
                if (TheaterSelection != null)
                {
                    TheaterSelection(esp);
                    GridViewPerformance.DataSource = Model.PerformanceList;
                    GridViewPerformance.DataBind();
                    lblTheater.Text = "Selected Theater: ";
                    lblSelectedTheater.Text = string.Format("{0}.", SelectedTheaterName);
                    ddlCityList.Enabled = false;
                }

            }
        }
        #endregion


        //GridViewPerformance - creating ID colomn as hidden and extracting the data
        #region GridViewPerformance

        protected void GridViewPerformance_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
            }

        }

        protected void GridViewPerformance_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = GridViewPerformance.Rows[index];

            String SelectedPerformanceID = row.Cells[0].Text;

            string path = string.Format("~/ContentPages/Users/Payment.aspx?PerformanceID={0}", SelectedPerformanceID);
            Response.Redirect(path);


        }

        #endregion






    }
}