<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Admin.Master" AutoEventWireup="true" CodeBehind="insert_category.aspx.cs" Inherits="KpopZtation.View.CategoryFolder.insert_category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../StyleCSS/insertStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center-containerIns">
        <div style="margin-bottom: 20px;">
            <asp:Label ID="nameLbl" runat="server" Text="Category Name" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="nameTbx" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="btn-container">
            <asp:Button ID="insertBtn" runat="server" Text="Insert" OnClick="insertBtn_Click" CssClass="btn btn-primary" />
        </div>
        <div>
            <asp:Label ID="errorLbl" runat="server" Text="" CssClass="error-label" Visible ="false"></asp:Label>
        </div>
    </div>
</asp:Content>
