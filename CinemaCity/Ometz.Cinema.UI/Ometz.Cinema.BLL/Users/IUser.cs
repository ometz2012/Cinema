using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ometz.Cinema.BLL.Users
{
    public interface IUser
    {

        //Method that gets all Comments of specific user
       IList< UserCommentDTO> GetAllUserComments(System.Guid userID);

        //Method that gets comments of a specific user for specific movie
        IList<UserCommentDTO> GetUserCommentByMovie(System.Guid userID, int movieID);

        //Method that gets all Ratings for specific user
        IList<UserRatingDTO> GetAllUserRatings(System.Guid userID);

        //Method that gets Ratings of sepcific user for specific Movie
        IList<UserRatingDTO> GetUserRatingsByMovie(System.Guid userID, int movieID);

        //Method that gets all Favorite movies of a specific user
        IList<UserFavoriteMovieDTO> GetFavoriteMoviesByUser(System.Guid userID);

        
        //Method that presents User information


        //Method that updates comment


        //Method that deletes comment


        //Method that updates User Information


    }
}
