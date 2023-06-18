<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Guest.Master" AutoEventWireup="true" CodeBehind="detail_category.aspx.cs" Inherits="KpopZtation.View.CategoryFolder.detail_category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../StyleCSS/detailArtistStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="containerUp">
        <div class="page-title">
            <asp:Label ID="titleLbl" runat="server" Text="Choose Service Type" Font-Bold="True" Font-Size="25px"></asp:Label>
        </div>
        <div class="artist-name">
            <asp:Label ID="categoryName" runat="server" Font-Bold="True" Font-Size="18px"></asp:Label>
        </div>
        <div class="insert-album">
            <asp:Label ID="insertLbl" runat="server" Text="Insert Service" Visible="False" Font-Bold="True"></asp:Label>
            <div class="insert-button-container">
                <asp:Button ID="insertBtn" runat="server" Text="Insert" Visible="false" OnClick="insertBtn_Click" CssClass="insert-button" />
            </div>
        </div>
        <div class="album-label">
            <asp:Label ID="albumLbl" runat="server" Text="All Service Type:" Font-Bold="True" Font-Size="22px"></asp:Label>
        </div>
        <div class="empty-message">
            <asp:Label ID="isEmptyLbl" runat="server" Text="No album released by this artist :(" Visible="false"></asp:Label>
        </div>
        <div>
            <asp:GridView ID="albumGrid" runat="server" AutoGenerateColumns="False" OnRowDataBound="albumGrid_RowDataBound" CellPadding="3" CellSpacing="2" OnRowDeleting="albumGrid_RowDeleting" OnRowEditing="albumGrid_RowEditing" OnSelectedIndexChanged="albumGrid_SelectedIndexChanged" CssClass="album-grid">
              <Columns>
                <asp:BoundField DataField="ServiceID" HeaderText="ID" SortExpression="ServiceId" HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide">
<HeaderStyle CssClass="Hide"></HeaderStyle>

<ItemStyle CssClass="Hide"></ItemStyle>
                  </asp:BoundField>
                <asp:BoundField DataField="ServiceName" HeaderText="Name" SortExpression="ServiceName" />
                <asp:BoundField DataField="ServicePrice" HeaderText="Price" SortExpression="ServicePrice" />
                <asp:BoundField DataField="ServiceDescription" HeaderText="Description" SortExpression="ServiceDescription" />
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" ControlStyle-CssClass="gridview-button" >
<ControlStyle CssClass="gridview-button"></ControlStyle>
                  </asp:CommandField>
                <asp:CommandField ButtonType="Button" HeaderText="Admin Control" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" ControlStyle-CssClass="gridview-button" >
<ControlStyle CssClass="gridview-button"></ControlStyle>
                  </asp:CommandField>
              </Columns>
              <RowStyle CssClass="album-grid-row" />
              <HeaderStyle CssClass="album-grid-header" />
              <SelectedRowStyle CssClass="album-grid-selected-row" />
            </asp:GridView>
        </div>
        <div class="error-message">
            <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>
        </div>
    </div>
    
</asp:Content>
