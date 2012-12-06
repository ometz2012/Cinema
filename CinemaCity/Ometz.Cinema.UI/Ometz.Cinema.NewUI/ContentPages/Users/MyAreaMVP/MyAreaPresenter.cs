using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ometz.Cinema.BLL.Users;

namespace Ometz.Cinema.UI.ContentPages.Users.MyAreaMVP
{
    public class MyAreaPresenter
    {
        public IMyAreaView Myview { get; set; }

        public MyAreaPresenter(IMyAreaView myView)
        {
            Myview = myView;

            Myview.LoadData += LoadData;

            Myview.RemoveMovie += RemoveMovieFromFavorites;

            Myview.TreeViewUpdateDelete += UpdateDleteComment;
        }

        //Method that extracts all data to populate the tables
        private void LoadData(LoadDataArgs e)
        {
            IUser UserServices = new UserServices();
            //UserID extraction from DataBase
            Guid UserID = UserServices.GetUserID(e.UserName);

            IList<UserCommentDTO> ListOfComments = UserServices.GetAllUserComments(UserID);
            IList<UserRatingDTO> ListOfRatings = UserServices.GetAllUserRatings(UserID);
            IList<UserFavoriteMovieDTO> ListOfFavoriteMovies = UserServices.GetFavoriteMoviesByUser(UserID);
            IList<String> ListOfMovies = UserServices.GetMoviesToWhichTheUserCommented(UserID);

            //Data transfer to MyAre MODEL
            Myview.Model.ListOfComments = new List<CommentLine>();
            Myview.Model.ListOfRatings = new List<RatingLine>();
            Myview.Model.ListOfFavorites = new List<FavoriteLine>();
            Myview.Model.ListOfMovies = new List<String>();
            foreach (var item in ListOfComments)
            {
                CommentLine row = new CommentLine();
                row.CommentID = item.commentID;
                row.MovieTitle = item.MovieTitle;
                row.CommentContent = item.Content;
                row.MovieID = item.movieID;
                Myview.Model.ListOfComments.Add(row);
            }

            foreach (var item in ListOfMovies)
            {
                String row1 = null;
                row1 = item;
                bool check = Myview.Model.ListOfMovies.Contains(row1);
                if (!check)
                {
                    Myview.Model.ListOfMovies.Add(row1);
                }
            }

            foreach (var item in ListOfRatings)
            {
                RatingLine row = new RatingLine();
                row.MovieTitle = item.MovieTitle;
                row.Rating = item.rate.ToString();
                Myview.Model.ListOfRatings.Add(row);

            }



            foreach (var item in ListOfFavoriteMovies)
            {
                FavoriteLine row = new FavoriteLine();
                row.MovieTitle = item.MovieTitle;
                Myview.Model.ListOfFavorites.Add(row);
            }
        }


        //Method that removes movie from favorites
        private void RemoveMovieFromFavorites(GridUpdateArgs gua)
        {
            string selectedMovieTitle = gua.ID;
            string userName = gua.UserName;
            IUser UserServices = new UserServices();
            Guid UserID = UserServices.GetUserID(userName);
            bool check = UserServices.RemoveMovieFromFavoriteList(UserID, selectedMovieTitle);

            if (check)
            {
                Myview.Model.IsValidTransastion = true;
            }
            else
            {
                Myview.Model.IsValidTransastion = false;
            }

        }

        private void UpdateDleteComment(TreeViewUpdateArgs tua)
        {
            IUser UserServices = new UserServices();
            bool check = false;
            if (tua.ActionToPerform == "Delete")
            {
                int commentID = tua.ChildID;
                check = UserServices.DeleteComment(commentID);
            }
            else if (tua.ActionToPerform == "Update")
            {
                UserCommentDTO CommentToUpdate = new UserCommentDTO();
                CommentToUpdate.commentID = tua.ChildID;
                CommentToUpdate.Content = tua.ChildContent;
                check = UserServices.UpdateComment(CommentToUpdate);
            }

            if (check)
            {

                Guid UserID = UserServices.GetUserID(tua.UserName);
                IList<UserCommentDTO> ListOfComments = UserServices.GetAllUserComments(UserID);
                IList<String> ListOfMovies = UserServices.GetMoviesToWhichTheUserCommented(UserID);
                Myview.Model.IsValidTransastion = true;
                Myview.Model.ListOfComments = new List<CommentLine>();
                Myview.Model.ListOfMovies = new List<String>();
                foreach (var item in ListOfComments)
                {
                    //creating list of comments
                    CommentLine row = new CommentLine();
                    row.CommentID = item.commentID;
                    row.MovieTitle = item.MovieTitle;
                    row.CommentContent = item.Content;
                    row.MovieID = item.movieID;
                    Myview.Model.ListOfComments.Add(row);
                }
                foreach (var item in ListOfMovies)
                {
                    String row1 = null;
                    row1 = item;
                    bool checkIfContains = Myview.Model.ListOfMovies.Contains(row1);
                    if (!checkIfContains)
                    {
                        Myview.Model.ListOfMovies.Add(row1);
                    }
                }
            }

        }


    }

    //----------------------------------------------

    public delegate void DataLoadHandler(LoadDataArgs e);
    public delegate void GridUpdateHandler(GridUpdateArgs gua);
    public delegate void TreeViewUpdateHandler(TreeViewUpdateArgs tua);


    public class LoadDataArgs : EventArgs
    {
        public string UserName { get; set; }
    }

    public class GridUpdateArgs : EventArgs
    {
        public String ID { get; set; }
        public String NewText { get; set; }
        public String UserName { get; set; }


    }

    public class TreeViewUpdateArgs : EventArgs
    {
        public int ParentID;
        public int ChildID;
        public String ChildContent;
        public String ActionToPerform { get; set; }
        public String UserName { get; set; }
    }


}
