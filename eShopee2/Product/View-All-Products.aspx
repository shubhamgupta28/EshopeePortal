<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View-All-Products.aspx.cs" Inherits="eShopee2.Product.View_All_Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Product Management</h2>
    <a href="Add-Product.aspx">Add Product</a>
    <asp:Panel ID="pnlProduct" runat="server"></asp:Panel>
</asp:Content>