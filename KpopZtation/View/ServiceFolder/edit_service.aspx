<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Admin.Master" AutoEventWireup="true" CodeBehind="edit_service.aspx.cs" Inherits="KpopZtation.View.AlbumFolder.edit_album" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../StyleCSS/editStyle.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="containerEdit">
        <h2>Update Album Data</h2>
        <div>
            <label for="nameTbx">Album Name</label>
            <asp:TextBox ID="nameTbx" runat="server" CssClass="input"></asp:TextBox>
        </div>
        <div>
            <label for="descTbx">Description</label>
            <asp:TextBox ID="descTbx" runat="server" CssClass="input"></asp:TextBox>
        </div>
        <div>
            <label for="priceTbx">Price</label>
            <asp:TextBox ID="priceTbx" runat="server" type="number" CssClass="input"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="updateBtn" runat="server" Text="Update" CssClass="button" OnClick="updateBtn_Click" />
            <asp:Label ID="errorLbl" runat="server" CssClass="error" Text="" Visible ="false"></asp:Label>
        </div>
    </div>
</asp:Content>
