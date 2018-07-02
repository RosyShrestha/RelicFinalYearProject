<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login V11</title>
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
</head>

<body>
	
	<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100 p-l-50 p-r-50 p-t-77 p-b-30">
				<form runat="server" class="login100-form validate-form">
					<span class="login100-form-title p-b-55">
						<h4>Change Password</h4>
					</span>

					<div class="wrap-input100  m-b-16" >
                        <b>Email</b>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="a">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="a">invalid</asp:RegularExpressionValidator>
						<asp:TextBox ID="txtEmail" class="input100" runat="server" ></asp:TextBox>
                       
					</div>

                   
					<%--<div class="wrap-input100 m-b-16" ">
                        <b>Old Password</b>
						<asp:TextBox ID="txtOldPassword" TextMode="Password" class="input100" runat="server"></asp:TextBox>
                      
					</div>--%>

                    <div class="wrap-input100 m-b-16" >
                        <b>New Password<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="a">*</asp:RequiredFieldValidator>
                        </b>
						&nbsp;<asp:TextBox ID="txtNewPassword" class="input100" runat="server" TextMode="Password"></asp:TextBox>
                     
					</div>
                    
					 <div class="wrap-input100 m-b-16" >
                         <b>Confirm Password<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPasswrod" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="a">*</asp:RequiredFieldValidator>
                         <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPasswrod" ErrorMessage="CompareValidator" ForeColor="Red" ValidationGroup="a">Mismatch</asp:CompareValidator>
                         </b>
						&nbsp;<asp:TextBox ID="txtConfirmPasswrod" class="input100" runat="server" TextMode="Password"></asp:TextBox>
                    
					</div>

					<div class="container-login100-form-btn p-t-25">
                        <asp:Button ID="btnUpdatePassword" class="login100-form-btn" runat="server" Text="Reset" OnClick="btnConfirm_Click" ValidationGroup="a" />
						
					</div>
				</form>
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

</body>
</html>
