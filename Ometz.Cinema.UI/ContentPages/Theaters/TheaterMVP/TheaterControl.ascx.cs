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



	//	[Guid("4531D5B6-268C-4AB3-81EB-57D0845E21DF")]

	 protected void Page_Load(object sender, EventArgs e)
	 {
		 if (!IsPostBack)
		 {
			 if (this.LoadData != null)
			 {
				 var ex = new EventArgs();
				 LoadData(ex);
			 }

			 Label1.Text = "it works, yeah!!!!";


			 string theat = Session["TheaterID"].ToString();
			 Guid theaterId = new Guid();
				theaterId= Guid.Parse(theat);
			  
			 

			 TheaterServices showTheater=new TheaterServices();
			 TheaterModelDTO currentTheater = new TheaterModelDTO();
			 currentTheater = showTheater.GetTheater(theaterId);

			 lblName.Text = currentTheater.Name;

			 
			 AddressServices showAddress = new AddressServices();
			 AddressModelDTO currentAddress = new AddressModelDTO();

			 currentAddress=showAddress.GetAddress(theaterId);

			 lblAddressLine1.Text = currentAddress.AddressLine1;
			 lblCity.Text = currentAddress.City;
			 lblCountry.Text = currentAddress.Country;
			 lblEmail.Text = currentAddress.Email;
			 lblPhone.Text = currentAddress.Phone;
			 lblPostalCode.Text = currentAddress.PostalCode;
			 lblProvince.Text = currentAddress.Province;

			 PerformanceServices showAllPerformances=new PerformanceServices();

			 GridViewPerformance.DataSource = showAllPerformances.GetPerformances(theaterId);
			 GridViewPerformance.DataBind();

			 
		 }

	 }
	}
	}
