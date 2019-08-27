<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Kalip.master" AutoEventWireup="true" CodeFile="Haberler.aspx.cs" ValidateRequest="false" EnableEventValidation="false" Inherits="Yonetim_Haberler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="tiny_mce/tiny_mce.js"></script>
<script type="text/javascript">


    tinyMCE.init({
        // General options
        mode: "textareas",
        elements: '<%=TxtAciklama.ClientID %>',
        theme: "advanced",
        plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,wordcount,advlist,autosave",

        // Theme options
        theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,styleselect,formatselect,fontselect,fontsizeselect",
        theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
        theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
        theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak,restoredraft",
        theme_advanced_toolbar_location: "top",
        theme_advanced_toolbar_align: "left",
        theme_advanced_statusbar_location: "bottom",
        theme_advanced_resizing: true,

        // Example content CSS (should be your site CSS)
        content_css: "css/content.css",

        // Drop lists for link/image/media/template dialogs
        template_external_list_url: "lists/template_list.js",
        external_link_list_url: "lists/link_list.js",
        external_image_list_url: "lists/image_list.js",
        media_external_list_url: "lists/media_list.js",

        // Style formats
        style_formats: [
			{ title: 'Bold text', inline: 'b' },
			{ title: 'Red text', inline: 'span', styles: { color: '#ff0000'} },
			{ title: 'Red header', block: 'h1', styles: { color: '#ff0000'} },
			{ title: 'Example 1', inline: 'span', classes: 'example1' },
			{ title: 'Example 2', inline: 'span', classes: 'example2' },
			{ title: 'Table styles' },
			{ title: 'Table row 1', selector: 'tr', classes: 'tablerow1' }
		],

        // Replace values for the template plugin
        template_replace_values: {
            username: "Some User",
            staffid: "991234"
        }
    });
</script>
    
     <h3>Kampanyalar</h3>
    <table border="0" width="100%">
        <tr>
            <td align="right" width="83">
                Başlık :
            </td>
            <td align="left">
                <b><asp:TextBox ID="TxtBaslik" runat="server" Width="350px"></asp:TextBox></b>
                <asp:HiddenField ID="HfID" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" width="83">
                Açıklama :
            </td>
            <td align="left">
                <asp:TextBox ID="TxtAciklama" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="83">
                Etiket:</td>
            <td align="left">
                <asp:TextBox ID="TxtEtiket" runat="server" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="83">
                &nbsp;</td>
            <td align="left">
                <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" 
                    onclick="BtnKaydet_Click" Width="200px" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:DataList ID="DataList1" runat="server" DataKeyField="ID" 
        DataSourceID="SqlDataSource1" onitemcommand="DataList1_ItemCommand">
        <ItemTemplate>

        <table border="0" width="100%">
	<tr>
		<td bgcolor="#C0C0C0"><asp:Label ID="BaslikLabel" runat="server" Text='<%# Eval("Baslik") %>' /></td>
	</tr>
	<tr>
		<td > <asp:Label ID="AciklamaLabel" runat="server"  Text='<%# Eval("Aciklama") %>' /></td>
	</tr>
	<tr>
		<td bgcolor="#FFFF00"> <asp:Label ID="EtiketLabel" runat="server" Text='<%# Eval("Etiket") %>' /></td>
	</tr>
	<tr>
		<td>
		<p align="right"> <asp:Button ID="BtnSil" CommandArgument='<%# Eval("ID") %>' runat="server" Text="Sil" OnClientClick="javascript:return confirm('Silmek istediğinize eminmisiniz?');"
                CommandName="Sil" />
            &nbsp;
            <asp:Button ID="BtnGuncelle" runat="server" CommandArgument='<%# Eval("ID") %>' Text="Güncelle" 
                CommandName="Guncelle" /></td>
	</tr>
</table>
<hr>

            
         
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:GenelConnectionString %>" 
        SelectCommand="SELECT * FROM [Haberler_Tbl]"></asp:SqlDataSource>

</asp:Content>

