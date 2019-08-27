<%@ Control Language="C#" AutoEventWireup="true" CodeFile="YorumlarKisa.ascx.cs" Inherits="TR_ASCX_YorumlarKisa" %>
<style>
.Ad 
{
   color:#AC3928;
   font-size:10px;
   font-family:Arial;
    }
    .Yorum 
{
   color:#252424;
   font-size:10px;
   font-family:Arial;
    }
</style>
<asp:DataList ID="DataList1" runat="server" DataKeyField="ID" 
    DataSourceID="SqlDataSource1">
    <ItemTemplate>
        <img src="resimler/yorumico.png" /> &nbsp;<asp:Label CssClass="Ad" ID="AdLabel" runat="server" Text='<%# Eval("Ad") %>' />&nbsp;&nbsp;<asp:Label CssClass="Yorum" ID="AciklamaLabel" runat="server" Text='<%# YorumKes(Eval("Aciklama").ToString()) %>' /><br />
        
       
    </ItemTemplate>
</asp:DataList>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:GenelConnectionString %>" 
    SelectCommand="SELECT TOP(5) * FROM Yorum_Tbl WHERE GorunsunMu = 'True' ORDER BY ID DESC">
</asp:SqlDataSource>
<br />
<asp:Button ID="BtnTumYorumlar" runat="server" BackColor="#666666" 
                ForeColor="White" Text="Tüm Yorumları Gör" />

