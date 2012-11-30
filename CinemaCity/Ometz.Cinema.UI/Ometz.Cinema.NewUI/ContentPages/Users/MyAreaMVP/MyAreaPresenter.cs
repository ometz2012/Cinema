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

    }

    //----------------------------------------------

    public delegate void DataLoadHandler(LoadDataArgs e);


    public class LoadDataArgs : EventArgs
    {
        public string UserName { get; set; }
    }


}
