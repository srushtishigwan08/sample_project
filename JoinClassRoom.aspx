<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMaster.Master" AutoEventWireup="true" CodeBehind="JoinClassRoom.aspx.cs" Inherits="StudentCommunityPlatform.JoinClassRoom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            color: #007BFF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
    <table style="width:900px;text-align:center" >
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="6">
                  <h4>Student Community Platform</h4>
              <h6 class="font-weight-light"><asp:Label ID="lblclass" runat="server" Text="Label"></asp:Label> Class Room</h6>

            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl="~/img/chat.png" Width="100px" />
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:Image ID="Image2" runat="server" Height="100px" ImageUrl="~/img/share.jfif" Width="100px" />
            </td>
            <td></td>
            <td>
                <asp:Image ID="Image3" runat="server" Height="100px" ImageUrl="~/img/sendNotification.jfif" Width="100px" />
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:Image ID="Image4" runat="server" Height="100px" ImageUrl="~/img/invitefriend.png" Width="100px" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style1"> <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/GroupChat.aspx"> Chat </asp:HyperLink></td>
            <td>&nbsp;</td>
            <td class="auto-style1">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ShareResources.aspx">Share Resources</asp:HyperLink>
            </td>
            <td>&nbsp;</td>
            <td class="auto-style1">  <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Notication.aspx">Send Notification</asp:HyperLink></td>
            <td>&nbsp;</td>
            <td class="auto-style1"><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/InviteFriend.aspx">Invite Friend </asp:HyperLink></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="7">                  <h4>List of Student in :<asp:Label ID="lbl2" runat="server" Text="Label"></asp:Label> &nbsp;Class Room</h4></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="7">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="7"><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" Width="80%">
              <Columns>
                  <asp:TemplateField HeaderText="ID">
                      <ItemTemplate>
                          <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
               
                  <asp:TemplateField HeaderText="Student Name">
                      <ItemTemplate>
                          <asp:Label ID="Label3" runat="server" Text='<%# Eval("fullname") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="Joining Date">
                      <ItemTemplate>
                          <asp:Label ID="Label67" runat="server" Text='<%# Eval("jdate") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
            
              </Columns>
                    </asp:GridView></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</center>

</asp:Content>
