<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSalesBetweenTwoDateUI.aspx.cs" Inherits="StockManagementSystem.UI.ViewSalesBetweenTwoDateUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
            width: 486px;
        }
        .auto-style2 {
            text-align: right;
            width: 125px;
        }
    </style>
    <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />   
    <link rel="stylesheet" href="/resources/demos/style.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <table style="width:55%; margin-left: 0px;">
            <tr>
                <td class="auto-style1">
            <asp:Label ID="Label1" runat="server" Text="From Date"></asp:Label>
                </td>
                <td class="auto-style2">
                   
               
                    <asp:TextBox ID="fromDateTextBox" runat="server"></asp:TextBox>
                   
               
            </tr>
            <tr>
                <td class="auto-style1">
            <asp:Label ID="Label2" runat="server" Text="To Date"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="toDateTextBox" runat="server"></asp:TextBox>
                </td>
              
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
            <asp:Button ID="viewSalesSearchButton" runat="server" Text="Search" OnClick="viewSalesSearchButton_Click" />
                </td>
              
            </tr>
        </table>
    
    </div>
        <div style="margin-left: 440px">
            <br />
            <asp:Label ID="messageLabel" runat="server"></asp:Label>
            <br />
&nbsp;&nbsp;&nbsp;
        </div>
      
        <asp:GridView ID="salesSummaryGridView" runat="server" AutoGenerateColumns="False" Height="138px" style="margin-left: 297px; text-align: center;" Width="585px">
            
            <Columns>
                    <asp:TemplateField HeaderText="SL">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("ItemName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Sale Quantity">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("StockOutQuantity")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
    </form>
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/jquery-ui-1.12.1.min.js"></script>
      <script>
          $(function () {
              $("#fromDateTextBox").datepicker({
                  changeMonth: true,
                  changeYear: true,
                  showAnim: "clip",
                  dateFormat: "dd-MM-yy",
                  //minDate: new Date(1990, 1, 1),
                  //maxDate: new Date(2090,1,1),
                  showWeek: true,
                  firstDay: 1
              });
          });

          $(function () {
              $("#toDateTextBox").datepicker({
                  changeMonth: true,
                  changeYear: true,
                  showAnim: "clip",
                  dateFormat: "dd-MM-yy",
                  showWeek: true,
                  firstDay: 1
                  
              });
          });
  </script>
</body>
</html>
