<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="ManagerInitialMenu.aspx.cs" Inherits="ENETCare.IMS.WebFrontEnd.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <br />
    <asp:Button ID="ChangePwdBtn" runat="server" OnClick="ChangePwdBtn_Click" Text="Change Password" />
    <br />
    <br />
    <asp:Button ID="ApproveBtn" runat="server" OnClick="ApproveBtn_Click" Text="Approve Interventions" />
</asp:Content>
