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
        public event PageReset PageReset;

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
                    ListBoxMovies.DataSource =this.Model.MovieList;
                    ListBoxMovies.DataTextField = "MovieTitle";
                    ListBoxMovies.DataValueField = "MovieID";
                    ListBoxMovies.DataBind();
                    lblMovieDescription.Text = this.Model.MovieDescription;
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
                lblMovieDescription.Text = Model.MovieDescription;
            }
        }

        protected void btnSelectMovie_Click(object sender, EventArgs e)
        {
            String SlectedMovieID = ListBoxMovies.SelectedItem.Value.ToString();
            String SelectedMovieName= ListBoxMovies.SelectedItem.Text;
            SelectedParamterArgs esp = new SelectedParamterArgs(SlectedMovieID);
            if (MovieWasSelected != null)
            {
                MovieWasSelected(esp);
                ddlCityList.DataSource = Model.CityList;
                ddlCityList.DataBind();
                lblMovie.Text = "Selected movie: ";
                lblSelectedMovie.Text = string.Format("{0}.", SelectedMovieName);
                //btnSelectMovie.Enabled = false;
            }
        }

        protected void ddlCityList_SelectedIndexChanged(object sender, EventArgs e)
        {
            String SelectedCity = ddlCityList.SelectedItem.Text;
            SelectedParamterArgs esp = new SelectedParamterArgs(SelectedCity);
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

        protected void GridViewTheater_SelectedIndexChanged(object sender, EventArgs e)
        {
            String SelectedTheaterID = GridViewTheater.SelectedRow.Cells[0].Text;
            String SelectedTheaterName=GridViewTheater.SelectedRow.Cells[1].Text;
            SelectedParamterArgs esp = new SelectedParamterArgs(SelectedTheaterID);
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

        protected void GridViewPerformance_SelectedIndexChanged(object sender, EventArgs e)
        {
            String SelectedPerformanceID = GridViewPerformance.SelectedRow.Cells[0].Text;
            SelectedParamterArgs esp = new SelectedParamterArgs(SelectedPerformanceID);
            if (PerformanceSelection != null)
            {
                PerformanceSelection(esp);
            }
        }


        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (PageReset != null)
            {
                EventArgs ex = new EventArgs();
                PageReset(ex);
            }
            btnSelectMovie.Enabled = true;
            ddlCityList.Enabled = true;
        }

   

     




    }
}