<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Customer.Master" AutoEventWireup="true" CodeBehind="transaction.aspx.cs" Inherits="KpopZtation.View.transaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="StyleCSS/transactionStyle.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class ="containerUp">
        <div class="transaction-title">
            <asp:Label ID="titleLbl" runat="server" Text="Transaction History"></asp:Label>
        </div>
        <div>
            <asp:GridView ID="transactionGrid" runat="server" AutoGenerateColumns="False" OnRowDataBound="transactionGrid_RowDataBound" CssClass="transaction-grid">
                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" ItemStyle-Width="120px"/>
                    <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" ItemStyle-Width="180px"/>
                    <asp:BoundField DataField="Customer.CustomerName" HeaderText="Customer Name" SortExpression="Customer.CustomerName" />
                    <asp:TemplateField HeaderText="Laundry Order List">
                        <ItemTemplate>
                            <asp:GridView ID="transactionDetailGrid" runat="server" AutoGenerateColumns="false" CssClass="transaction-detail-grid">
                                <Columns>
                                    <asp:BoundField DataField="Service.ServiceName" HeaderText="Service Type" SortExpression="Service.ServiceName" />
                                    <asp:BoundField DataField="Qty" HeaderText="Quantity" SortExpression="TransactionDetail.Qty" />
                                    <asp:BoundField DataField="Service.ServicePrice" HeaderText="Service Price" SortExpression="Service.ServicePrice" />
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="isEmptyLbl" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
