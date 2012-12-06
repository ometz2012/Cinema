<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PaymentControl.ascx.cs"
    Inherits="Ometz.Cinema.UI.ContentPages.Users.PaymentMVP.PaymentControl" %>
<link href="../../../Styles/Site.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .style1
    {
        width: 916px;
    }
    .style2
    {
        color: #666666;
        font-variant: small-caps;
        text-transform: none;
        font-weight: 200;
        margin-bottom: 0px;
        font-size: 1.2em;
    }
    .style3
    {
        color: #666666;
        font-variant: small-caps;
        text-transform: none;
        font-weight: 200;
        margin-bottom: 0px;
        font-size: 1.2em;
    }
    .style4
    {
    }
    #ButtonBack
    {
        width: 138px;
    }
    .style5
    {
        color: #666666;
        font-variant: small-caps;
        text-transform: none;
        font-weight: 200;
        margin-bottom: 0px;
        font-size: 1.2em;
        width: 71px;
        text-align: right;
    }
    .style6
    {
        width: 71px;
    }
    .style7
    {
        color: #666666;
        font-variant: small-caps;
        text-transform: none;
        font-weight: 200;
        margin-bottom: 0px;
        font-size: 1.2em;
        width: 94px;
        text-align: right;
    }
    .style8
    {
        width: 94px;
    }
</style>
<html>
<head>
  <script type="text/javascript" language="JavaScript">
      function clickedButton() {

          window.location = "/Default.aspx"

      }
    </script>
</head>
</html>

 
<table class="style1">
    <tr>
        <td class="style3">
            Movie
        </td>
        <td colspan="4">
            <asp:Label ID="lblMovie" runat="server" Text="Label" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style3">
            Theater:
        </td>
        <td colspan="4">
            <asp:Label ID="lblTheater" runat="server" Text="Label" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style3">
            Performance:
        </td>
        <td colspan="4">
            <asp:Label ID="lblPerformance" runat="server" Text="Label" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style3">
            Ticket Price (<asp:Label ID="lblCurencyPrice" runat="server" Text="$CAD"></asp:Label>
            ):
        </td>
        <td colspan="4">
            &nbsp;
            <asp:TextBox ID="txtPrice" runat="server" BackColor="#CCCCCC" ReadOnly="True" Width="49px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style3">
            Amount of Tickets:
        </td>
        <td colspan="4">
            &nbsp;
            <asp:TextBox ID="txtTicketsAmount" runat="server" AutoPostBack="True" MaxLength="4"
                OnTextChanged="txtTicketsAmount_TextChanged" Width="50px"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="ValidatorEmptyTextTicketsAmount" runat="server" ControlToValidate="txtTicketsAmount"
                ErrorMessage="Please enter amount of tickets." ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="ValidatorTicketAmountINT" runat="server" ControlToValidate="txtTicketsAmount"
                ErrorMessage="Please enter numbers only." ForeColor="Red" OnServerValidate="ValidatorTicketAmountINT_ServerValidate"></asp:CustomValidator>
        </td>
    </tr>
    <tr>
        <td class="style3">
            Order Total (<asp:Label ID="lblCurencyTotal" runat="server" Text="$CAD"></asp:Label>
            ):
        </td>
        <td colspan="4">
            &nbsp;
            <asp:TextBox ID="txtTotal" runat="server" BackColor="#CCCCCC" ReadOnly="True" Width="51px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style3">
            &nbsp;
        </td>
        <td colspan="4">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="style3" colspan="5">
            <h3>
            Please fill out your credit card details:
            </h3> 
        </td>
    </tr>
    <tr>
        <td class="style3">
            Credit Card Number:
        </td>
        <td colspan="4">
            &nbsp;
            <asp:TextBox ID="txbCreditCardNumber" runat="server" MaxLength="16" Width="191px"
                CausesValidation="True"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ValidatorEmptyText" runat="server" ControlToValidate="txbCreditCardNumber"
                ErrorMessage="Please fill out credit card number and the expiration date." ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="ValidatorInteger" runat="server" ControlToValidate="txbCreditCardNumber"
                ErrorMessage="Please use numbers only." ForeColor="Red" OnServerValidate="ValidatorInteger_ServerValidate"></asp:CustomValidator>
        </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;Expiration Date
        </td>
        <td class="style5">
            Month:
        </td>
        <td class="style2">
            <asp:DropDownList ID="ddlMonth" runat="server">
                <asp:ListItem Value="0">Select Month...</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td class="style7">
            Year:
        </td>
        <td class="style2">
            <asp:DropDownList ID="ddlYear" runat="server">
                <asp:ListItem Value="0">Select Year...</asp:ListItem>
                <asp:ListItem>2012</asp:ListItem>
                <asp:ListItem>2013</asp:ListItem>
                <asp:ListItem>2014</asp:ListItem>
                <asp:ListItem>2015</asp:ListItem>
                <asp:ListItem>2016</asp:ListItem>
                <asp:ListItem>2017</asp:ListItem>
                <asp:ListItem>2018</asp:ListItem>
                <asp:ListItem>2019</asp:ListItem>
                <asp:ListItem>2020</asp:ListItem>
                <asp:ListItem>2021</asp:ListItem>
                <asp:ListItem>2022</asp:ListItem>
                <asp:ListItem>2023</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style3">
            &nbsp;
        </td>
        <td class="style6">
            &nbsp;
        </td>
        <td class="style4">
            &nbsp;
        </td>
        <td class="style8">
            &nbsp;
        </td>
        <td class="style4">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="style3">
            &nbsp;
        </td>
        <td class="style6">
            &nbsp;</td>
        <td class="style4">
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="SUBMIT"
                Width="96px" />
        </td>
        <td class="style8">
            <input id="ButtonBack" type="button" value="GO TO MAIN PAGE" onclick="clickedButton()" />
        </td>
        <td class="style4">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="style3">
            &nbsp;
        </td>
        <td class="style4" colspan="2">
            <asp:Label ID="lblOrderDetails" runat="server"></asp:Label>
        </td>
        <td class="style8">
            &nbsp;
        </td>
        <td class="style4">
            &nbsp;
        </td>
    </tr>
</table>
