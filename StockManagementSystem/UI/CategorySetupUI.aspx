<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategorySetupUI.aspx.cs" Inherits="StockManagementSystem.UI.CategorySetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
            width: 1001px;
            height: 442px;
        }
        .auto-style3 {
            height: 31px;
            width: 245px;
            text-align: right;
        }
        .auto-style4 {
            width: 245px;
            text-align: right;
        }
        .auto-style5 {
            height: 31px;
            width: 184px;
            text-align: right;
        }
        .auto-style6 {
            width: 184px;
            text-align: right;
        }
        .auto-style7 {
            text-align: center;
            width: 1001px;
            height: 442px;
        }
        .auto-style8 {
            text-align: center;
            margin-left: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style7">
    
        <div class="auto-style8">
    
    
        <br />
        <br />
        <br />
        </div>
        <table style="width: 23%; margin-left: 505px; height: 96px;">
            <tr>
                <td class="auto-style3">
    
        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                </td>
                <td class="auto-style5">
        <asp:TextBox ID="categoryNameTextBox" runat="server" Height="16px" Width="139px"></asp:TextBox>
    
                </td>
                
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
               
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style6">
                    <asp:Button ID="updateButton" runat="server" OnClick="updateButton_Click1" Text="Update" />
        <asp:Button ID="categorySaveButton" runat="server" style="margin-left: 0" Text="Save" Width="59px" OnClick="categorySaveButton_Click" />
                </td>
               
            </tr>
         
        </table>
        <div class="auto-style8">
            <br />
        </div>
        <div class="auto-style7">
    
           
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
           
                <asp:Label ID="categoryMessageLabel" runat="server" style="text-align: center" ForeColor="#CC0000"></asp:Label>
                <br />
            <br />
            <asp:GridView ID="categorySetupGridView" runat="server" AutoGenerateColumns="False" style="margin-left: 564px; text-align: center;">
                <Columns>
                 <asp:TemplateField HeaderText="SL" >
                   <ItemTemplate >
                       <asp:Label ID="Label3" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Name">
                   <ItemTemplate>
                       <asp:Label ID="Label2" runat="server" Text='<%#Eval("CategoryName") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
                       <asp:TemplateField>
                   <ItemTemplate>
                       <asp:LinkButton ID="updateLinkButton" runat="server" CommandArgument='<%#Eval("CategoryId") %>' OnClick="updateLink_OnClick">Update</asp:LinkButton>
                   </ItemTemplate>
               </asp:TemplateField>
                
            </Columns>
                
            </asp:GridView>
    
                <asp:HiddenField ID="categoryIdHiddenField" runat="server" />
    
    </div>
        <div class="auto-style1">
   
            <br />
        </div>
        <div style="margin-left: 120px">
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

        <br />

    
    </div>
    </form>
</body>
</html>
