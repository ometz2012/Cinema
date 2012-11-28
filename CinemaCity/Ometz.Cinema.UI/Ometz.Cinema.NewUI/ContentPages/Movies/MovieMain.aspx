<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieMain.aspx.cs" Inherits="Ometz.Cinema.NewUI.ContentPages.Movies.MovieMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <br />

    <asp:Label ID="lblTitleMovie" runat="server" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#000099" Text="Title"></asp:Label>
&nbsp;
    <asp:DropDownList ID="ddlTitleMovie" runat="server" Height="26px" 
    Width="135px" >
    </asp:DropDownList>
&nbsp;
    <asp:Label ID="lblActorMovie" runat="server" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#000099" Text="Actor"></asp:Label>
&nbsp;
    <asp:DropDownList ID="ddlActorMovie" runat="server" Height="25px" 
    Width="135px">
    </asp:DropDownList>
&nbsp; 
    <asp:Label ID="lblGenreMovie" runat="server" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#000099" Text="Genre"></asp:Label>
&nbsp;
    <asp:DropDownList ID="ddlGenreMovie" runat="server" Height="25px" 
    Width="135px">
    </asp:DropDownList>
&nbsp;
    <asp:Label ID="lblYearMovie" runat="server" Font-Bold="True" Font-Size="Medium" 
        ForeColor="#000099" Text="Year"></asp:Label>
&nbsp;
    <asp:DropDownList ID="ddlYearMovie" runat="server" Height="25px" 
    Width="66px">
    </asp:DropDownList>
&nbsp;
    <asp:Label ID="lblProducerMovie" runat="server" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#000099" Text="Producer"></asp:Label>
&nbsp;
    <asp:DropDownList ID="ddlProducerMovie" runat="server" Height="25px" 
    Width="135px">
    </asp:DropDownList>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Repeater ID="RepeaterMovie" runat="server">
    <HeaderTemplate />
   
    
    <HeaderTemplate />
    
    <ItemTemplate />
    
     

      <separatortemplate>
      </separatortemplate>

    
    </asp:Repeater>
    <br />

</asp:Content>


