﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ometz.Cinema.BLL.MoviePeople;

namespace Ometz.Cinema.UI.ContentPages.MoviePeople.Actors
{
    public partial class ActorsInMovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PeopleInMovie2.SetLabelText("Actors in " + "\"" + Request.QueryString["movieTitle"] + "\"" + " Movie");
               
            }
            switch(Request.QueryString["selector"])
            {
                case "actorsInMovie":
                    ActorsInMovieHandler();
                    break;
                case "actorFoundByName":
                    PeopleInMovie2.SetLabelText("Actor Full Information");
                    ActorFoundByNameHandler();
                    break;
            }          
          
        }
        private void ActorsInMovieHandler()
        {
            MoviePeopleServices actors = new MoviePeopleServices();
            GridView actorsInMovie = new GridView();
            actorsInMovie = PeopleInMovie2.gridPeopleInMovie;
            int movieId = Convert.ToInt32(Request.QueryString["movieId"]);
            List<MoviePersonDTO> person;
            person = actors.GetMoviePeopleByMovieId(movieId, "Actor");
            if (person != null)
            {
                actorsInMovie.DataSource = person;
                actorsInMovie.DataBind();
                GetAppropriateView(actorsInMovie);
            }
            else
                return;
        }
        private void ActorFoundByNameHandler()
        {
               MoviePeopleServices personInfo = new MoviePeopleServices();
               List<MoviePersonDTO> actorToShow = new List<MoviePersonDTO>();
               MoviePersonDTO actor = personInfo.GetMoviePersonByName(Request.QueryString["personToShow"].ToString(), "Actor");
               if (actor != null)
               {
                   actorToShow.Add(actor);
                   GridView actorFoundByName = new GridView();
                   actorFoundByName = PeopleInMovie2.gridPeopleInMovie;
                   actorFoundByName.DataSource = actorToShow;
                   actorFoundByName.DataBind();
                   GetAppropriateView(actorFoundByName);

               }
               //actorToShow.Add(Request.QueryString["personToShow"]);
        }
        private void GetAppropriateView(GridView actorsGrid)
        {
            actorsGrid.HeaderRow.Cells[(int)PeopleInMovie2.SelectButton].Visible = false;
            foreach (GridViewRow row in actorsGrid.Rows)
            {
                row.Cells[(int)PeopleInMovie2.SelectButton].Visible = false;
                DateTime birthDate = Convert.ToDateTime(row.Cells[(int)PeopleInMovie2.BirthDate].Text);
                string result = birthDate.ToString("d/MM/yyyy");
                if (result == "01/01/9999")
                {
                    result = "Unknown";
                }
                row.Cells[(int)PeopleInMovie2.BirthDate].Text = result;              
            }
        }
    }
}