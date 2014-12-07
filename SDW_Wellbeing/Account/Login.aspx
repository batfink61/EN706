<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="SDW_Wellbeing.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <div class="container signin">
    <div class="row form-group">
    <h3>Please enter your details</h3>
    <p>If your not registered for the service you can do so <a href="/Default.aspx">here</a></p>
    <div class="span12">
    <div id="validate" runat="server" class="form-group">
    <fieldset class="form">
    <asp:Label ID="EmailLabel" runat="server" Text="Email:" Font-Bold="True"></asp:Label>
    <asp:Label ID="EmailError" runat="server" CssClass="error"></asp:Label>
    <asp:TextBox ID="UserID" runat="server"  CssClass="form-control" ontextchanged="UserID_TextChanged"></asp:TextBox>
    <asp:Label ID="PasswordLabel" runat="server" Text="Password:" Font-Bold="True"></asp:Label>  
     <asp:Label ID="PasswordError" runat="server" CssClass="error"></asp:Label>
    <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
    <asp:Button ID="LoginButton" runat="server" CssClass="submit login btn form-btn" onclick="LoginButton_Click" Text="Log In" />
    <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </fieldset>
    
    </div>
    </div>
     </div>
    </div>
</asp:Content>
