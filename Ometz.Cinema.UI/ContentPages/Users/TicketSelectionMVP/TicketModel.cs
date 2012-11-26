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
        String MovieID { get; set; }
        String MovieTitle { get; set; }
    }

    public class TheaterLine

    {
        String TheaterID { get; set; }
        String TheaterName { get; set; }
        String Address { get; set; }
    }

    public class PerformanceLine
    {
        String PerformaceDate { get; set; }
        String StartingTime { get; set; }
        String Duration { get; set; }
        String Price { get; set; }
    }
    public class ToDel
    {
        String Delllll { get; set; }
    }



}