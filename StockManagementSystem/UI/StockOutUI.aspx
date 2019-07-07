<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="StockManagementSystem.UI.StockOutUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 444px;
            text-align: right;
        }

        .auto-style2 {
            text-align: right;
            width: 62px;
        }

        .auto-style3 {
            width: 444px;
            text-align: right;
            height: 26px;
        }

        .auto-style4 {
            text-align: right;
            height: 26px;
            width: 62px;
        }

        .auto-style7 {
            width: 680px;
            height: 160px;
        }

        .auto-style8 {
            width: 444px;
        }

        .auto-style9 {
            width: 62px;
        }

        .auto-style10 {
            text-align: left;
            margin-left: 253px;
        }
    </style>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <div>
        </div>

        <br />
        &nbsp;<table align="left" class="auto-style7" style="margin-right: 146px; height: 170px; width: 622px; margin-left: 93px;">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label1" runat="server" Text="Company"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:DropDownList ID="companyDropDownList" runat="server" Height="22px" Width="143px" Style="margin-left: 0px" AutoPostBack="True" OnTextChanged="companyDropDownList_TextChanged">
                    </asp:DropDownList>
                </td>

            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="Item"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="itemDropDownList" runat="server" Height="23px" Width="143px" Style="margin-left: 0px" AutoPostBack="True" OnTextChanged="itemDropDownList_TextChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label3" runat="server" Text="Reorder Level"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="reorderLevelTextBox" runat="server" Width="145px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label4" runat="server" Text="Available Quantity"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="availableQuantityTextBox" runat="server" Width="145px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label5" runat="server" Text="Stock Out Quantity"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="stockOutQuantityTextBox" runat="server" Width="145px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="addButton" runat="server" Style="text-align: right" Text="Add" Width="60px" Height="26px" OnClick="addButton_Click" />
                </td>
            </tr>
        </table>

        <br />

        <div style="margin-left: 240px; text-align: left;" class="auto-style10">

            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

            <asp:GridView ID="stockOutGridView" runat="server" AutoGenerateColumns="False" Height="141px" Style="margin-left: 102px; text-align: center;" Width="391px">
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
                    <asp:TemplateField HeaderText="Company">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("CompanyName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("StockOutQuantity")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>

            <div class="auto-style10">

            <br />

           
            &nbsp;<asp:Button ID="sellButton" runat="server" Text="Sell" OnClick="sellButton_Click" style="margin-left: 0px" Width="70px" />
                &nbsp;&nbsp;
            <asp:Button ID="damageButton" runat="server" Text="Damage" OnClick="damageButton_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="lostButton" runat="server" Text="Lost" Width="68px" OnClick="lostButton_Click" />
            &nbsp;</div>
            <asp:HiddenField ID="itemIdHiddenField" runat="server" />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="messageLabel" runat="server" style="text-align: center"></asp:Label>
            <asp:HiddenField ID="availableQuantityHiddenField" runat="server" />
        </div>
    </form>
</body>
</html>
