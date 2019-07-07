<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeUI.aspx.cs" Inherits="StockManagementSystem.UI.HomeUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" href="CategorySetupUI.aspx" runat="server">Category Setup</asp:LinkButton>
        <br />
        <br/>
        <asp:LinkButton ID="LinkButton2" href="CompanySetupUI.aspx" runat="server">Company Setup</asp:LinkButton>
         <br />
         <br/>
        <asp:LinkButton ID="LinkButton3" href="ItemSetupUI.aspx"  runat="server">Item Setup</asp:LinkButton>
         <br />
         <br/>
        <asp:LinkButton ID="LinkButton4" href="StockInUI.aspx"  runat="server">Stock In</asp:LinkButton>
         <br />
         <br/>
        <asp:LinkButton ID="LinkButton5" href="StockOutUI.aspx"  runat="server">Stock Out</asp:LinkButton>
         <br />
         <br/>
        <asp:LinkButton ID="LinkButton6" href="SearchAndViewItemsSummaryUI.aspx"  runat="server">Search &amp; View Items Summary</asp:LinkButton>
        
        <br />
        
        <br />
        <asp:LinkButton ID="LinkButton7" href="ViewSalesBetweenTwoDateUI.aspx"  runat="server">View Sales Between Two Dates</asp:LinkButton>
        
        <br />
        
    </div>
        
    </form>
</body>
</html>
