using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ometz.Cinema.BLL.Movies;

namespace Ometz.Cinema.NewUI.ContentPages.Movies
{
    /// <summary>
    /// Summary description for MoviePhotoHandler
    /// </summary>
    public class MoviePhotoHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int movieID = Convert.ToInt32(context.Request.QueryString["MovieID"]);
            MovieServices MovieServices = new MovieServices();
            byte[] photo = MovieServices.GetPhoto(movieID);
            if (photo == null)
            {
                return;
            }
            context.Response.ContentType = "image/jpeg";
            context.Response.BinaryWrite(photo);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


    }
}