<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SDW_Wellbeing._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container-fluid">
  <div class="row">
    <div class="col-md-8">
    <h1>Welcome, activity logger</h1>
    <p>Posuere tellus tempus at ullamcorper amet in praesent varius ipsum mi mi adipiscing porttitor. Dolor lacinia id in varius donec diam egestas tempus. Viverra facilisis pellentesque at egestas facilisis metus orci tellus sollicitudin. Mi hendrerit iaculis viverra facilisis enim hendrerit id id ultrices at posuere tincidunt tempus facilisis ligul a. Tempus id hendrerit id morbi diam amet dolor hendrerit viverra dignissim praesent.    
    </p>
    
    
    </div>
  <div class="col-md-4">

                    <div class="form-group">
                    
                            <legend>Register:</legend>
                            <p>
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="control-label">User Name:</asp:Label><br />
                                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry form-control"></asp:TextBox><br />
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                     CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label><br />
                                <asp:TextBox ID="Email" runat="server" CssClass="textEntry"></asp:TextBox><br />
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" 
                                     CssClass="failureNotification" ErrorMessage="E-mail is required." ToolTip="E-mail is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label><br />
                                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox><br />
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                     CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label><br />
                                <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox><br />
                                <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic" 
                                     ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired" runat="server" 
                                     ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                     CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                            </p>
                            <asp:Button ID="btnRegister" runat="server" Text="Register" 
                                onclick="btnRegister_Click"  />

                            <asp:Label ID="lblMessage" runat="server"></asp:Label>

                    </div>


  
  </div>

  </div>
</div>
</asp:Content>
