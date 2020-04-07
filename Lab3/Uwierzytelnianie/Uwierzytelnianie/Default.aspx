<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Uwierzytelnianie._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    Login: <asp:TextBox  ID="txtLogin" runat="server"></asp:TextBox><br />
   Hasło: <asp:TextBox ID="txtHaslo" runat="server"></asp:TextBox><br />
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /><br />
    <asp:Label ID="lKomunikat" runat="server" Text="Dalej, Proszę się zalogować"></asp:Label>
   

</asp:Content>
