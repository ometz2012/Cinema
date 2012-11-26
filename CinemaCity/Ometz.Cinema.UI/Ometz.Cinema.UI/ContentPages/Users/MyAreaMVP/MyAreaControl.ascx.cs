using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ometz.Cinema.UI.ContentPages.Users.MyAreaMVP
{
    public partial class MyAreaControl : System.Web.UI.UserControl, IMyAreaView
    {
         public event DataLoadHandler LoadData;

         public MyAreaPresenter Presenter { get; set; }
         public MyAreaModel Model { get; set; }

         protected override void OnInit(EventArgs e)
         {
             base.OnInit(e);

             this.Model = new MyAreaModel();
             this.Presenter = new MyAreaPresenter(this);
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
               // Label1.Text = "it works, yeah!!!!";

                GridViewComments.DataSource = Model.ListOfComments;
                GridViewComments.DataBind();

                GridViewRating.DataSource = Model.ListOfRatings;
                GridViewRating.DataBind();

                GridViewFavorite.DataSource = Model.ListOfFavorites;
                GridViewFavorite.DataBind();

               


            }
        }
    }
}