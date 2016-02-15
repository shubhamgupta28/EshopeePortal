<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View-Product.aspx.cs" Inherits="eShopee2.Product.View_Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div id="leftcol">
        <div id="image">
            <asp:Image ID="imgProduct" runat="server" />
        </div>
        <div id="productpanel">
            <h2><asp:Literal ID="litName" runat="server"></asp:Literal></h2>
            <p><asp:Literal ID="litExcerpt" runat="server"></asp:Literal></p>
            <table>
                <tr>
                    <td>Cost</td>
                    <td><asp:Literal ID="litCost" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td>In Stock</td>
                    <td><asp:Literal ID="litInStock" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnAddToCart" runat="server" /></td>
                    <td></td>
                </tr>
            </table>
        </div>
        <div id="description">
            <p><asp:Literal ID="litDescription" runat="server"></asp:Literal></p>
        </div>
    </div>
</asp:Content>
