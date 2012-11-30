<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainMoviePeople.ascx.cs" Inherits="Ometz.Cinema.UI.ContentPages.MoviePeople.MoviePeopleUserControls.MainMoviePeople" %>

<link href="../../../Styles/Site.css" rel="stylesheet" type="text/css" />
<script src="../../../Scripts/jquery-1.4.1.min.js" type="text/javascript"> </script>

<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 216px;
    }
    .style3
    {
        width: 290px;
    }
</style>

<p>
    &nbsp;</p>
<table class="style1">
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style3">
            <asp:Label ID="lblSearchByMovieName" runat="server" CssClass="bold"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style3">
            <asp:GridView ID="gridMovies" runat="server">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
           
        </td>
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
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style3">
            <asp:Label ID="lblSearchByPersonName" runat="server" CssClass="bold"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            &nbsp;</td>
        <td>
            <asp:TextBox ID="txtSearchPersonByName" runat="server" 
                ontextchanged="txtSearchPersonByName_TextChanged"></asp:TextBox>
        </td>
           	

    </tr>
    

</table>


     <a id="slickbox-toggle" href="#">Show</a>		                 
     <div id="slickbox">Search the Movie Person by First or Last name, Full Name or 
Part of the Name ..</div>

<script type="text/javascript">
    $(document).ready(function () {

        $('#slickbox').hide();
    });
    $('a#slickbox-toggle').click(function () {
       
        $('#slickbox').slideToggle(100);
        $(this).text($(this).text() == 'Show' ? 'Hide' : 'Show'); // <- HERE
        return false;
    });
 </script>