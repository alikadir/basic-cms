<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Yorumlar.ascx.cs" Inherits="TR_ASCX_Yorumlar" %>
<asp:DataList ID="DataList1" runat="server" DataKeyField="ID" 
    DataSourceID="SqlDataSource1" Font-Names="Arial">
    <ItemTemplate>
       <font style="color:Red">Ad:</font> 
        <asp:Label ID="AdLabel" runat="server" Text='<%# Eval("Ad") %>' />
        <br />
        <font style="color:Red"> Aciklama:</font> 
        <asp:Label ID="AciklamaLabel" runat="server" Text='<%# Eval("Aciklama") %>' />
    </ItemTemplate>
</asp:DataList>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:GenelConnectionString %>" 
    SelectCommand="SELECT * FROM Yorum_Tbl WHERE GorunsunMu = 'True' ORDER BY ID DESC">
</asp:SqlDataSource>
