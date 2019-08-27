<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Kalip.master" AutoEventWireup="true" CodeFile="FlashBanner.aspx.cs" Inherits="Yonetim_FlashBanner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="BtnYukle" runat="server"
        Text="Yükle" onclick="BtnYukle_Click" />
    <br />
    Etiket :
    <asp:TextBox ID="TxtEtiket" runat="server"></asp:TextBox>
    <br />
    <asp:DataList ID="DataList1" runat="server" DataKeyField="ID" 
        DataSourceID="SqlDataSource1">
        <ItemTemplate>

        <img src='<%# "../Foto/FlashBanner/" + Eval("Resim") %>' /><br />
        Etiket : <%#Eval("Etiket") %><br />
        <a href='<%# "FlashBanner.aspx?Sil="+Eval("ID")+"&Resim="+Eval("Resim") %>' onclick="javascript:return confirm('Resim Silinsin Mi?');">Sil</a>
           
                   </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:GenelConnectionString %>" 
        SelectCommand="SELECT * FROM [FlashBanner_Tbl]"></asp:SqlDataSource>
</asp:Content>

