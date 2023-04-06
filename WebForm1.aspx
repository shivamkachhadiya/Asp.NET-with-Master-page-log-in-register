<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>rajkot</asp:ListItem>
        <asp:ListItem>surat</asp:ListItem>
        <asp:ListItem>ahemdabad</asp:ListItem>
    </asp:DropDownList><br />
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatColumns="3">
        <asp:ListItem>male</asp:ListItem>
        <asp:ListItem>female</asp:ListItem>
        <asp:ListItem>other</asp:ListItem>
</asp:RadioButtonList>
<asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="3">
    <asp:ListItem>play</asp:ListItem>
    <asp:ListItem>read</asp:ListItem>
    <asp:ListItem>write</asp:ListItem>
</asp:CheckBoxList>
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="register" />
    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="log in" />
    <asp:GridView ID="GridView1" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="edit">
                <ItemTemplate>
                    <asp:Button ID="Button2" runat="server" CommandArgument='<%# Eval("id") %>' OnClick="Button2_Click" Text="update" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="delete">
                <ItemTemplate>
                    <asp:Button ID="Button3" runat="server" CommandArgument='<%# Eval("id") %>' OnClick="Button3_Click" Text="delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
</asp:Content>
