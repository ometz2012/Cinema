<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Theater.aspx.cs" Inherits="Ometz.Cinema.UI.ContentPages.Theaters.Theater" %>
<%@ Register src="TheaterSearchMVP/TheaterSearchControl.ascx" tagname="TheaterSearchControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<uc1:TheaterSearchControl ID="TheaterSearchControl1" runat="server" />
</asp:Content>
