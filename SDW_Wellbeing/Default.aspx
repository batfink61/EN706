<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SDW_Wellbeing._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container-fluid">
  <div class="row">
    <div class="col-md-6">
    <h1>Wellbeing Portal</h1>
    <p>Welcome to your Wellbeing Portal.<br />
    You can register on-line and use this portal to access health and wellbeing information<br />
    as well as managing your own progress. You will be able to track your own exercise and weight trends<br />
    and compare these with recomendations published by the NHS.<br />
    You will also be able to share your progress with a healthcare professional and book an <br />
    appointment to review your progress.
    </p>
  </div>
  <div class="col-md-6">

                    <div class="form-group">
                    
                            <legend>Register</legend>
                       
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="control-label">User Name:</asp:Label>
                                <asp:Label ID="UserNameError" runat="server" AssociatedControlID="UserName" CssClass="error"></asp:Label>
                                <asp:TextBox ID="UserName" runat="server" CssClass="required form-control" ></asp:TextBox>
                                

                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                <asp:Label ID="EmailError" runat="server" AssociatedControlID="Email" CssClass="error"></asp:Label>
                                <asp:TextBox ID="Email" runat="server" CssClass="textEntry form-control"></asp:TextBox>
                                
                            
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                <asp:Label ID="PasswordError" runat="server" AssociatedControlID="Password" CssClass="error"></asp:Label>
                                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry form-control" TextMode="Password"></asp:TextBox>
                                
                               
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                                <asp:Label ID="ConfirmPasswordError" runat="server" AssociatedControlID="ConfirmPassword" CssClass="error"></asp:Label>
                                <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry form-control" TextMode="Password"></asp:TextBox>
                            

                            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn form-btn" onclick="btnRegister_Click"  />
                            <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>

                    </div>


  
  </div>

  </div>
</div>
</asp:Content>
