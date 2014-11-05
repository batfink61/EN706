<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Calform.aspx.cs" Inherits="SDW_Wellbeing._CalForm" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container-fluid">
  <div class="row">
    <div class="col-md-4">

    <h1>Welcome</h1>
    
    <asp:Calendar ID="Calendar" runat="server" BackColor="White" 
            BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" 
            ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" 
            onselectionchanged="Calendar_SelectionChanged" 
            ondayrender="Calendar_DayRender">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
            VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" 
            Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
        <TodayDayStyle BackColor="#CCCCCC" />
        </asp:Calendar>
        
        <a href="WeightManagement.aspx">View Weight</a>
        
    </div>
    <div class="col-md-4">
   
    <p>&nbsp;</p><p>Summary</p><p>
    <asp:Literal ID="CalSummary" runat="server"></asp:Literal>
    </p>
    </div>
    <div class="col-md-4">

    </td><td valign="top">
    
    <h2>Advice</h2>

    <h3>Weight</h3>

    <ul>
    <li><a href="http://www.nhs.uk/Conditions/Obesity/Pages/Introduction.aspx">Losing weight</a></li>
    <li><a href="http://www.nhs.uk/LiveWell/c25k/Pages/couch-to-5k.aspx">Couch to 5k</a></li>
    <li><a href="http://www.nhs.uk/conditions/bulimia/pages/introduction.aspx">Bulimia Nervosa</a></li>
    <li><a href="http://www.nhs.uk/conditions/bulimia/pages/introduction.aspx">Binge Eating</a></li>
    </ul>

    <h3>Exercise</h3>

    <ul>
    <li><a href="http://www.nhs.uk/LiveWell/Fitness/Pages/Fitnesshome.aspx">Health and Fitness</a></li>
    <li><a href="http://www.nhs.uk/Livewell/fitness/Pages/whybeactive.aspx">Benefits of Exercise</a></li>
    <li><a href="http://www.nhs.uk/livewell/tiredness-and-fatigue/Pages/tiredness-and-fatigue.aspx">Tiredness and Fatigue</a></li>
    </ul>
    
  </div>

  </div>
</div>



</asp:Content>
