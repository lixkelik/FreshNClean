<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Customer.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="KpopZtation.View.cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="StyleCSS/cartStyle.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        <asp:Label ID="titleLbl" runat="server" Text="Your Cart"></asp:Label>
    </div>
    <div class="cart-grid">
        <asp:GridView ID="cartGrid" runat="server" AutoGenerateColumns="False" OnRowDeleting="cartGrid_RowDeleting" CssClass="grid-view">
            <Columns>
                <asp:BoundField DataField="Service.ServiceId" HeaderText="ID" SortExpression="ServiceId" HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide">
<HeaderStyle CssClass="Hide"></HeaderStyle>

<ItemStyle CssClass="Hide"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Service.ServiceName" HeaderText="Name" SortExpression="ServiceName" />
                <asp:BoundField DataField="Qty" HeaderText="Quantity" SortExpression="Qty" />
                <asp:BoundField DataField="Service.ServicePrice" HeaderText="Price" SortExpression="ServicePrice" />
                <asp:CommandField ButtonType="Button" DeleteText="Remove" ShowDeleteButton="True" ControlStyle-CssClass="btn" >
<ControlStyle CssClass="btn"></ControlStyle>
                </asp:CommandField>
            </Columns>
            <HeaderStyle CssClass="grid-view-header" />
        </asp:GridView>
    </div>
    <div class="empty-message">
        <asp:Label ID="isEmptyLbl" runat="server" Text=""></asp:Label>
    </div>
    <div class="checkout-button">
        <asp:Button ID="checkoutBtn" runat="server" Text="Checkout" OnClick="checkoutBtn_Click" CssClass="btn" />
    </div>
    <div>
        <asp:Label ID="errorLbl" runat="server" Text="" Visible="false" CssClass="error-message"></asp:Label>
    </div>
</asp:Content>
