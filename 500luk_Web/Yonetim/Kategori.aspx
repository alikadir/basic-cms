<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Kalip.master" AutoEventWireup="true" CodeFile="Kategori.aspx.cs" Inherits="Yonetim_Kategori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 153px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h3>Kategori<asp:HiddenField ID="HfID" runat="server" />
    </h3>
    <asp:Panel ID="Panel1" runat="server" Visible="False">
    
   <table border="0" width="100%">
	<tr>
		<td align="right" class="style1">Bağlı Olduğu Kategori :</td>
		<td align="left">
            <asp:Label ID="LblKategoriAd" runat="server"></asp:Label>
        </td>
	</tr>
	<tr>
		<td align="right" class="style1">Kategori Adı :</td>
		<td align="left">
            <asp:TextBox ID="TxtKategoriAd" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td align="right" class="style1">Boş Resim Kullan :</td>
		<td align="left">
            <asp:CheckBox ID="CbxResim" runat="server" />
        </td>
	</tr>
	<tr>
		<td align="right" class="style1">Resim Yükle :</td>
		<td align="left">
            <asp:FileUpload ID="FileUpload1" runat="server" />
            &nbsp;<asp:Image ID="Image1" runat="server" />
        </td>
	</tr>
	<tr>
		<td align="right" class="style1">Etiket : </td>
		<td align="left">
            <asp:TextBox ID="TxtEtiket" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td align="right" class="style1">&nbsp;</td>
		<td align="left">
            <asp:Button ID="BtnKaydet" runat="server" onclick="BtnKaydet_Click" 
                Text="Kaydet" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="BtnIptal" runat="server" onclick="BtnIptal_Click" 
                Text="İptal" />
        </td>
	</tr>
</table>
</asp:Panel>
    <br />
    <asp:Button ID="BtnAnaEkle" runat="server" onclick="BtnAnaEkle_Click" 
        Text="Ana Kategori Ekle" Width="300px" />
    <br />
    <br />
    <asp:Button ID="BtnGuncelle" runat="server" onclick="BtnGuncelle_Click" 
        Text="Seçili Kategoriyi Güncelle" Width="300px" />
    <br />
    <asp:Button ID="BtnSil" runat="server" onclick="BtnSil_Click" OnClientClick="javascript:return confirm('Kategori Silinsin Mi?');"
        Text="Seçili Kategoriyi Sil" Width="300px" />
    <br />
    <asp:Button ID="BtnEkle" runat="server" onclick="BtnEkle_Click" 
        Text="Seçili Kategoriye Alt Kategori Ekle" Width="300px" />
    <br />
    <br />
    <asp:TreeView ID="TreeView1" runat="server" ImageSet="Simple" NodeIndent="10" 
        Font-Size="15px">
        <HoverNodeStyle Font-Underline="True" ForeColor="#DD5555" />
        <NodeStyle Font-Names="Verdana" Font-Size="15px" ForeColor="Black" 
            HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
        <ParentNodeStyle Font-Bold="False" />
        <SelectedNodeStyle Font-Underline="True" ForeColor="#DD5555" 
            HorizontalPadding="0px" VerticalPadding="0px" />
    </asp:TreeView>
</asp:Content>

