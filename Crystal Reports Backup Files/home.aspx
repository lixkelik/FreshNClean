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
    <div class="whiteBg"></div>
    <div class="serviceList">
        <asp:Table ID="serviceTable" runat="server">
            <asp:TableRow CssClass="row" runat="server">
                <asp:TableCell ID="cell1" CssClass="cell">
                    <div>
                        <a><%=categories[0].CategoryName%></a>
                    </div>
                    <asp:Button ID="service1Btn" runat="server" Text="Details" OnClick="service1Btn_Click"/>
                </asp:TableCell>

                <asp:TableCell ID="cell2" CssClass="cell">
                    <div>
                        <a><%=categories[1].CategoryName%></a>
                    </div>
                    <asp:Button ID="service2Btn" runat="server" Text="Details" OnClick="service2Btn_Click"/>
                </asp:TableCell>

                <asp:TableCell ID="cell3" CssClass="cell">
                    <div>
                        <a><%=categories[2].CategoryName%></a>
                    </div>
                    <asp:Button ID="service3Btn" runat="server" Text="Details" OnClick="service3Btn_Click"/>
                </asp:TableCell>

                <asp:TableCell ID="cell4" CssClass="cell">
                    <div>
                        <a><%=categories[3].CategoryName%></a>
                    </div>
                    <asp:Button ID="service4Btn" runat="server" Text="Details" OnClick="service4Btn_Click"/>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</asp:Content>
