<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Guest.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="KpopZtation.View.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="StyleCSS/homeStyles.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="banner">
        <div class="companySlogan">
            <h1>Indonesia's First Choice in Laundry</h1>
            <p>We serve a lot of laundry ranging from clothes, shoes and even a leather bag with competitive price.</p>
        </div>
        <div class="image"></div>
    </div>
    <div class="categoriesList" style="margin-top: 57px; background-color:#FFFFFF; box-shadow: 0px 4px 16px rgba(0, 0, 0, 0.15);">
        <asp:Table ID="categoriesTable" runat="server" style="display: flex; justify-content: center"></asp:Table>
    </div>
    <div class="emptySpace"></div>
</asp:Content>
