<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GenerateQR.aspx.cs" Inherits="Event_Mgt_QR_Code.GenerateQR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-6 grid-margin stretch-card">
              <div class="card">
                <div class="card-body">
                  <h4 class="card-title">Generate QR Code</h4>
                
                    <br />
                      <div class="form-group row">
                      <label for="exampleInputUsername2" class="col-sm-3 col-form-label">Select Event</label>
                      <div class="col-sm-9">
        <asp:DropDownList ID="DropDownList1" runat="server" Width="291px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                          <asp:HiddenField ID="HiddenField1" runat="server" />
                          <asp:HiddenField ID="HiddenField2" runat="server" />
                          <asp:HiddenField ID="HiddenField3" runat="server" />
                      </div>
                    </div>
                
                 
                      
                    
                   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating">
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
                          <%-- <asp:TemplateField HeaderText="EmailID">
                               <ItemTemplate>
                                   <asp:Label ID="Label6" runat="server" Text='<%# Eval("emailid") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>--%>
                           <asp:TemplateField HeaderText="QR Code">
                               <ItemTemplate>
                                   <asp:Image ID="Image1" runat="server" Height="75px" ImageUrl='<%# Eval("qr_code") %>' Width="75px" />
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Operation">
                               <ItemTemplate>
                                   <asp:Button ID="Button1" runat="server"  class="btn btn-primary mr-2" Text="Generate QR" CommandName="Update" />
                                <br />   <asp:Button ID="Button2" runat="server" Text="Send Email" class="btn btn-primary mr-2" CommandName="Delete"/>
                               </ItemTemplate>
                           </asp:TemplateField>
                       </Columns>
                    </asp:GridView>
                    <br />
                    
                </div>
              </div>
            </div>
</asp:Content>
