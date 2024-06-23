<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="UploadCSV.aspx.cs" Inherits="Event_Mgt_QR_Code.UploadCSV" %>
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
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                      </div>
                    </div>
                
                    <div class="form-group row">
                      <label for="exampleInputUsername2" class="col-sm-3 col-form-label">Upload Members CSV File</label>
                      <div class="col-sm-9">
        <asp:FileUpload ID="FileUpload1" runat="server" />
                   
                      </div>
                    </div>
                    <asp:Button ID="BtnUpload" class="btn btn-primary mr-2" runat="server" Text="Upload" OnClick="BtnUpload_Click" />
                   
                      <br />
                    <br />
                   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                       <Columns>
                           <asp:TemplateField HeaderText="Event ID">
                               <ItemTemplate>
                                   <asp:Label ID="Label1" runat="server" Text='<%# Eval("eid") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Event Name">
                               <ItemTemplate>
                                   <asp:Label ID="Label2" runat="server" Text='<%# Eval("ename") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Member No">
                               <ItemTemplate>
                                   <asp:Label ID="Label3" runat="server" Text='<%# Eval("memberno") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Member Name">
                               <ItemTemplate>
                                   <asp:Label ID="Label4" runat="server" Text='<%# Eval("mem_name") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Contact No">
                               <ItemTemplate>
                                   <asp:Label ID="Label5" runat="server" Text='<%# Eval("Contact_no") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Email Id">
                               <ItemTemplate>
                                   <asp:Label ID="Label6" runat="server" Text='<%# Eval("emailid") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
                       </Columns>
                    </asp:GridView>
                    <br />
                    <asp:GridView ID="GridView2" runat="server">
                    </asp:GridView>
                    <br />
        <asp:Button ID="BtnExport"  class="btn btn-primary mr-2" runat="server" Text="Export in Excel" OnClick="BtnExport_Click" />
                    
                      <br />
                </div>
              </div>
            </div>
</asp:Content>
