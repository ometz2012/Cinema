using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ometz.Cinema.BLL.Addresses;
using Ometz.Cinema.BLL.Theaters;

namespace Ometz.Cinema.UI.ContentPages.Theaters.TheaterSearchMVP
{
	public partial class TheaterSearchControl : System.Web.UI.UserControl,ITheaterSearchView
	{

		
		public event DataLoadHandler LoadData;
		public event LoadCityHandler LoadCity;
		public event LoadTheatersHandler LoadTheaters;

		public TheaterSearchPresenter Presenter { get; set; }
		public TheaterSearchModel Model { get; set; }

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			this.Model = new TheaterSearchModel();
			this.Presenter = new TheaterSearchPresenter(this);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (this.LoadData != null)
				{
					var ex = new EventArgs();
					
					LoadCity(ex);
					ddlCity.DataSource = Model.ListOfCities;
					ddlCity.DataBind();
					ddlCity.Items.Insert(0, new ListItem("<-Choose City->", ""));

				}
			}
		
			ViewState["City"] = ddlCity.SelectedValue.ToString();
		}

		protected void btnSearch_Click(object sender, EventArgs e)
		{
			string city = ViewState["City"].ToString();
			LoadTheaters(city);

			GridViewTheaterList.DataSource = Model.ListOfTheaters;
			GridViewTheaterList.Columns[0].Visible = true;
			GridViewTheaterList.DataBind();
			GridViewTheaterList.Columns[0].Visible = false;
		}

		protected void GridViewTheaterList_SelectedIndexChanged(object sender, EventArgs e)
		{
				GridViewTheaterList.Columns[0].Visible = true;
				string theaterID = GridViewTheaterList.SelectedRow.Cells[0].Text;
				Response.Redirect("~/ContentPages/Theaters/TheaterInfo.aspx?TheaterID=" + theaterID);
			
		}
		
	}
}