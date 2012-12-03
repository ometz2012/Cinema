<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TicketControl.ascx.cs"
    Inherits="Ometz.Cinema.UI.ContentPages.Users.TicketSelectionMVP.TicketControl" %>
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
        width: 265px;
    }
    a
    {
        color: #0254EB;
    }
    a:visited
    {
        color: #0254EB;
    }
    a.morelink
    {
        text-decoration: none;
        outline: none;
    }
    .morecontent span
    {
        display: none;
    }
    .comment
    {
        width: 400px;
        background-color: #f0f0f0;
        margin: 10px;
    }
</style>
<table class="style1">
    <tr>
        <td class="style2" rowspan="2">
            CHOOSE A MOVIE:
        </td>
        <td class="style4" rowspan="2">
            <asp:ListBox ID="ListBoxMovies" runat="server" Width="178px" OnSelectedIndexChanged="MovieListBox_SelectedIndexChanged"
                AutoPostBack="True"></asp:ListBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        <td>
            <%--<asp:Label ID="lblMovieDescription" runat="server"></asp:Label>--%>
            <div class="comment more" id="inputContainer" runat="server">
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnSelectMovie" runat="server" Text="SELECT MOVIE" Width="121px"
                OnClick="btnSelectMovie_Click" />
        </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;
        </td>
        <td colspan="2">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="style2">
            CHOOSE A CITY:
        </td>
        <td colspan="2">
            <asp:DropDownList ID="ddlCityList" runat="server" Width="177px" AutoPostBack="True"
                OnSelectedIndexChanged="ddlCityList_SelectedIndexChanged" DataTextField="CityName"
                DataValueField="CityID">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;
        </td>
        <td colspan="2">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="style2">
            CHOOSE THEATER:
        </td>
        <td colspan="2">
            <asp:GridView ID="GridViewTheater" runat="server" AutoGenerateColumns="False" OnRowCreated="GridViewTheater_RowCreated"
                OnRowCommand="GridViewTheater_RowCommand">
                <Columns>
                    <asp:BoundField DataField="TheaterID" HeaderText="Theater ID" />
                    <asp:BoundField DataField="TheaterName" HeaderText="Theater Name" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:ButtonField CommandName="Select" HeaderText="Select" Text="Select" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;
        </td>
        <td colspan="2">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="style2">
            CHOOSE PERFORMANCE:
        </td>
        <td colspan="2">
            <asp:GridView ID="GridViewPerformance" runat="server" AutoGenerateColumns="False"
                OnRowCommand="GridViewPerformance_RowCommand" OnRowCreated="GridViewPerformance_RowCreated">
                <Columns>
                    <asp:BoundField DataField="PerformanceID" HeaderText="Performance ID" />
                    <asp:BoundField DataField="PerformaceDate" HeaderText="Performace Date" />
                    <asp:BoundField DataField="StartingTime" HeaderText="Starting Time" />
                    <asp:BoundField DataField="Duration" HeaderText="Duration" />
                    <asp:BoundField DataField="Price" HeaderText="Price ($CAD)" />
                    <asp:ButtonField HeaderText="Select" Text="Select" CommandName="Select" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;
        </td>
        <td colspan="2">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="style2">
            YOUR ORDER:
        </td>
        <td class="style4">
            <asp:Label ID="lblMovie" runat="server"></asp:Label>
            <asp:Label ID="lblSelectedMovie" runat="server"></asp:Label>
            <asp:Label ID="lblMovieID" runat="server" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="lblCity" runat="server"></asp:Label>
            <asp:Label ID="lblSelectedCity" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblTheater" runat="server"></asp:Label>
            <asp:Label ID="lblSelectedTheater" runat="server"></asp:Label>
            <br />
        </td>
        <td>
            &nbsp;
            <asp:Button ID="btnReset" runat="server" Text="RESET" Width="143px" OnClick="btnReset_Click"
                ToolTip="By pushing the button you will be able reset your choice and start over." />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;
        </td>
        <td class="style4">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
</table>
<html>
<script type="text/javascript" src="http://code.jquery.com/jquery-latest.min.js"
    charset="utf-8"> 
</script>
<script type="text/javascript">
    $(document).ready(function () {
        var showChar = 100;
        var ellipsestext = "...";
        var moretext = "more";
        var lesstext = "less";
        $('.more').each(function () {
            var content = $(this).html();
            if (content.length > showChar) {
                var c = content.substr(0, showChar);
                var h = content.substr(showChar - 1, content.length - showChar);
                var html = c + '<span class="moreellipses">' + ellipsestext + '&nbsp;</span><span class="morecontent"><span>' + h + '</span>&nbsp;&nbsp;<a href="" class="morelink">' + moretext + '</a></span>';
                $(this).html(html);
            }
        });
        $(".morelink").click(function () {
            if ($(this).hasClass("less")) { $(this).removeClass("less"); $(this).html(moretext); }
            else { $(this).addClass("less"); $(this).html(lesstext); }
            $(this).parent().prev().toggle();
            $(this).prev().toggle();
            return false;
        });
    });

</script>
</html>
