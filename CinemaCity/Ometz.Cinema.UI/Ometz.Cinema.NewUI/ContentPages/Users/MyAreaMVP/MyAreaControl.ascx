<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyAreaControl.ascx.cs" Inherits="Ometz.Cinema.UI.ContentPages.Users.MyAreaMVP.MyAreaControl" %>
<style type="text/css">
    
h3
{
    font-size: 1.2em;
}

h1, h2, h3, h4, h5, h6, h7
{
    font-size: 1.5em;
    color: #666666;
    font-variant: small-caps;
    text-transform: none;
    font-weight: 200;
    margin-bottom: 0px;
   
}

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
            width: 201px;
        }
    </style>

<link href="../../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <table class="style1">
        <tr>
            <td class="style3">
                <h3>
                    My Favorite Movies:
                </h3>
            </td>
            <td class="style2">
                <asp:GridView ID="GridViewFavorite" runat="server" AutoGenerateColumns="False" 
                    onselectedindexchanged="GridViewFavorite_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="MovieTitle" HeaderText="Movie Name" />
                        <asp:ButtonField HeaderText="Remove" Text="Remove" CommandName="Select" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;
                <br />
            </td>
            <td class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                <h3>
                    &nbsp; My Comments:
                </h3>
            </td>
            <td class="style2">
                <asp:GridView ID="GridViewComments" runat="server" AutoGenerateColumns="False" 
                    onrowdatabound="GridViewComments_RowDataBound" 
                    onrowcommand="GridViewComments_RowCommand" 
                    onrowcreated="GridViewComments_RowCreated">
                    <Columns>
                        <asp:BoundField DataField="CommentID" HeaderText="Comment ID"  />
                        <asp:BoundField DataField="MovieTitle" HeaderText="Movie Name" />
                      <%--  <asp:BoundField DataField="CommentContent" HeaderText="My Comments" ItemStyle-CssClass="hidden" />--%>
                        <asp:TemplateField HeaderText="My Comments">
                        <ItemTemplate>
                        <asp:TextBox runat="server" ID="txtComment"></asp:TextBox>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField HeaderText="Update Comment" Text="Update" 
                            CommandName="Select">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:ButtonField>
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblGridCommentsUpdate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;
                <br />
            </td>
            <td class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                <h3>
                    &nbsp; My Ratings:
                </h3>
            </td>
            <td class="style2">
                <asp:GridView ID="GridViewRating" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="MovieTitle" HeaderText="Movie Name" />
                        <asp:BoundField DataField="Rating" HeaderText="My Ratings" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;
                <br />
            </td>
            <td class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;
            </td>
            <td class="style2">
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>


