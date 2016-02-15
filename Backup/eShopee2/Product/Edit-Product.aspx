<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit-Product.aspx.cs" Inherits="eShopee2.Product.Edit_Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Edit Product</h2>
    <asp:Literal ID="litError" runat="server"></asp:Literal>   
    <table>
        <tr>
            <td>Name</td>
            <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Product Image</td>
            <td><asp:FileUpload ID="fileImage" runat="server" /></td>
        </tr>
        <tr>
            <td>Excerpt</td>
            <td><asp:TextBox ID="txtExcerpt" runat="server" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Description</td>
            <td><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Cost</td>
            <td><asp:TextBox ID="txtCost" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>In Stock</td>
            <td>
                <asp:RadioButtonList ID="radInStock" runat="server">
                    <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                    <asp:ListItem Value="No" Text="No"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>Featured</td>
            <td>
                <asp:RadioButtonList ID="radFeatured" runat="server">
                    <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                    <asp:ListItem Value="No" Text="No"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr
        <tr>
            <td>Status</td>
            <td>
                <asp:RadioButtonList ID="radStatus" runat="server">
                    <asp:ListItem Value="Active" Text="Active"></asp:ListItem>
                    <asp:ListItem Value="Inactive" Text="Inactive"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>Category</td>
            <td>
                <asp:ListBox ID="lstCategory" runat="server" SelectionMode="Multiple">
                    
                </asp:ListBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnUpdateProduct" runat="server" Text="Update Product" /></td>
        </tr>
    </table>
</asp:Content>
