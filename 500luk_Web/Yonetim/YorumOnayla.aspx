<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Kalip.master" AutoEventWireup="true" CodeFile="YorumOnayla.aspx.cs" Inherits="Yonetim_YorumOnayla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h3>Yorum onayla</h3>
     <p>
         <asp:DataList ID="DataList1" runat="server" DataKeyField="ID"
             DataSourceID="SqlDataSource1" onitemcommand="DataList1_ItemCommand" 
             Width="100%" Font-Names="Arial">
             <ItemTemplate>
                <font style="color:Red">Baslik:</font> 
                 <asp:Label ID="BaslikLabel" runat="server" Text='<%# Eval("Baslik") %>' />
                 <br />
                 <font style="color:Red">Aciklama:</font> 
                 <asp:Label ID="AciklamaLabel" runat="server" Text='<%# Eval("Aciklama") %>' />
                 <br />
                 <font style="color:Red">Eposta:</font> 
                 <asp:Label ID="EpostaLabel" runat="server" Text='<%# Eval("Eposta") %>' />
                 <br />
                <font style="color:Red"> Ad:</font> 
                 <asp:Label ID="AdLabel" runat="server" Text='<%# Eval("Ad") %>' />
                 <br />
                 <asp:Button ID="BtnSil" runat="server" OnClientClick="javascript:return confirm('silinsin mi?');" CommandName="Sil" Text="Sil" CommandArgument='<%# Eval("ID") %>'/>
                 &nbsp;&nbsp;&nbsp;
                 <asp:Button ID="BtnOnay" runat="server" CommandName="Onay" Text="Onayla" CommandArgument='<%# Eval("ID") %>' />
                 <br />
                
                 <hr />
             </ItemTemplate>
         </asp:DataList>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
             ConnectionString="<%$ ConnectionStrings:GenelConnectionString %>" 
             SelectCommand="SELECT * FROM [Yorum_Tbl] WHERE ([GorunsunMu] = @GorunsunMu)">
             <SelectParameters>
                 <asp:Parameter DefaultValue="False" Name="GorunsunMu" Type="Boolean" />
             </SelectParameters>
         </asp:SqlDataSource>
     </p>
    
</asp:Content>

