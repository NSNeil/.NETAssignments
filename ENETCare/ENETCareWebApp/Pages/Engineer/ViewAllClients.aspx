<%@ Page Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="ViewAllClients.aspx.cs" Inherits="ENETCare.IMS.WebFrontEnd.Pages.Engineer.ViewAllClients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:Label ID="HeaderLabel" runat="server" Text="All clients in current district"></asp:Label>
    <asp:GridView ID="ClientsGridView" DataSourceID="AllClientsODS" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="Show details" InsertVisible="False">
                <ItemTemplate>
                    <asp:Button Text="ShowDetail" ID="ShowDetailsBtn" runat="server" OnClick="ShowDetailsBtn_OnClick"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ConflictDetection="CompareAllValues" OldValuesParameterFormatString="original_{0}" ID="AllClientsODS" runat="server" SelectMethod="GetList" TypeName="ENETCare.IMS.DatabaseAccessLayer.ClientRepository" OnSelecting="AllClientsODS_OnSelecting">
       
    </asp:ObjectDataSource>
</asp:Content>
