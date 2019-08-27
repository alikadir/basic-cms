<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Kalip.master" AutoEventWireup="true" CodeFile="ResimEkle.aspx.cs" Inherits="Yonetim_ResimEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Küçük Resim<br />
 <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    BüyükResim<br />
    <asp:FileUpload ID="FileUpload2" runat="server" />
    <br />
 
    Etiket :<br />
    <asp:DropDownList ID="Cbx1" runat="server" Width="200px">
        <asp:ListItem>Galeri</asp:ListItem>
        <asp:ListItem>deneme etiket</asp:ListItem>
    </asp:DropDownList>
    <br /><br />   <asp:Button ID="BtnYukle" runat="server"
        Text="Yükle" onclick="BtnYukle_Click" />
    <br /> <br />
    <hr />
    <asp:DataList ID="DataList1" runat="server" DataKeyField="ID" 
        DataSourceID="SqlDataSource1" >
        <ItemTemplate>
        <div style="margin-right:30px;margin-bottom:30px;">
        <img src='<%# "../Foto/Galeri/" + Eval("KucukResim") %>' /><br />
        Etiket : <%#Eval("Etiket") %><br />
        <a href='<%# "ResimEkle.aspx?Sil="+Eval("ID")+"&KucukResim="+Eval("KucukResim")+"&BuyukResim="+Eval("BuyukResim") %>' onclick="javascript:return confirm('Resim Silinsin Mi?');">Sil</a>
           </div>
                   </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:GenelConnectionString %>" 
        SelectCommand="SELECT * FROM [Resim_Tbl] ORDER BY Etiket"></asp:SqlDataSource>
</asp:Content>

