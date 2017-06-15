<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="AccountantEngineersAndManagers.aspx.cs" Inherits="ENETCare.IMS.WebFrontEnd.Pages.Accountant.AccountantEngineersAndManagers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:Button ID="ViewSiteEngineers" runat="server" OnClick="ViewSiteEngineers_Click" Text="View Site Engineers" Width="224px" />
    <br />
    <br />
    <asp:Button ID="ViewManagers" runat="server" Text="View Managers" Width="221px" OnClick="ViewManagers_Click" />
    <br />
    <br />
    <asp:Table ID="ReportOut" runat="server" border ="1">
        <asp:TableRow>
            <asp:TableCell><b>Id</b></asp:TableCell>
            <asp:TableCell><b>Name</b></asp:TableCell>
        </asp:TableRow>
        
    </asp:Table>
    <br />
    <br />
    <br />
</asp:Content>
