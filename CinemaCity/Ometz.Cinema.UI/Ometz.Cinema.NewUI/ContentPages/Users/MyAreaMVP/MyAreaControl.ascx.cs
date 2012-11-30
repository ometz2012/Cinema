using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Ometz.Cinema.UI.ContentPages.Users.MyAreaMVP
{
    public partial class MyAreaControl : System.Web.UI.UserControl, IMyAreaView
    {
        public event DataLoadHandler LoadData;
        public event GridUpdateHandler GridUpdate;
        public event GridUpdateHandler RemoveMovie;

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
                    var ex = new LoadDataArgs();
                    ex.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                    LoadData(ex);
                }
                // Label1.Text = "it works, yeah!!!!";

                GridViewComments.DataSource = Model.ListOfComments;
                //GridViewComments.DataBind();

                GridViewRating.DataSource = Model.ListOfRatings;
                GridViewRating.DataBind();

                GridViewFavorite.DataSource = Model.ListOfFavorites;
                GridViewFavorite.DataBind();




            }
        }

        //GridViewComments - making ID colomn invisible
        protected void GridViewComments_RowCreated(object sender, GridViewRowEventArgs e)
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

        //GridViewComments - populating the textbox with comment content 
        protected void GridViewComments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.DataItem is CommentLine)
                {
                    var currentLine = (CommentLine)e.Row.DataItem;
                    var myCommentCell = (TextBox)e.Row.FindControl("txtComment");
                    int length = currentLine.CommentContent.Length;
                    myCommentCell.Width = length * 6;
                    myCommentCell.ToolTip = currentLine.CommentContent;
                    myCommentCell.Text = currentLine.CommentContent;
                }
            }
        }

        protected void GridViewComments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridViewComments.Rows[index];

                string selectedID = row.Cells[0].Text;

                var commentBox = (TextBox)row.FindControl("txtComment");
                string updatedComment = commentBox.Text;

                GridUpdateArgs gua = new GridUpdateArgs();
                gua.ID = selectedID;
                gua.NewText = updatedComment;

                if (GridUpdate != null)
                {
                    GridUpdate(gua);
                }

                if (Model.IsValidTransastion)
                {
                    var ex = new LoadDataArgs();
                    ex.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                    LoadData(ex);
                    GridViewComments.DataSource = Model.ListOfComments;
                    lblGridCommentsUpdate.Text = "Your update was saved.";
                    lblGridCommentsUpdate.BackColor = Color.LightGreen;
                }
                else
                {
                    lblGridCommentsUpdate.Text = "The data was not saved, plese try again.";
                    lblGridCommentsUpdate.BackColor = Color.OrangeRed;


                }

            }
        }


        protected void GridViewFavorite_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewFavorite.SelectedRow;
            string selectedMovieTitle = row.Cells[0].Text;
            GridUpdateArgs gua = new GridUpdateArgs();
            gua.ID = selectedMovieTitle;
            gua.UserName = System.Web.HttpContext.Current.User.Identity.Name;
            if (RemoveMovie != null)
            {
                RemoveMovie(gua);
                if (Model.IsValidTransastion == true)
                {
                    var ex = new LoadDataArgs();
                    ex.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                    LoadData(ex);
                    GridViewFavorite.DataSource = Model.ListOfFavorites;
                    GridViewFavorite.DataBind();
                    GridViewComments.DataSource = Model.ListOfComments;
                }
            }

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            GridViewComments.DataBind();
        }









    }
}