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

		//public string theaterID;
		public event DataLoadHandler LoadData;

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
					LoadData(ex);
				}
				
				
			}
		//Session["City"]=ddlCity.SelectedValue.ToString();
			ViewState["City"] = ddlCity.SelectedValue.ToString();
		}

		protected void btnSearch_Click(object sender, EventArgs e)
		{
			
			//string city = Session["City"].ToString();
			string city = ViewState["City"].ToString();
			TheaterServices showTheaters=new TheaterServices();
			GridViewTheaterList.DataSource = showTheaters.GetTheaters(city);
			GridViewTheaterList.DataBind();
			GridViewTheaterList.Columns[0].Visible = false;
		}

		protected void GridViewTheaterList_SelectedIndexChanged(object sender, EventArgs e)
		{
				//Session["TheaterID"] = GridViewTheaterList.SelectedRow.Cells[0].Text;
				string theaterID = GridViewTheaterList.SelectedRow.Cells[0].Text;
				Response.Redirect("~/ContentPages/Theaters/TheaterInfo.aspx?TheaterID=" + theaterID);
			
		}
		
	}
}