<%@ Page Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="CreateClient.aspx.cs" Inherits="ENETCare.IMS.WebFrontEnd.Pages.Engineer.CreateClient" %>
<%@ Import Namespace="ENETCare.IMS.BusinessLogicLayer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style29 {
            width: 140px;
            height: 26px;
        }
        .auto-style30 {
            width: 780px;
            height: 109px;
        }
    .auto-style32 {
        width: 775px;
    }
    .auto-style35 {
        width: 140px;
    }
    .auto-style36 {
        width: 777px;
    }
        .auto-style37 {
            width: 299px;
        }
        .auto-style38 {
            height: 26px;
        }
        .auto-style39 {
            width: 250px;
        }
        .auto-style41 {
            width: 165px;
            height: 26px;
        }
        .auto-style42 {
            height: 26px;
            width: 394px;
        }
        .auto-style43 {
            width: 309px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <table class="auto-style10">
        <tr>
            <td class="auto-style37">&nbsp;</td>
            <td class="auto-style39">
                <h1 style="font-family:verdana;">Create Client</h1>            
            </td>
            <td class="auto-style43">&nbsp;</td>
        </tr>
    </table>
    <p class="auto-style32">
        <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
    </p>
    <table class="auto-style30">
        <tr>
            <td class="auto-style35" rowspan="5"></td>
            <td class="auto-style41">
                <asp:Label ID="Label_ClientName" runat="server" Font-Names="Verdana" Text="Name" Width="137px"></asp:Label>
            </td>
            <td class="auto-style42">
                <asp:TextBox ID="TextBox_ClientName" runat="server" OnTextChanged="TextBox1_TextChanged" Width="209px"></asp:TextBox>
            </td>
            <td rowspan="5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style41">
                <asp:Label ID="Label_ClientDistrict" runat="server" Font-Names="Verdana" Text="District" Width="128px"></asp:Label>
            </td>
            <td class="auto-style42">
                <asp:Label ID="DistrictLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style41">
                <asp:Label ID="Label_ClientDescriptiveLocation" runat="server" Font-Names="Verdana" Text="Descriptive Location" Width="191px"></asp:Label>
            </td>
            <td class="auto-style42">
                <asp:TextBox ID="TextBox_ClientDescriptiveLocation" runat="server" Width="384px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style38">
                &nbsp;</td>
            <td class="auto-style38">
                <asp:Button ID="Button_CreateClient" runat="server" Text="Create Client" OnClick="Button_CreateClient_Click" Width="150px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style38">
                &nbsp;</td>
            <td class="auto-style38">
                <asp:TextBox ID="TextBox_ErrorMsg" runat="server" Visible="False" Width="386px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style29">
                &nbsp;</td>
            <td class="auto-style41">
                &nbsp;</td>
        </tr>
        </table>
    <p class="auto-style36">
    </p>
    <asp:ObjectDataSource ID="DistrictRepository" runat="server" SelectMethod="GetAll" TypeName="ENETCare.IMS.DatabaseAccessLayer.DistrictRepository" >
        
    </asp:ObjectDataSource>  
</asp:Content>