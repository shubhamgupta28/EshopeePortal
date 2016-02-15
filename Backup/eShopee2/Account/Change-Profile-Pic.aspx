<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Change-Profile-Pic.aspx.cs" Inherits="eShopee2.Account.Change_Profile_Pic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Change Profile Pic</h2>
    <asp:Literal ID="litError" runat="server"></asp:Literal><br>
    <asp:Image ID="imgProfilePic" runat="server"/><br>
    <asp:FileUpload ID="fileProfilePic" runat="server" /><br>
    <asp:Button ID="btnUpload" Text="Update Pic" runat="server" />
</asp:Content>
