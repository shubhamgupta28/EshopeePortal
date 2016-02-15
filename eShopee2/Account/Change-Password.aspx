<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Change-Password.aspx.cs" Inherits="eShopee2.Account.Change_Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Change Account Password</h2>
    <asp:Literal ID="litError" runat="server"></asp:Literal>
    <table>
        <tr>
            <td>Old Password</td>
            <td><asp:TextBox ID="txtOldPassword" TextMode="Password" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>New Password</td>
            <td><asp:TextBox ID="txtNewPassword" TextMode="Password" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Confirm New Password</td>
            <td><asp:TextBox ID="txtConfNewPassword" TextMode="Password" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnUpdate" Text="Update Password" runat="server" 
                    onclick="btnUpdate_Click" /></td>
        </tr>
    </table>
</asp:Content>
