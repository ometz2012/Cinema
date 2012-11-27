using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ometz.Cinema.BLL.Theaters;
using Ometz.Cinema.BLL.Addresses;
using Ometz.Cinema.BLL.Performances;


namespace Ometz.Cinema.UI.ContentPages.Theaters.TheaterMVP
{
	
	public partial class TheaterControl : System.Web.UI.UserControl,ITheaterView
	{
				 public event DataLoadHandler LoadData;

         public TheaterPresenter Presenter { get; set; }
         public TheaterModel Model { get; set; }

   protected override void OnInit(EventArgs e)
         {
             base.OnInit(e);

             this.Model = new TheaterModel();
             this.Presenter = new TheaterPresenter(this);
         }



	 protected void Page_Load(object sender, EventArgs e)
	 {
		 if (!IsPostBack)
		 {
			 if (this.LoadData != null)
			 {
				 string theat = Request.QueryString["TheaterID"];// "4531D5B6-268C-4AB3-81EB-57D0845E21DF";
				 Guid theaterId = new Guid();
				 theaterId = Guid.Parse(theat);
				 LoadData(theaterId);

			 lblName.Text =Model.TheaterName;
			 lblAddressLine1.Text = Model.AddressLine1;
			 lblCity.Text = Model.City;
			 lblCountry.Text = Model.Country;
			 lblEmail.Text = Model.Email;
			 lblPhone.Text = Model.Phone;
			 lblPostalCode.Text = Model.PostalCode;
			 lblProvince.Text = Model.Province;

			 GridViewPerformance.DataSource = Model.ListOfPerformances;
			 GridViewPerformance.DataBind();
			 GridViewPerformance.Columns[0].Visible = false;
			 }
		 }

	 }

	 protected void GridViewPerformance_SelectedIndexChanged(object sender, EventArgs e)
	 {
		 string performanceId = GridViewPerformance.SelectedRow.Cells[0].Text;
		 Response.Redirect("~/ContentPages/Users/Payment.aspx?PerformanceID=" + performanceId);
	 }

	 protected void btnBack_Click(object sender, EventArgs e)
	 {
		 Response.Redirect("~/ContentPages/Theaters/Theater.aspx");
	 }
	 
	}
	}
