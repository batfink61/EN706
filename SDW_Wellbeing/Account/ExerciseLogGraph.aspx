<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExerciseLogGraph.aspx.cs" Inherits="SDW_Wellbeing.Account.ExerciseManagement" %>
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

$(function () {
        $('#Div3').highcharts({
            chart: {
                type: 'line',
                width: 1000
            },
            title: {
                text: 'weight',
                x: -20 //center
            },
            xAxis: {
                title: {
                    enabled: true,
                    text: 'Date',
                },
                maxPadding: 0.05,
                showLastLabel: true, 

            categories: [<%=dateList %>]            },
            yAxis: {
                title: {
                    text: 'weight'
                },
                plotLines: [{
                    value: 0,
                    width: 1,
                    color: '#808080'
                }]
            },
            tooltip: {
                valueSuffix: '°C'
            },
            legend: {
                layout: 'vertical',
                align: 'right',
                verticalAlign: 'top',
                x: -10,
                y: 100,
                borderWidth: 0
            },
            series: [{
                name: 'Weight',
                data: [<%=durationList %>]            }]
        });
    });

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
        .datesWeightsTable {
		    border-collapse: collapse;
		    table-layout: fixed;
		    width: 100%;
        }
	    .datesWeightsTd
        {
		    border: 1px solid #999;
		    padding: 0.1em 1em;
	    }
        .datesWeightsTh
        {
		    border: 1px solid #999;
		    padding: 0.1em 1em;
	    }
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
<!--Testing-->
 <fieldset>
			<legend>View Exercise Log/Graph</legend>
            <!--
			<div>
				<label for="name">UserID: </label>&nbsp;<asp:TextBox ID="userID" runat="server"></asp:TextBox>
			</div>
            -->
			<div>
				<label for="email">From Date: </label>
                &nbsp;<asp:TextBox ID="fromDate" runat="server" ></asp:TextBox>
                <img alt="click me" src="../images/calendar_information.png" onclick="displayCalendar()" />
			</div>
            <div id="datePicker">
                <asp:Calendar id="calEventDate" 
                OnSelectionChanged="calEventDate_SelectionChanged"
                Runat="server" />
             </div>
             
               
			<div>
				<label for="message">To Date: </label>
				&nbsp;<asp:TextBox ID="toDate" runat="server"></asp:TextBox>
                <img alt="click me" src="../images/calendar_information2.png" onclick="displayCalendar2()" />
			</div>
            <div id="datePicker2">
                <asp:Calendar id="calEventDate2" 
                OnSelectionChanged="calEventDate2_SelectionChanged"
                Runat="server" />
             </div>
            
         
            <div><asp:Button ID="Button1" runat="server" Text="OK" CssClass="btn form-btn" onclick="Button1_Click" /></div>
            <br />
            <div>
                <%=dateExerciseTable %>
                <asp:Label ID="message" runat="server"></asp:Label>
             </div>
            
            <%=graph%>

		</fieldset>
</asp:Content>
