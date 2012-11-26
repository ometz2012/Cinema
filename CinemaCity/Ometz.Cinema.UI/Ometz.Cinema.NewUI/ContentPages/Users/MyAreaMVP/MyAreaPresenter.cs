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
       private void LoadData(EventArgs e)
       {
           //Data Extraction from the database
           Guid UserIDTemp = new Guid();
           UserIDTemp=Guid.Parse( "e441de1f-9877-4074-bcd7-7b46bf3a7143");

           IUser UserServices = new UserServices();
           IList<UserCommentDTO> ListOfComments = UserServices.GetAllUserComments(UserIDTemp);
           IList<UserRatingDTO> ListOfRatings = UserServices.GetAllUserRatings(UserIDTemp);
           IList<UserFavoriteMovieDTO> ListOfFavoriteMovies = UserServices.GetFavoriteMoviesByUser(UserIDTemp);

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


          
           Myview.Model.ChosenMovie = "It works";

       }

   }

       //----------------------------------------------

      public delegate void DataLoadHandler (EventArgs e);

    
}
