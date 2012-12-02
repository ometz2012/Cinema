using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ometz.Cinema.BLL.MoviePeople;

namespace Ometz.Cinema.NewUI.ContentPages.MoviePeople.MoviePeopleUserControls
{
    /// <summary>
    /// Summary description for MoviePersonPhoto
    /// </summary>
    public class MoviePersonPhoto : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
         Guid personID = new Guid();
        // personID = Guid.Parse("57ED65A6-A1C0-46E6-AF3E-E12D13B1A49C");
         MoviePeopleServices imagedata = new MoviePeopleServices();

         // byte[] photo = imadata.GetPhoto(personID);//personId
        personID = Guid.Parse(context.Request.QueryString["personId"]);
        

         byte[] photo = imagedata.GetPhoto(personID);
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