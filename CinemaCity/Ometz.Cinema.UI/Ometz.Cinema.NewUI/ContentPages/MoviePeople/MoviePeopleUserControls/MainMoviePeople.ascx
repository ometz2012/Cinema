<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainMoviePeople.ascx.cs" Inherits="Ometz.Cinema.UI.ContentPages.MoviePeople.MoviePeopleUserControls.MainMoviePeople" %>

<link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />

<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 216px;
    }
</style>

<p>
    &nbsp;</p>
<table class="style1">
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            <asp:Label ID="lblSearchByMovieName" runat="server" CssClass="bold"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            <asp:GridView ID="gridMovies" runat="server">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>

