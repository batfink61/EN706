<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WeightGraph.aspx.cs" Inherits="SDW_Wellbeing.WeightGraph" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<script type="text/javascript">
$(function () {
        $('#Div1').highcharts({
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

            categories: ['2013-10-09','2013-11-15','2013-12-05','2014-01-22','2014-01-25']            },
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
                data: [30.5,20,10,5,14]            }]
        });
    });

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="Div1" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
</asp:Content>
