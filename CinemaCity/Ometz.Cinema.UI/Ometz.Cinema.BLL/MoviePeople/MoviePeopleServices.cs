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

        //get list of actors for ddlActorMovie MainMovie.aspx

        public List<MoviePersonDTO> GetActors()
        {
            using (var context = new CinemaEntities())
            {
                string cast = "actor";

                var listmoviePeople = (from moviePerson in context.PersonMovies
                                       where moviePerson.Person.PersonType.Description == cast
                                       select moviePerson).ToList();

                if (listmoviePeople.Count() > 0)
                {
                    List<MoviePersonDTO> moviePeopleToReturn = new List<MoviePersonDTO>();
                    foreach (var item in listmoviePeople)
                    {
                        MoviePersonDTO moviePeopleRow = new MoviePersonDTO()
                        {
                            FirstName = item.Person.FirstName,
                            LastName = item.Person.LastName,
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

        //get list of  for ddlProducerMovie MainMovie.aspx

        public List<MoviePersonDTO> GetProducers()
        {
            using (var context = new CinemaEntities())
            {
                string cast = "producer";

                var castmovie = (from moviePerson in context.PersonMovies
                                 where moviePerson.Person.PersonType.Description == cast
                                 select moviePerson).ToList();

                if (castmovie.Count() > 0)
                {
                    List<MoviePersonDTO> moviePeopleToReturn = new List<MoviePersonDTO>();
                    foreach (var item in castmovie)
                    {
                        MoviePersonDTO moviePeopleRow = new MoviePersonDTO()
                        {
                            FirstName = item.Person.FirstName,
                            LastName = item.Person.LastName,
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
