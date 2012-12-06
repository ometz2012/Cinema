<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyAreaControl.ascx.cs"
    Inherits="Ometz.Cinema.UI.ContentPages.Users.MyAreaMVP.MyAreaControl" %>
<link rel="stylesheet" type="text/css" href="../../../Styles/Site.css" />
<style type="text/css">
    a:link, a:visited
    {
        color: #034af3;
    }
    
    .style1
    {
        width: 100%;
    }
    .style3
    {
        width: 502px;
    }
    .style5
    {
        width: 800px;
    }
    .style7
    {
        width: 489px;
        text-align: center;
    }
    .style8
    {
    }
</style>
<link href="../../../Styles/Site.css" rel="stylesheet" type="text/css" />
<table class="style1" frame="below">
    <tr>
        <td class="style3">
            &nbsp;
            <asp:Button ID="btnFavoritesAndRatings" runat="server" BackColor="LightGreen" BorderColor="Black"
                BorderStyle="Ridge" BorderWidth="1px" OnClick="btnFavoritesAndRatings_Click"
                Text="Favorites and Ratings" Font-Size="Medium" />
            <asp:Button ID="btnComments" runat="server" BackColor="LightGray" BorderColor="Black"
                BorderStyle="Ridge" BorderWidth="1px" OnClick="btnComments_Click" 
                Text="Comments to Movies" Font-Size="Medium" />
        </td>
        <td class="style2">
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </td>
    </tr>
</table>
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
        <table class="style5">
            <tr>
                <td class="style7">
                    &nbsp;
                </td>
                <td class="style7">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style7">
                    <h3>
                        Favorite Movies
                    </h3>
                </td>
                <td class="style7">
                    <h3>
                        Ratings
                    </h3>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    <asp:GridView ID="GridViewFavorite" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewFavorite_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="MovieTitle" HeaderText="Movie Name" />
                            <asp:ButtonField CommandName="Select" HeaderText="Remove" Text="Remove" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td class="style7">
                    <asp:GridView ID="GridViewRating" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="MovieTitle" HeaderText="Movie Name" />
                            <asp:BoundField DataField="Rating" HeaderText="My Ratings" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;
                </td>
                <td class="style7">
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <table class="style1">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style8">
                    <asp:TreeView ID="trvComments" runat="server" ImageSet="Arrows" OnSelectedNodeChanged="trvComments_SelectedNodeChanged"
                        ToolTip="Press on the arrows to view the comments." Font-Size="Large">
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                        <ParentNodeStyle Font-Bold="False" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#003399" HorizontalPadding="0px"
                            VerticalPadding="0px" BackColor="#CCFFCC" />
                    </asp:TreeView>
                    &nbsp;
                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                <fieldset>
                <legend> Comment Update </legend>
                    <br />
                    <h4>
                        <asp:Label ID="lblMovieName" runat="server" Text="Movie:"></asp:Label>
                        <asp:Label ID="lblMovieID" runat="server" Visible="False"></asp:Label>
                    </h4>
                    <br />
                    <asp:TextBox ID="txtMovieTitle" runat="server" Width="177px" 
                        BackColor="LightGray" ReadOnly="True"></asp:TextBox>
                    <br />
                    <br />
                    <h4>
                        <asp:Label ID="lblComment" runat="server" Text="Comment:"></asp:Label>
                        <asp:Label ID="lblCommentID" runat="server" Visible="False"></asp:Label>
                    </h4>
                    <br />
                    <asp:TextBox ID="txtCommentContent" runat="server" Width="516px" 
                        MaxLength="100"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="( Maximum 100 characters.)"></asp:Label>
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnUpdate" runat="server" Text="Update Comment" Width="136px" 
                        onclick="btnUpdate_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnDelete" runat="server" Text="Delete Comment" 
                        onclick="btnDelete_Click" />
                    </fieldset>
                </td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>
