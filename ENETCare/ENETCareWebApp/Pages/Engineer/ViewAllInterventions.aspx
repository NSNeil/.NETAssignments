<%@ Page AutoEventWireup="true" CodeBehind="ViewAllInterventions.aspx.cs" Inherits="ENETCare.IMS.WebFrontEnd.Pages.Engineer.ViewAllInterventions" Language="C#" MasterPageFile="~/Master1.Master" Title="" %>
<%@ Import Namespace="ENETCare.IMS.BusinessLogicLayer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:DropDownList AutoPostBack="True" ID="RangeDropDownList" OnSelectedIndexChanged="RangeDropDownList_OnSelectedIndexChanged" runat="server">
        <asp:ListItem>All interventions</asp:ListItem>
        <asp:ListItem>Current district</asp:ListItem>

    </asp:DropDownList>
    <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>

    <asp:GridView OnRowCancelingEdit="InterventionsGridView_OnRowCancelingEdit" ID="InterventionsGridView" DataSourceID="AllInterventionODS" runat="server" AutoGenerateColumns="False" OnRowUpdating="InterventionsGridView_RowUpdating">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="InterventionId" InsertVisible="False" ReadOnly="True" HeaderText="Intervention Id" SortExpression="InterventionId" />
            <asp:TemplateField HeaderText="State" SortExpression="State">
                <EditItemTemplate>
                    <asp:DropDownList ID="StateDropDownList" runat="server" DataTextField="State" DataValueField="State" SelectedValue='<%# Bind("State") %>'>
                        <asp:ListItem>Proposed</asp:ListItem>
                        <asp:ListItem>Approved</asp:ListItem>
                        <asp:ListItem>Complete</asp:ListItem>
                        <asp:ListItem>Cancelled</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Note" HeaderText="Note" SortExpression="Note"/>
            <asp:BoundField DataField="Life" HeaderText="Life" SortExpression="Life" />
            <asp:TemplateField HeaderText="MostRecentVisitDate" SortExpression="MostRecentVisitDate">
                <EditItemTemplate>
                    <asp:TextBox ID="DateTextBox" Enabled="False" ReadOnly="True" runat="server" Text='<%# Bind("MostRecentVisitDate") %>'></asp:TextBox>
                    <asp:ImageButton ID="ShowCalendarBtn" runat="server" Height="30px" ImageUrl="~/Images/Calendar.png" OnClick="ShowCalendarBtn_OnClick" Width="30px" />
                    <asp:Calendar ID="InterventionCalendar" runat="server" OnSelectionChanged="InterventionCalendar_OnSelectionChanged"></asp:Calendar>
                    <br />
                </EditItemTemplate>
                <ItemTemplate>
                     <%# ((Intervention)(Container.DataItem)).MostRecentVisitDate  %>    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Cost" ReadOnly="True" InsertVisible="False" HeaderText="Cost" SortExpression="Cost" />
            <asp:BoundField DataField="LabourHours" ReadOnly="True" InsertVisible="False" HeaderText="LabourHours" SortExpression="LabourHours" />
            <asp:BoundField DataField="DateToPerform" ReadOnly="True" InsertVisible="False" HeaderText="DateToPerform" SortExpression="DateToPerform" />
            <asp:TemplateField HeaderText="District" InsertVisible="False" SortExpression="Client">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox10" ReadOnly="True" runat="server" Text='<%# Bind("ProposedBy.District") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                     <%# ((Intervention)(Container.DataItem)).ProposedBy.District  %>    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Intervention Type" InsertVisible="False" SortExpression="InterventionType">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True" Text='<%# Bind("InterventionType.Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                     <%# ((Intervention)(Container.DataItem)).InterventionType.Name  %>    
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Client" InsertVisible="False" SortExpression="Client">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" ReadOnly="True" runat="server" Text='<%# Bind("Client.Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                     <%# ((Intervention)(Container.DataItem)).Client.Name  %>    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ID of Proposed By" InsertVisible="False" SortExpression="ProposedById">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox30" runat="server" ReadOnly="True" Text='<%# Bind("ProposedBy.SiteEngineerId") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                     <%# ((Intervention)(Container.DataItem)).ProposedBy.SiteEngineerId  %>    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Proposed By" InsertVisible="False" SortExpression="ProposedBy">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True" Text='<%# Bind("ProposedBy.Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                     <%# ((Intervention)(Container.DataItem)).ProposedBy.Name  %>    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Approved By" InsertVisible="False" SortExpression="ApprovedBy">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" ReadOnly="True" Text='<%# Bind("ApprovedBy.Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                     <%# ((Intervention)(Container.DataItem)).ApprovedBy.Name  %>    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ConflictDetection="CompareAllValues" OldValuesParameterFormatString="original_{0}" ID="AllInterventionODS" runat="server" SelectMethod="GetList" TypeName="ENETCare.IMS.DatabaseAccessLayer.InterventionRepository" UpdateMethod="UpdateInterventionInfo" OnUpdating="InterventionRepository_Updating">
       
    </asp:ObjectDataSource>    
    <asp:ObjectDataSource ConflictDetection="CompareAllValues" OldValuesParameterFormatString="original_{0}" OnSelecting="RegionInterventionODS_OnSelecting" ID="RegionInterventionODS" runat="server" SelectMethod="GetList" TypeName="ENETCare.IMS.DatabaseAccessLayer.InterventionRepository" UpdateMethod="UpdateInterventionInfo" OnUpdating="RegionInterventionODS_Updating" >
       
    </asp:ObjectDataSource>  
    </asp:Content>
