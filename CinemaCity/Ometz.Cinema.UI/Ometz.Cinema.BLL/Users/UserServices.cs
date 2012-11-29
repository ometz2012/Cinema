﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Data;
using Ometz.Cinema.DAL;

namespace Ometz.Cinema.BLL.Users
{
    public class UserServices : IUser
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

                if (results != null)
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

        //==============================================================================================
        #region UserMovieTheater

        //Method that gets all movies
        public IList<UserFavoriteMovieDTO> GetListOfMovies()
        {
            IList<UserFavoriteMovieDTO> ListOfMovies = new List<UserFavoriteMovieDTO>();
            using (var context = new CinemaEntities())
            {
                var results = (from mv in context.Movies
                               select mv);

                foreach (var item in results)
                {
                    UserFavoriteMovieDTO row = new UserFavoriteMovieDTO();
                    row.movieID = item.MovieID;
                    row.MovieTitle = item.Title;
                    ListOfMovies.Add(row);
                }
            }
            return ListOfMovies;
        }

        //Method that gets Movie description
        public String GetMovieDescriptionByMovieID(int movieID)
        {
            String Description = null;
            using (var context = new CinemaEntities())
            {
                var results = (from mv in context.Movies
                               where mv.MovieID == movieID
                               select mv);

                foreach (var item in results)
                {
                    Description = item.Description;
                }

            }
            return Description;
        }

        //Method that gets all the cities
        public IList<String> GetCitiesByMovieID(int movieID)
        {
            IList<String> ListOfCities = new List<String>();
            using (var context = new CinemaEntities())
            {
                var results = (from pr in context.Perfomances
                               where pr.MovieID == movieID
                               join ad in context.Addresses
                               on pr.TheaterID equals ad.ObjectID
                               select new { City = ad.City });
                foreach (var item in results)
                {
                    String row = null;
                    row = item.City;
                    ListOfCities.Add(row);
                }
            }
            return ListOfCities;
        }


        //Method that gets the theaters by City
        public IList<UserTheaterDTO> GetTheatersByCity(String City, int movieID)
        {
            IList<UserTheaterDTO> ListOfTheaters = new List<UserTheaterDTO>();
            using (var context = new CinemaEntities())
            {
                var results = (from pr in context.Perfomances.Include("Theater")
                               join ad in context.Addresses.Include("ObjectType")
                               on pr.TheaterID equals ad.ObjectID
                               where pr.MovieID == movieID
                               where ad.City == City
                               where ad.ObjectType.Description == "Theater"
                               select new
                               {
                                   TheaterID = pr.TheaterID,
                                   TheaterName = pr.Theater.Name,
                                   AddressTh = ad
                               });

                foreach (var item in results)
                {
                    UserTheaterDTO row = new UserTheaterDTO();
                    row.TheaterID = item.TheaterID;
                    row.TheaterName = item.TheaterName;
                    row.TheaterAddress = String.Format("str. {0}, {1}, phone number: {2}.", item.AddressTh.AddressLine1, item.AddressTh.City, item.AddressTh.Phone);
                    ListOfTheaters.Add(row);
                }

            }
            return ListOfTheaters;
        }


        //Method that gets Performances by Theater
        public IList<UserPerformanceDTO> GetPerformancesByTheaterIDandMovieID(Guid TheaterID, int movieID)
        {
            IList<UserPerformanceDTO> ListOfPerformances = new List<UserPerformanceDTO>();
            using (var context = new CinemaEntities())
            {
                var results = (from pr in context.Perfomances.Include("Movie").Include("Theater")
                               where pr.TheaterID == TheaterID && pr.MovieID == movieID
                               select pr);
                foreach (var item in results)
                {
                    UserPerformanceDTO row = new UserPerformanceDTO();
                    row.performanceID = item.PerfomanceID;
                    row.MovieTitle = item.Movie.Title;
                    row.roomNumber = item.Room.RoomNumber;
                    row.Date = item.Date.ToString("yyyy/MM/dd");
                    string hours = item.StartingTime.Hours.ToString();
                    string minutes = item.StartingTime.Minutes.ToString();
                    row.StartingTime = string.Format("{0}:{1}", hours, minutes);
                    row.Duration = item.Duration;
                    row.price = item.Price;
                    ListOfPerformances.Add(row);
                }
            }
            return ListOfPerformances;

        }

