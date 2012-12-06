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
        public event GridUpdateHandler RemoveMovie;
        public event TreeViewUpdateHandler TreeViewUpdateDelete;

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

                GridViewRating.DataSource = Model.ListOfRatings;
                GridViewRating.DataBind();

                GridViewFavorite.DataSource = Model.ListOfFavorites;
                GridViewFavorite.DataBind();

                PopulateTreeView();
                trvComments.CollapseAll();

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
                }
            }

        }

        protected void PopulateTreeView()
        {
            trvComments.Nodes.Clear();

            foreach (var item in Model.ListOfMovies)
            {
                TreeNode node = new TreeNode();
                node.Text = item;
                node.Value = item;
                trvComments.Nodes.Add(node);
                AddChildNode(node, item);

            }


        }

        private void AddChildNode(TreeNode ParentNode, string movieName)
        {
            var ListOfCommentsPerMovie = from line in Model.ListOfComments
                                         where line.MovieTitle == movieName
                                         select line;

            if (ListOfCommentsPerMovie != null)
            {
                foreach (var item in ListOfCommentsPerMovie)
                {
                    TreeNode ChildNode = new TreeNode();
                    ChildNode.Text = item.CommentContent;
                    ChildNode.Value = item.CommentID.ToString();
                    ParentNode.ChildNodes.Add(ChildNode);
                    //place recursion

                }

            }
            else
            {
                return;
            }


        }

        protected void btnComments_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            btnComments.BackColor = Color.LightGreen;
            btnFavoritesAndRatings.BackColor = Color.LightGray;
        }
        protected void btnFavoritesAndRatings_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            btnComments.BackColor = Color.LightGray;
            btnFavoritesAndRatings.BackColor = Color.LightGreen;
        }

        protected void trvComments_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNode SelectedNode = trvComments.SelectedNode;
            lblStatus.Text = "";
            lblStatus.BackColor = Color.White;

            if (SelectedNode.Parent != null)
            {
                txtMovieTitle.Text = SelectedNode.Parent.Text;
                txtCommentContent.Text = SelectedNode.Text;
                lblMovieID.Text = SelectedNode.Parent.Value;
                lblCommentID.Text = SelectedNode.Value;
 
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            TreeViewUpdateArgs tua = new TreeViewUpdateArgs();
            tua.ChildContent = txtCommentContent.Text;
            int commentID;
            bool checkIntCommentID = int.TryParse(lblCommentID.Text,out commentID);
            tua.ChildID = commentID;
            tua.ActionToPerform = "Update";
            tua.UserName = System.Web.HttpContext.Current.User.Identity.Name;

            if (checkIntCommentID)
            {
                if (TreeViewUpdateDelete != null)
                {
                    TreeViewUpdateDelete(tua);
                }
            }
            if (Model.IsValidTransastion == true)
            {
                txtMovieTitle.Text = "";
                txtCommentContent.Text = "";
                PopulateTreeView();
                trvComments.CollapseAll();
                lblStatus.Text = "Comment was updated.";
                lblStatus.BackColor = Color.LightGreen;
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            TreeViewUpdateArgs tua = new TreeViewUpdateArgs();
            tua.ChildContent = txtCommentContent.Text;
            int commentID;
            bool checkIntCommentID = int.TryParse(lblCommentID.Text, out commentID);
            tua.ChildID = commentID;
            tua.ActionToPerform = "Delete";
            tua.UserName = System.Web.HttpContext.Current.User.Identity.Name;

            if (checkIntCommentID)
            {
                if (TreeViewUpdateDelete != null)
                {
                    TreeViewUpdateDelete(tua);
                }
            }
            if (Model.IsValidTransastion == true)
            {
                txtMovieTitle.Text = "";
                txtCommentContent.Text = "";
                PopulateTreeView();
                trvComments.CollapseAll();
                lblStatus.Text = "Comment was deleted.";
                lblStatus.BackColor = Color.LightGreen;
 
            }
           
          
        }











    }
}