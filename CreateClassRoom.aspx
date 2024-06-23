<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMaster.Master" AutoEventWireup="true" CodeBehind="CreateClassRoom.aspx.cs" Inherits="StudentCommunityPlatform.CreateClassRoom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auth-form-light text-left py-5 px-4 px-sm-5">
              <div class="brand-logo">
                  <%-- <img src="../../images/logo-dark.svg" alt="logo">--%>
              </div>
              <h4>Student Community Platform</h4>
              <h6 class="font-weight-light">Create New  Communication Class Room</h6>
           
               
                <div class="form-group">
                  
                  <asp:TextBox ID="txtClassRoom" runat="server" class="form-control form-control-lg" placeholder="Class Room Name" ></asp:TextBox>
                </div>
             
                 <div class="form-group">
                  
                    <asp:TextBox ID="txtDesc" runat="server" class="form-control form-control-lg" placeholder="Class Room Details" ></asp:TextBox>
                </div>
           

            
                <div class="mt-3">
                    <%-- <a class="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn" href="../../dashboard.aspx">SIGN IN</a>--%>

                    <asp:Button ID="BtnSubmit" class="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn" runat="server" Text="Save" OnClick="BtnSubmit_Click" />
                </div>
                <div class="my-2 d-flex justify-content-between align-items-center">
                  <div class="form-check">
                 
                      <asp:Label ID="lblmsg" runat="server"></asp:Label>
                  </div>
               
                </div>
               
               
             































            </div>
</asp:Content>
