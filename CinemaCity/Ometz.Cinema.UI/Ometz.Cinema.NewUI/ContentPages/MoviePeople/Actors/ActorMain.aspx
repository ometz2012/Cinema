<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActorMain.aspx.cs" Inherits="Ometz.Cinema.UI.ContentPages.MoviePeople.Actors.ActorMain" %>
<%@ Register src="../MoviePeopleUserControls/MainMoviePeople.ascx" tagname="MainMoviePeople" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style13
    {
        width: 90px;
        text-align: right;
    }
        .style14
    {       
        text-align: center;
        font-weight: bold;
        font-size:large;
    }
    
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p class="style14">
Actors
<br /></p>
    <uc1:MainMoviePeople ID="MainMoviePeople1" runat="server" />
</asp:Content>
