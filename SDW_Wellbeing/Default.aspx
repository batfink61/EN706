<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SDW_Wellbeing._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container-fluid">
  <div class="row">
    <div class="col-md-6">
    <h1>Welcome, activity logger</h1>
    <p>Posuere tellus tempus at ullamcorper amet in praesent varius ipsum mi mi adipiscing porttitor. Dolor lacinia id in varius donec diam egestas tempus. Viverra facilisis pellentesque at egestas facilisis metus orci tellus sollicitudin. Mi hendrerit iaculis viverra facilisis enim hendrerit id id ultrices at posuere tincidunt tempus facilisis ligul a. Tempus id hendrerit id morbi diam amet dolor hendrerit viverra dignissim praesent.    
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
