using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Data;
using Ometz.Cinema.DAL;

namespace Ometz.Cinema.BLL.Users
{
    public class UserServices:IUser
    {
        //Method that gets all Comments of specific user
        public IList<UserCommentDTO> GetAllUserComments(System.Guid userID)
        {
            IList<UserCommentDTO> ListOfComments = new List<UserCommentDTO>();

            using (var context = new CinemaEntities())
            {
                var results = (from com in context.Comments.Include("Movie")
                               where com.UserID == userID
                               select com);

                if (results!=null)
                {
                    foreach (var item in results)
                    {
                        UserCommentDTO row = new UserCommentDTO();
                        row.userID = userID.ToString();
                        row.commentID = item.CommentID;
                        row.movieID = item.MovieID;
                        row.Content = item.Content;
                        row.MovieTitle = item.Movie.Title;
                        ListOfComments.Add(row);
                    }
                }
            }


            return ListOfComments;
        }

        //Method that gets comments of a specific user for specific movie
        public IList<UserCommentDTO> GetUserCommentByMovie(Guid userID, int movieID)
        {
            IList<UserCommentDTO> ListOfComments = new List<UserCommentDTO>();



            return ListOfComments;
        }

        //Method that gets all Ratings for specific user
        public IList<UserRatingDTO> GetAllUserRatings(Guid userID)
        {
            IList<UserRatingDTO> ListOfRatings = new List<UserRatingDTO>();

            using (var context = new CinemaEntities())
            {
                var results = (from rt in context.Ratings.Include("Movie")
                               where rt.UserID == userID
                               select rt);

                if (results != null)
                {
                    foreach (var item in results)
                    {
                        UserRatingDTO row = new UserRatingDTO();
                        row.ratingID = item.RatingID;
                        row.userID = userID.ToString();
                        row.movieID = item.MovieID;
                        row.MovieTitle = item.Movie.Title;
                        row.rate = item.Rate;
                        ListOfRatings.Add(row);                  
                    }
                }
            }


            return ListOfRatings;
        }

        //Method that gets Ratings of sepcific user for specific Movie
        public IList<UserRatingDTO> GetUserRatingsByMovie(Guid userID, int movieID)
        {
            IList<UserRatingDTO> ListOfRatings = new List<UserRatingDTO>();

            return ListOfRatings;

        }

        //Method that gets all Favorite movies of a specific user
        public IList<UserFavoriteMovieDTO> GetFavoriteMoviesByUser(Guid userID)
        {
            IList<UserFavoriteMovieDTO> ListOfMovies = new List<UserFavoriteMovieDTO>();

            using (var context = new CinemaEntities())
            {
                var results = (from fv in context.Favorites.Include("Movie")
                               where fv.UserID == userID
                               select fv);

                foreach (var item in results)
                {
                    UserFavoriteMovieDTO row = new UserFavoriteMovieDTO();
                    row.userID = userID.ToString();
                    row.movieID = item.MovieID;
                    row.MovieTitle = item.Movie.Title;
                    ListOfMovies.Add(row);
                }
            }


            return ListOfMovies;
        }
    }
}
