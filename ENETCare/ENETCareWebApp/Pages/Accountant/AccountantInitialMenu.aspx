<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="AccountantInitialMenu.aspx.cs" Inherits="ENETCare.IMS.WebFrontEnd.Pages.Accountant.AccountantInitialMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <br />
    <br />
    <asp:Button ID="ChangePassword" runat="server" Text="Change Password" Width="446px" OnClick="ChangePassword_Click" />
    <br />
    <br />
    <br />
    <asp:Button ID="EngineersAndManagers" runat="server" Text="Engineers and Managers" Width="445px" OnClick="EngineersAndManagers_Click" />
    <br />
    <br />
    <br />
    <asp:Button ID="Reports" runat="server" Text="Reports" Width="453px" OnClick="Reports_Click" />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