        //Method that gets Performance info by its ID
        public UserPerformanceDTO GetPerformanceByID(int performanceID)
        {
            UserPerformanceDTO CurrentPerformance = new UserPerformanceDTO();

            using (var context = new CinemaEntities())
            {
                var results = (from pr in context.Perfomances.Include("Theater").Include("Movie").Include("Room")
                               where pr.PerfomanceID == performanceID
                               join ad in context.Addresses
                               on pr.TheaterID equals ad.ObjectID
                               where ad.ObjectType.Description == "Theater"
                               select new
                               {
                                   PerformanceOut = pr,
                                   AddressOut = ad
                               });
                if (results != null)
                {
                    foreach (var item in results)
                    {
                        UserPerformanceDTO row = new UserPerformanceDTO();
                        row.performanceID = performanceID;
                        row.TheaterName = item.PerformanceOut.Theater.Name;
                        row.Date = item.PerformanceOut.Date.ToString("yyy/MM/dd");
                        row.Duration = item.PerformanceOut.Duration;
                        string hour = item.PerformanceOut.StartingTime.Hours.ToString();
                        string minutes = item.PerformanceOut.StartingTime.Minutes.ToString();
                        row.StartingTime = string.Format("{0}:{1}", hour, minutes);
                        row.price = item.PerformanceOut.Price;
                        row.MovieTitle = item.PerformanceOut.Movie.Title;
                        row.roomNumber = item.PerformanceOut.Room.RoomNumber;
                        string street = item.AddressOut.AddressLine1;
                        if (item.AddressOut.AddressLine2 != null)
                        {
                            street = string.Format("{0}, {1}", item.AddressOut.AddressLine1, item.AddressOut.AddressLine2);
                        }
                        string phone = item.AddressOut.Phone;
                        row.TheaterAddress = string.Format("{0}, Phone: {1}", street, phone);

                    }
                }
            }

            return CurrentPerformance;

        }

        #endregion

        //Method that gets UserID during the login
        public Guid GetUserID(String UserName)
        {
            Guid UserID = new Guid();

            using (var context = new CinemaEntities())
            {
                var results = (from usr in context.aspnet_Users
                               where usr.UserName == UserName
                               select usr);
                if (results != null)
                {
                    foreach (var item in results)
                    {
                        UserID = item.UserId;
                    }

                }
                return UserID;

            }
        }
        //Method that get user type by description
        public int GetUserType(String Description)
        {
            int type = 0;
            using (var context = new CinemaEntities())
            {
                var results = (from pt in context.PersonTypes
                               where pt.Description == Description
                               select pt);
                if (results != null)
                {
                    foreach (var item in results)
                    {
                        type = item.PersonType1;

                    }
                }
            }
            return type;
        }

        //Method that creates new user
        public bool CreateNewUser(UserModelDTO NewUser)
        {
            bool check = false;
            using (TransactionScope Trans = new TransactionScope())
            {
                try
                {
                    using (var context = new CinemaEntities())
                    {

                        //Enetring into Users Table
                        try
                        {
                            User NewUserIn = new User();
                            NewUserIn.UserID = NewUser.UserID;
                            NewUserIn.Password = NewUser.Password;

                            if (NewUserIn.EntityState == EntityState.Detached)
                            {
                                context.Users.AddObject(NewUserIn);
                            }
                            context.SaveChanges();
                        }
                        catch { }


                        //Entering into Person Table
                        try
                        {
                            Person NewPersonIn = new Person();
                            NewPersonIn.FirstName = NewUser.FirstName;
                            NewPersonIn.LastName = NewUser.LastName;
                            NewPersonIn.PersonTypeID = NewUser.personTypeID;
                            NewPersonIn.PersonID = Guid.NewGuid();
                            if (NewPersonIn.EntityState == EntityState.Detached)
                            {
                                context.People.AddObject(NewPersonIn);
                            }
                            context.SaveChanges();

                        }
                        catch { }


                        ////Entering into Authonticated User Table
                        //try
                        //{
                        //    AuthenticatedUser NewAuthUser = new AuthenticatedUser();
                        //    NewAuthUser.PersonID = NewUser.PersonID;
                        //    NewAuthUser.UserID = NewUser.UserID;
                        //    NewAuthUser.AuthenticatedUserID = Guid.NewGuid();
                        //    if (NewAuthUser.EntityState == EntityState.Detached)
                        //    {
                        //        context.AuthenticatedUsers.AddObject(NewAuthUser);
                        //    }
                        //    context.SaveChanges();

                        //}
                        //catch { }




                    }

                }
                catch
                {
                    check = false;
                    Trans.Dispose();
                    return check;
                }

                check = true;
                Trans.Complete();
                return check;
            }

        }


    }

    //Exceptions
    #region Exceptions




    #endregion
}
