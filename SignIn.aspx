<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="items/StyleSheet.css" rel="stylesheet">
</head>
<body>
     <div class="login-page">
  <div class="form">
        <!--<form class="login-form">-->
       <form id="form1" runat="server">
           <p class="mm"><b>UserName</b>
       <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
           <b>Password</b>
               <asp:TextBox ID="txtpassword" runat="server"></asp:TextBox>
               <b>Email Address</b>
               <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
               <asp:Button ID="btnsign" runat="server" Text="SignUp"  />
               <a href="Login.aspx">LogIn</a>
               </p>
           </form>
      </div>
         </div>
</body>
</html>
