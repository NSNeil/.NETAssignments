<%@ Page Title="ViewCostByEngineer" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="ViewCostByEngineer.aspx.cs" Inherits="ENETCare.IMS.WebFrontEnd.Pages.Accountant.ViewCostByEngineer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
    <br />
    <br />
    Generate Report Showing total cost and labour hours for each site engineer working for ENET Care.
    <br />
    <br />
    <asp:Button ID="GenerateReport" runat="server" OnClick="GenerateReport_Click" Text="Generate Report" />
    <br />
    <br />
    <asp:Table ID="ReportOut" runat="server" border ="1">
        <asp:TableRow>
            <asp:TableCell><b>Name</b></asp:TableCell>
            <asp:TableCell><b>Total Cost</b></asp:TableCell>
            <asp:TableCell><b>Total Labour Hours</b></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />
    <br />
</asp:Content>
