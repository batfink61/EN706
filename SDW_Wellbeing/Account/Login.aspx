<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="SDW_Wellbeing.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>


               

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <div class="container signin">
    <div class="row form-group">
    <div class="span12">
    <asp:Label ID="EmailLabel" runat="server" Text="Email :"></asp:Label>
    <asp:TextBox ID="UserID" runat="server"  CssClass="form-control" ontextchanged="UserID_TextChanged"></asp:TextBox>
    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="UserID" 
                                      ErrorMessage="E-mail is required." ToolTip="E-mail is required." 
                                     ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
            <asp:Label ID="PasswordLabel" runat="server" Text="Password :"></asp:Label>
    
    <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                     ErrorMessage="Password is required." ToolTip="Password is required." 
                                     ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
    
    <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-default" onclick="LoginButton_Click" 
        Text="Log In" />

</div>
     </div>
    </div>
</div>
</asp:Content>
