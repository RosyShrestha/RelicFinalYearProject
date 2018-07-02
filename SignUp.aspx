<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="Sign_Up" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Sign Up</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="icon" type="image/png" href="Login/images/icons/favicon.ico"/>
	<link rel="stylesheet" type="text/css" href="Login/vendor/bootstrap/css/bootstrap.min.css">
	<link rel="stylesheet" type="text/css" href="Login/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
	<link rel="stylesheet" type="text/css" href="Login/fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
	<link rel="stylesheet" type="text/css" href="Login/vendor/animate/animate.css">
	<link rel="stylesheet" type="text/css" href="Login/vendor/css-hamburgers/hamburgers.min.css">
	<link rel="stylesheet" type="text/css" href="Login/vendor/select2/select2.min.css">
	<link rel="stylesheet" type="text/css" href="Login/css/util.css">
	<link rel="stylesheet" type="text/css" href="Login/css/main.css">
    <script>
        function onlyNumbers(event) {
            var charCode = (event.which) ? event.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        function alphabet(event) {
            var charCode = (event.which) ? event.which : event.keyCode
            if (charCode > 31 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
                return false;
            return true;
        }
    </script>
    
</head>
<body>
	<form id="form1" runat="server">
	<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100 p-l-50 p-r-50 p-t-77 p-b-30">
				<div runat="server" class="login100-form validate-form">
                    &nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
					<span class="login100-form-title p-b-55">
						Sign Up
					</span>

					<div class="wrap-input100 m-b-16" data-validate = "Valid email is required: ex@abc.xyz">
                        <b>Firstname<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Firstname required" ForeColor="Red" ValidationGroup="a">*</asp:RequiredFieldValidator>
                        </b>&nbsp;<asp:TextBox ID="txtFirstName"  onkeypress="return alphabet(event)" class="input100"  runat="server"></asp:TextBox>
					
					</div>

                    <div class="wrap-input100  m-b-16" data-validate = "Valid email is required: ex@abc.xyz">
                        <b>Lastname<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLastName" ErrorMessage="Lastname Required" ForeColor="Red" ValidationGroup="a">*</asp:RequiredFieldValidator>
                        </b>&nbsp;<asp:TextBox ID="txtLastName" onkeypress="return alphabet(event)" class="input100"  runat="server"></asp:TextBox>
					
					
                      <div class="wrap-input100 m-b-16" data-validate = "Valid email is required: ex@abc.xyz">
                          <b>Email<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Required" ForeColor="Red" ValidationGroup="a">*</asp:RequiredFieldValidator>
                          </b>&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="a">Invalid Email</asp:RegularExpressionValidator>
                          <asp:TextBox ID="txtEmail" class="input100"  runat="server"></asp:TextBox>
					
					</div>
                      <div class="wrap-input100 m-b-16" data-validate = "Valid email is required: ex@abc.xyz">
                          <b>Password<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password Required" ForeColor="Red" ValidationGroup="a">*</asp:RequiredFieldValidator>
                          </b>&nbsp;<asp:TextBox ID="txtPassword" TextMode="Password" class="input100"  runat="server" ></asp:TextBox>
					
					</div>
                        <div class="wrap-input100 m-b-16" data-validate = "Valid email is required: ex@abc.xyz">
                          <b>Retype Password<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password Required" ForeColor="Red" ValidationGroup="a">*</asp:RequiredFieldValidator>
                          </b>&nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtRetypePassword" ErrorMessage="CompareValidator" ForeColor="Red" ValidationGroup="a">Mismatch</asp:CompareValidator>
                            <asp:TextBox ID="txtRetypePassword" TextMode="Password" class="input100"  runat="server" ></asp:TextBox>
					
					</div>
                    
                   
                    
                     <div class="wrap-input100 m-b-16" data-validate = "Valid email is required: ex@abc.xyz">
                         <b>Address<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address Required" ForeColor="Red" ValidationGroup="a">*</asp:RequiredFieldValidator>
                         </b>
                        &nbsp;<asp:TextBox ID="txtAddress" onkeypress="return alphabet(event)" class="input100" runat="server"></asp:TextBox>
               
					</div>

                     <div class="wrap-input100 m-b-16" data-validate = "Valid email is required: ex@abc.xyz">
                         <b>Phone Number<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="a">*</asp:RequiredFieldValidator>
                         </b>
                        &nbsp;<asp:TextBox ID="txtPhoneNumber" onkeypress="return onlyNumbers(event)" class="input100" runat="server" MaxLength="10"></asp:TextBox>
               
					</div>
                    </div>
                       
               
					
					<div class="container-login100-form-btn p-t-25">
						
                        <asp:Button ID="btnCreate" class="login100-form-btn" runat="server" Text="Create" OnClick="btnCreate_Click" ValidationGroup="a" />
						
					
					</div>
                    </div>
                </div>
            </div>
        </div>
        
	
	

	
<!--===============================================================================================-->	
	<script src="Login/vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="Login/vendor/bootstrap/js/popper.js"></script>
	<script src="Login/vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="Login/vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="Login/js/main.js"></script>
  </form>
</body>
</html>
