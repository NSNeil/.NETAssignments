<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="AccountantGetAverageCostNTime.aspx.cs" Inherits="ENETCare.IMS.WebFrontEnd.Pages.Accountant.AccountantGetAverageCostNTime" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:Button ID="Back" runat="server" OnClick="Back_Click" Text="Back" />
    <br />
    <br />
    Get Average Cost and Labour Hours for every engineer who has completed a project and who works for ENET Care.
    <br />
    <br />
    <asp:Button ID="GetAverageCostNHours" runat="server" OnClick="GetAverageCostNHours_Click" Text="Get Report" />
    <br />
    <br />
    <asp:Table ID="ReportOut" runat="server" border = "1">
        <asp:TableRow>
            <asp:TableCell><b>Name</b></asp:TableCell>
            <asp:TableCell><b>Average Cost</b></asp:TableCell>
            <asp:TableCell><b>Average Hours</b></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
