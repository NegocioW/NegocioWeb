<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Negocio.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
      <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
    </style>
  
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var options = {
                title: 'USA City Distribution'
            };
            var chartType = $("#rblChartType input:checked").val();

            //3D Pie Chart
            if (chartType == "2") {
                options.is3D = true;
            }

            //Doughnut Chart
            if (chartType == "3") {
                options.pieHole = 0.5;
            }
            $.ajax({
                type: "POST",
                url: "CS.aspx/GetChartData",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.PieChart($("#chart")[0]);
                    chart.draw(data, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
    </script>
    <asp:RadioButtonList ID="rblChartType" runat="server" AutoPostBack="true">
        <asp:ListItem Text="Pie" Value="1" Selected="True" />
        <asp:ListItem Text="Pie-3D" Value="2" />
        <asp:ListItem Text="Doughnut" Value="3" />
    </asp:RadioButtonList>
    <div id="chart" style="width: 900px; height: 500px;">
        <asp:TextBox ID="txtfecha" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </div>
</asp:Content>