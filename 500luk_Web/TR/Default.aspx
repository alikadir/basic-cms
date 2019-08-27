<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="TR_Default" %>

<%@ Register src="ASCX/Deneme.ascx" tagname="Deneme" tagprefix="uc1" %>

<%@ Register src="ASCX/YorumEkle.ascx" tagname="YorumEkle" tagprefix="uc2" %>

<%@ Register src="ASCX/Galeri.ascx" tagname="Galeri" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                </td>
                
                <td align=right>
                    <uc1:Deneme ID="Deneme1" runat="server" />
                </td>
            </tr>
        </table>
        türkçe ana sayfa<br />
        <uc2:YorumEkle ID="YorumEkle1" runat="server" />
        <uc3:Galeri ID="Galeri" runat="server" />
        <uc1:Deneme ID="Deneme4" runat="server" />
        <uc1:Deneme ID="Deneme2" runat="server" />
        <div align=center style="text-align: left">
        
            <uc1:Deneme ID="Deneme3" runat="server" />
        
        </div>
    </div>
    </form>
</body>
</html>
