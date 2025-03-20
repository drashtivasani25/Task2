<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="T1.WebForm1" EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-top: 4px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Name<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </h2>
            <h2>Age<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </h2>
            <h2>Grade<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </h2>
        </div>
        <div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" />
        </div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" CssClass="auto-style1">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button ID="Button2" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="Button2_Click" style="height: 26px" Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:Button ID="Button3" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="Button3_Click" Text="Update" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
    </form>
</body>
</html>
