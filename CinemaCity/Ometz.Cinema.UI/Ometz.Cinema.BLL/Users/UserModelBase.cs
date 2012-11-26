using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ometz.Cinema.BLL.Users
{
    public class UserModelBase
    {

    }

    public abstract class UserBase
    {
        
    }

    public abstract class UserCommentBase
    {
        public int commentID { get; set; }
        public String Content { get; set; }
        public int movieID { get; set; }
        public String MovieTitle { get; set; }
        public String userID { get; set; }
    }
    public abstract class UserRatingBase
    {
        public int ratingID { get; set; }
        public int rate { get; set; }
        public int movieID { get; set; }
        public String MovieTitle { get; set; }
        public String userID { get; set; }
    }

    public abstract class UserFavoriteMovieBase
    {
        public int movieID { get; set; }
        public String MovieTitle { get; set; }
        public String userID { get; set; }
    }

}
