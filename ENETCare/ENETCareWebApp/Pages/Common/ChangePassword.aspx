<%@ Page Language="C#" Async="true" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ENETCare.IMS.WebFrontEnd.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

        <div>
         <h2>Change Password</h2>
         <hr />
         <asp:PlaceHolder runat="server" ID="PasswordStatus" Visible="false">
            <p>
               <asp:Literal runat="server" ID="StatusText" />
            </p>
         </asp:PlaceHolder>
         <asp:PlaceHolder runat="server" ID="PasswordForm" Visible="false">
            <div style="margin-bottom: 10px">
               <asp:Label runat="server" AssociatedControlID="OldPassword">Old Password</asp:Label>
               <div>
                  <asp:TextBox runat="server" ID="OldPassword" TextMode="Password" />
               </div>
            </div>
            <div style="margin-bottom: 10px">
               <asp:Label runat="server" AssociatedControlID="NewPassword">New Password</asp:Label>
               <div>
                  <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" />
               </div>
            </div>
            <div style="margin-bottom: 10px">
               <asp:Label runat="server" AssociatedControlID="VerifyNewPassword">Verify New Password</asp:Label>
               <div>
                  <asp:TextBox runat="server" ID="VerifyNewPassword" TextMode="Password" />
               </div>
            </div>
            <div style="margin-bottom: 10px">
               <div>
                  <asp:Button runat="server" OnClick="ChangePassword_Click" Text="Change Password" />
               </div>
            </div>
         </asp:PlaceHolder>
      </div>
    <p class="auto-style36">
    </p>
</asp:Content>
