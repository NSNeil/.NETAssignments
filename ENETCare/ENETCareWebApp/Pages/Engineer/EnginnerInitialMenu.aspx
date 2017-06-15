<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="EnginnerInitialMenu.aspx.cs" Inherits="ENETCare.IMS.WebFrontEnd.Pages.Engineer.EnginnerInitialMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <p>
        <asp:Button ID="ChangePwdBtn" runat="server" Text="Change Password" Width="500px" OnClick="ChangePwdBtn_Click" />
    </p>
    <p>
    </p>
    <p>
        <asp:Button ID="CreateClientBtn" runat="server" Text="Create Client" Width="494px" OnClick="CreateClientBtn_Click" />
    </p>
    <p>
    </p>
    <p>
        <asp:Button ID="ViewAllClientsBtn" runat="server" Text="View All Clients" Width="491px" OnClick="ViewAllClientsBtn_Click" />
    </p>
    <p>
    </p>
    <p>
        <asp:Button ID="InterventionHistoryBtn" runat="server" Text="Intervention History" Width="487px" OnClick="InterventionHistoryBtn_Click" />
    </p>
    <p>
    </p>
    <p>
        <asp:Button ID="CreateInterventionBtn" runat="server" Text="Create Intervention" Width="481px" OnClick="CreateInterventionBtn_Click" />
    </p>
    <p>
    </p>
</asp:Content>
