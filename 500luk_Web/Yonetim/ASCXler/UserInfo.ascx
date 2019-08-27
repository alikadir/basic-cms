<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserInfo.ascx.cs" Inherits="Yonetim_ASCXler_UserInfo" %>
<asp:Panel ID="Panel1" runat="server">

    <style type="text/css">
    .ah
    {
    	color:White; font-family:Arial; font-weight:bold; font-size:15px;text-decoration:none;
    	}
    	
    	.ah:hover
    	{
    		color:White; font-family:Arial; font-weight:bold; font-size:15px;text-decoration:underline;
    		}
    
    </style>
<table border="0" cellpadding="0"  cellspacing="0" width="100%" style="height:30px;background-color:Silver;">
    <tr>
        <td >
        
        &nbsp;&nbsp;&nbsp;
        <a class="ah" href="FlashBanner.aspx" style="margin-right:20px">Flash Banner</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <a class="ah" href="Banner.aspx" style="margin-right:20px">Banner</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <a class="ah" href="Duyurular.aspx" style="margin-right:20px">Duyurular</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <a class="ah" href="Haberler.aspx" style="margin-right:20px">Kampanyalar</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <a class="ah" href="ResimEkle.aspx" style="margin-right:20px">Galeri</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <a class="ah" href="Kategori.aspx" style="margin-right:20px">Kategori</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <a class="ah" href="Urunler.aspx" style="margin-right:20px">Ürünler</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <a class="ah" href="YorumOnayla.aspx" style="margin-right:20px">Yorum Onayla</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
         <td align=right>
         <asp:Label ForeColor=White Font-Size=Large ID="LblInfo" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
    </tr>
</table>
</asp:Panel>

