<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="AccountantViewCostPerMonth.aspx.cs" Inherits="ENETCare.IMS.WebFrontEnd.Pages.Accountant.AccountantViewCostPerDistrict" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="Back" runat="server" OnClick="Back_Click" Text="Back" />
    </p>
    <p>
        Get report showing each month and the total cost across all districts for that month</p>
    <p>
        <br />
        <asp:Button ID="GetTotalCostByMonth" runat="server" OnClick="GetTotalCostByMonth_Click" Text="GetReport" />
    </p>
    <p>
        <asp:Table ID="ReportOut" runat="server" border ="1">
            <asp:TableRow>
                <asp:TableCell><b>Month</b></asp:TableCell>
                <asp:TableCell><b>Year</b></asp:TableCell>
                <asp:TableCell><b>Total Cost</b></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
