<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="eShopee2.Account.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Customer Registration Form</h2>
    <asp:Literal ID="litError" runat="server"></asp:Literal>
    <table>
        <tr>
            <td>Name</td>
            <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Email Address</td>
            <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
        </tr>
        
        <tr>
            <td>Password</td>
            <td><asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Confirm Password</td>
            <td><asp:TextBox ID="txtRePassword" TextMode="Password" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnRegister" runat="server" Text="Register" 
                    onclick="btnRegister_Click" /></td>
        </tr>
    </table>
</asp:Content>
