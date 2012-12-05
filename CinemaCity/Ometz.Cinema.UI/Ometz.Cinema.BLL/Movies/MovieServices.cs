using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ometz.Cinema.DAL;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;


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

                //byte[] buffer = binary.ToArray();
                //MemoryStream stream = new MemoryStream(buffer);
                //BitmapImage image = new BitmapImage();
                //image.BeginInit();
                //image.StreamSource = stream;
                //image.EndInit();
                //return image;



            }
        }

        public List<MovieModelDTO> GetAllYears()
        {
            using (var context = new CinemaEntities())
            {
                var allYears = (from movie in context.Movies
                                orderby movie.Year ascending
                                select new
                                {
                                    MovieId = movie.MovieID,
                                    Year = movie.Year

                                }).ToList();

                List<MovieModelDTO> allYearsToReturn = new List<MovieModelDTO>();

                if (allYears != null)
                {

                    foreach (var item in allYears)
                    {
                        MovieModelDTO yearRow = new MovieModelDTO()
                        {
                            MovieID = item.MovieId,
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

        //---Method that extracts movie photo
        public Byte[] GetPhoto(int movieId)
        {

            byte[] photo = null;
            using (var context = new CinemaEntities())
            {
                var result = (from image in context.Movies
                              where image.MovieID == movieId
                              select image).SingleOrDefault();
                if (result == null)
                {
                    return null;
                }
                photo = result.Photo;
                //foreach (var item in result)
                //{
                //photo = item.Photo;
                //}
            }
            return photo;
        }

        public MovieModelDTO GetMovieByID(int movieID)
        {
            MovieModelDTO SelectedMovie = new MovieModelDTO();

            using (var context = new CinemaEntities())
            {
                var results = (from mv in context.Movies.Include("Genre")
                               where mv.MovieID == movieID
                               select mv);

                if (results != null)
                {
                    foreach (var item in results)
                    {
                        SelectedMovie.MovieID = item.MovieID;
                        SelectedMovie.Title = item.Title;
                        SelectedMovie.GenreName = item.Genre.Name;
                        SelectedMovie.Description = item.Description;
                        SelectedMovie.Year = item.Year;
                    }
                }
            }

            return SelectedMovie;
        }

        public void ToDelete()
        {
            bool check = false;
        }

        
        


    }

}

