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
                                     MovieId = movie.MovieID,
                                     Title = movie.Title

                                 }).ToList();
                List<MovieModelDTO> allMoviesToReturn = new List<MovieModelDTO>();
                if (allMovies != null)
                {

                    foreach (var item in allMovies)
                    {
                        MovieModelDTO movieRow = new MovieModelDTO()
                        {
                            MovieID = item.MovieId,
                            Tilte = item.Title
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
    }
}
