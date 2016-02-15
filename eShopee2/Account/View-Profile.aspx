<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View-Profile.aspx.cs" Inherits="eShopee2.Account.View_Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>View Profile</h2>
    <asp:Panel ID="pnlImage" runat="server"></asp:Panel>
    <table>
        <tr>
            <td>Name</td>
            <td><asp:Literal ID="litName" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td>Email Address</td>
            <td><asp:Literal ID="litEmail" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td>Mobile</td>
            <td><asp:Literal ID="litMobile" runat="server"></asp:Literal></td>
        </tr>
    </table>
</asp:Content>
