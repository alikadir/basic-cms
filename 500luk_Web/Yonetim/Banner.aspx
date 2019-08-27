<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Kalip.master" AutoEventWireup="true" CodeFile="Banner.aspx.cs" Inherits="Yonetim_Banner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="Yükle" /><br />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

</asp:Content>

