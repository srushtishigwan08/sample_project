<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="StudentCommunityPlatform.Registration" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <title>StudentCommunityPlatform</title>
  <!-- base:css -->
  <link rel="stylesheet" href="../../vendors/typicons/typicons.css">
  <link rel="stylesheet" href="../../vendors/css/vendor.bundle.base.css">
  <!-- endinject -->
  <!-- plugin css for this page -->
  <!-- End plugin css for this page -->
  <!-- inject:css -->
  <link rel="stylesheet" href="../../css/vertical-layout-light/style.css">
  <!-- endinject -->
  <link rel="shortcut icon" href="../../images/favicon.png" />
</head>
<body>
    <form id="form1" runat="server">
      <div class="container-scroller">
    <div class="container-fluid page-body-wrapper full-page-wrapper">
      <div class="content-wrapper d-flex align-items-center auth px-0">
        <div class="row w-100 mx-0">
          <div class="col-lg-4 mx-auto">
            <div class="auth-form-light text-left py-5 px-4 px-sm-5">
              <div class="brand-logo">
                  <asp:HyperLink ID="HyperLink1" runat="server">Login</asp:HyperLink>
                  <%-- <img src="../../images/logo-dark.svg" alt="logo">--%>
              </div>
              <h4>Student Community Platform</h4>
              <h6 class="font-weight-light">Student Registration</h6>
           
               
                <div class="form-group">
                  
                  <asp:TextBox ID="txtfname" runat="server" class="form-control form-control-lg" placeholder="First Name" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfname" Display="Dynamic" ErrorMessage="First Name should not empty" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtfname" Display="Dynamic" ErrorMessage="only alphabets" ForeColor="#FF3300" SetFocusOnError="True" ValidationExpression="^[a-zA-Z\s]+$">*</asp:RegularExpressionValidator>
                </div>
             
                 <div class="form-group">
                  
                    <asp:TextBox ID="txtmname" runat="server" class="form-control form-control-lg" placeholder="Middle Name" ></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtmname" Display="Dynamic" ErrorMessage="Middle name should not empty" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtmname" Display="Dynamic" ErrorMessage="only alphabets" ForeColor="#FF3300" SetFocusOnError="True" ValidationExpression="^[a-zA-Z\s]+$">*</asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                  
                  <asp:TextBox ID="txtlname" runat="server" class="form-control form-control-lg" placeholder="Last Name" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtlname" Display="Dynamic" ErrorMessage="Last  name should not empty" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtlname" Display="Dynamic" ErrorMessage="only alphabets" ForeColor="#FF3300" SetFocusOnError="True" ValidationExpression="^[a-zA-Z\s]+$">*</asp:RegularExpressionValidator>
                </div>
             
                <div class="form-group">
                  
                    <asp:TextBox ID="txtemail" runat="server" class="form-control form-control-lg" placeholder="Email " ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtemail" Display="Dynamic" ErrorMessage="Email name should not empty" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemail" ErrorMessage="Invalid email" ForeColor="#FF3300" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </div>

                 <div class="form-group">
                  
                    <asp:TextBox ID="txtContact" runat="server" class="form-control form-control-lg" placeholder="Contact Number" ></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtContact" Display="Dynamic" ErrorMessage="contact name should not empty" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </div>

                  <div class="form-group">
                  
                    <asp:TextBox ID="txtcname" runat="server" class="form-control form-control-lg" placeholder="Course Name" ></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtcname" Display="Dynamic" ErrorMessage="Course name should not empty" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </div>
                 <div class="form-group">
                  Upload Last Semister Marksheet
                     <asp:FileUpload ID="FileUpload1" runat="server"  /> 
                </div>

             <div class="form-group">
                  
          <asp:TextBox ID="txtUname" runat="server" class="form-control form-control-lg" placeholder="Username"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUname" Display="Dynamic" ErrorMessage="username  should not empty" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                  
          <asp:TextBox ID="txtpassowrd" runat="server" class="form-control form-control-lg" placeholder="Password" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtpassowrd" Display="Dynamic" ErrorMessage="password should not empty" ForeColor="#FF3300" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </div>
                <div class="mt-3">
                    <%-- <a class="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn" href="../../dashboard.aspx">SIGN IN</a>--%>

                    <asp:Button ID="BtnRegistration" class="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn" runat="server" Text="Submit" OnClick="BtnRegistration_Click" />
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
                    <br />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#FF3300" />
                </div>
                <div class="my-2 d-flex justify-content-between align-items-center">
                  <div class="form-check">
                 
                      <asp:Label ID="lblmsg" runat="server"></asp:Label>
                  </div>
               
                </div>
               
               
             































            </div>
          </div>
        </div>
      </div>
      <!-- content-wrapper ends -->
    </div>
    <!-- page-body-wrapper ends -->
  </div>
  <!-- container-scroller -->
  <!-- base:js -->
  <script src="../../vendors/js/vendor.bundle.base.js"></script>
  <!-- endinject -->
  <!-- inject:js -->
  <script src="../../js/off-canvas.js"></script>
  <script src="../../js/hoverable-collapse.js"></script>
  <script src="../../js/template.js"></script>
  <script src="../../js/settings.js"></script>
  <script src="../../js/todolist.js"></script>
  <!-- endinject -->
        
    </form>
</body>
</html>