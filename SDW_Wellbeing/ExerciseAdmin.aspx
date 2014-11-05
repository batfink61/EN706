<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExerciseAdmin.aspx.cs" Inherits="SDW_Wellbeing.ExerciseAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Label ID="Label1" runat="server" Text="Exercise Name"></asp:Label><asp:TextBox ID="ExerciseName"
    runat="server"></asp:TextBox>
    <asp:Button ID="CreateExercise" runat="server" Text="Submit" 
        onclick="CreateExercise_Click" />

</asp:Content>
