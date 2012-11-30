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

            Myview.GridUpdate += GridViewCommentUpdate;

            Myview.RemoveMovie += RemoveMovieFromFavorites;
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

               //Data transfer to MyAre MODEL
               Myview.Model.ListOfComments = new List<CommentLine>();
               Myview.Model.ListOfRatings = new List<RatingLine>();
               Myview.Model.ListOfFavorites = new List<FavoriteLine>();
               foreach (var item in ListOfComments)
               {
                   CommentLine row = new CommentLine();
                   row.CommentID = item.commentID;
                   row.MovieTitle = item.MovieTitle;
                   row.CommentContent = item.Content;
                   Myview.Model.ListOfComments.Add(row);
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

        //Method that updates the comment in the Comments GridView
        private void GridViewCommentUpdate(GridUpdateArgs gua)
        {
            UserCommentDTO CommentToUpdate = new UserCommentDTO();
            CommentToUpdate.commentID = int.Parse(gua.ID);
            CommentToUpdate.Content = gua.NewText;
            IUser UserServices = new UserServices();
            bool check = UserServices.UpdateComment(CommentToUpdate);

            if (check)
            {
                Myview.Model.IsValidTransastion = true;
            }
            else
            {
                Myview.Model.IsValidTransastion = false;
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



    }

    //----------------------------------------------

    public delegate void DataLoadHandler(LoadDataArgs e);
    public delegate void GridUpdateHandler (GridUpdateArgs gua);


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


}
