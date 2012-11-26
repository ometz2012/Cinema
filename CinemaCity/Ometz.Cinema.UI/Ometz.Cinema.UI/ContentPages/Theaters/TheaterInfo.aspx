<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TheaterInfo.aspx.cs" Inherits="Ometz.Cinema.UI.ContentPages.Theaters.TheaterInfo" %>
<%@ Register src="TheaterMVP/TheaterControl.ascx" tagname="TheaterControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<uc1:TheaterControl ID="TheaterControl1" runat="server" />
</asp:Content>
