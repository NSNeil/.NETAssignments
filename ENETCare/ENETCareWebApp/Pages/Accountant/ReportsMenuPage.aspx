<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="ReportsMenuPage.aspx.cs" Inherits="ENETCare.IMS.WebFrontEnd.Pages.Accountant.ReportsMenuPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <p>
        <br />
        <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
    </p>
    <p>
        <asp:Button ID="TotalCostByEngineer" runat="server" Text="Total Cost By Engineer" Width="469px" OnClick="TotalCostByEngineer_Click" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="AverageCostsByEngineer" runat="server" Text="Average Cost By Engineer" Width="465px" OnClick="AverageCostsByEngineer_Click" />
    </p>
    <p>
        <asp:Button ID="CostPerDistrict" runat="server" Text="Cost Per District" Width="465px" OnClick="CostPerDistrict_Click" />
    </p>
    <p>
        <asp:Button ID="MonthlyCostForDistrict" runat="server" Text="Monthly Costs For District" Width="460px" OnClick="MonthlyCostForDistrict_Click" />
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
