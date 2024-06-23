<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMaster.Master" AutoEventWireup="true" CodeBehind="BrowseClassRoom.aspx.cs" Inherits="StudentCommunityPlatform.BrowseClassRoom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="col-md-12">
              <div class="card">
                <div class="table-responsive pt-3">
                 <%-- <table class="table table-striped project-orders-table">
                    <thead>
                      <tr>
                        <th class="ml-5">ID</th>
                        <th>Communication Class Room Name</th>
                      
                        <th>Actions</th>
                      </tr>
                    </thead>
                    <tbody>
                      <tr>
                        <td>1</td>
                        <td>Python Programming </td>
                        
                        <td>
                          <div class="d-flex align-items-center">
                            <button type="button" class="btn btn-success btn-sm btn-icon-text mr-3">
                              Browse
                              <i class="typcn typcn-edit btn-icon-append"></i>                          
                            </button>
                           
                          </div>
                        </td>
                      </tr>
                   <tr>
                        <td>2</td>
                        <td>Java Programming </td>
                        
                        <td>
                          <div class="d-flex align-items-center">
                            <button type="button" class="btn btn-success btn-sm btn-icon-text mr-3">
                              Browse
                              <i class="typcn typcn-edit btn-icon-append"></i>                          
                            </button>
                           
                          </div>
                        </td>
                      </tr>
                         <tr>
                        <td>3</td>
                        <td>Dot Net Framework</td>
                        
                        <td>
                          <div class="d-flex align-items-center">
                            <button type="button" class="btn btn-success btn-sm btn-icon-text mr-3">
                              Browse
                              <i class="typcn typcn-edit btn-icon-append"></i>                          
                            </button>
                           
                          </div>
                        </td>
                      </tr>
                    </tbody>
                  </table>--%>


          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ClassRoomId" OnRowUpdating="GridView1_RowUpdating" Width="80%">
              <Columns>
                  <asp:TemplateField HeaderText="ID">
                      <ItemTemplate>
                          <asp:Label ID="Label1" runat="server" Text='<%# Eval("ClassRoomId") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Communication Class Room Name">
                      <ItemTemplate>
                          <asp:Label ID="Label2" runat="server" Text='<%# Eval("RoomName") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Description">
                      <ItemTemplate>
                          <asp:Label ID="Label3" runat="server" Text='<%# Eval("description") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="Created By">
                      <ItemTemplate>
                          <asp:Label ID="Label67" runat="server" Text='<%# Eval("fullname") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Action">
                      <ItemTemplate>

                           <div class="d-flex align-items-center">
                          
                               <asp:Button class="btn btn-success btn-sm btn-icon-text mr-3" ID="Button1" runat="server" CommandName="Update" Text="Joint Class Room" />
                              <i class="typcn typcn-edit btn-icon-append"></i>                          
                            </button>
                           
                          </div>

                         
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
                    </asp:GridView>

                    <table>
                        <tr>
                            <td>

                            </td>
                        </tr>
                             <tr>
                            <td>

                                <asp:Label ID="Label4" runat="server" Text="Shared Resources to You"></asp:Label></td>
                        </tr>
                             <tr>
                            <td>

                                <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <table class="w-100">
                                            <tr>
                                                <td>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("filename1") %>' Width="100px" />
                                                </td>
                                                <td>&nbsp;&nbsp;&nbsp;</td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                        </tr>
                             <tr>
                            <td>

                            </td>
                        </tr>
                    </table>
                </div>
              </div>
            </div>
</asp:Content>
