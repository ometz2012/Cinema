<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TheaterControl.ascx.cs" Inherits="Ometz.Cinema.UI.ContentPages.Theaters.TheaterMVP.TheaterControl" %>
<style type="text/css">
	.style1
	{
		width: 100%;
	}
	.style2
	{
		width: 114px;
	}
	.hidden
	{
		display:none;
	}
</style>

<table class="style1">
	<tr>
		<td class="style2">
			<asp:Label ID="lblTheaterName" runat="server" Text="Theater Name :"></asp:Label>
		</td>
		<td>
			<asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
		</td>
		<td>
			&nbsp;</td>
		<td>
			&nbsp;</td>
		<td>
			&nbsp;</td>
	</tr>
	<tr>
		<td class="style2">
			<asp:Label ID="lblAddress" runat="server" Text="Address :"></asp:Label>
		</td>
		<td>
			<asp:Label ID="lblAddressLine1" runat="server" Text="Label"></asp:Label>
			,<asp:Label ID="lblCity" runat="server" Text="Label"></asp:Label>
			,<asp:Label ID="lblPostalCode" runat="server" Text="Label"></asp:Label>
			,<asp:Label ID="lblProvince" runat="server" Text="Label"></asp:Label>
			,<asp:Label ID="lblCountry" runat="server" Text="Label"></asp:Label>
		</td>
		<td>
			&nbsp;</td>
		<td>
			&nbsp;</td>
		<td>
			&nbsp;</td>
	</tr>
	<tr>
		<td class="style2">
			<asp:Label ID="lblShowPhone" runat="server" Text="Phone :"></asp:Label>
		</td>
		<td>
			<asp:Label ID="lblPhone" runat="server" Text="Label"></asp:Label>
		</td>
		<td>
			&nbsp;</td>
		<td>
			&nbsp;</td>
		<td>
			&nbsp;</td>
	</tr>
	<tr>
		<td class="style2">
			<asp:Label ID="lblShowEmail" runat="server" Text="Email :"></asp:Label>
		</td>
		<td>
			<asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
		</td>
		<td>
			&nbsp;</td>
		<td>
			&nbsp;</td>
		<td>
			&nbsp;</td>
	</tr>
	<tr>
		<td class="style2">
			&nbsp;</td>
		<td>
			<asp:GridView ID="GridViewPerformance" runat="server" 
				AutoGenerateColumns="False" 
				onselectedindexchanged="GridViewPerformance_SelectedIndexChanged">
				<Columns>
					<asp:BoundField DataField="PerformanceID" HeaderText="PerformanceID" ItemStyle-CssClass="hidden" />
					<asp:BoundField DataField="Tilte" HeaderText="Movie Name" />
					<asp:BoundField DataField="RoomNumber" HeaderText="Room Number" />
					<asp:BoundField DataField="Date" HeaderText="Date" />
					<asp:BoundField DataField="StartingTime" HeaderText="Starting Time" />
					<asp:BoundField DataField="Duration" HeaderText="Duration" />
					<asp:BoundField DataField="Price" HeaderText="Price" />
					<asp:CommandField ShowSelectButton="True" SelectText="Buy Ticket" />
				</Columns>
			</asp:GridView>
		</td>
		<td>
			&nbsp;</td>
		<td>
			&nbsp;</td>
		<td>
			&nbsp;</td>
	</tr>
	<tr>
		<td class="style2">
			<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
		</td>
		<td>
			&nbsp;</td>
		<td>
			&nbsp;</td>
		<td>
			&nbsp;</td>
		<td>
			&nbsp;</td>
	</tr>
</table>

