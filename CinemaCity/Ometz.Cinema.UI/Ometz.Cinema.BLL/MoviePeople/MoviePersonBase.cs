using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ometz.Cinema.BLL.MoviePeople
{
    public class MoviePersonBase
    {
        public string FirstName
        { get; set; }

        public string LastName
        { get; set; }

        public DateTime BirthDate
        { get; set; }

        public string BirthPlace
        { get; set; }

        public string FullName
        { get; set; }

    }
}
