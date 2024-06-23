<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EventSchedule.aspx.cs" Inherits="Event_Mgt_QR_Code.EventSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="col-md-6 grid-margin stretch-card">
              <div class="card">
                <div class="card-body">
                  <h4 class="card-title">Event Master Entry</h4>
                
                
                    <div class="form-group row">
                      <label for="exampleInputUsername2" class="col-sm-3 col-form-label">Event Name</label>
                      <div class="col-sm-9">
          <asp:TextBox ID="txtEventName" runat="server" class="form-control"  placeholder="Event Name"></asp:TextBox>
                   
                      </div>
                    </div>
                    <div class="form-group row">
                      <label for="exampleInputEmail2" class="col-sm-3 col-form-label">Event Date</label>
                      <div class="col-sm-9">
                        <asp:TextBox ID="txteventDate" runat="server" class="form-control"  placeholder="Event Date"></asp:TextBox>
                      </div>
                    </div>
                    <div class="form-group row">
                      <label for="exampleInputMobile" class="col-sm-3 col-form-label">Event Time</label>
                      <div class="col-sm-9">
                         <asp:TextBox ID="txtEventTime" runat="server" class="form-control"  placeholder="Event Time"></asp:TextBox>
                      </div>
                    </div>
                    <div class="form-group row">
                      <label for="exampleInputPassword2" class="col-sm-3 col-form-label">Organization</label>
                      <div class="col-sm-9">
                        <asp:TextBox ID="txtEventOraganization" runat="server" class="form-control"  placeholder="Name of Organization"></asp:TextBox>
                      </div>
                    </div>
                    <div class="form-group row">
                      <label for="exampleInputConfirmPassword2" class="col-sm-3 col-form-label">Contact Person</label>
                      <div class="col-sm-9">
                         <asp:TextBox ID="txtcontactperson" runat="server" class="form-control"  placeholder="Contact Person"></asp:TextBox>
                      </div>
                    </div>
                   <div class="form-group row">
                      <label for="exampleInputPassword2" class="col-sm-3 col-form-label">Contact Number</label>
                      <div class="col-sm-9">
                        <asp:TextBox ID="txtContactNum" runat="server" class="form-control"  placeholder="Contact Number"></asp:TextBox>
                      </div>
                    </div>
                     <div class="form-group row">
                      <label for="exampleInputPassword2" class="col-sm-3 col-form-label">Address</label>
                      <div class="col-sm-9">
                        <asp:TextBox ID="txtLOcation" runat="server" class="form-control"  placeholder="Address"></asp:TextBox>
                      </div>
                    </div>
          <asp:Button ID="btnSUbmit" class="btn btn-primary mr-2" runat="server" Text="Submit" OnClick="btnSUbmit_Click" />
                     <asp:Button ID="BtnCancel" class="btn btn-primary mr-2" runat="server" Text="Cancel" />
                  <%--  <button type="submit" class="btn btn-primary mr-2">Submit</button>
                    <button class="btn btn-light">Cancel</button>--%>
                    <br />
                    
                  <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                </div>
              </div>
            </div>
</asp:Content>
