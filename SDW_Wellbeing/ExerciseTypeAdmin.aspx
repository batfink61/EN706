﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExerciseTypeAdmin.aspx.cs" Inherits="SDW_Wellbeing.ExerciseAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="container-fluid">
  <div class="row">
    <div id="exercises" runat="server" class="col-md-6">
  </div>
  <div class="col-md-6">
  <div id="validate" runat="server" class="form-group">
  <h3>Add Exercise</h3>
<asp:Label ID="addExercise" runat="server" Text="Exercise Name:" CssClass="control-label"></asp:Label><asp:TextBox ID="ExerciseName"
    runat="server" CssClass="required form-control"></asp:TextBox>
    <asp:Button ID="CreateExercise" runat="server" Text="Add" 
        onclick="CreateExercise_Click" class="btn form-btn" />
    
   </div>
   </div>
        </div>
    
</asp:Content>
