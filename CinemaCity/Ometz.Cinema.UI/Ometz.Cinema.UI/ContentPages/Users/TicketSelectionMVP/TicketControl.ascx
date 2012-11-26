<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TicketControl.ascx.cs" Inherits="Ometz.Cinema.UI.ContentPages.Users.TicketSelectionMVP.TicketControl" %>
<link href="../../../Styles/Site.css" rel="stylesheet" type="text/css" />

<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 168px;
        text-align: right;
    }
    .style4
    {
        width: 242px;
    }
</style>


<table class="style1">
    <tr>
        <td class="style2" rowspan="2">
            CHOOSE A MOVIE:</td>
        <td class="style4" rowspan="2">
            <asp:ListBox ID="ListBoxMovies" runat="server" 
                Width="178px" onselectedindexchanged="MovieListBox_SelectedIndexChanged"></asp:ListBox>
&nbsp;&nbsp;&nbsp;&nbsp; </td>
        <td>
            <asp:Label ID="lblMovieDescription" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnSelectMovie" runat="server" Text="SELECT MOVIE" 
                Width="121px" onclick="btnSelectMovie_Click" />
        </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            CHOOSE A CITY:</td>
        <td colspan="2">
            <asp:DropDownList ID="ddlCityList" runat="server" Width="177px" 
                AutoPostBack="True" onselectedindexchanged="ddlCityList_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            CHOOSE THEATER:</td>
        <td colspan="2">
            <asp:GridView ID="GridViewTheater" runat="server" AutoGenerateColumns="False" 
                onselectedindexchanged="GridViewTheater_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="TheaterID" HeaderText="Theater ID" 
                        InsertVisible="False" />
                    <asp:BoundField DataField="TheaterName" HeaderText="Theater Name" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:ButtonField CommandName="Select" HeaderText="Select" Text="Select" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            CHOOSE PERFORMANCE:</td>
        <td colspan="2">
            <asp:GridView ID="GridViewPerformance" runat="server" 
                AutoGenerateColumns="False" 
                onselectedindexchanged="GridViewPerformance_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="PerformanceID" HeaderText="Performance ID" 
                        InsertVisible="False" />
                    <asp:BoundField DataField="PerformaceDate" HeaderText="Performace Date" />
                    <asp:BoundField DataField="StartingTime" HeaderText="Starting Time" />
                    <asp:BoundField DataField="Duration" HeaderText="Duration" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:ButtonField HeaderText="Select" Text="Select" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            YOUR ORDER:</td>
        <td class="style4">
            <asp:Label ID="lblMovie" runat="server"></asp:Label>
            <asp:Label ID="lblSelectedMovie" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblCity" runat="server"></asp:Label>
            <asp:Label ID="lblSelectedCity" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblTheater" runat="server"></asp:Label>
            <asp:Label ID="lblSelectedTheater" runat="server"></asp:Label>
            <br />
        </td>
        <td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnReset" runat="server" Text="RESET" Width="89px" 
                onclick="btnReset_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="CANCEL" Width="89px" />
        </td>
    </tr>
</table>


