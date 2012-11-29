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
                        MoviePersonDTO moviePeopleRow = new MoviePersonDTO();
                        
                            moviePeopleRow.FirstName = item.Person.FirstName;
                            moviePeopleRow.LastName = item.Person.LastName;
                            moviePeopleRow.BirthDate = (DateTime)item.Person.BirthDate;
                            //
                         // string BirthDate = item.Person.BirthDate.ToString("yyyy'/'MM'/'dd");
                          moviePeopleRow.BirthPlace = item.Person.BirthPlace;
                        
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

        //Method gets First Name or Last Name or Full Name or Part of the Name of the person and
       // person type ("actor", "director" etc..) and return the person's Data
       public MoviePersonDTO GetMoviePersonByName(string personName, string personType)
        {
            using (var context = new CinemaEntities())
            {
                var allPeopleByType = (from person in context.People
                                       where person.PersonType.Description == personType
                                       select new
                                       {
                                           FullName = person.FirstName + " " + person.LastName,
                                           BirthDate = person.BirthDate,
                                           BirthPlace = person.BirthPlace,
                                           FirstName = person.FirstName,
                                           LastName = person.LastName
                                       }).ToList();

                var foundPerson = (from person in allPeopleByType
                                   where person.FullName.ToLower().Contains(personName.ToLower())
                                   select person).FirstOrDefault();
                                  
                if (foundPerson != null)
                {
                    MoviePersonDTO moviePersonToReturn = new MoviePersonDTO()
                    {
                        FirstName = foundPerson.FirstName,
                        LastName = foundPerson.LastName,
                        BirthDate = (DateTime)foundPerson.BirthDate,
                        BirthPlace = foundPerson.BirthPlace
                    };
                    return moviePersonToReturn;
                    
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
