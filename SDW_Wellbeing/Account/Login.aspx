<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="SDW_Wellbeing.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>


               

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <div class="container signin">
    <div class="row form-group">
    <div class="span12">
    <fieldset class="form">
    <asp:Label ID="EmailLabel" runat="server" Text="Email:"></asp:Label>
    <asp:TextBox ID="UserID" runat="server"  CssClass="form-control email required has-error" ontextchanged="UserID_TextChanged"></asp:TextBox>
    <asp:Label ID="PasswordLabel" runat="server" Text="Password:"></asp:Label>  
    <asp:TextBox ID="Password" runat="server" CssClass="form-control required" TextMode="Password"></asp:TextBox>
    <asp:Button ID="LoginButton" runat="server" CssClass="submit login btn btn-default" onclick="LoginButton_Click" Text="Log In" />
    </fieldset>
    </div>
     </div>
    </div>
</asp:Content>
