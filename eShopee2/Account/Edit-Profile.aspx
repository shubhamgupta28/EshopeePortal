<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit-Profile.aspx.cs" Inherits="eShopee2.Account.Edit_Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Edit Profile</h2>
    <asp:Literal ID="litError" runat="server"></asp:Literal>
    <table>
        <tr>
            <td>Email Address</td>
            <td><asp:Literal ID="litEmail" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td>Name</td>
            <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
        </tr>
        
        <tr>
            <td>Mobile</td>
            <td><asp:TextBox ID="txtMobile" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnUpdate" runat="server" Text="Update" 
                    onclick="btnUpdate_Click" /></td>
        </tr>
    </table>
</asp:Content>
