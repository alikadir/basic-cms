<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Kalip.master" AutoEventWireup="true" CodeFile="Urunler.aspx.cs" EnableEventValidation="false" ValidateRequest="false" Inherits="Yonetim_Urunler" %>

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


    tinyMCE.init({
        // General options
        mode: "textareas",
        elements: '<%=TxtSpot.ClientID %>',
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
    
<h3>Ürünler</h3>
    
        <asp:DropDownList ID="CbxUrunler" runat="server" Width="300px">
        </asp:DropDownList>
    <br />
    <br />
        <asp:Button ID="BtnYeniUrun" runat="server" Text="Yeni Ürün Ekle" 
        Width="300px" onclick="BtnYeniUrun_Click" />
    <br />
    <br />
        <asp:Button ID="BtnGuncelle" runat="server" Text="Seçili Ürünü Güncelle" 
        Width="300px" onclick="BtnGuncelle_Click" />
    <br />
        <asp:Button ID="BtnSil" runat="server" Text="Seçili Ürünü Sil" 
        Width="300px" onclick="BtnSil_Click" OnClientClick="javascript:return confirm('Ürünü Silinsin Mi?');"/>
   <br />
        <asp:Button ID="BtnResim" runat="server" 
            Text="Seçili Ürünün Resimlerini Güncelle" Width="300px" 
        onclick="BtnResim_Click" />
    <asp:HiddenField ID="HfID" runat="server" />
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server">
    <table border="1" width="100%">
	<tr>
		<td width="109" align="right">Ad :</td>
		<td align="left">
            <asp:TextBox ID="TxtAd" runat="server" Width="300px"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td width="109" align="right">Spot : </td>
		<td align="left">
            <asp:TextBox ID="TxtSpot" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
        </td>
	</tr>
	    <tr>
            <td align="right" width="109">
                Aciklama :</td>
            <td align="left">
                <asp:TextBox ID="TxtAciklama" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
	<tr>
		<td width="109" align="right">Etiket :&nbsp; </td>
		<td align="left">
            <asp:TextBox ID="TxtEtiket" runat="server" Width="300px"></asp:TextBox>
        </td>
	</tr>
	    <tr>
            <td align="right" width="109">
                Kategori :</td>
            <td align="left">
                <asp:ListBox ID="LbxKategori" runat="server" Height="150px" 
                    SelectionMode="Multiple" Width="300px"></asp:ListBox>
                CTRL ile çoklu seçim yapılabilir</td>
        </tr>
	<tr>
		<td width="109" align="right">&nbsp;</td>
		<td align="left">
            <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" 
                onclick="BtnKaydet_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="BtnUrunIptal" runat="server" Text="İptal" 
                onclick="BtnUrunIptal_Click" />
        </td>
	</tr>
</table>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        <asp:Label ID="LblAd" runat="server"></asp:Label>
        <br />
        Büyük Resim&nbsp;<asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;
        <br />
        Küçük Resim
        <asp:FileUpload ID="FileUpload2" runat="server" />
        <br />
        <asp:Button ID="BtnResimYukle" runat="server" Text="Kaydet" 
            onclick="BtnResimYukle_Click" />
        <br />
        <asp:DataList ID="DataList1" runat="server" DataKeyField="ID" 
            DataSourceID="SqlDataSource1">
            <ItemTemplate>
                <img src='<%# "../Foto/UrunResim/" + Eval("KResim") %>' />
               <br />
                <a href='<%# "Urunler.aspx?Sil="+Eval("ID")+"&BResim="+Eval("BResim") +"&KResim="+Eval("KResim")%>' 
                    onclick="javascript:return confirm('Resim Silinsin Mi?');">Sil</a>
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:GenelConnectionString %>" 
            SelectCommand="SELECT * FROM [UrunResim_Tbl] WHERE ([UrunID] = @UrunID)">
            <SelectParameters>
                <asp:ControlParameter ControlID="HfID" Name="UrunID" PropertyName="Value" 
                    Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </asp:Panel>
   
</asp:Content>

