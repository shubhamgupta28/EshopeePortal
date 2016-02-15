<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add-Category.aspx.cs" Inherits="eShopee2.Product.Add_Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add Product Category</h2>
    <asp:Literal ID="litError" runat="server"></asp:Literal>   
    <table>
        <tr>
            <td>Name</td>
            <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Description</td>
            <td><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Parent Category</td>
            <td>
                <asp:ListBox ID="lstParent" runat="server">
                    <asp:ListItem Text="Parent" Value="0" Selected=True></asp:ListItem>
                </asp:ListBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnAddCategory" runat="server" Text="Add Category" 
                    onclick="btnAddCategory_Click" /></td>
        </tr>
    </table>
</asp:Content>
