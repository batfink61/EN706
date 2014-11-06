<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="record_weight.aspx.cs" Inherits="SDW_Wellbeing.Account.record_weight" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<title>Record Weight</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    Date <br />
    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox><br />
    Weight <br />
    <asp:TextBox ID="txtWeight" runat="server"></asp:TextBox><br /><br />
    <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
    <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
    <br />

</asp:Content>
