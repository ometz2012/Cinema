<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProducersInMovie.aspx.cs" Inherits="Ometz.Cinema.NewUI.ContentPages.MoviePeople.Producers.ProducersInMovie" %>
<%@ Register src="../MoviePeopleUserControls/PeopleInMovie.ascx" tagname="PeopleInMovie" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:PeopleInMovie ID="PeopleInMovie1" runat="server" />
</asp:Content>
