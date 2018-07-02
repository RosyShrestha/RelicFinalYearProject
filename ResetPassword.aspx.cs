using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    bllUsers blu = new bllUsers();

    protected void BtnReset_Click(object sender, EventArgs e)
    {
        DataTable dt = blu.SelectFromUsersTable(txtEmail.Text);
        String Email = dt.Rows[0]["Email"].ToString();
        SendActivationEmail(Email);
        string message = string.Empty;

        message = "Password Recovery has been send to your email account";


        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
    }
    private void SendActivationEmail(string Email)
    {
        using (MailMessage mm = new MailMessage("reliceco@gmail.com", txtEmail.Text))
        {
            mm.Subject = "Account Activation";
            string body = "Hello " +  ",";
            body += "<br /><br />Please click the following link to activate your account";
            body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("ResetPassword.aspx", "ChangePassword.aspx?Email=" + Email) + "'>Click here to change your password.</a>";
            body += "<br /><br />Thanks";
            mm.Body = body;
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential("reliceco@gmail.com", "relic1234");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }
    }
}