<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Ometz.Cinema.NewUI._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
	<style>
    #galleria{ width: 400px; height: 400px; background: #000 }
	</style>
	 
	  <h2>
        Welcome to Cinema Management System!
    </h2>
    <p>
        <b> Developed By Ometz .NET Course </b> 
    </p>
    <p>
       <b> November- December 2012 </b> 
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
