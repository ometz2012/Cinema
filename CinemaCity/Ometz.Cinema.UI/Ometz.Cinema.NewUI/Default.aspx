<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Ometz.Cinema.NewUI._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

<style type="text/css">
    #galleria{ width: 400px; height: 400px; background: #000 }
	</style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
		 
	  <h2>
        Welcome to Cinema Management System!
    </h2>
    <p>
        <b> Developed By Ometz .NET Course </b> 
    </p>
    <p>
       <b> November - December 2012 </b> 
       <br />
       <br />
    </p>
		
			<div id="galleria">
            <img src="images/The Bourne Identity.jpg" alt="Smiley Face" />
            <img src="images/MONEYBALL.jpg"  alt="Smiley Face" />
						<img src="images/THE HELP.jpg" alt="Smiley Face" />
						<img src="images/Iron Lady.jpg" alt="Smiley Face" />
        </div>

				<script type="text/javascript">
					$(document).ready(function () {

						Galleria.loadTheme('galleria/themes/classic/galleria.classic.min.js');
						Galleria.run('#galleria');
					});
    </script>

		
</asp:Content>
