<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WritersInMovie.aspx.cs" Inherits="Ometz.Cinema.NewUI.ContentPages.MoviePeople.Writers.WritersInMovie" %>
<%@ Register src="../MoviePeopleUserControls/PeopleInMovie.ascx" tagname="PeopleInMovie" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc2:PeopleInMovie ID="PeopleInMovie1" runat="server" />
</asp:Content>
