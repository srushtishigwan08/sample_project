<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EventAttendence.aspx.cs" Inherits="Event_Mgt_QR_Code.EventAttendence" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="col-md-6 grid-margin stretch-card">
              <div class="card">
                <div class="card-body">
                  <h4 class="card-title">Upload CSV File</h4>
                
                    <br />
                      <div class="form-group row">
                      <label for="exampleInputUsername2" class="col-sm-3 col-form-label">Select Event</label>
                      <div class="col-sm-9">
        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                      </div>
                    </div>
                
                    <div class="form-group row">
                      <label for="exampleInputUsername2" class="col-sm-3 col-form-label">Upload QR Code</label>
                      <div class="col-sm-9">
        <asp:FileUpload ID="FileUpload1" runat="server" />
                   
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   
                      </div>
                    </div>
                    
                     
                    <asp:Button ID="Button1" class="btn btn-primary mr-2" runat="server" Text="Upload & Validate" OnClick="Button1_Click" />
                      <br />
                
                <br />
                  <center>
                       
                      <h3>
                          <br />
          <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                          </h3>
                      </center>
                </div>
              </div>
            </div>
</asp:Content>
