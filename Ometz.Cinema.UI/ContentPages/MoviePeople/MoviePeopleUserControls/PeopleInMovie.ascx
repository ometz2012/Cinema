<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PeopleInMovie.ascx.cs" Inherits="Ometz.Cinema.UI.ContentPages.MoviePeople.MoviePeopleUserControls.PeopleInMovie" %>
<link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />

<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 68px;
    }
    .style3
    {
        width: 432px;
    }
</style>

<table class="style1">
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style3">
            <asp:Label ID="lblPersonInMovie" runat="server" CssClass="bold"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style3">
            <asp:GridView ID="gridPersonInMovie" runat="server">
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
        <td class="style3">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style3">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>

