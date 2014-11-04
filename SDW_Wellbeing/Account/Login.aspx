<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="SDW_Wellbeing.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:TextBox ID="UserID" runat="server" ontextchanged="UserID_TextChanged"></asp:TextBox>
    <asp:TextBox ID="Password" runat="server"></asp:TextBox>
    <asp:Button ID="LoginButton" runat="server" onclick="LoginButton_Click" 
        Text="Log In" />
</asp:Content>
