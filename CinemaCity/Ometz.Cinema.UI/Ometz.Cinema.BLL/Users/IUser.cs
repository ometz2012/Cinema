using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ometz.Cinema.BLL.Users
{
    public interface IUser
    {

        //Method that gets all Comments of specific user
        IList<UserCommentDTO> GetAllUserComments(System.Guid userID);

        //Method that gets comments of a specific user for specific movie
        IList<UserCommentDTO> GetUserCommentByMovie(System.Guid userID, int movieID);

        //Method that gets list of movies to which the specific user commented
        IList<String> GetMoviesToWhichTheUserCommented(Guid userID);

        //Method that gets all Ratings for specific user
        IList<UserRatingDTO> GetAllUserRatings(System.Guid userID);

        //Method that gets Ratings of sepcific user for specific Movie
        IList<UserRatingDTO> GetUserRatingsByMovie(System.Guid userID, int movieID);

        //Method that gets all Favorite movies of a specific user
        IList<UserFavoriteMovieDTO> GetFavoriteMoviesByUser(System.Guid userID);

        //===========================================25/11/2012
        //Method that gets all movies
        IList<UserFavoriteMovieDTO> GetListOfMovies();

        //Method that gets Movie description
        String GetMovieDescriptionByMovieID(int movieID);

        //Method that gets all the cities
        IList<String> GetCitiesByMovieID(int movieID);


        //Method that gets the theaters by City
        IList<UserTheaterDTO> GetTheatersByCity(String City, int movieID);


        //Method that gets Performances by Theater
        IList<UserPerformanceDTO> GetPerformancesByTheaterIDandMovieID(Guid TheaterID, int movieID);

        //Method that gets Performance info by its ID
        UserPerformanceDTO GetPerformanceByID(int performanceID);

        //Method that submits the order
        UserOrderDTO CreateOrder(UserOrderDTO NewOrder);


        //Method that gets UserID during the login
        Guid GetUserID(String UserName);

        //Method that get user type by description
        int GetUserType(String Description);

        //Method that creates new user
        bool CreateNewUser(UserModelDTO NewUser);


        //Method that updates comment
        bool UpdateComment(UserCommentDTO UpdatedComment);

        //Method that removes comment
        bool DeleteComment(int commentID);


        //Method that deletes movie from favorite list
        bool RemoveMovieFromFavoriteList(Guid UserID, string movieTitle);

      
        


    }
}
