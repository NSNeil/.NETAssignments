<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="ClientAssociatedInterventions.aspx.cs" Inherits="ENETCare.IMS.WebFrontEnd.Pages.Engineer.ClientAssociatedInterventions" %>
<%@ Import Namespace="ENETCare.IMS.BusinessLogicLayer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:button runat="server" text="Back" OnClick="OnClick"/>
    <asp:Label runat="server" Text="Associated Interventions"></asp:Label>
    <br />
    <asp:GridView AutoGenerateColumns="False" ID="AssociatedInterventionGridView" DataSourceID="AssociatedInterventionODS" runat="server">
        <Columns>
            <asp:BoundField DataField="InterventionId" InsertVisible="False" ReadOnly="True" HeaderText="Intervention Id" SortExpression="InterventionId" />
            <asp:TemplateField HeaderText="State" SortExpression="State">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Note" HeaderText="Note" SortExpression="Note" />
            <asp:BoundField DataField="Life" HeaderText="Life" SortExpression="Life" />
            <asp:TemplateField HeaderText="MostRecentVisitDate" SortExpression="MostRecentVisitDate">
                <ItemTemplate>
                     <%# ((Intervention)(Container.DataItem)).MostRecentVisitDate  %>    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Cost" ReadOnly="True" InsertVisible="False" HeaderText="Cost" SortExpression="Cost" />
            <asp:BoundField DataField="LabourHours" ReadOnly="True" InsertVisible="False" HeaderText="LabourHours" SortExpression="LabourHours" />
            <asp:BoundField DataField="DateToPerform" ReadOnly="True" InsertVisible="False" HeaderText="DateToPerform" SortExpression="DateToPerform" />
            <asp:TemplateField HeaderText="District" InsertVisible="False" SortExpression="Client">
                <ItemTemplate>
                     <%# ((Intervention)(Container.DataItem)).ProposedBy.District  %>    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Intervention Type" InsertVisible="False" SortExpression="InterventionType">
                <ItemTemplate>
                     <%# ((Intervention)(Container.DataItem)).InterventionType.Name  %>    
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Client" InsertVisible="False" SortExpression="Client">
                <ItemTemplate>
                     <%# ((Intervention)(Container.DataItem)).Client.Name  %>    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Proposed By" InsertVisible="False" SortExpression="ProposedBy">
                <ItemTemplate>
                     <%# ((Intervention)(Container.DataItem)).ProposedBy.Name  %>    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Approved By" InsertVisible="False" SortExpression="ApprovedBy">
                <ItemTemplate>
                     <%# ((Intervention)(Container.DataItem)).ApprovedBy.Name  %>    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ConflictDetection="CompareAllValues" OldValuesParameterFormatString="original_{0}" ID="AssociatedInterventionODS" runat="server" SelectMethod="GetList" TypeName="ENETCare.IMS.DatabaseAccessLayer.InterventionRepository" OnSelecting="AssociatedInterventionODS_OnSelecting">

    </asp:ObjectDataSource>
</asp:Content>
