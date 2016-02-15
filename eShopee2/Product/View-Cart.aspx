<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View-Cart.aspx.cs" Inherits="eShopee2.Product.View_Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="cart">
        <h2>Your Cart Items</h2>
        <asp:Literal ID="litError" runat="server"></asp:Literal>
        <asp:Panel ID="pnlCart" runat="server"></asp:Panel>
        <asp:Button ID="btnPayment" Text="Make Payment" runat="server" />
    </div>
</asp:Content>
