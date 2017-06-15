<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="ViewCompletedInterventionCostPerDistrict.aspx.cs" Inherits="ENETCare.IMS.WebFrontEnd.Pages.Accountant.ViewCompletedInterventionCostPerDistrict" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
    <br />
    <br />
    Get Report showing each district, the total cost for each district from completed projects and the total cost for all ENET Care districts.
    <br />
    <br />
    <asp:Button ID="GetReport" runat="server" OnClick="GetReport_Click" Text="Get Report" />
    <br />
    <br />
    <br />
    <asp:Table ID="ReportOut" runat="server" border="1">
        <asp:TableRow>
            <asp:TableCell><b>District</b></asp:TableCell>
            <asp:TableCell><b>Total Cost</b></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <asp:Label ID="TotalCostOut" runat="server" Text="Total Cost: "></asp:Label>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
