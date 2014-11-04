<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WeightManagement.aspx.cs" Inherits="SDW_Wellbeing.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">

    function displayCalendar() {
        var datePicker = document.getElementById('datePicker');
        datePicker.style.display = 'block';
    }
    function displayCalendar2() {
        var datePicker2 = document.getElementById('datePicker2');
        datePicker2.style.display = 'block';
    }
    </script>
    <style type="text/css">
        #datePicker
        {
            display:none;
            position:absolute;
            border:solid 2px black;
            background-color:white;
        }
        #datePicker2
        {
            display:none;
            position:absolute;
            border:solid 2px black;
            background-color:white;
        }
        .content
        {
            width:400px;
            background-color:white;
            margin:auto;
            padding:10px;
        }
   </style>
   <style type="text/css">
	
	body {
		font: 100% arial, helvetica, sans-serif;
	}
	
	fieldset {
		padding: 0 1em 1em 1em;
	}
	
	legend {
		padding: 1em;
	}
	
	label {
		float: left;
		clear: left;
		width: 7em;
	}
	
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <fieldset>
			<legend>Read Weight</legend>
			<div>
				<label for="name">UserID: </label>&nbsp;<asp:TextBox ID="userID" runat="server"></asp:TextBox>
			</div>
			<div>
				<label for="email">From Date: </label>
                &nbsp;<asp:TextBox ID="fromDate" runat="server" ></asp:TextBox>
                <img src="calendar_information.png" onclick="displayCalendar()" />
			</div>
            <div id="datePicker">
                <asp:Calendar id="calEventDate" 
                OnSelectionChanged="calEventDate_SelectionChanged"
                Runat="server" />
             </div>
             
               
			<div>
				<label for="message">To Date: </label>
				&nbsp;<asp:TextBox ID="toDate" runat="server"></asp:TextBox>
                <img src="calendar_information2.png" onclick="displayCalendar2()" />
			</div>
            <div id="datePicker2">
                <asp:Calendar id="calEventDate2" 
                OnSelectionChanged="calEventDate2_SelectionChanged"
                Runat="server" />
             </div>
            
         
            <div><asp:Button ID="Button1" runat="server" Text="OK" onclick="Button1_Click" /></div>
            <br />
            <div>
                    <asp:TextBox ID="message" runat="server" Height="151px" TextMode="MultiLine" 
                        Width="362px"></asp:TextBox>
                </div>
            

		</fieldset>
</asp:Content>
