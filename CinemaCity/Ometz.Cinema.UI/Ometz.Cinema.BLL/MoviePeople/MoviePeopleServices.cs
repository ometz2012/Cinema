using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ometz.Cinema.DAL;

namespace Ometz.Cinema.BLL.MoviePeople
{
    public class MoviePeopleServices
    {
        // Method gets movie Id and type of movie person ("Actor", "Director" etc..) and return list of people
        public List<MoviePersonDTO> GetMoviePeopleByMovieId(int movieId, string personType)
        {
            using (var context = new CinemaEntities())
            {
                var moviePeople = (from moviePerson in context.PersonMovies
                                 //  where moviePerson.MovieID == movieId && moviePerson.Person.PersonType.Description.Contains("actor")
                                   where moviePerson.MovieID == movieId && moviePerson.Person.PersonType.Description == personType
                                   select moviePerson).ToList();
                if (moviePeople.Count() > 0)
                {
                    List<MoviePersonDTO> moviePeopleToReturn = new List<MoviePersonDTO>();
                    foreach (var item in moviePeople)
                    {
                        MoviePersonDTO moviePeopleRow = new MoviePersonDTO()
                        {
                            FirstName = item.Person.FirstName,
                            LastName = item.Person.LastName,
                            BirthDate = (DateTime)item.Person.BirthDate,
                            BirthPlace = item.Person.BirthPlace
                        };
                        moviePeopleToReturn.Add(moviePeopleRow);
                    }
                    return moviePeopleToReturn;
                }
                else
                {
                    return null;
                }
            }

        }

        //public object GetMoviePeopleByMovieId(string p, string p_2)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
