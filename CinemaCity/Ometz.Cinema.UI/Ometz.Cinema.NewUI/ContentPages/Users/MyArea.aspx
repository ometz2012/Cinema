<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MyArea.aspx.cs" Inherits="Ometz.Cinema.UI.ContentPages.Users.MyArea" %>

<%@ Register Src="~/ContentPages/Users/MyAreaMVP/MyAreaControl.ascx" TagName="MyAreaControl"
    TagPrefix="MyAreaControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    </p>
    <h2>
        WELCOME TO MY AREA</h2>
    <h3>
    </h3>
    <p>
    </p>
    <MyAreaControl:MyAreaControl runat="server" ID="myAreaInput" />
</asp:Content>
