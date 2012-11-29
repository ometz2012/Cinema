<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActorMain.aspx.cs" Inherits="Ometz.Cinema.UI.ContentPages.MoviePeople.Actors.ActorMain" %>
<%@ Register src="../MoviePeopleUserControls/MainMoviePeople.ascx" tagname="MainMoviePeople" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style14
    {       
        text-align: center;
        font-weight: bold;
        font-size:large;
    }
    
        .style15
        {
            width: 122px;
        }
        .style16
        {
            width: 221px;
        }
    
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p class="style14">
Actors
<br /></p>
    <uc1:MainMoviePeople ID="MainMoviePeople1" runat="server" />
    <table class="style1">
        <tr>
            <td class="style15">
                &nbsp;</td>
            <td class="style16">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" 
                    Text="Search" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style15">
                &nbsp;</td>
            <td class="style16">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
