<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Galeri.ascx.cs" Inherits="TR_ASCX_Galeri" %>
<script src="fancybox/jquery-1.4.1.js" type="text/javascript"></script>
<link href="fancybox/jquery.fancybox-1.3.3.css" rel="stylesheet" type="text/css" />
<script src="fancybox/jquery.fancybox-1.3.3.js" type="text/javascript"></script>
<script src="fancybox/jquery.mousewheel-3.0.4.pack.js" type="text/javascript"></script>
<asp:DataList ID="DataList1" runat="server" DataKeyField="ID" Width="800" 
        DataSourceID="SqlDataSource1" RepeatColumns="5">
        <ItemStyle Height="140px" />
        <ItemTemplate>
            <table border="1" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                     <a rel="GG" class="aSPAresim" href='<%# "../Foto/Galeri/" + Eval("BuyukResim") %>'><img border="0"  src='<%# "../Foto/Galeri/" + Eval("KucukResim") %>' /></a>
                    </td>
                </tr>
            </table>
           
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:GenelConnectionString %>" 
        SelectCommand="SELECT * FROM [Resim_Tbl] WHERE Etiket='Galeri'"></asp:SqlDataSource>

         <script type="text/javascript">
             $(document).ready(function () {
                 $("a[rel=GG]").fancybox();
             });

      
      </script>      