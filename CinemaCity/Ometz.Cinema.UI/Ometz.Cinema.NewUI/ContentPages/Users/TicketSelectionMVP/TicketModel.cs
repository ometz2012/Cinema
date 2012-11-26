using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ometz.Cinema.UI.ContentPages.Users.TicketSelectionMVP
{
    public class TicketModel
    {
        public String MovieDescription { get; set; }
        public List<MovieLine> MovieList { get; set; }
        public List<String> CityList { get; set; }
        public List<TheaterLine> TheaterList { get; set; }
        public List<PerformanceLine> PerformanceList { get; set; }
    }


    public class MovieLine
    {
        public String MovieID { get; set; }
        public String MovieTitle { get; set; }
    }

    public class TheaterLine
    {
        public String TheaterID { get; set; }
        public String TheaterName { get; set; }
        public String Address { get; set; }
    }

    public class PerformanceLine
    {
        public String PerformaceDate { get; set; }
        public String StartingTime { get; set; }
        public String Duration { get; set; }
        public String Price { get; set; }
    }



}