<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>
<script runat="server">

  
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Relic-Login</title>
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
						Login
					</span>

					<div class="wrap-input100 m-b-16" >
				<b>Email<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="a">*</asp:RequiredFieldValidator>
                        </b>
                        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="a">Invalid</asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtEmail" class="input100" runat="server"></asp:TextBox>
						
					</div>

					<div class="wrap-input100 m-b-16" >
                        <b>Password<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="a">*</asp:RequiredFieldValidator>
                        </b>&nbsp;<asp:TextBox ID="txtPassword" class="input100" runat="server" TextMode="Password" ></asp:TextBox>
						
					</div>

					<%--<div class="contact100-form-checkbox m-l-4">
						<input class="input-checkbox100" id="ckb1" type="checkbox" name="remember-me"/>
						<label class="label-checkbox100" for="ckb1">
							Remember me
						</label>
					</div>
					--%>
					<div class="container-login100-form-btn p-t-25">
						
                        <asp:Button ID="btnLogin" href="Product.aspx" class="login100-form-btn" runat="server" Text="Login" OnClick="btnLogin_Click" ValidationGroup="a" />
						
					</div>
				
                    <div class="text-right p-t-13 p-b-23">
						

                        <asp:HyperLink ID="HyperLink2"  href="ResetPassword.aspx" class="txt2" runat="server">Forgot Password?</asp:HyperLink>
                        
					</div>

					
					<div class="text-center w-full p-t-115">
						<span class="txt1">
							Not a member?
						</span>

                        <asp:HyperLink ID="HyperLink1" href="SignUp.aspx" runat="server">Sign up now</asp:HyperLink>
                       
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
