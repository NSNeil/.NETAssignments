<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="CreateIntervention.aspx.cs" Inherits="ENETCare.IMS.WebFrontEnd.Pages.Engineer.CreateIntervention" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <p>
        <asp:Label ID="ErrorLabel" runat="server"></asp:Label>
    </p>
    <p>
        Intervention Type: &nbsp;<asp:DropDownList ID="InterventionTypeDropDownList" runat="server" DataSourceID="InterventionType" DataTextField="Name" DataValueField="Name">
        </asp:DropDownList>
        <asp:SqlDataSource ID="InterventionType" runat="server" ConnectionString="<%$ ConnectionStrings:ENETConnection %>" SelectCommand="SELECT [Name] FROM [InterventionType]"></asp:SqlDataSource>
    </p>
    <p>
        Client:<asp:TextBox ID="ClientTextBox" runat="server" Enabled="False"></asp:TextBox>
        <asp:Button ID="ViewAllClientsBtn" runat="server" Text="View All Clients" OnClick="ViewAllClientsBtn_Click" />
        <asp:GridView ID="ClientGridView" runat="server">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="ChooseBtn" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" OnClick="ChooseBtn_OnClick" Text="Choose" OnCommand="ChooseBtn_OnCommand" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </p>
    <p>
        Labour Hours:
        <asp:TextBox ID="LabourHoursTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Cost:
        <asp:TextBox ID="CostTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Date To Perform:<asp:TextBox ID="DateToPerformTextBox" runat="server" Enabled="False"></asp:TextBox>
&nbsp;<asp:ImageButton ID="ShowCalendarBtn" runat="server" Height="30px" ImageUrl="~/Images/Calendar.png" OnClick="ShowCalendarBtn_Click" Width="30px" />
        <asp:Calendar ID="InterventionCalendar" runat="server" Visible="False" OnSelectionChanged="InterventionCalendar_SelectionChanged"></asp:Calendar>
    </p>
    <p>
        State: <asp:DropDownList ID="StateDropDownList" runat="server">
            <asp:ListItem>Proposed</asp:ListItem>
            <asp:ListItem>Approved</asp:ListItem>
            <asp:ListItem>Complete</asp:ListItem>
        </asp:DropDownList></p>
    <p>
        Note:
        <asp:TextBox ID="NoteTextBox" runat="server" Height="50px" TextMode="MultiLine" Width="443px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="CreateBtn" runat="server" OnClick="CreateBtn_Click" Text="Create" />
    </p>
</asp:Content>
