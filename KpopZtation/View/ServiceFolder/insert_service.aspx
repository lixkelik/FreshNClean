<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Admin.Master" AutoEventWireup="true" CodeBehind="insert_service.aspx.cs" Inherits="KpopZtation.View.AlbumFolder.insert_service" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../StyleCSS/insertStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center-containerIns">
        <div style="margin-bottom: 20px; text-align:center;">
            <asp:Label ID="titleLbl" runat="server" Text="Insert an Album" Font-Bold="True" Font-Size="25px"></asp:Label>
        </div>
        <div style="margin-bottom: 20px;">
            <asp:Label ID="nameLbl" runat="server" Text="Album Name" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="nameTbx" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div style="margin-bottom: 20px;">
            <asp:Label ID="descLbl" runat="server" Text="Description" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="descTbx" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div style="margin-bottom: 20px;">
            <asp:Label ID="priceLbl" runat="server" Text="Price" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="priceTbx" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="btn-container">
            <asp:Button ID="insertBtn" runat="server" Text="Insert Album" OnClick="insertBtn_Click" CssClass="btn btn-primary"/>
        </div>
        <div>
            <asp:Label ID="errorLbl" runat="server" Text="" CssClass="error-label" Visible="false"></asp:Label>
        </div>
    </div>
    
</asp:Content>
