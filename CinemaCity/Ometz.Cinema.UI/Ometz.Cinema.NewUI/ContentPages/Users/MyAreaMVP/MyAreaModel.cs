using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ometz.Cinema.UI.ContentPages.Users.MyAreaMVP
{
    public class MyAreaModel
    {
        public List<CommentLine> ListOfComments { get; set; }
        public List<RatingLine> ListOfRatings { get; set; }
        public List<FavoriteLine> ListOfFavorites { get; set; }
        public List<String> ListOfMovies { get; set; }

        public String ChosenMovie { get; set; }
        public bool IsValidTransastion { get; set; }


    }

    public class CommentLine
    {
        public int CommentID { get; set; }
        public int MovieID { get; set; }
        public String MovieTitle { get; set; }
        public String CommentContent { get; set; }
    }

    public class RatingLine
    {
        public String MovieTitle { get; set; }
        public String Rating { get; set; }
    }

    public class FavoriteLine
    {
        public String MovieTitle { get; set; }
    }
}