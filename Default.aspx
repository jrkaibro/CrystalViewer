<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>     
        <asp:TextBox ID="TextBox1" runat="server" BorderStyle="None" CssClass="input" ReadOnly="True" Width="1349px"></asp:TextBox>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
            Height="1039px" Width="901px" ReportSourceID="CrystalReportSource1" ToolTip="crystal" EnableDatabaseLogonPrompt="True" ReuseParameterValuesOnRefresh="True" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="Reports\Sample.rpt"></Report>
        </CR:CrystalReportSource>
    
    </div>
    </form>
</body>
</html>
