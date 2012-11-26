<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Movie.aspx.cs" Inherits="Ometz.Cinema.NewUI.ContentPages.Movies.Movie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<style type="text/css">
        .style1
        {
            width: 84%;
            margin-left: 38px;
            height: 305px;
        }
        .style2
        {
            width: 282px;
        }
        .style3
        {
            width: 148px;
        }
        .style4
        {
            width: 100%;
            height: 334px;
        }
        .style5
        {
            width: 386px;
        }
        .style6
        {
            width: 173px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblMovieName" runat="server" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#000099" Text="Movie Name:"></asp:Label>
        &nbsp;&nbsp;
    <asp:Label ID="lblMovieTitle" runat="server" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#000099"></asp:Label>
    <br />
    <br />
    <br />
    <table class="style4">
        <tr>
            <td class="style5">
                <asp:Image ID="imgMoviePicture" runat="server" Height="300px" Width="381px" />
            </td>
            <td class="style6">
                &nbsp;</td>
            <td>
                <table class="style1">

                <tr>
                 <td class="style3">
                <asp:Label ID="lblGenreMovie" runat="server" Font-Bold="True" Font-Size="Medium" 
                    Text="Genre"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="lblGenreType" runat="server"></asp:Label>
                    </td>
                
                </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblYearMovie" runat="server" Font-Bold="True" Font-Size="Medium" 
                    Text="Year"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="blYear" runat="server"></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td class="style3">
                <asp:Label ID="lblMainActorsMovie" runat="server" Font-Bold="True" 
                    Font-Size="Medium" Text="Main Actors"></asp:Label>
            </td>
            <td class="style2">
                <asp:LinkButton ID="lnkbtnActors" runat="server"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" 
                    Text="Producer"></asp:Label>
            </td>
            <td class="style2">
                <asp:LinkButton ID="lnkbtnProducer" runat="server"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblDirectorMovie" runat="server" Font-Bold="True" 
                    Font-Size="Medium" Text="Director"></asp:Label>
            </td>
            <td class="style2">
                <asp:LinkButton ID="lnkbtnDirector" runat="server"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblComposerMovie" runat="server" Font-Bold="True" 
                    Font-Size="Medium" Text="Composer"></asp:Label>
            </td>
            <td class="style2">
                <asp:LinkButton ID="lnkbtnComposer" runat="server"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblSoundtrackMovie" runat="server" Font-Bold="True" 
                    Font-Size="Medium" Text="Soundtrack"></asp:Label>
            </td>
            <td class="style2">
                <asp:LinkButton ID="lnkbtnSoundtrack" runat="server"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblOfficialSiteMovie" runat="server" Font-Bold="True" 
                    Font-Size="Medium" Text="Official Site"></asp:Label>
            </td>
            <td class="style2">
                <asp:LinkButton ID="lnkbtnOfficialSite" runat="server"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblWhereToSee" runat="server" Font-Bold="True" 
                    Font-Size="Medium" Text="Where to see"></asp:Label>
            </td>
            <td class="style2">
                <asp:LinkButton ID="nkbtnWhereToSee" runat="server"></asp:LinkButton>
                </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblBuyTicketMovie" runat="server" Font-Bold="True" 
                    Font-Size="Medium" Text="Buy tickets"></asp:Label>
            </td>
            <td class="style2">
                <asp:LinkButton ID="lnkbtnBuyTickets" runat="server"></asp:LinkButton>
                </td>
        </tr>
    </table>

            </td>
        </tr>
    </table>
    <br />

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    &nbsp;&nbsp;&nbsp;
<asp:Label ID="lblDescriptionMovie" runat="server" Font-Bold="True" 
    Font-Size="Medium" Text="Description"></asp:Label>
<br />
<br />
&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblDescriptionDetails" runat="server"></asp:Label>
<br />
<br />
&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" 
    Text="External Reviews:"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="lnkbtnExternReview" runat="server"></asp:LinkButton>
<br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnAddToFavorites" runat="server" Text="Add to Favorites" 
    Width="153px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnAddComments" runat="server" Height="26px" 
    Text="Add Comments" Width="152px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnAddRating" runat="server" Text="Add Rating" Width="153px" />
<br />
<br />

</asp:Content>


