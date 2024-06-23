<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMaster.Master" AutoEventWireup="true" CodeBehind="GroupChat.aspx.cs" Inherits="StudentCommunityPlatform.GroupChat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
<tr>
<td colspan="2">
</td>
</tr>
<tr>
<td style="width: 100px; text-align: right">
</td>
<td style="width: 94px; text-align: center">
</td>
</tr>
<tr>
<td style="width: 100px; text-align: right">
<strong>UserName</strong>:</td>
<td style="width: 94px">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
<asp:Button ID="brnadd" runat="server" OnClick="brnadd_Click" Text="ADD" Font-Bold="True" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
<asp:Label ID="lbluname" runat="server" Font-Bold="True" ForeColor="#004000"></asp:Label>
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
    </td>
</tr>
<tr>
<td style="width: 100px; height: 260px">
</td>
<td style="width: 94px; height: 260px">
<%--<%-–<asp:TextBox ID="txtmsg" runat="server" Height="250px" TextMode="MultiLine" Width="472px"></asp:TextBox>–-%>--%>
<iframe frameborder="no" height="315" scrolling="no" src="MSG.aspx" width="515">
</iframe>

</td>
</tr>
<tr>
<td style="width: 100px; height: 77px;">
</td>
<td style="width: 94px; height: 77px;">
<table style="width: 480px">
<tr>
<td style="width: 100px; height: 50px;">
<asp:TextBox ID="txtsend" runat="server" Height="40px" TextMode="MultiLine" Width="384px"></asp:TextBox></td>
<td style="width: 100px; height: 50px;">
<asp:Button ID="Button1" runat="server" Height="47px" OnClick="Button1_Click" Text="SEND"
Width="72px" Font-Bold="True" /></td>
</tr>
</table>
</td>
</tr>
</table>
</asp:Content>
