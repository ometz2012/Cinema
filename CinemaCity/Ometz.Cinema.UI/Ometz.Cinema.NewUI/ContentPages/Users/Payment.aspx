<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="Ometz.Cinema.UI.ContentPages.Users.Payment" %>
<%@ Register Src="~/ContentPages/Users/PaymentMVP/PaymentControl.ascx" TagName="PaymentControl" TagPrefix="PaymentControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<PaymentControl:PaymentControl runat="server" id="PaymentControlInput"/>
</asp:Content>
