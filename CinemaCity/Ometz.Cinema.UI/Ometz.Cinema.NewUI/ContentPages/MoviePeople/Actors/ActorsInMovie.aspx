<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActorsInMovie.aspx.cs" Inherits="Ometz.Cinema.UI.ContentPages.MoviePeople.Actors.ActorsInMovie" %>
<%@ Register src="../MoviePeopleUserControls/PeopleInMovie.ascx" tagname="PeopleInMovie" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:PeopleInMovie ID="PeopleInMovie2" runat="server" />
</asp:Content>

