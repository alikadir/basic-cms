<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Kalip.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Yonetim_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center">
<br />
<br />
<table border="0" width="300px">
	<tr>
		<td align=right>Eposta : </td>
		<td align=left>
            <asp:TextBox ID="TxtEposta" runat="server" Width="200px"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td align=right>Sifre : </td>
		<td align=left>
            <asp:TextBox ID="TxtSifre" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>&nbsp;</td>
		<td align=left>
            <asp:Button ID="BtnGirıs" runat="server" Text="Giriş" onclick="BtnGirıs_Click" 
                Width="100px" />
        </td>
	</tr>
</table>
</div>
</asp:Content>

