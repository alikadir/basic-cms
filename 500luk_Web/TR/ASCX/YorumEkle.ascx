<%@ Control Language="C#" AutoEventWireup="true" CodeFile="YorumEkle.ascx.cs" Inherits="TR_ASCX_YorumEkle" %>
<style type="text/css">
    .style1
    {
        width: 80px;
        text-align: left;
    }
</style>
<table border="0" width="100%">
    <tr>
        <td valign="top" class="style1">
            Adınız :
        </td>
        <td>
            <asp:TextBox ID="TxtAd" runat="server" Width="150px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="TxtAd" ErrorMessage="!" ValidationGroup="Yorum"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td valign="top" class="style1">
            Epostanız :
        </td>
        <td>
            <asp:TextBox ID="TxtEposta" runat="server" Width="150px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="TxtEposta" ErrorMessage="!" 
                ValidationGroup="Yorum"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td valign="top" class="style1">
            Açıklama :</td>
        <td>
            <asp:TextBox ID="TxtAciklama" runat="server" Height="140px" TextMode="MultiLine" 
                Width="150px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="TxtAciklama" ErrorMessage="!" 
                ValidationGroup="Yorum"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td valign="top" class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="BtnGonder" runat="server" onclick="BtnGonder_Click" 
                Text="Gönder" ValidationGroup="Yorum" BackColor="#666666" 
                ForeColor="White" />
        </td>
    </tr>
</table>
<br />

