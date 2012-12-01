<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Ometz.Cinema.NewUI._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
	<style>
    #galleria{ width: 400px; height: 400px; background: #000 }
	</style>
	 
	  <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
		<p>
			<div id="galleria">
            <img src="images/The Bourne Identity.jpg"  >
            <img src="images/MONEYBALL.jpg"  >
						<img src="images/THE HELP.jpg"  >
						<img src="images/Iron Lady.jpg"  >
        </div>

				<script type="text/javascript">
					$(document).ready(function () {

						Galleria.loadTheme('galleria/themes/classic/galleria.classic.min.js');
						Galleria.run('#galleria');
					});
    </script>

		</p>
</asp:Content>
