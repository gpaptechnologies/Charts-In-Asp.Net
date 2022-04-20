<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChartControl.aspx.cs" Inherits="Chart.ChartControl" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Charts in Asp.Net</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="tblChartData" runat="server" Font-Bold="true" HorizontalAlign="Center" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" Width="50%">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell ColumnSpan="2" Font-Bold="true" HorizontalAlign="Center" ForeColor="Blue" Font-Size="X-Large">
                    CHARTS<hr />
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell>
                        State
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlStates" runat="server" AppendDataBoundItems="true">
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        Chart Type
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:RadioButtonList ID="rblChartType" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Column" Value="10" Selected="True" />
                            <asp:ListItem Text="Bar" Value="7" />
                            <asp:ListItem Text="Pie" Value="17" />
                        </asp:RadioButtonList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                        <hr />
                        <asp:Button ID="btnShowChart" runat="server" Text="Show Chart" Font-Bold="true" color="Blue" ForeColor="YellowGreen" OnClick="btnShowChart_Click" Style="color: blue" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableFooterRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:Label ID="lblMessage" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label>
                    </asp:TableCell>
                </asp:TableFooterRow>
            </asp:Table>
           <div id="divChart" runat="server" visible="false" style="text-align: center">
                <asp:Chart ID="myChart" runat="server" Width="500px" Height="350px">
                    <Series>
                        <asp:Series Name="EMP Count" ChartType="StackedColumn">
                        </asp:Series>
                    </Series>
                    <Titles>
                        <asp:Title IsDockedInsideChartArea="true" Text="Employee Details" BackColor="YellowGreen" ForeColor="Blue" Font="Microsoft Sans Serif, 10pt"></asp:Title>
                    </Titles>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisX Title="State" TitleForeColor="Blue" TitleFont="Microsoft Sans Serif, 12pt"></AxisX>
                            <AxisY Title="EMP Count" TitleForeColor="Blue" TitleFont="Microsoft Sans Serif, 12pt"></AxisY>
                        </asp:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <asp:Legend Docking="Bottom"></asp:Legend>
                    </Legends>
                </asp:Chart>

            </div>
        </div>
    </form>
</body>
</html>
