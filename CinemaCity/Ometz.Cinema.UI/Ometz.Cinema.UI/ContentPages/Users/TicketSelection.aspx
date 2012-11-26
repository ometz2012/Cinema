<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TicketSelection.aspx.cs" Inherits="Ometz.Cinema.UI.ContentPages.Users.TicketSelection" %>
<%@ Register Src="~/ContentPages/Users/TicketSelectionMVP/TicketControl.ascx" TagName="TicketControl" TagPrefix="TicketControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<TicketControl:TicketControl runat="server" ID = "TicketControlInput"/>
</asp:Content>
