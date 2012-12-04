using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ometz.Cinema.DAL;

namespace Ometz.Cinema.BLL.Movies
{
    public class MovieServices
    {
        public List<MovieModelDTO> GetAllMovies()
        {
            
            using (var context = new CinemaEntities())
            {
                var allMovies = (from movie in context.Movies
                                 select new
                                 {
                                    MovieID = movie.MovieID,
                                     Title = movie.Title,
                                     Photo=movie.Photo,//added by Elena for RepeaterMovie MovieMain.aspx
                                     Description=movie.Description//

                                 }).ToList();
                List<MovieModelDTO> allMoviesToReturn = new List<MovieModelDTO>();
                if (allMovies != null)
                {

                    foreach (var item in allMovies)
                    {
                        MovieModelDTO movieRow = new MovieModelDTO()
                        {

                            MovieID = item.MovieID,
                            Title = item.Title,
                            //Photo=item.Photo,
                            Description=item.Description,
                            Photo = (byte[])item.Photo

                        };

                        allMoviesToReturn.Add(movieRow);
                    }

                    return allMoviesToReturn;
                }
                else
                {
                    return null;
                }

            }
        }

        public List<MovieModelDTO> GetAllYears()
        {
            using (var context = new CinemaEntities())
            {
                var allYears = (from movie in context.Movies
                                select new
                                {
                                  //  MovieId = movie.MovieID, We don't need a movie Id(changed by Marat)
                                    Year = movie.Year

                                }).Distinct().ToList();

                List<MovieModelDTO> allYearsToReturn = new List<MovieModelDTO>();

                if (allYears != null)
                {

                    foreach (var item in allYears)
                    {
                        MovieModelDTO yearRow = new MovieModelDTO()
                        {
                            // MovieID = item.MovieId,   We don't need a movie Id (changed by Marat)
                            Year = item.Year
                        };
                        allYearsToReturn.Add(yearRow);
                    }

                    return allYearsToReturn;
                }
                else
                {
                    return null;
                }

            }
        }

        public List<MovieModelDTO> GetAllGenres()
        {
            using (var context = new CinemaEntities())
            {
                var allGenre = (from genre in context.Genres
                                select new
                                {

                                    GenreName = genre.Name

                                }).ToList();

                List<MovieModelDTO> allGenresToReturn = new List<MovieModelDTO>();

                if (allGenre != null)
                {

                    foreach (var item in allGenre)
                    {
                        MovieModelDTO genreRow = new MovieModelDTO()
                        {
                            GenreName = item.GenreName
                        };
                        allGenresToReturn.Add(genreRow);
                    }

                    return allGenresToReturn;
                }
                else
                {
                    return null;
                }

            }

        }
    }
}

